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

        public MainProcess(UserInterface u)
        {
            this.userControls = u;
            registerMods();
            runMainProcess();
        }

        private void runMainProcess()
        {
            while (userControls.emergencyStopActive)
            {
                Thread.Sleep(25);
            }
            if (userControls.requestedReset)
            {
                resetRobot();
                userControls.requestedReset = false;
            }
        }


        private void registerMods()
        {
            //Add code for registering which modules are available and notifi the UI.
        }

        private void resetRobot()
        {

        }
    }
}
