using System;

namespace BCPAO.PhotoManager.Helpers
{
    public static class Number
    {
        public static Decimal Round(Decimal number, int precision = 2)
        {
            return Math.Round(number, precision, MidpointRounding.AwayFromZero);
        }
    }
}
