using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace RangeTask
{
    class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range Intersect(Range otherRange)
        {
            if (otherRange.From >= To || otherRange.To <= From)
            {
                return null;
            }

            return new Range(Math.Max(From, otherRange.From), Math.Min(To, otherRange.To));
        }

        public Range[] Union(Range otherRange)
        {
            if (otherRange.From > To || otherRange.To < From)
            {
                return new Range[] { new Range(From, To), new Range(otherRange.From, otherRange.To) };
            }

            return new Range[] { new Range(Math.Min(From, otherRange.From), Math.Max(To, otherRange.To)) };
        }

        public Range[] Difference(Range otherRange)
        {
            if (otherRange.From <= From && otherRange.To >= To)
            {
                return null;
            }
            if (otherRange.From > From && otherRange.To > To)
            {
                return new Range[] { new Range(From, otherRange.From) };
            }
            else if (otherRange.From < From && otherRange.To < To)
            {
                return new Range[] { new Range(otherRange.To, To) };
            }

            return new Range[] { new Range(From, otherRange.From), new Range(otherRange.To, To) };
        }
    }
}