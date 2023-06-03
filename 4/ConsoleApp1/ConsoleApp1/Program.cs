using System;
using System.Collections.Generic;

namespace VectorProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задані вектори
            int[] vector1 = { 1, 2, 3 };
            int[] vector2 = { 4, 5, 6 };

            // Обчислення векторного добутку
            LinkedList<LinkedList<int>> result = VectorProduct(vector1, vector2);

            // Вивід векторного добутку на екран
            PrintVectorProduct(result);

            Console.ReadLine();
        }

        static LinkedList<LinkedList<int>> VectorProduct(int[] vector1, int[] vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vectors must have the same length.");
            }

            // Створення колекції для результату векторного добутку
            LinkedList<LinkedList<int>> result = new LinkedList<LinkedList<int>>();

            // Обчислення векторного добутку
            for (int i = 0; i < vector1.Length; i++)
            {
                LinkedList<int> product = new LinkedList<int>();
                for (int j = 0; j < vector2.Length; j++)
                {
                    // Обчислення значення векторного добутку елементів векторів
                    product.AddLast(vector1[i] * vector2[j]);
                }
                // Додавання вектору добутків до результату
                result.AddLast(product);
            }

            return result;
        }

        static void PrintVectorProduct(LinkedList<LinkedList<int>> result)
        {
            // Вивід векторного добутку на екран
            foreach (LinkedList<int> product in result)
            {
                foreach (int value in product)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
