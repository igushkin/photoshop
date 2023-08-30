using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public struct Pixel
    {
        private double r;
        private double g;
        private double b;

        public Pixel(double r, double g, double b) : this()
        {
            R = r;
            G = g;
            B = b;
        }

        public static Pixel operator *(Pixel p, double m) => new Pixel(
                Trim(p.R * m),
                Trim(p.G * m),
                Trim(p.B * m)
            );

        public static Pixel operator *(double m, Pixel p) => p * m;

        public double R
        {
            get => r;
            set => r = Check(value);
        }

        public double G
        {
            get => g;
            set => g = Check(value);
        }

        public double B
        {
            get => b;
            set => b = Check(value);
        }

        private double Check(double value)
        {
            if (value < 0 || value > 1)
                throw new ArgumentException(string.Format("Wrong channel value {0} (the value must be between 0 and 1", value));
            return value;
        }

        public static double Trim(double value)
        {
            if (value < 0)
                return 0;
            if (value > 1)
                return 1;
            return value;
        }
    }
}
