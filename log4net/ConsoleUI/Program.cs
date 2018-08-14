using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
[assembly:log4net.Config.XmlConfigurator(Watch=true)]

namespace ConsoleUI
{
    class Program
    {
        private static readonly log4net.ILog Log = LogHelper.GetLogger(); 
        static void Main(string[] args)
        {
            LoggingFuntion();
        }
        private static void LoggingFuntion()
        {
            
            var secs = 3;
            Log.Fatal("Start log FATAL...");
            Console.WriteLine("Start log FATAL...");
           Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Error("Start log ERROR...");
            Console.WriteLine("Start log ERROR...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); 

            Log.Warn("Start log WARN...");
            Console.WriteLine("Start log WARN...");
            Thread.Sleep(TimeSpan.FromSeconds(secs));

            Log.Info("Start log INFO...");
            Console.WriteLine("Start log INFO...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); 

            Log.Debug("Start log DEBUG...");
            Console.WriteLine("Start log DEBUG...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); 

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }

    }
}
