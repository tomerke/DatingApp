using System;

namespace API.Extensions
{
    public static class NewBaseType
    {
        public static int Calculate(this DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;
            if (dob.Year > today.AddYears)
        }
    }

}