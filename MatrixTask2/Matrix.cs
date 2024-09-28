using System.Text;
using VectorTask;

namespace MatrixTask;

internal class Matrix
{
    private Vector[] _rows;

    public Matrix(int rowsCount, int columnsCount)
    {
        if (rowsCount <= 0)
        {
            throw new ArgumentException($"Rows count {rowsCount} should be > 0", nameof(rowsCount));
        }

        if (columnsCount <= 0)
        {
            throw new ArgumentException($"Columns count {columnsCount} should be > 0", nameof(columnsCount));
        }

        _rows = new Vector[rowsCount];

        for (int i = 0; i < rowsCount; i++)
        {
            _rows[i] = new Vector(columnsCount);
        }
    }

    public Matrix(Matrix matrix)
    {
        _rows = new Vector[matrix.RowsCount];

        for (int i = 0; i < matrix.RowsCount; i++)
        {
            _rows[i] = new Vector(matrix._rows[i]);
        }
    }

    public Matrix(double[,] array)
    {
        if (array.GetLength(0) == 0)
        {
            throw new ArgumentException("Array size should be not 0");
        }

        _rows = new Vector[array.GetLength(0)];

        for (int i = 0; i < array.GetLength(0); i++)
        {
            _rows[i] = new Vector(array.GetLength(1));

            for (int j = 0; j < array.GetLength(1); j++)
            {
                _rows[i][j] = array[i, j];
            }
        }
    }

    public Matrix(Vector[] rows)
    {
        if (rows.Length == 0)
        {
            throw new ArgumentException($"Rows count {rows.Length} should be > 0");
        }

        for (int i = 1; i < rows.Length; i++)
        {
            if (rows[i].Size != rows[0].Size)
            {
                throw new ArgumentException("Rows size should be equals");
            }
        }

        this._rows = new Vector[rows.Length];

        for (int i = 0; i < rows.Length; i++)
        {
            this._rows[i] = new Vector(rows[i]);
        }
    }

    public int RowsCount
    {
        get => _rows.Length;
    }

    public int ColumnsCount
    {
        get => _rows[0].Size;
    }

    public Vector GetRow(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= RowsCount)
        {
            throw new ArgumentOutOfRangeException(nameof(rowIndex), $"Row index {rowIndex} should be between 0 and {RowsCount - 1}");
        }

        return new Vector(_rows[rowIndex]);
    }

    public void SetRow(int rowIndex, Vector row)
    {
        if (rowIndex < 0 || rowIndex >= RowsCount)
        {
            throw new ArgumentOutOfRangeException(nameof(rowIndex), $"Row index {rowIndex} should be between 0 and {RowsCount - 1}");
        }

        if (row.Size != ColumnsCount)
        {
            throw new ArgumentException($"Vector length {row.Size} should be = matrix columns count {RowsCount}");
        }

        _rows[rowIndex] = new Vector(row);
    }

    public Vector GetColumn(int columnIndex)
    {
        if (columnIndex < 0 || columnIndex >= ColumnsCount)
        {
            throw new ArgumentOutOfRangeException(nameof(columnIndex), $"Column index {columnIndex} should be between 0 and {ColumnsCount - 1}");
        }

        Vector column = new Vector(RowsCount);

        for (int i = 0; i < RowsCount; i++)
        {
            column[i] = _rows[i][columnIndex];
        }

        return column;
    }

    public void Transpose()
    {
        Vector[] newRows = new Vector[ColumnsCount];

        for (int j = 0; j < ColumnsCount; j++)
        {
            newRows[j] = GetColumn(j);
        }

        _rows = newRows;
    }

    public void CalculateProduct(double scalar)
    {
        for (int i = 0; i < RowsCount; i++)
        {
            _rows[i].CalculateProduct(scalar);
        }
    }

    private Matrix GetMinor(int rowIndex, int columnIndex)
    {
        Matrix minor = new Matrix(RowsCount - 1, ColumnsCount - 1);

        int minorRowIndex = 0;
        int minorColumnIndex = 0;

        for (int i = 0; i < RowsCount; i++)
        {
            if (i != rowIndex)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    if (j != columnIndex)
                    {
                        minor._rows[minorRowIndex][minorColumnIndex] = _rows[i][j];
                        minorColumnIndex++;
                    }
                }

                minorColumnIndex = 0;
                minorRowIndex++;
            }
        }

        return minor;
    }

    public double GetDeterminant()
    {
        if (RowsCount != ColumnsCount)
        {
            throw new Exception($"Rows count {RowsCount} should be = columns count {ColumnsCount}");
        }

        if (RowsCount == 1)
        {
            return _rows[0][0];
        }

        if (RowsCount == 2)
        {
            return _rows[0][0] * _rows[1][1] - _rows[1][0] * _rows[0][1];
        }

        double determinant = 0;
        int sign = 1;

        for (int i = 0; i < ColumnsCount; i++)
        {
            determinant += sign * _rows[0][i] * GetMinor(0, i).GetDeterminant();
            sign = -sign;
        }

        return determinant;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append("{");

        for (int i = 0; i < RowsCount; i++)
        {
            stringBuilder.Append(_rows[i].ToString());
            if (i < RowsCount - 1)
            {
                stringBuilder.Append(", ");
            }
        }

        stringBuilder.Append("}");

        return stringBuilder.ToString();
    }

    public override int GetHashCode()
    {
        const int prime = 37;
        int hash = 1;

        foreach (Vector row in _rows)
        {
            hash = prime * hash + row.GetHashCode();
        }

        return hash;
    }

    public override bool Equals(object o)
    {
        if (ReferenceEquals(o, this))
        {
            return true;
        }

        if (o is null || o.GetType() != GetType())
        {
            return false;
        }

        Matrix matrix = (Matrix)o;

        if (matrix.ColumnsCount != ColumnsCount || matrix.RowsCount != RowsCount)
        {
            return false;
        }

        for (int i = 0; i < RowsCount; i++)
        {
            if (matrix._rows[i] != _rows[i])
            {
                return false;
            }
        }

        return true;
    }

    public Vector CalculateProduct(Vector vector)
    {
        if (vector.Size == 0)
        {
            throw new ArgumentException($"Vector size {vector.Size} should be > 0");
        }

        if (vector.Size > RowsCount)
        {
            throw new ArgumentException($"Vector size {vector.Size} should be <= matrix columns count {ColumnsCount}");
        }

        if (vector.Size != RowsCount)
        {
            throw new ArgumentException($"Vector length {vector.Size} should be = matrix rows count {RowsCount}");
        }

        Vector productVector = new Vector(RowsCount);


        for (int i = 0; i < RowsCount; i++)
        {
            productVector[i] = Vector.GetScalarProduct(_rows[i], vector);
        }

        return productVector;
    }

    private static void CheckMatrixDimensions(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.ColumnsCount != matrix2.ColumnsCount || matrix1.RowsCount != matrix2.RowsCount)
        {
            throw new ArgumentException("First matrix rows and columns count should be = second matrix rows and columns count");
        }
    }

    public void CalculateSum(Matrix matrix)
    {
        CheckMatrixDimensions(this, matrix);

        for (int i = 0; i < matrix.RowsCount; i++)
        {
            _rows[i].CalculateSum(matrix._rows[i]);
        }
    }

    public void CalculateDifference(Matrix matrix)
    {
        CheckMatrixDimensions(this, matrix);

        for (int i = 0; i < matrix.RowsCount; i++)
        {
            _rows[i].CalculateDifference(matrix._rows[i]);
        }
    }

    public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
    {
        CheckMatrixDimensions(matrix1, matrix2);

        Matrix matrix = new Matrix(matrix1);

        matrix.CalculateSum(matrix2);

        return matrix;
    }

    public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
    {
        CheckMatrixDimensions(matrix1, matrix2);

        Matrix matrix = new Matrix(matrix1);

        matrix.CalculateDifference(matrix2);

        return matrix;
    }

    public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
    {
        CheckMatrixDimensions(matrix1, matrix2);

        Matrix productMatrix = new Matrix(matrix1);

        for (int i = 0; i < matrix2.RowsCount; i++)
        {
            for (int j = 0; j < matrix2.ColumnsCount; j++)
            {
                productMatrix._rows[i][j] *= matrix2._rows[i][j];
            }
        }

        return productMatrix;
    }
}