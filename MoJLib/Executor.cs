using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;

namespace MoJ
{
    public class Executor
    {



        #region Mouse Functions

        [Flags]
        public enum MouseEventFlags
        {
            NONE = 0,
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            LeftClick = 0x00000006,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            MiddleClick = 0x00000060,
            //Move = 0x00000001,
            //Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010,
            RightClick = 0x00000018
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




        private static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }


        private static void MouseEvent(MouseEventFlags value)
        {
            MousePoint position = GetCursorPosition();

            mouse_event
                ((int)value,
                 position.X,
                 position.Y,
                 0,
                 0);
        }

        #endregion


        #region Keyboard functions
        /*
         * http://www.pinvoke.net/default.aspx/user32.keybd_event
         * http://www.pinvoke.net/default.aspx/user32/MapVirtualKey.html
         * http://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
         * http://stackoverflow.com/questions/2934557/convert-character-to-the-corresponding-virtual-key-code
         * http://social.msdn.microsoft.com/Forums/en-US/windowscompatibility/thread/627b1c8c-0b75-4f73-9e29-3e17e93d539a
         * 
         * 
        */

        public static byte KEYBDEVENTF_SHIFTSCANCODE = 0x2A;
        

        



        [StructLayout(LayoutKind.Explicit)]
        public struct Helper
        {
            [FieldOffset(0)]
            public short Value;
            [FieldOffset(0)]
            public byte VirtualKey;
            [FieldOffset(1)]
            public byte ScanCode;
        }

        private static Helper toHelper(char c)
        {
            return new Helper { Value = NativeWIN32.VkKeyScan(c) };
        }

        public static string fromHelper(Helper h)
        {
            string buffer = "";
            byte shiftState = h.ScanCode;
            if ((shiftState & 1) != 0) buffer += "{shift}";
            if ((shiftState & 2) != 0) buffer += "{ctrl}";
            if ((shiftState & 4) != 0) buffer += "{alt}";

            return buffer;
        }

        public static List<Helper> parseKeyboardData(string data)
        {
            
            List<Helper> keyList = new List<Helper>();

            bool tag = false;
            string buffer = string.Empty;;
            for (int i = 0; i < data.Length; i++)
            {
                char c = data[i];
                if (tag)
                {
                    //we are in a tag
                    if (c == '}')
                    {
                        tag = false;
                        switch (buffer.ToLower())
                        {
                            case "shift":
                                var h = new Helper();
                                h.VirtualKey = (byte)VirtualKeys.VK_SHIFT;
                                h.ScanCode = KEYBDEVENTF_SHIFTSCANCODE;
                                keyList.Add(h);
                                break;
                        }
                        continue;
                    }
                    else
                    {
                        buffer += c;
                    }
                }
                else
                {
                    //we re not in a tag
                    if (c == '{')
                    {
                        buffer = string.Empty;
                        tag = true;
                        continue;
                    }
                    else
                    {
                        keyList.Add(toHelper(c));
                    }
                }
            }
            return keyList;
        }

        #endregion



        public static void Run(Action a)
        {
            switch (a.Method)
            {
                case ActionMethod.MouseButtonClick:
                case ActionMethod.MouseButtonDown:
                case ActionMethod.MouseButtonUp:
                    RunMouse(a);
                    break;
                default:
                    RunKeyboard(a);
                    break;
            }
            if (a.Delay > 0)
                Thread.Sleep(a.Delay);
        }



        private static void RunMouse(Action a)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            string flag = Enum.GetName(typeof(ActionMethod), a.Method).Replace("MouseButton", "");

            flag = textInfo.ToTitleCase(a.Data.Replace("@", "")) + flag;

            MouseEventFlags mef = (MouseEventFlags)Enum.Parse(typeof(MouseEventFlags), flag);
            MouseEvent(mef);
        }



        /// <summary>
        /// {shift} = KEYBDEVENTF_SHIFTVIRTUAL
        /// </summary>
        /// <param name="a"></param>
        private static void RunKeyboard(Action a)
        {

           

            int KEYBDEVENTF_KEYDOWN = 0;
            int KEYBDEVENTF_KEYUP = 2;

            bool keyDown = false;
            bool keyUp = false;

            switch (a.Method)
            {
                case ActionMethod.KeyDown:
                    keyDown = true;
                    break;
                case ActionMethod.KeyUp:
                    keyUp = true;
                    break;
                default:
                    keyUp = true;
                    keyDown = true;
                    break;
            }


            var keyList = parseKeyboardData(a.Data);


            foreach (Helper h in keyList)
            {
                if (keyDown)
                    NativeWIN32.keybd_event(h.VirtualKey, h.ScanCode, KEYBDEVENTF_KEYDOWN, 0);
                if (keyUp)
                    NativeWIN32.keybd_event(h.VirtualKey, h.ScanCode, KEYBDEVENTF_KEYUP, 0);

            }
        }

    }







}
