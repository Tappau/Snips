using System;

namespace SnipsSolution
{
    public class Clock : IDisposable
    {
        private static DateTime? _nowforTest;

        public static DateTime Now => _nowforTest ?? DateTime.Now;

        private static DateTime? _utcNowForTest;
        public static DateTime UtcNow => _utcNowForTest ?? DateTime.UtcNow;

        public static IDisposable NowIs(DateTime datetime)
        {
            _nowforTest = datetime;
            return new Clock();
        }

        public static IDisposable UtcNowIs(DateTime datetime)
        {
            _utcNowForTest = datetime;
            return new Clock();
        }

        public void Dispose()
        {
            _utcNowForTest = null;
            _nowforTest = null;
        }
    }
}