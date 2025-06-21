using System;

namespace SingletonPatternExample
{
    // Singleton Logger Class
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();

        // Private constructor to prevent instantiation
        private Logger()
        {
            Console.WriteLine("Logger Initialized.");
        }

        // Public static method to access the single instance
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock) // Ensure thread safety
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        // Sample log method
        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }

    // Program to test the Singleton