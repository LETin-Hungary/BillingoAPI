using System;

namespace LETin.Billingo.Api
{
    public interface IDateTimeProvider
    {
        DateTime CurrentTime {get;}
    }
}