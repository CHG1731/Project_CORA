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
        private int baseServoPosition = 850, baseServoMin = 0, baseServoMax = 850, baseServo = 11, baseServoDefault = 850;
        private int midServoPosition = 850, midServoMin = 0, midServoMax = 1023, midServo = 9, midServoDefault = 850;
        private int endServoPosition = 512, endServoMin = 0, endServoMax = 1023, endServo = 4, endServoDefault = 512;
        private int rotServoPosition = 850, rotServoMin = 0, rotServoMax = 1023, rotServo = 17, rotServoDefault = 850, rotServoSwitchPos = 0;
        private int frameServoPosition = 0, frameServoMin = 0, frameServoMax = 0 /*TODO Add actual value*/, frameServoDefault = 0; 
        private int moduleServoPosition = 512, moduleServoMin = 0, moduleServoMax = 1023, moduleServo = 18, moduleServoDefault = 512;
        private int frameModInterval = 10;

        private String[] modules = new String[20];

        public MainProcess(UserInterface u)
        {
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
                    if(this.modEquiped != 0)
                    {
                        setRobotPosition(new int[6] { baseServoDefault, midServoDefault, endServoDefault, moduleServoDefault, rotServoSwitchPos, frameModInterval * this.modEquiped });
                        switchMod(true);
                    }
                    this.modEquiped = userControls.modEquiped;
                    setRobotPosition(new int[6] { baseServoDefault, midServoDefault, endServoDefault, moduleServoDefault, rotServoSwitchPos, frameModInterval * this.modEquiped });
                    switchMod(false);
                    setRobotPosition(new int[6] { baseServoDefault, midServoDefault, endServoDefault, moduleServoDefault, rotServoDefault, frameModInterval * this.modEquiped });
                }
                //Read joystick and update Servo Positionues
                calculateServoPositions();
                //Send Servoor Positionues to servo's
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
            while (!(baseServoPosition == destinations[0] && midServoPosition == destinations[1] && endServoPosition == destinations[2] && moduleServoPosition == destinations[3]))
            {
                baseServoPosition = checkServoPosition(baseServoPosition, destinations[0]);
                midServoPosition = checkServoPosition(midServoPosition, destinations[1]);
                endServoPosition = checkServoPosition(endServoPosition, destinations[2]);
                moduleServoPosition = checkServoPosition(moduleServoPosition, destinations[3]);
                sendServoPositions();
                Thread.Sleep(20);
            }
            while (rotServoPosition != destinations[4] && frameServoPosition != destinations[5])
            {
                rotServoPosition = checkServoPosition(rotServoPosition, destinations[4]);
                frameServoPosition = checkServoPosition(frameServoPosition, destinations[5]); //Might not work for frameservo.
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
        private void switchMod(bool eject)
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
            baseServoPosition -= JoyStickState.Xaxis - JoyStickState.Yaxis;
            midServoPosition -= JoyStickState.Xaxis;
            endServoPosition += JoyStickState.Xaxis + JoyStickState.Yaxis;
            rotServoPosition += JoyStickState.Zaxis; //<- This for rotation??
            if(baseServoPosition > baseServoMax) { baseServoPosition = baseServoMax; }
            else if(baseServoPosition < baseServoMin) { baseServoPosition = baseServoMin; }
            if(midServoPosition > midServoMax) { midServoPosition = midServoMax; }
            else if(midServoPosition < midServoMin) { midServoPosition = midServoMin; }
            if(endServoPosition > endServoMax) { endServoPosition = endServoMax; }
            else if(endServoPosition < endServoMin) { endServoPosition = endServoMin; }
            if(rotServoPosition > rotServoMax) { rotServoPosition = rotServoMax; }
            else if(rotServoPosition < rotServoMin) { rotServoPosition = rotServoMin; }
        }

        private void sendServoPositions()
        {
            /*
            Dynamixel.setPosition(portnum, baseServo, baseServoPosition);
            Dynamixel.setPosition(portnum, midServo, midServoPosition);
            Dynamixel.setPosition(portnum, endServo, endServoPosition);
            Dynamixel.setPosition(portnum, rotServo, rotServoPosition);
            Dynamixel.setPosition(portnum, moduleServo, moduleServoPosition);
            */
        }
    }
}
