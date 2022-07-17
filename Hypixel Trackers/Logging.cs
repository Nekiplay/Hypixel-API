using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypixel_Trackers
{
    public class Logging
    {
        // Lock to make the logging class thread safe.
        static readonly object _locker = new object();

        public delegate void msgHandlerWriteLineDelegate(string msg, Color col);
        public static event msgHandlerWriteLineDelegate themsgHandlerWriteLineDelegate;

        public delegate void msgHandlerWriteDelegate(string msg, Color col);
        public static event msgHandlerWriteDelegate themsgHandlerWriteDelegate;

        public static void Write(string a, Color Col)
        {
            if (themsgHandlerWriteDelegate != null)
            {
                lock (_locker)
                {
                    themsgHandlerWriteDelegate(a, Col);
                }
            }
        }

        public static void Write(string a)
        {
            if (themsgHandlerWriteDelegate != null)
            {
                lock (_locker)
                {
                    themsgHandlerWriteDelegate(a, Color.Black);
                }
            }
        }

        public static void WriteLine(string a, Color Col)
        {
            if (themsgHandlerWriteLineDelegate != null)
            {
                lock (_locker)
                {
                    themsgHandlerWriteLineDelegate(a, Col);
                }
            }
        }

        public static void WriteLine(string a)
        {
            if (themsgHandlerWriteLineDelegate != null)
            {
                lock (_locker)
                {
                    themsgHandlerWriteLineDelegate(a, Color.Black);
                }
            }
        }

        // Console Methods That implement the delegates in my logging class.

        public static void ConsoleWriteLine(string message, Color Col)
        {
            try
            {
                if (Col == Color.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Col.Name);
                }
                Thread.BeginCriticalRegion();
                Console.WriteLine(message);
                Thread.EndCriticalRegion();
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine("ThreadAbortException : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
            }
        }

        public static void ConsoleWrite(string message, Color Col)
        {
            try
            {
                if (Col == Color.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Col.Name);
                }
                Thread.BeginCriticalRegion();
                Console.Write(message);//**THIS IS WHERE IS HANGS...IT NEVER RETURNS **
                Thread.EndCriticalRegion();
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine("ThreadAbortException : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
            }
        }

        public static void ConsoleUpdate(string message)
        {
            try
            {
                Thread.BeginCriticalRegion();
                Console.WriteLine(message);//**THIS IS WHERE IS HANGS...IT NEVER RETURNS **
                Thread.EndCriticalRegion();
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine("ThreadAbortException : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
            }
        }

        // The main method...subscribes to delegates and spawns a thread to boot HW..main thread then exits.

        public static void Reg()
        {
            Logging.themsgHandlerWriteDelegate += new Logging.msgHandlerWriteDelegate(ConsoleWrite);
            Logging.themsgHandlerWriteLineDelegate += new Logging.msgHandlerWriteLineDelegate(ConsoleWriteLine);
            //Logging.themsgHandlerUpdateDelegate += new Logging.msgHandlerUpdateDelegate(ConsoleUpdate);
        }
    }
}
