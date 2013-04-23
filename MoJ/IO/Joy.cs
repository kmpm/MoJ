using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX.DirectInput;


namespace MoJ.IO
{
    public class Joy : IDisposable
    {

        public event DeviceFoundEventHandler DeviceFound;
        public event JoystickStateEventHandler JoystickStateChanged;
        public Dictionary<string, DeviceInstance> sticks = new Dictionary<string, DeviceInstance>();
        Joystick stick;
        JoystickState state;
        Logger Logger = new Logger("MoJ.Joy");
        System.Windows.Forms.Form _boundForm;
        DirectInput dinput;

        public enum DeviceType
        {
            Unknown = 0,
            Button,
            Pov,
            HatSwitch,
            Slider
        }

        public Joy(System.Windows.Forms.Form boundForm)
        {
            state = new JoystickState();
            _boundForm = boundForm;
            dinput = new DirectInput();
        }

        public string Name
        {
            get
            {
                if (stick != null)
                {
                    return stick.Information.InstanceName;
                }
                else
                {
                    return string.Empty;
                }
            }

        }

        public void GetSticks()
        {
            using (Logger.Context("GetSticks"))
            {

                foreach (DeviceInstance device in dinput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly))
                {
                    Logger.Info(device.InstanceName);
                    sticks.Add(device.InstanceName, device);
                }
                if (sticks.Count == 0)
                {
                    throw new JoystickNotFoundException();
                }
            }
        }

        public void ConnectDevice(string key)
        {
            ConnectDevice(sticks[key]);
        }

        public void ConnectDevice(DeviceInstance device)
        {
            using (Logger.Context("ConnectDevice"))
            {

                stick = new SharpDX.DirectInput.Joystick(dinput, device.InstanceGuid);
                stick.SetCooperativeLevel(_boundForm, CooperativeLevel.Exclusive | CooperativeLevel.Background);

                if (stick == null)
                {
                    throw new JoystickNotFoundException();
                }

                foreach (DeviceObjectInstance deviceObject in stick.GetObjects())
                {
                    Logger.Debug("deviceObject {0}", deviceObject.Name);
                    UpdateControl(deviceObject);
                }

                // acquire the device
                stick.Acquire();
            }
        }

        public void ReleaseDevice()
        {
            //timer1.Stop();

            if (stick != null)
            {
                stick.Unacquire();
                stick.Dispose();
            }
            stick = null;
        }

        void UpdateControl(DeviceObjectInstance d)
        {
            if (ObjectGuid.Button == d.ObjectType)
            {
                OnDeviceFound(DeviceType.Button, d);
                return;
            }
            else if (ObjectGuid.PovController == d.ObjectType)
            {
                OnDeviceFound(DeviceType.Pov, d);
                return;
            }
            else if (ObjectGuid.Slider == d.ObjectType)
            {
                OnDeviceFound(DeviceType.Slider, d);
            }
            else
            {
                OnDeviceFound(DeviceType.Unknown, d);
            }
        }

        protected void OnDeviceFound(DeviceType t, DeviceObjectInstance i)
        {
            if (DeviceFound != null)
            {
                DeviceFound(this, new DeviceFoundArguments(t, i));
            }
        }

        protected void OnJoystickStateChanged(JoystickState s)
        {
            if (JoystickStateChanged != null)
            {
                JoystickStateChanged(this, s);
            }
        }

        public void PollData()
        {

            try
            {
                stick.Acquire();
                stick.Poll();
            }
            catch (Exception ex)
            {
                return;
            }


            state = stick.GetCurrentState();
            //if (Result.Last.IsFailure)
            //    return;

            OnJoystickStateChanged(state);
        }

        public void Dispose()
        {
            ReleaseDevice();
        }
    }
}
