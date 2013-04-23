using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoJ
{
    public class JoystickNotFoundException : Exception
    {
        public JoystickNotFoundException():base("There are no joysticks attached to the system.")
        {
           
        }
    }
}
