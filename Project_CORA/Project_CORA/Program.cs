﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//Alsjeblieft zo min mogelijk aan dit bestand schrijven
namespace Project_CORA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UserInterface userControls = new UserInterface();
            Application.Run(userControls);
            MainProcess mainProcess = new MainProcess(userControls);
        }
    }
}
