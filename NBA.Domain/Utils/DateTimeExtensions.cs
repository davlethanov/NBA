using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Domain.Utils
{
    public static class DateTimeExtensions
    {
        public static int GetAge(this DateTime date)
        {
            var today = DateTime.Today;
            return (today.Year - date.Year - 1) +
                 (((today.Month > date.Month) ||
                 ((today.Month == today.Month) && (today.Day >= date.Day))) ? 1 : 0);
        }
    }
}
