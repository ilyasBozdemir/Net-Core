using System;

namespace MovieStore.Services
{
    public class DatabaseLogger : ILoggerService
    {
        public void Write(string message)
               => Console.WriteLine($"[DatabaseLogger] => {message}");

    }
}