using System;
using System.Net.Mime;

namespace SnipsSolution
{
    /// <summary>
    /// Usage in App.xaml.cs
    /// Add the following early on
    /// _exceptionHandler = new WpfGlobalExceptionHandler(_loggingService)
    /// </summary>
    public class WpfGlobalExceptionHandler
    {
        private const string DispatcherUnhandledException = "Application.Current.DispatcherUnhandledException";
        private const string UnhandledException = "ApplDomain.CurrentDomain.UnhandledException";
        private const string TaskExceptionEvent = "TaskSchedular.UnobservedTaskException";

        protected internal WpfGlobalExceptionHandler()
        {
            
        }
    }
}