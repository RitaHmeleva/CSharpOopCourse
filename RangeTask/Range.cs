namespace RangeTask;

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

    public Range? GetIntersection(Range range)
    {
        if (range.From >= To || range.To <= From)
        {
            return null;
        }

        return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
    }

    public Range[] GetUnion(Range range)
    {
        if (range.From > To || range.To < From)
        {
            return new Range[] { new Range(From, To), new Range(range.From, range.To) };
        }

        return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
    }

    public Range[] GetDifference(Range range)
    {
        if (range.From <= From && range.To >= To)
        {
            return new Range[] { };
        }

        if (range.From >= From && range.To <= To)
        {
            return new Range[] { new Range(From, range.From), new Range(range.To, To) };
        }

        if (range.From >= From && range.From <= To)
        {
            return new Range[] { new Range(From, range.From) };
        }

        if (range.To <= To && range.To >= From)
        {
            return new Range[] { new Range(range.To, To) };
        }

        return new Range[] { new Range(From, To) };
    }

    public override string ToString()
    {
        return "[" + From + "; " + To + "]";
    }
}