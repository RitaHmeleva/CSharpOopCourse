using VectorTask;

namespace MatrixTask;

internal class MatrixMain
{
    static void Main(string[] args)
    {
        int rowsCount = 4;
        int columnsCount = 3;

        double[] components1 = { 1, 4, 3 };
        double[] components2 = { 2, 9, 6 };
        double[] components3 = { 3, 0, 2, 8 };
        double[] components4 = { 2, 0, 1, 2 };

        double[,] vectors1 =
        {
            { 1, 4, 8, 2 },
            { 2, 9, 6, 5 },
            { 8, 0, 8, 1 },
            { 8, 0, 8, 13 }
        };

        double[,] vectors2 =
        {
            { 4, 5, 1},
            { 2, 2, 2 }
        };

        Vector vector1 = new Vector(components1);
        Vector vector2 = new Vector(components2);
        Vector vector3 = new Vector(components3);

        Matrix matrix1 = new Matrix(rowsCount, columnsCount);
        Matrix matrix2 = new Matrix(matrix1);
        Matrix matrix3 = new Matrix(vectors1);
        Matrix matrix4 = new Matrix(vectors2);

        Vector[] vectors = { vector1, vector2, vector3 };
        Matrix matrix5 = new Matrix(vectors);

        Console.WriteLine(matrix1);
        Console.WriteLine(matrix2);
        Console.WriteLine(matrix3);
        Console.WriteLine(matrix4);
        Console.WriteLine(matrix5);

        Console.WriteLine("Количество строк: " + matrix3.RowsCount);

        Console.WriteLine("Количество столбцов: " + matrix3.ColumnsCount);

        Console.WriteLine("Вектор-строка по индексу: " + matrix3.GetRow(2));

        Vector vector = new Vector(new double[] { 4, 4, 3, 8 });
        matrix3.SetRow(2, vector);
        Console.WriteLine("Задание вектор-строки по индексу: " + matrix3);

        Console.WriteLine("Вектор-столбец по индексу: " + matrix4.GetColumn(2));

        matrix4.Transpose();
        Console.WriteLine("Транспонирование: " + matrix4);

        matrix3.Multiply(2);
        Console.WriteLine("Произведение матрицы и скаляра: " + matrix3);

        Console.WriteLine(matrix3);
        Console.WriteLine("Определитель матрицы: " + matrix3.GetDeterminant());

        Console.WriteLine("Произведение матрицы и вектора: " + matrix3.GetProduct(new Vector(components4)));

        matrix3.Add(matrix3);
        Console.WriteLine("Сумма матриц: " + matrix3);

        matrix3.Subtract(matrix3);
        Console.WriteLine("Разность матриц: " + matrix3);

        Console.WriteLine("Сумма матриц: " + Matrix.GetSum(matrix4, matrix4));

        Console.WriteLine("Разность матриц: " + Matrix.GetDifference(matrix3, matrix3));

        Console.WriteLine("Произведение матриц: " + Matrix.GetProduct(matrix4, matrix4));

        Console.ReadLine();
    }
}