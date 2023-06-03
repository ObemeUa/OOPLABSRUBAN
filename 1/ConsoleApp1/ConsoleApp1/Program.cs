using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("One-dimensional array operations:");
        OneDimensionalArrayOperations();

        Console.WriteLine("\nTwo-dimensional array operations:");
        TwoDimensionalArrayOperations();
    }

    public static void OneDimensionalArrayOperations()
    {
        int[] array = { -2, 3, 5, 0, -8, 2, 10, 4 };

        // Finding the smallest positive number
        int minPositive = FindSmallestPositive(array);
        Console.WriteLine("Smallest positive number: " + minPositive);

        // Checking if two vectors are parallel
        int[] vectorX = { 2, 4, -1 };
        int[] vectorY = { -1, -2, 0 };
        bool areParallel = AreVectorsParallel(vectorX, vectorY);
        Console.WriteLine("Are vectors parallel? " + areParallel);

        // Transforming the array to place all zeros first
        TransformArray(array);
        Console.WriteLine("Transformed array: " + string.Join(", ", array));
    }

    public static int FindSmallestPositive(int[] array)
    {
        int minPositive = int.MaxValue;
        foreach (int num in array)
        {
            if (num > 0 && num < minPositive)
                minPositive = num;
        }
        return minPositive;
    }

    public static bool AreVectorsParallel(int[] vectorX, int[] vectorY)
    {
        if (vectorX.Length != vectorY.Length)
            return false;

        double ratio = (double)vectorX[0] / vectorY[0];
        for (int i = 1; i < vectorX.Length; i++)
        {
            if ((double)vectorX[i] / vectorY[i] != ratio)
                return false;
        }
        return true;
    }

    public static void TransformArray(int[] array)
    {
        int zeroIndex = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == 0)
            {
                int temp = array[i];
                array[i] = array[zeroIndex];
                array[zeroIndex] = temp;
                zeroIndex++;
            }
        }
    }

    public static void TwoDimensionalArrayOperations()
    {
        int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            { 10, 11, 12 }
        };

        // Placing elements of odd rows in descending order
        SortOddRowsDescending(matrix);
        Console.WriteLine("Sorted matrix:");
        PrintMatrix(matrix);

        // Calculating the sum of columns with at least one negative element
        int[] columnSums = CalculateColumnSums(matrix);
        Console.WriteLine("Column sums: " + string.Join(", ", columnSums));

        // Finding saddle points of the matrix
        int[,] saddlePoints = FindSaddlePoints(matrix);
        Console.WriteLine("Saddle points:");
        PrintMatrix(saddlePoints);
    }

    public static void SortOddRowsDescending(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i += 2)
        {
            int[] row = GetRow(matrix, i);
            Array.Sort(row);
            Array.Reverse(row);
            SetRow(matrix, i, row);
        }
    }

    public static int[] CalculateColumnSums(int[,] matrix)
    {
        int columns = matrix.GetLength(1);
        int[] sums = new int[columns];

        for (int j = 0; j < columns; j++)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, j];
            }
            sums[j] = sum;
        }

        return sums;
    }

    public static int[,] FindSaddlePoints(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        int[,] saddlePoints = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            int rowMin = int.MaxValue;
            int minColumnIndex = -1;
            for (int j = 0; j < columns; j++)
            {
                if (matrix[i, j] < rowMin)
                {
                    rowMin = matrix[i, j];
                    minColumnIndex = j;
                }
            }

            bool isSaddlePoint = true;
            for (int k = 0; k < rows; k++)
            {
                if (matrix[k, minColumnIndex] > rowMin)
                {
                    isSaddlePoint = false;
                    break;
                }
            }

            if (isSaddlePoint)
                saddlePoints[i, minColumnIndex] = rowMin;
        }

        return saddlePoints;
    }

    public static int[] GetRow(int[,] matrix, int row)
    {
        int columns = matrix.GetLength(1);
        int[] rowData = new int[columns];
        for (int j = 0; j < columns; j++)
        {
            rowData[j] = matrix[row, j];
        }
        return rowData;
    }

    public static void SetRow(int[,] matrix, int row, int[] rowData)
    {
        int columns = matrix.GetLength(1);
        for (int j = 0; j < columns; j++)
        {
            matrix[row, j] = rowData[j];
        }
    }

    public static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
