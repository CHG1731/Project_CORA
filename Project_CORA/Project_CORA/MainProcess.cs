using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Project_CORA
{
    class MainProcess
    {
        UserInterface userControls;

        private int modEquiped = 0;
        Dynamixel dynamixel;
        SerialPort2Dynamixel serialPort;
        SerialPort arduinoPort = new SerialPort();

        private bool emergencyStopInEffect = false;

        //Declaration of the positions required for module switching.
        private int baseCoupleVal1 = 690, endCoupleVal1 = 600, moduleCoupleVal1 = 490, midCoupleVal1 = 720;
        private int baseCoupleVal2 = 800, endCoupleVal2 = 600, moduleCoupleVal2 = 490, midCoupleVal2 = 680;
        private int baseCoupleVal3 = 850, endCoupleVal3 = 630, moduleCoupleVal3 = 715, midCoupleVal3 = 700;
        private int baseCoupleVal4 = 850, endCoupleVal4 = 630, moduleCoupleVal4 = 675, midCoupleVal4 = 600;
        //Declaration of Servo Positionues.
        public int baseServoMin = 300, baseServoMax = 850, baseServo = 15, baseServoDefault = 840;
        private int midServoMin = 0, midServoMax = 850, midServo = 9, midServoDefault = 800;
        private int endServoMin = 512, endServoMax = 1023, endServo = 4, endServoDefault = 512;
        private int rotServoMin = 0, rotServoMax = 1023, rotServo = 17, rotServoDefault = 512, rotServoSwitchPos = 826;
        private int frameServoMin = 0, frameServoMax = 6000, frameServoDefault = 0, oldFramePosition = 0; 
        private int moduleServo = 18, moduleServoDefault = 512;
        private int coupleServo = 7, coupleServoDefault = 512;
        private int clawServoOne = 11, clawSeroTwo = 5;
        private int millis = 0;

        public MainProcess(UserInterface u)
        {
            ServoPositions.baseServo = baseServoDefault;
            ServoPositions.midServo = midServoDefault;
            ServoPositions.endServo = endServoDefault;
            ServoPositions.rotServo = rotServoDefault;
            ServoPositions.moduleServo = moduleServoDefault;
            ServoPositions.frameServo = frameServoDefault;
            ServoPositions.clawServoOne = 512;
            ServoPositions.clawServoTwo = 512;
            serialPort = new SerialPort2Dynamixel();
            dynamixel = new Dynamixel();
            if (serialPort.open("COM4") == false)
            {
                dynamixel.sendTossModeCommand(serialPort);
            }
            arduinoPort.BaudRate = 9600;
            arduinoPort.PortName = "COM9";
            arduinoPort.Open();
            this.userControls = u;
            runMainProcess();
        }

        /*
         * Main loop of the program
         */
        private void runMainProcess()
        {
            while (true)
            {
                //Check if emergency stop is in effect
                checkForEmergencyStop();
                //check if robot needs to reset
                if (userControls.requestedReset || checkResetButton())
                {
                    userControls.requestedReset = false;
                    arduinoPort.WriteLine("reset#");
                    setRobotPosition(new int[5]  { baseServoDefault, midServoDefault, endServoDefault,
                        moduleServoDefault, rotServoDefault });
                }
                //Check if a new module is requested
                //switch modules if so
                if (userControls.modEquiped != this.modEquiped)
                {
                    changeMod();
                }
                if (userControls.runMacro)
                {
                    runMacro();
                }
                //Read joystick and update Servo Positionues
                calculateServoPositions();
                //Send Servoor Positionues to servo's
                sendServoPositions();
                Thread.Sleep(1);
                millis++;
            }
        }

        /*
         * Function takes an array containing the target positions for each servo.
         * First all the joints of the arm are moved to their target values,
         * the the rotation and frame positions are set.
         * This is done in this order to prevent te arm from slamming into the frame.
         */
        private void setRobotPosition(int[] destinations)
        {
            while (!(ServoPositions.baseServo == destinations[0] && ServoPositions.midServo == destinations[1]
                    && ServoPositions.endServo == destinations[2] && ServoPositions.moduleServo == destinations[3]))
            {
                ServoPositions.baseServo = checkServoPosition(ServoPositions.baseServo, destinations[0]);
                ServoPositions.midServo = checkServoPosition(ServoPositions.midServo, destinations[1]);
                ServoPositions.endServo = checkServoPosition(ServoPositions.endServo, destinations[2]);
                ServoPositions.moduleServo = checkServoPosition(ServoPositions.moduleServo, destinations[3]);
                sendServoPositions();
                Thread.Sleep(1);
            }
            if (destinations.Length == 6) { arduinoPort.WriteLine(String.Concat("set", destinations[5], "#")); }
            while (!(ServoPositions.rotServo == destinations[4]))
            {
                ServoPositions.rotServo = checkServoPosition(ServoPositions.rotServo, destinations[4]);
                sendServoPositions();
                Thread.Sleep(1);
            }
        }

        /*
         * Help functions used by position setting functions to determine
         * if a servo has reached it's target position and if not return
         * a new value higher or lower by the speedOffset.
         * This value is then givin to the respective servo.
         */
        private int checkServoPosition(int servoPosition, int servoDestination)
        {
            checkForEmergencyStop();
            int speedOffset = 100 / Settings.speedSetting, brakeDis = 100 / Settings.speedSetting;
            if (servoPosition > servoDestination)
            {
                if (servoPosition - servoDestination > brakeDis) { servoPosition -= speedOffset; }
                else { servoPosition--; }
            }
            else if (servoPosition < servoDestination)
            {
                if (servoDestination - servoPosition > brakeDis) { servoPosition += speedOffset; }
                else { servoPosition++; }
            }
            return servoPosition;
        }

        /*
         * Function stores a module on, or gets a module from
         * the specified index of the module rack.
         * Based on the value of "eject", module is either coupled
         * or decoupled.
         */ 
        private void changeMod()
        {
            //arduinoPort.WriteLine("reset#");
            ServoPositions.clawServoOne = ServoPositions.clawServoTwo = 512;
            if(ServoPositions.frameServo > 1000)
            {
                arduinoPort.WriteLine("reset");
                Thread.Sleep(ServoPositions.frameServo);
            }
            if (this.modEquiped != 0 && this.modEquiped == 1)
            {
                coupleModOne(true);
            }
            else if(this.modEquiped != 0 && this.modEquiped == 2)
            {
                coupleModTwo(true);
            }
            this.modEquiped = userControls.modEquiped;
            if (this.modEquiped == 1) { coupleModOne(false); }
            else if(this.modEquiped == 2) { coupleModTwo(false); }
            setRobotPosition(new int[7] { baseServoDefault, midServoDefault, endServoDefault, moduleServoDefault,
                rotServoDefault, 0 , coupleServoDefault});
        }

        /*
         * Helper function used by changeMod()
         */ 
        private void coupleModOne(bool eject)
        {
            int oldSpeedSetting = Settings.speedSetting;
            //Settings.speedSetting = 10;
            if (eject)
            {
                arduinoPort.WriteLine("set2600#");
                Thread.Sleep(4000);
                setRobotPosition(new int[5]  { baseCoupleVal2, (midCoupleVal2 - 40), endCoupleVal2,
                        moduleCoupleVal2, rotServoSwitchPos });
                setRobotPosition(new int[5]  { baseCoupleVal1, midCoupleVal1, endCoupleVal1,
                        moduleCoupleVal1, rotServoSwitchPos });
                dynamixel.setSpeed(serialPort, coupleServo, 1023 + 1023);
                Thread.Sleep(7500);
                arduinoPort.WriteLine("reset#");
                Thread.Sleep(2000);
                dynamixel.setSpeed(serialPort, coupleServo, 0);
                setRobotPosition(new int[5]  { baseServoDefault, midServoDefault, endServoDefault,
                        moduleServoDefault, rotServoSwitchPos });
            }
            else
            {
                setRobotPosition(new int[5]  { baseCoupleVal1, midCoupleVal1, endCoupleVal1,
                        moduleCoupleVal1, rotServoSwitchPos });
                dynamixel.setSpeed(serialPort, coupleServo, 1023);
                arduinoPort.WriteLine("set2500#");
                Thread.Sleep(9000);
                dynamixel.setSpeed(serialPort, coupleServo, 0);
                arduinoPort.WriteLine("set2350#");
                Thread.Sleep(3000);
                setRobotPosition(new int[5]  { baseCoupleVal2, midCoupleVal2, endCoupleVal2,
                        moduleCoupleVal2, rotServoDefault });
                setRobotPosition(new int[5]  { baseServoDefault, midServoDefault, endServoDefault,
                        moduleServoDefault, rotServoDefault });
                arduinoPort.WriteLine("reset#");
            }
        }

        private void coupleModTwo(bool eject)
        {
            int oldSpeedSetting = Settings.speedSetting;
            //Settings.speedSetting = 10;
            if (eject)
            {
                arduinoPort.WriteLine("set2170#");
                Thread.Sleep(4000);
                setRobotPosition(new int[5]  { baseCoupleVal4, midCoupleVal4, endCoupleVal4,
                        moduleCoupleVal4, rotServoSwitchPos });
                setRobotPosition(new int[5]  { baseCoupleVal3, midCoupleVal3, endCoupleVal3,
                        moduleCoupleVal3, rotServoSwitchPos });
                dynamixel.setSpeed(serialPort, coupleServo, 1023 + 1023);
                Thread.Sleep(7500);
                arduinoPort.WriteLine("reset#");
                Thread.Sleep(2000);
                dynamixel.setSpeed(serialPort, coupleServo, 0);
                setRobotPosition(new int[5]  { baseServoDefault, midServoDefault, endServoDefault,
                        moduleServoDefault, rotServoSwitchPos });
            }
            else
            {
                setRobotPosition(new int[5]  { baseCoupleVal3, midCoupleVal3, endCoupleVal3,
                        moduleCoupleVal3, rotServoSwitchPos });
                dynamixel.setSpeed(serialPort, coupleServo, 1023);
                arduinoPort.WriteLine("set2200#");
                Thread.Sleep(9000);
                dynamixel.setSpeed(serialPort, coupleServo, 0);
                setRobotPosition(new int[5]  { baseCoupleVal4, midCoupleVal4, endCoupleVal4,
                        moduleCoupleVal4, rotServoDefault });
                setRobotPosition(new int[5]  { baseServoDefault, midServoDefault, endServoDefault,
                        moduleServoDefault, rotServoDefault });
                arduinoPort.WriteLine("reset#");
            }
        }


        /*
         * Function calculates the Positions of all the joints
         * based on input from the controller and stores
         * the Positionues in the ServoPositions class.
         */
        private void calculateServoPositions()
        {
            int speedSetting = Settings.speedSetting;
            Boolean controlledMovement = false;
            if (JoyStickState.buttons != null)
            {
                if (JoyStickState.buttons[0] && ServoPositions.clawServoOne < 630 && ServoPositions.clawServoTwo > 410) {
                    ServoPositions.clawServoOne += 10;
                    ServoPositions.clawServoTwo -= 10;
                }
                else if (JoyStickState.buttons[3] && ServoPositions.clawServoOne > 300)
                {
                    ServoPositions.clawServoOne -= 10;
                    ServoPositions.clawServoTwo += 10;
                }
            }
            ServoPositions.baseServo -= (JoyStickState.Yaxis / speedSetting) - (JoyStickState.Zaxis / speedSetting);
            ServoPositions.midServo -= (JoyStickState.Yaxis / speedSetting);
            ServoPositions.endServo += (JoyStickState.Yaxis / speedSetting) - (JoyStickState.Zaxis / speedSetting);
            ServoPositions.rotServo -= (JoyStickState.Zrotation / speedSetting);
            ServoPositions.moduleServo += (JoyStickState.Yaxis / speedSetting);
            ServoPositions.frameServo += (int)(JoyStickState.slider * 0.60);
            switch (JoyStickState.pov)
            {
                case 1:
                    ServoPositions.moduleServo += (100 / speedSetting);
                    break;
                case 5:
                    ServoPositions.moduleServo -= (100 / speedSetting);
                    break;
            }
            if(ServoPositions.baseServo > baseServoMax) { ServoPositions.baseServo = baseServoMax; }
            else if(ServoPositions.baseServo < baseServoMin) { ServoPositions.baseServo = baseServoMin; }
            if(ServoPositions.midServo > midServoMax) { ServoPositions.midServo = midServoMax; }
            else if(ServoPositions.midServo < midServoMin) { ServoPositions.midServo = midServoMin; }
            if(ServoPositions.endServo > endServoMax) { ServoPositions.endServo = endServoMax; }
            else if(ServoPositions.endServo < endServoMin) { ServoPositions.endServo = endServoMin; }
            if(ServoPositions.rotServo > rotServoMax) { ServoPositions.rotServo = rotServoMax; }
            else if(ServoPositions.rotServo < rotServoMin) { ServoPositions.rotServo = rotServoMin; }
            if (ServoPositions.frameServo > frameServoMax) { ServoPositions.frameServo = frameServoMax; }
            else if (ServoPositions.frameServo < frameServoMin) { ServoPositions.frameServo = frameServoMin; }
        }
        
        /*
         * Function called when the runMacro flag has been raised by userControls.
         * The function takes a list of macro's from userControls and executes them one by one.
         */
        private void runMacro()
        {
            List<int[]> macro;
            float percentageStep = 0;
            Settings.percentage = 0;
            for(int i = 0; i < userControls.macrosToRun.Count; i++)
            {
                percentageStep += userControls.macrosToRun.ElementAt(i).Count;
            }
            percentageStep = 100 / percentageStep;
            for(int i = 0; i < userControls.macrosToRun.Count; i++)
            {
                macro = userControls.macrosToRun.ElementAt(i);
                for(int macroIndex = 0; macroIndex < macro.Count; macroIndex++)
                {
                    if (macro.ElementAt(macroIndex)[0] < 300)
                    {
                        userControls.modEquiped = macro.ElementAt(macroIndex)[0];
                        changeMod();
                    }
                    else if(macro.ElementAt(macroIndex)[2] < 300)
                    {
                        runMacro(userControls.macroLib.macroStorage.ElementAt(macro.ElementAt(macroIndex)[2]), percentageStep);
                    }
                    else
                    {
                        setRobotPosition(macro.ElementAt(macroIndex));
                        Settings.percentage += percentageStep;
                    }
                }
            }
            Settings.percentage = 100;
            userControls.runMacro = false;
        }

        /*
         * Overload of runMacro. Called when a macro is called by the first
         * runMacro functionn when a macro is called from within another macro.
         * Function can be used recusively when the macro called from within a macro
         * contains yet another macro. 
         */
        private void runMacro(List<int[]> macro, float percentageStep)
        {
            percentageStep = percentageStep / macro.Count;
            for(int i = 0; i < macro.Count; i++)
            {
                if (macro.ElementAt(i)[0] < 300)
                {
                    userControls.modEquiped = macro.ElementAt(i)[0];
                    this.modEquiped = macro.ElementAt(i)[0];
                    changeMod();
                }
                else if (macro.ElementAt(i)[2] < 300)
                {
                    runMacro(userControls.macroLib.macroStorage.ElementAt(macro.ElementAt(i)[2]), percentageStep);
                }
                else
                {
                    setRobotPosition(macro.ElementAt(i));
                }
                Settings.percentage += percentageStep;
            }
        }
        
        /*
         * Function that writes all the values in ServoPositions to the servo's
         * in order to move them.
         */ 
        private void sendServoPositions()
        {
            if (userControls.requestedReset == false) //possible cause of rebuild problem?
            {
                dynamixel.setPosition(serialPort, baseServo, ServoPositions.baseServo);
                dynamixel.setPosition(serialPort, midServo, ServoPositions.midServo);
                dynamixel.setPosition(serialPort, endServo, ServoPositions.endServo);
                dynamixel.setPosition(serialPort, rotServo, ServoPositions.rotServo);
                dynamixel.setPosition(serialPort, moduleServo, ServoPositions.moduleServo);
                dynamixel.setPosition(serialPort, clawServoOne, ServoPositions.clawServoOne);
                dynamixel.setPosition(serialPort, clawSeroTwo, ServoPositions.clawServoTwo);
                if (JoyStickState.buttons != null) {
                    if (JoyStickState.buttons[7]) { arduinoPort.WriteLine(String.Concat("set", ServoPositions.frameServo, "#")); }
                }
            }
        }

        private void checkForEmergencyStop()
        {
            if (JoyStickState.buttons != null)
            {
                emergencyStopInEffect = JoyStickState.buttons[1];
            }
            while (emergencyStopInEffect)
            {
                Thread.Sleep(200);
                if (userControls.requestedReset || JoyStickState.buttons[1])
                {
                    emergencyStopInEffect = false;
                    Thread.Sleep(200);
                }
            }
        }

        private bool checkResetButton()
        {
            bool state = false;
            if (JoyStickState.buttons != null)
            {
                state = JoyStickState.buttons[11];
            }
            return state;
        }
    }
}
