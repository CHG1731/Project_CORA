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
        public static bool[] buttons { get; set; }
        public static int[] pov { get; set; }
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
            int x = state.Z;
        }
    }
}
