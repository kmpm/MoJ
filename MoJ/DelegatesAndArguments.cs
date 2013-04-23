using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoJ
{
    public class DeviceFoundArguments
    {
        public DeviceFoundArguments(IO.Joy.DeviceType type, SharpDX.DirectInput.DeviceObjectInstance instance)
        {
            DeviceType = type;
            Instance = instance;
        }

        public IO.Joy.DeviceType DeviceType { get; private set; }
        public SharpDX.DirectInput.DeviceObjectInstance Instance { get; private set; }
    }

    

    public delegate void DeviceFoundEventHandler(object sender, DeviceFoundArguments e);

    public delegate void JoystickStateEventHandler(object sender, SharpDX.DirectInput.JoystickState s);
}
