// Copyright (C) 2013 Peter Magnusson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;
using System.Reflection;

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

        public static void HelpText()
        {
            log.Debug("\r\n" + String.Join("\r\n", Enum.GetNames(typeof(WindowsInput.VirtualKeyCode))));
        }

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

                MouseEventFlags mef;
                bool found = Enum.TryParse<MouseEventFlags>(flag, out mef);
                if (found)
                {
                    MouseEvent(mef);
                }
                else
                {
                    log.WarnFormat("Mouse button '{0}' does not exist", a.Data);
                }
            }
        }



        /// <summary>
        /// Executes a keyboard style event
        /// </summary>
        /// <param name="a"></param>
        private static void RunKeyboard(Action a)
        {
            using (log4net.ThreadContext.Stacks["NDC"].Push("RunKeyboard"))
            {
                string simulateName = "Simulate" + Enum.GetName(a.Method.GetType(), a.Method);                
                MethodInfo theMethod = typeof(WindowsInput.InputSimulator).GetMethod(simulateName);

                if (log.IsDebugEnabled) log.DebugFormat("Method '{0}' is '{1}',", simulateName, theMethod != null);
                
                if(theMethod != null){
                    var parameters = theMethod.GetParameters();
                    
                    if(parameters[0].ParameterType == typeof(WindowsInput.VirtualKeyCode))
                    {
                        WindowsInput.VirtualKeyCode keyCode;
                        bool found = Enum.TryParse<WindowsInput.VirtualKeyCode>(a.Data.ToUpper(), out keyCode);
                        if (log.IsDebugEnabled) log.DebugFormat("KeyCode {0} is = {1}", a.Data, found);
                        if (found)
                        {
                            
                            theMethod.Invoke(null, new object[] { keyCode });
                        }

                    }
                    else if (parameters[0].ParameterType == typeof(String))
                    {
                        //This should actually only be 'SimulateTextEntry'                     
                        theMethod.Invoke(null, new object[] { a.Data });
                    }
                }       
            }
        }
    }
}
