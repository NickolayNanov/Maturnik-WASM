using Maturnik.Application.Common.Interfaces;
using System;

namespace Maturnik.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
