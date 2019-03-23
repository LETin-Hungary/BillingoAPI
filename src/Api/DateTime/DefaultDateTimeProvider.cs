using System;

namespace LETin.Billingo.Api
{
    public class DefaultDateTimeProvider : IDateTimeProvider
    {
        public DateTime CurrentTime => DateTime.UtcNow;
    }
}