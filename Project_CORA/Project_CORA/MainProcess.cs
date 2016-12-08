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

        private int modSelected = 0;
        private int modEquiped = 0;

        //Declaration of Servoor Positionues.
        public int baseServoMin = 0, baseServoMax = 850, baseServo = 11, baseServoDefault = 850;
        private int midServoMin = 0, midServoMax = 1023, midServo = 9, midServoDefault = 850;
        private int endServoMin = 0, endServoMax = 1023, endServo = 4, endServoDefault = 512;
        private int rotServoMin = 0, rotServoMax = 1023, rotServo = 17, rotServoDefault = 850, rotServoSwitchPos = 0;
        private int frameServoMin = 0, frameServoMax = 0 /*TODO Add actual value*/, frameServoDefault = 0; 
        private int moduleServoMin = 0, moduleServoMax = 1023, moduleServo = 18, moduleServoDefault = 512;
        private int frameModInterval = 10;

        private String[] modules = new String[20];

        public MainProcess(UserInterface u)
        {
            ServoPositions.baseServo = 850;
            ServoPositions.midServo = 850;
            ServoPositions.endServo = 512;
            ServoPositions.rotServo = 512;
            ServoPositions.frameServo = 0;
            this.userControls = u;
            registerMods();
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
                while (userControls.emergencyStopActive)
                {
                    Thread.Sleep(25);
                }
                //check if robot needs to reset
                if (userControls.requestedReset)
                {
                    setRobotPosition(new int[6]  { baseServoDefault, midServoDefault, endServoDefault, moduleServoDefault, rotServoDefault, frameServoDefault });
                    userControls.requestedReset = false;
                }
                //Check if a new module is requested
                //switch modules if so
                if (userControls.modEquiped != this.modEquiped)
                {
                    changeMod();
                }
                //Read joystick and update Servo Positionues
                //calculateServoPositions();
                //Send Servoor Positionues to servo's

                ServoPositions.baseServo -= 30;
                ServoPositions.midServo -= 30;
                ServoPositions.endServo += 30;
                sendServoPositions();
                Thread.Sleep(20);
            }
        }

        /*
         * Function reads the file that specifies which modules are stored
         * in the rack and at what index, and stores the information
         * in the modules array.
         */
        private void registerMods()
        {
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
         * Function to reset the robot. If a module is currently
         * equiped it is ejected and stored.
         * All Servoor-Positionues are then set to their default positions
         * and the robot moves to it's starting position.
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
                Thread.Sleep(20);
            }
            while (ServoPositions.rotServo != destinations[4] && ServoPositions.frameServo != destinations[5])
            {
                ServoPositions.rotServo = checkServoPosition(ServoPositions.rotServo, destinations[4]);
                ServoPositions.frameServo = checkServoPosition(ServoPositions.frameServo, destinations[5]); //Might not work for frameservo.
                sendServoPositions();
                Thread.Sleep(20);
            }
        }

        private int checkServoPosition(int servoPosition, int servoDestination)
        {
            int brakeDis = 10, speedOffset = 5;
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
         * Based on the Positionue of "eject", module is either coupled
         * or decoupled.
         */ 
        private void changeMod()
        {
            if (this.modEquiped != 0)
            {
                setRobotPosition(new int[6] { baseServoDefault, midServoDefault, endServoDefault, moduleServoDefault,
                    rotServoSwitchPos, frameModInterval * this.modEquiped });
                coupleMod(true);
            }
            this.modEquiped = userControls.modEquiped;
            setRobotPosition(new int[6] { baseServoDefault, midServoDefault, endServoDefault, moduleServoDefault,
                rotServoSwitchPos, frameModInterval * this.modEquiped });
            coupleMod(false);
            setRobotPosition(new int[6] { baseServoDefault, midServoDefault, endServoDefault, moduleServoDefault,
                rotServoDefault, frameModInterval * this.modEquiped });
        }

               
        private void coupleMod(bool eject)
        {
            //TODO Implement function
        }

        /*
         * Function calculates the Positionues of all the joints
         * based on input from the controller and stores
         * the Positionues in the globally defined variables.
         */
        private void calculateServoPositions()
        {
            ServoPositions.baseServo -= JoyStickState.Xaxis - JoyStickState.Yaxis;
            ServoPositions.midServo -= JoyStickState.Xaxis;
            ServoPositions.endServo += JoyStickState.Xaxis + JoyStickState.Yaxis;
            ServoPositions.rotServo += JoyStickState.Zaxis; //<- This for rotation??
            if(ServoPositions.baseServo > baseServoMax) { ServoPositions.baseServo = baseServoMax; }
            else if(ServoPositions.baseServo < baseServoMin) { ServoPositions.baseServo = baseServoMin; }
            if(ServoPositions.midServo > midServoMax) { ServoPositions.midServo = midServoMax; }
            else if(ServoPositions.midServo < midServoMin) { ServoPositions.midServo = midServoMin; }
            if(ServoPositions.endServo > endServoMax) { ServoPositions.endServo = endServoMax; }
            else if(ServoPositions.endServo < endServoMin) { ServoPositions.endServo = endServoMin; }
            if(ServoPositions.rotServo > rotServoMax) { ServoPositions.rotServo = rotServoMax; }
            else if(ServoPositions.rotServo < rotServoMin) { ServoPositions.rotServo = rotServoMin; }
        }

        private void sendServoPositions()
        {
            /*
            Dynamixel.setPosition(portnum, baseServo, ServoPositions.baseServo);
            Dynamixel.setPosition(portnum, midServo, ServoPositions.midServo);
            Dynamixel.setPosition(portnum, endServo, ServoPositions.endServo);
            Dynamixel.setPosition(portnum, rotServo, ServoPositions.rotServo);
            Dynamixel.setPosition(portnum, moduleServo, ServoPositions.moduleServo);
            */
        }

    }
}
