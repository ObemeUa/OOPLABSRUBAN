using System;

namespace MathLibrary
{
    // Інтерфейс для раціональних дробів
    public interface IRational
    {
        IRational Add(IRational other);
        IRational Subtract(IRational other);
        IRational Multiply(IRational other);
        IRational Divide(IRational other);
    }

    // Інтерфейс для комплексних чисел
    public interface IComplex
    {
        IComplex Add(IComplex other);
        IComplex Subtract(IComplex other);
        IComplex Multiply(IComplex other);
        IComplex Divide(IComplex other);
    }

    // Клас для раціональних дробів
    public class Rational : IRational
    {
        private int numerator;
        private int denominator;

        public Rational(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public IRational Add(IRational other)
        {
            Rational rational = (Rational)other;
            int commonDenominator = denominator * rational.denominator;
            int commonNumerator = (numerator * rational.denominator) + (rational.numerator * denominator);
            return new Rational(commonNumerator, commonDenominator);
        }

        public IRational Subtract(IRational other)
        {
            Rational rational = (Rational)other;
            int commonDenominator = denominator * rational.denominator;
            int commonNumerator = (numerator * rational.denominator) - (rational.numerator * denominator);
            return new Rational(commonNumerator, commonDenominator);
        }

        public IRational Multiply(IRational other)
        {
            Rational rational = (Rational)other;
            int multipliedNumerator = numerator * rational.numerator;
            int multipliedDenominator = denominator * rational.denominator;
            return new Rational(multipliedNumerator, multipliedDenominator);
        }

        public IRational Divide(IRational other)
        {
            Rational rational = (Rational)other;
            int dividedNumerator = numerator * rational.denominator;
            int dividedDenominator = denominator * rational.numerator;
            return new Rational(dividedNumerator, dividedDenominator);
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }
    }

    // Клас для комплексних чисел
    public class Complex : IComplex
    {
        private double real;
        private double imaginary;

        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public IComplex Add(IComplex other)
        {
            Complex complex = (Complex)other;
            double sumReal = real + complex.real;
            double sumImaginary = imaginary + complex.imaginary;
            return new Complex(sumReal, sumImaginary);
        }

        public IComplex Subtract(IComplex other)
        {
            Complex complex = (Complex)other;
            double diffReal = real - complex.real;
            double diffImaginary = imaginary - complex.imaginary;
            return new Complex(diffReal, diffImaginary);
        }

        public IComplex Multiply(IComplex other)
        {
            Complex complex = (Complex)other;
            double multipliedReal = (real * complex.real) - (imaginary * complex.imaginary);
            double multipliedImaginary = (real * complex.imaginary) + (imaginary * complex.real);
            return new Complex(multipliedReal, multipliedImaginary);
        }

        public IComplex Divide(IComplex other)
        {
            Complex complex = (Complex)other;
            double divisor = (complex.real * complex.real) + (complex.imaginary * complex.imaginary);
            double dividedReal = ((real * complex.real) + (imaginary * complex.imaginary)) / divisor;
            double dividedImaginary = ((imaginary * complex.real) - (real * complex.imaginary)) / divisor;
            return new Complex(dividedReal, dividedImaginary);
        }

        public override string ToString()
        {
            string sign = imaginary < 0 ? "-" : "+";
            return $"{real} {sign} {Math.Abs(imaginary)}i";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Приклад використання класів для раціональних дробів та комплексних чисел
            IRational rational1 = new Rational(3, 4);
            IRational rational2 = new Rational(2, 5);
            IRational rationalSum = rational1.Add(rational2);
            IRational rationalDiff = rational1.Subtract(rational2);
            IRational rationalProduct = rational1.Multiply(rational2);
            IRational rationalQuotient = rational1.Divide(rational2);

            Console.WriteLine($"Раціональні дроби:");
            Console.WriteLine($"{rational1} + {rational2} = {rationalSum}");
            Console.WriteLine($"{rational1} - {rational2} = {rationalDiff}");
            Console.WriteLine($"{rational1} * {rational2} = {rationalProduct}");
            Console.WriteLine($"{rational1} / {rational2} = {rationalQuotient}");

            IComplex complex1 = new Complex(1, 2);
            IComplex complex2 = new Complex(3, 4);
            IComplex complexSum = complex1.Add(complex2);
            IComplex complexDiff = complex1.Subtract(complex2);
            IComplex complexProduct = complex1.Multiply(complex2);
            IComplex complexQuotient = complex1.Divide(complex2);

            Console.WriteLine($"Комплексні числа:");
            Console.WriteLine($"{complex1} + {complex2} = {complexSum}");
            Console.WriteLine($"{complex1} - {complex2} = {complexDiff}");
            Console.WriteLine($"{complex1} * {complex2} = {complexProduct}");
            Console.WriteLine($"{complex1} / {complex2} = {complexQuotient}");

            Console.ReadLine();
        }
    }
}
