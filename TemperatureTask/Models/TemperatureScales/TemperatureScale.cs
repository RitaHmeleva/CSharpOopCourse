namespace TemperatureTask.Models.TemperatureScales
{
    internal abstract class TemperatureScale
    {
        public abstract string Name { get; }

        public abstract string UnitsName { get; }

        public abstract string Code { get; }

        public abstract double ToKelvin(double value);

        public abstract double FromKelvin(double value);
    }
}