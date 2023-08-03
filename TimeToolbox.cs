using System;

namespace SubFutzer
{
    public class TimeToolbox
    {
        public static TimeSpan DateTimeToTimeSpan(DateTime dt)
        {
            return new TimeSpan(0, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        public static DateTime TimeSpanToDateTime(TimeSpan ts)
        {
            if (ts == TimeSpan.MinValue)
                return new DateTime(1, 1, 1, 0, 0, 0, 0);
            return new DateTime(1, 1, 1, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        public static long DateTimeToMilliseconds(DateTime dt)
        {
            return Convert.ToInt64(DateTimeToTimeSpan(dt).TotalMilliseconds);
        }
    }
}
