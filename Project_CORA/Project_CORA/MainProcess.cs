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

        //Declaration of motor values.
        private int baseMotVal = 850, baseMotMin = 0, baseMotMax = 850;
        private int midMotVal = 850, midMotMin = 0, midMotMax = 1023;
        private int endMotVal = 512, endMotMin = 0, endMotMax = 1023;
        private int rotMotVal = 512, rotMotMin = 0, rotMotMax = 1023;
        private int moduleMotVal = 512, moduleMotMin = 0, moduleMotMax = 1023;

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
                    resetRobot();
                    userControls.requestedReset = false;
                }
                //Check if the selected module changed.
                //Update displayed manual if so.
                if (userControls.modSelected != this.modSelected)
                {
                    this.modSelected = userControls.modSelected;
                    setManual(this.modSelected);
                }
                //Check if a new module is requested
                //switch modules if so
                if (userControls.modEquiped != this.modEquiped)
                {
                    bool eject = true;
                    if (this.modEquiped != 0)
                    {
                        switchMod(this.modEquiped, eject);
                    }
                    eject = false;
                    this.modEquiped = userControls.modEquiped;
                    switchMod(this.modEquiped, eject);
                }
                //Read joystick and updat motor values
                calculateMotorValues();
            }
        }

        /*
         * Function reads the file that specifies which modules are stored
         * in the rack and at what index, and stores the information
         * in the modules array.
         */ 
        private void registerMods()
        {
            /*
            String modName;
            int index = 0;
            System.IO.StreamReader modFile = new System.IO.StreamReader("D:\\Documents\\TI\\Project CORA\\Project_CORA\\modList.txt");
            while((modName = modFile.ReadLine()) != null)
            {
                modules[index++] = modName;
                userControls.addMod(modName);
            }
            modFile.Close();
            */
        }

        /*
         * Function searches for the manual corresponding to
         * the module specified by mod. If the manual is
         * found it is displayed on the UI.
         */ 
        private void setManual(int mod)
        {
            /*
            String manual = "", tmp;
            String path = "D:\\Documents\\TI\\Project CORA\\Project_CORA\\Manuals\\" + modules[mod] + "_Manual.txt";
            System.IO.StreamReader manFile = new System.IO.StreamReader(path);
            while ((tmp = manFile.ReadLine()) != null)
            {
                manual += tmp;
            }
            userControls.setManual(manual);
            */
        }

        /*
         * Function to reset the robot. If a module is currently
         * equiped it is ejected and stored.
         * All motor-values are then set to their default positions
         * and the robot moves to it's starting position.
         */ 
        private void resetRobot()
        {
            //TODO Implement function
        }

        /*
         * Function stores a module on, or gets a module from
         * the specified index of the module rack.
         * Based on the value of "eject", module is either coupled
         * or decoupled.
         */ 
        private void switchMod(int modIndex, bool eject)
        {
            //TODO Implement function
        }

        /*
         * Function calculates the values of all the joints
         * based on input from the controller and stores
         * the values in the globally defined variables.
         */
        private void calculateMotorValues()
        {
            baseMotVal -= JoyStickState.Xaxis - JoyStickState.Yaxis;
            midMotVal -= JoyStickState.Xaxis;
            endMotVal += JoyStickState.Xaxis + JoyStickState.Yaxis;
            rotMotVal += JoyStickState.Zaxis; //<- This for rotation??
            if(baseMotVal > baseMotMax) { baseMotVal = baseMotMax; }
            else if(baseMotVal < baseMotMin) { baseMotVal = baseMotMin; }
            if(midMotVal > midMotMax) { midMotVal = midMotMax; }
            else if(midMotVal < midMotMin) { midMotVal = midMotMin; }
            if(endMotVal > endMotMax) { endMotVal = endMotMax; }
            else if(endMotVal < endMotMin) { endMotVal = endMotMin; }
            if(rotMotVal > rotMotMax) { rotMotVal = rotMotMax; }
            else if(rotMotVal < rotMotMin) { rotMotVal = rotMotMin; }
        }
    }
}
