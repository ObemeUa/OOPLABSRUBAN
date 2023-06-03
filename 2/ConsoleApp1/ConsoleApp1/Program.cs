using System;

public class TPTriangle
{
    protected double cathetus1;
    protected double cathetus2;

    public TPTriangle()
    {
        cathetus1 = 0;
        cathetus2 = 0;
    }

    public TPTriangle(double cathetus1, double cathetus2)
    {
        this.cathetus1 = cathetus1;
        this.cathetus2 = cathetus2;
    }

    public TPTriangle(TPTriangle triangle)
    {
        cathetus1 = triangle.cathetus1;
        cathetus2 = triangle.cathetus2;
    }

    public void Input()
    {
        Console.Write("Enter the length of cathetus 1: ");
        cathetus1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the length of cathetus 2: ");
        cathetus2 = Convert.ToDouble(Console.ReadLine());
    }

    public void Output()
    {
        Console.WriteLine("Cathetus 1: " + cathetus1);
        Console.WriteLine("Cathetus 2: " + cathetus2);
    }

    public double CalculateArea()
    {
        return 0.5 * cathetus1 * cathetus2;
    }

    public double CalculatePerimeter()
    {
        double hypotenuse = Math.Sqrt(cathetus1 * cathetus1 + cathetus2 * cathetus2);
        return cathetus1 + cathetus2 + hypotenuse;
    }

    public bool CompareTo(TPTriangle otherTriangle)
    {
        return (cathetus1 == otherTriangle.cathetus1 && cathetus2 == otherTriangle.cathetus2);
    }

    public static TPTriangle operator +(TPTriangle triangle, double value)
    {
        TPTriangle result = new TPTriangle(triangle);
        result.cathetus1 += value;
        result.cathetus2 += value;
        return result;
    }

    public static TPTriangle operator -(TPTriangle triangle, double value)
    {
        TPTriangle result = new TPTriangle(triangle);
        result.cathetus1 -= value;
        result.cathetus2 -= value;
        return result;
    }

    public static TPTriangle operator *(TPTriangle triangle, double value)
    {
        TPTriangle result = new TPTriangle(triangle);
        result.cathetus1 *= value;
        result.cathetus2 *= value;
        return result;
    }
}

public class TPPiramid : TPTriangle
{
    private double height;

    public TPPiramid() : base()
    {
        height = 0;
    }

    public TPPiramid(double cathetus1, double cathetus2, double height) : base(cathetus1, cathetus2)
    {
        this.height = height;
    }

    public TPPiramid(TPPiramid piramid) : base(piramid)
    {
        height = piramid.height;
    }

    public new void Input()
    {
        base.Input();

        Console.Write("Enter the height: ");
        height = Convert.ToDouble(Console.ReadLine());
    }

    public new void Output()
    {
        base.Output();
        Console.WriteLine("Height: " + height);
    }

    public double CalculateVolume()
    {
        return (base.CalculateArea() * height) / 3;
    }

    public new double CalculatePerimeter()
    {
        double basePerimeter = base.CalculatePerimeter();
        double hypotenuse = Math.Sqrt(base.cathetus1 * base.cathetus1 + base.cathetus2 * base.cathetus2);
        double lateralEdge = Math.Sqrt(height * height + hypotenuse * hypotenuse);
        return basePerimeter + 2 * lateralEdge;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        TPTriangle triangle1 = new TPTriangle();
        triangle1.Input();
        Console.WriteLine("Triangle 1:");
        triangle1.Output();
        Console.WriteLine("Area: " + triangle1.CalculateArea());
        Console.WriteLine("Perimeter: " + triangle1.CalculatePerimeter());

        TPTriangle triangle2 = new TPTriangle(3, 4);
        Console.WriteLine("\nTriangle 2:");
        triangle2.Output();
        Console.WriteLine("Area: " + triangle2.CalculateArea());
        Console.WriteLine("Perimeter: " + triangle2.CalculatePerimeter());

        Console.WriteLine("\nComparing Triangle 1 with Triangle 2: " + triangle1.CompareTo(triangle2));

        TPTriangle triangle3 = new TPTriangle(triangle2);
        Console.WriteLine("\nTriangle 3 (copy of Triangle 2):");
        triangle3.Output();

        TPTriangle triangle4 = triangle1 + 2.5;
        Console.WriteLine("\nTriangle 4 (Triangle 1 + 2.5):");
        triangle4.Output();

        TPTriangle triangle5 = triangle2 - 1.5;
        Console.WriteLine("\nTriangle 5 (Triangle 2 - 1.5):");
        triangle5.Output();

        TPTriangle triangle6 = triangle1 * 1.5;
        Console.WriteLine("\nTriangle 6 (Triangle 1 * 1.5):");
        triangle6.Output();

        TPPiramid piramid1 = new TPPiramid();
        piramid1.Input();
        Console.WriteLine("\nPiramid 1:");
        piramid1.Output();
        Console.WriteLine("Volume: " + piramid1.CalculateVolume());
        Console.WriteLine("Perimeter: " + piramid1.CalculatePerimeter());

        TPPiramid piramid2 = new TPPiramid(3, 4, 5);
        Console.WriteLine("\nPiramid 2:");
        piramid2.Output();
        Console.WriteLine("Volume: " + piramid2.CalculateVolume());
        Console.WriteLine("Perimeter: " + piramid2.CalculatePerimeter());
    }
}
