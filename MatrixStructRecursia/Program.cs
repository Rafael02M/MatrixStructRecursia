using System;

namespace Project
{
    public struct MatrixModifier
    {
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int NewValue { get; set; }
        public int[,] Matrix {  get; set; }

        public MatrixModifier(int startX, int startY, int newValue, int[,] matrix)
        {
            StartX = startX; StartY = startY; NewValue = newValue; Matrix = matrix;
        }

        public int GetOldValue()
        {
            int oldValue = Matrix[StartX, StartY];
            return oldValue;
        }
        public void ToRight(int x, int y, int oldValue, int newValue)
        {
            int m = Matrix.GetLength(1);

            if(y + 1 > m - 1)
            {
                return;
            }
            if (Matrix[x, y + 1] != oldValue)
            {
            return;
            }
            Matrix[x, y + 1] = newValue;

            ToRight(x, y + 1, oldValue, newValue);
        }
        public void ToLeft(int x, int y, int oldValue, int newValue)
        {
            if (y - 1 < 0)
            {
                return;
            }
            if (Matrix[x, y - 1] != oldValue)
            {
                return;
            }
            Matrix[x, y - 1] = newValue;

            ToLeft(x, y - 1, oldValue, newValue);
        }
        public void ToUp(int x, int y, int oldValue, int newValue)
        {
            if (x - 1 < 0)
            {
                return;
            }
            if (Matrix[x - 1, y] != oldValue)
            {
                return;
            }
            Matrix[x - 1, y] = newValue;

            ToUp(x - 1, y, oldValue, newValue);
        }
        public void ToDown(int x, int y, int oldValue, int newValue)
        {
            int n = Matrix.GetLength(0);
            if (x + 1 > n - 1)
            {
                return;
            }
            if (Matrix[x + 1, y] != oldValue)
            {
                return;
            }
            Matrix[x + 1, y] = newValue;

            ToDown(x + 1, y, oldValue, newValue);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter startX");
            int startX = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter startY");
            int startY = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new value");
            int newValue = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the size of rown");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the size of column");
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];

            Random random = new Random();

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    matrix[i, j] = random.Next(1, 2);
                }
            }

            Console.WriteLine("\nOriginal matrix\n");

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
            MatrixModifier mtx = new MatrixModifier(startX, startY, newValue, matrix);
            mtx.Matrix[startX, startY] = newValue; 
            
            int oldValue = mtx.GetOldValue();
            
            mtx.ToRight(startX, startY, oldValue, newValue);
            mtx.ToLeft(startX, startY, oldValue, newValue);
            mtx.ToUp(startX, startY, oldValue, newValue);
            mtx.ToDown(startX, startY, oldValue, newValue);

            Console.WriteLine("\nModified matrix\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
