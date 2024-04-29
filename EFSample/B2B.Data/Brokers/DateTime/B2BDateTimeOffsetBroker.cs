namespace B2B.Data.Brokers.DateTime
{
    public class B2BDateTimeOffsetBroker : IB2BDateTimeOffsetBroker
    {
        public DateTimeOffset GetCurrentTime()
            => DateTimeOffset.Now;
    }
}
