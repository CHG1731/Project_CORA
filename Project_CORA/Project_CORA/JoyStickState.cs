using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimDX.DirectInput;

namespace Project_CORA
{
    static class JoyStickState
    {
        public static bool connected { get; set; }
        public static int Xaxis { get; set; }
        public static int Yaxis { get; set; }
        public static int Zaxis { get; set; }
        public static int Zrotation { get; set; }
        public static bool[] buttons { get; set; }
        public static int pov { get; set; }
        public static int slider { get; set; }
    }
    public class InitializeJoyStick
    {
        public InitializeJoyStick()
        {
            JoyStickState.connected = true;
            Connect();
        }
        DirectInput Input = new DirectInput();
        SlimDX.DirectInput.Joystick stick;
        Joystick[] Sticks;
        public void Run()
        {
            if (JoyStickState.connected)
            {
                Connect();
                Sticks = Connect();
                while (JoyStickState.connected)
                {
                    for (int i = 0; i < Sticks.Length; i++)
                    {
                        stickHandle(Sticks[i], i);
                    }
                }
            }
        }
        private Joystick[] Connect()
        {
            List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>();
            foreach (DeviceInstance device in Input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                try
                {
                    stick = new SlimDX.DirectInput.Joystick(Input, device.InstanceGuid);
                    stick.Acquire();

                    foreach (DeviceObjectInstance deviceObject in stick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                        {

                            stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
                        }
                    }
                    sticks.Add(stick);
                }
                catch (DirectInputException)
                {
                    JoyStickState.connected = false;
                }
            }
            return sticks.ToArray();
        }
        private void stickHandle(Joystick stick, int id)
        {
            JoystickState state = new JoystickState();
            state = stick.GetCurrentState();
            JoyStickState.buttons = state.GetButtons();
            int[] sliderval = state.GetSliders();
            JoyStickState.slider = sliderval[0];
            JoyStickState.Xaxis = state.X;
            JoyStickState.Yaxis = state.Y;
            JoyStickState.Zaxis = state.Z;
            JoyStickState.Zrotation = state.RotationZ;
            int[] pov = state.GetPointOfViewControllers();
            #region Switch
            switch(pov[0])
            {
                case 0:
                    JoyStickState.pov = 1;
                    break;
                case 4500:
                    JoyStickState.pov = 2;
                    break;
                case 9000:
                    JoyStickState.pov = 3;
                    break;
                case 13500:
                    JoyStickState.pov = 4;
                    break;
                case 18000:
                    JoyStickState.pov = 5;
                    break;
                case 22500:
                    JoyStickState.pov = 6;
                    break;
                case 27000:
                    JoyStickState.pov = 7;
                    break;
                case 31500:
                    JoyStickState.pov = 8;
                    break;
                default:
                    JoyStickState.pov = 0;
                    break;
            }
            #endregion
        }
    }
}
