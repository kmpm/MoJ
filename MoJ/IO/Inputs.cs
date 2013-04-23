using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MoJ.IO
{
    public class Inputs
    {
        [Flags]
        public enum MouseEventFlags
        {
            NONE=0,
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            LeftClick = 0x00000006,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            //Move = 0x00000001,
            //Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010,
        }

        private const byte KEYBDEVENTF_SHIFTVIRTUAL = 0x10;
        private const byte KEYBDEVENTF_SHIFTSCANCODE = 0x2A;
        private const int KEYBDEVENTF_KEYDOWN = 0;
        private const int KEYBDEVENTF_KEYUP = 2;

        public enum KeybdEventFlags
        {
            NONE=0,
            ShiftKeyDown,
            ShiftKeyUp
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = x;
            }

        }


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "keybd_event", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern void keybd_event(byte vk, byte scan, int flags, int extrainfo);

        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }

        public static void KeybdEvent(KeybdEventFlags evt)
        {
            switch (evt)
            {
                case KeybdEventFlags.ShiftKeyDown:
                    keybd_event(KEYBDEVENTF_SHIFTVIRTUAL, KEYBDEVENTF_SHIFTSCANCODE, KEYBDEVENTF_KEYDOWN, 0);
                    break;
                case KeybdEventFlags.ShiftKeyUp:
                    keybd_event(KEYBDEVENTF_SHIFTVIRTUAL, KEYBDEVENTF_SHIFTSCANCODE, KEYBDEVENTF_KEYUP, 0);
                    break;
            }
        }

        public static void MouseEvent(MouseEventFlags value)
        {
            MousePoint position = GetCursorPosition();

            mouse_event
                ((int)value,
                 position.X,
                 position.Y,
                 0,
                 0);
        }
    }
}
