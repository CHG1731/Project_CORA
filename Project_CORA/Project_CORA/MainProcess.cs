using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_CORA
{
    class MainProcess
    {
        UserInterface userControls;
        MacroLib macroLib;

        private int modEquiped = 0;
        Dynamixel dynamixel;
        SerialPort2Dynamixel serialPort;

        private bool emergencyStopInEffect = false;
        private Boolean emergencyReset = false;

        private int baseCoupleVal = 650, endCoupleVal = 712, moduleCoupleVal = 850;
        //Declaration of Servoor Positionues.
        //TODO properly set contraints.
        public int baseServoMin = 300, baseServoMax = 850, baseServo = 11, baseServoDefault = 850;
        private int midServoMin = 0, midServoMax = 810, midServo = 9, midServoDefault = 810;
        private int endServoMin = 512, endServoMax = 1023, endServo = 4, endServoDefault = 512;
        private int rotServoMin = 0, rotServoMax = 1023, rotServo = 17, rotServoDefault = 512, rotServoSwitchPos = 20;
        private int frameServoMin = 0, frameServoMax = 0 /*TODO Add actual value*/, frameServoDefault = 0; 
        private int moduleServoMin = 0, moduleServoMax = 1023, moduleServo = 18, moduleServoDefault = 512;
        private int coupleServoMin = 0, coupleServoMax = 1023, coupleServo = 7, coupleServoDefault = 512;
        private int frameModInterval = 10;

        private String[] modules = new String[20];

        public MainProcess(UserInterface u)
        {
            ServoPositions.baseServo = baseServoDefault;
            ServoPositions.midServo = midServoDefault;
            ServoPositions.endServo = endServoDefault;
            ServoPositions.rotServo = rotServoDefault;
            ServoPositions.moduleServo = moduleServoDefault;
            ServoPositions.coupleServo = coupleServoDefault;
            this.userControls = u;
            registerMods();
            runMainProcess();
        }

        /*
         * Main loop of the program
         */
        private void runMainProcess()
        {
            serialPort = new SerialPort2Dynamixel();
            dynamixel = new Dynamixel();
            if (serialPort.open("COM7") == false)
            {
                dynamixel.sendTossModeCommand(serialPort);
            }
            while (true)
            {
                //Check if emergency stop is in effect
                checkForEmergencyStop();
                //check if robot needs to reset
                if (userControls.requestedReset || checkResetButton())
                {
                    emergencyReset = false;
                    setRobotPosition(new int[7]  { baseServoDefault, midServoDefault, endServoDefault,
                        moduleServoDefault, rotServoDefault, frameServoDefault, coupleServoDefault });
                    userControls.requestedReset = false;
                }
                //Check if a new module is requested
                //switch modules if so
                if (userControls.modEquiped != this.modEquiped)
                {
                    changeMod();
                }
                if (userControls.runMacro)
                {
                    runMacro(userControls.macroToRun);
                }
                //Read joystick and update Servo Positionues
                calculateServoPositions();
                //Send Servoor Positionues to servo's
                sendServoPositions();
                //Thread.Sleep(1);
            }
        }

        /*
         * Function reads the file that specifies which modules are stored
         * in the rack and at what index, and stores the information
         * in the modules array.
         */
        private void registerMods()
        {
            //TODO Put module information in XML-format.
            String modName;
            int index = 0;
            System.IO.StreamReader modFile = new System.IO.StreamReader("D:\\Documents\\TI\\Project CORA\\Project_CORA\\modList.txt");
            while ((modName = modFile.ReadLine()) != null)
            {
                modules[index++] = modName;
                userControls.addMod(modName);
            }
            modFile.Close();
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
                    //ServoPositions.coupleServo = checkServoPosition(ServoPositions.coupleServo, destinations[6]);
                    sendServoPositions();
                    Thread.Sleep(1);
                }
                while (!(ServoPositions.rotServo == destinations[4] /*&& ServoPositions.frameServo == destinations[5]*/))
                {
                    ServoPositions.rotServo = checkServoPosition(ServoPositions.rotServo, destinations[4]);
                    //ServoPositions.frameServo = checkServoPosition(ServoPositions.frameServo, destinations[5]); //Might not work for frameservo.
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
            if (this.modEquiped != 0)
            {
                setRobotPosition(new int[7] { baseServoDefault, midServoDefault, endServoDefault, moduleServoDefault,
                    rotServoSwitchPos, frameModInterval * this.modEquiped, 0});
                coupleMod(true);
            }
            this.modEquiped = userControls.modEquiped;
            setRobotPosition(new int[7] { baseServoDefault, midServoDefault, endServoDefault, moduleServoDefault,
                rotServoSwitchPos, frameModInterval * this.modEquiped , 1023});
            coupleMod(false);
            setRobotPosition(new int[7] { baseServoDefault, midServoDefault, endServoDefault, moduleServoDefault,
                rotServoDefault, frameModInterval * this.modEquiped , coupleServoDefault});
        }

        /*
         * Helper function used by changeMod()
         */ 
        private void coupleMod(bool eject)
        {
            while(!(ServoPositions.baseServo == baseCoupleVal && ServoPositions.endServo == endCoupleVal && ServoPositions.moduleServo
                 == moduleCoupleVal))
            {
                ServoPositions.baseServo = checkServoPosition(ServoPositions.baseServo, baseCoupleVal);
                ServoPositions.endServo = checkServoPosition(ServoPositions.endServo, endCoupleVal);
                ServoPositions.moduleServo = checkServoPosition(ServoPositions.moduleServo, moduleCoupleVal);
                sendServoPositions();
                Thread.Sleep(1);
            }
            if (!eject)
            {
                ServoPositions.coupleServo = 1023;
                sendServoPositions();
            }
            else
            {
                ServoPositions.coupleServo = 0;
                sendServoPositions();
            }
            while (!(ServoPositions.baseServo == baseServoDefault && ServoPositions.endServo == endServoDefault))
            {
                ServoPositions.baseServo = checkServoPosition(ServoPositions.baseServo, baseServoDefault);
                ServoPositions.endServo = checkServoPosition(ServoPositions.endServo, endServoDefault);
                ServoPositions.moduleServo = checkServoPosition(ServoPositions.moduleServo, moduleServoDefault);
                sendServoPositions();
                Thread.Sleep(1);
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
            ServoPositions.baseServo -= (JoyStickState.Yaxis / speedSetting) - (JoyStickState.Zaxis / speedSetting);
            ServoPositions.midServo -= (JoyStickState.Yaxis / speedSetting);
            ServoPositions.endServo += (JoyStickState.Yaxis / speedSetting) - (JoyStickState.Zaxis /speedSetting);
            ServoPositions.rotServo -= (JoyStickState.Zrotation / speedSetting);
            ServoPositions.moduleServo += (JoyStickState.Yaxis / speedSetting);
            ServoPositions.coupleServo += (JoyStickState.Xaxis / speedSetting);
            switch (JoyStickState.pov)
            {
                case 1:
                    ServoPositions.moduleServo += speedSetting;
                    break;
                case 5:
                    ServoPositions.moduleServo -= speedSetting;
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
        }

        private void runMacro(List<int[]> macroCommands)
        {
            for(int i = 0; i < userControls.macroToRun.Count; i++)
            {
                setRobotPosition(userControls.macroToRun.ElementAt<int[]>(i));   
            } 
            userControls.stillNotDone = false;
        }

        /*
         * Function that writes all the values in ServoPositions to the servo's
         * in order to move them.
         */ 
        private void sendServoPositions()
        {
            if (!emergencyReset)
            {
                dynamixel.setPosition(serialPort, baseServo, ServoPositions.baseServo);
                dynamixel.setPosition(serialPort, midServo, ServoPositions.midServo);
                dynamixel.setPosition(serialPort, endServo, ServoPositions.endServo);
                dynamixel.setPosition(serialPort, rotServo, ServoPositions.rotServo);
                dynamixel.setPosition(serialPort, moduleServo, ServoPositions.moduleServo);
                dynamixel.setPosition(serialPort, coupleServo, ServoPositions.coupleServo);
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
