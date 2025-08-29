namespace ShanYue.Util
{

    /// <summary>
    /// 最好线程安全 ---->待实现
    /// </summary>
    public class SnowflakeIdUtils
    {
        private static readonly object _lock = new object();
        private static long _lastTimestamp = -1L;
        private static long _sequence = 0L;

        private const long Twepoch = 1288834974657L;
        private const int SequenceBits = 12;
        private const long MaxSequence = -1L ^ (-1L << SequenceBits);

        public static long NextId()
        {
            lock (_lock)
            {
                var timestamp = GetCurrentTimestamp();
                if (timestamp == _lastTimestamp)
                {
                    _sequence = (_sequence + 1) & MaxSequence;
                    if (_sequence == 0)
                        timestamp = WaitNextMillis(_lastTimestamp);
                }
                else
                {
                    _sequence = 0;
                }

                _lastTimestamp = timestamp;
                return ((timestamp - Twepoch) << SequenceBits) | _sequence;
            }
        }

        private static long GetCurrentTimestamp() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        private static long WaitNextMillis(long lastTimestamp)
        {
            var timestamp = GetCurrentTimestamp();
            while (timestamp <= lastTimestamp)
                timestamp = GetCurrentTimestamp();
            return timestamp;
        }
    }

}
