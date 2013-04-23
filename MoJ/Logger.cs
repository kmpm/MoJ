using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoJ
{
    public class LogContext : IDisposable
    {
        private List<string> _context;
        internal LogContext(List<string> context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.RemoveAt(_context.Count - 1);
        }
    }

    public enum LogLevel
    {
        DEBUG = 0,
        INFO,
        WARN,
        ERROR
    }


    public class Logger
    {
        private List<string> _context = new List<string>();
        private const String template = "@level; @name; @context; @msg";
        private string _name=string.Empty;


        public Logger(string name)
        {
            _name = name;
        }


        public void Debug(string msg)
        {
            Log(LogLevel.DEBUG, msg);
        }

        public void Debug(string format, params object[] args)
        {
            Debug(String.Format(format, args));
        }

        public void Info(string msg)
        {
            Log(LogLevel.INFO, msg);
        }

        public void Info(string format, params object[] args)
        {
            Info(String.Format(format, args));
        }


        public void Error(string msg)
        {
            Log(LogLevel.ERROR, "{0}", msg);
        }

        public void Error(Exception e)
        {
            Error(String.Format("{0}", e.ToString(), e.Message));
        }

        private void Log(LogLevel l, string format, params object[] args)
        {
            Log(l, String.Format(format, args));
        }

        private void Log(LogLevel l, string msg)
        {
            string line = template.Replace("@level", Enum.GetName(typeof(LogLevel), l));
            line = line.Replace("@msg", msg);
            line = line.Replace("@name", _name);

            string stx = string.Join(">", _context);
            line = line.Replace("@context", stx);

            Console.WriteLine(line);
        }

        public IDisposable Context(string msg)
        {
            _context.Add(msg);
            return new LogContext(_context);
        }
    }
}
