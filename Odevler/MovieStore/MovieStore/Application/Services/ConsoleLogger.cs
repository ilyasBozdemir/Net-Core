using System;

namespace MovieStore.Services
{
  public class ConsoleLogger : ILoggerService
  {
    public void Write(string message)
            => Console.WriteLine($"\n[ConsoleLogger] => {message}");
  }
}