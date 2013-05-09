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


        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      

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

        public static void RunThreaded(Task t)
        {
            Thread thread = new Thread(RunThreadTask);

            thread.Start(t);
        }

        private static void RunThreadTask(object o)
        {
            Run((Task)o);
        }

        public static void Run(Task t)
        {
            using (log4net.ThreadContext.Stacks["NDC"].Push("Run(Task '" + t.Name + "')"))
            {
                foreach (Action a in t.Actions)
                {
                    Run(a);
                }
            }
        }
        public static void Run(Action a)
        {
            using (log4net.ThreadContext.Stacks["NDC"].Push("Run(Action)"))
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
                {
                    if (log.IsDebugEnabled) log.DebugFormat("Sleeping for {0}ms", a.Delay);
                    Thread.Sleep(a.Delay);
                }
            }
        }



        private static void RunMouse(Action a)
        {
            using (log4net.ThreadContext.Stacks["NDC"].Push("RunMouse"))
            {
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;

                string flag = Enum.GetName(typeof(ActionMethod), a.Method).Replace("MouseButton", "");

                flag = textInfo.ToTitleCase(a.Data) + flag;

                MouseEventFlags mef = (MouseEventFlags)Enum.Parse(typeof(MouseEventFlags), flag);
                MouseEvent(mef);
            }
        }



        /// <summary>
        /// {shift} = KEYBDEVENTF_SHIFTVIRTUAL
        /// </summary>
        /// <param name="a"></param>
        private static void RunKeyboard(Action a)
        {
            using (log4net.ThreadContext.Stacks["NDC"].Push("RunKeyboard"))
            {


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

                if (log.IsDebugEnabled) log.DebugFormat("keyDown:{0}, keyUp:{1}", keyDown, keyUp);

                var keyList = parseKeyboardData(a.Data);

                var inputList = new List<NativeWIN32.INPUT>();
                foreach (NativeWIN32.INPUT input in keyList)
                {
                    var flags = input.ki.dwFlags;
                    var i = input;
                    if (keyDown)
                    {
                        i.ki.dwFlags = flags | NativeWIN32.KEYEVENTF_KEYDOWN;
                        inputList.Add(i);
                    }
                    if (keyUp)
                    {
                        i.ki.dwFlags = flags | NativeWIN32.KEYEVENTF_KEYUP;
                        inputList.Add(i);
                    }
                }
                var inputs = inputList.ToArray();
                if(log.IsDebugEnabled) log.DebugFormat("Sending {0} keystrokes", inputs.Length);
                NativeWIN32.SendInput(1, ref inputs, Marshal.SizeOf(inputs));
            }
        }

        public static List<NativeWIN32.INPUT> parseKeyboardData(string data)
        {

            var keyList = new List<NativeWIN32.INPUT>();

            bool tag = false;
            string buffer = string.Empty; ;
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
                                var input = new NativeWIN32.INPUT
                                {
                                    type = NativeWIN32.INPUT_KEYBOARD,
                                    ki = new NativeWIN32.KEYBDINPUT
                                    {
                                        wVk = (ushort)NativeWIN32.VK.SHIFT,
                                        wScan = NativeWIN32.KEYEVENTSCAN_SHIFTSCANCODE,
                                    }
                                };
                                keyList.Add(input);
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
                        var input = new NativeWIN32.INPUT
                        {
                            type = NativeWIN32.INPUT_KEYBOARD,
                            ki = new NativeWIN32.KEYBDINPUT
                            {
                                wVk = 0,
                                wScan = c,
                                dwFlags = NativeWIN32.KEYEVENTF_UNICODE
                            }
                        };
                        keyList.Add(input);
                    }
                }
            }
            return keyList;
        }

    }







}
