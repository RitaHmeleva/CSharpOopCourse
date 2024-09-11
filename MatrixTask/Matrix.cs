using System;
using VectorTask;

namespace MatrixTask;

internal class Matrix
{
    private Vector[] _vectors;

    public Matrix(int rowsCount, int columnsCount)
    {
        if (rowsCount <= 0)
        {
            throw new ArgumentException(nameof(rowsCount), $"Rows count {rowsCount} should be > 0");
        }

        if (columnsCount <= 0)
        {
            throw new ArgumentException(nameof(columnsCount), $"Columns count {columnsCount} should be > 0");
        }

        _vectors = new Vector[rowsCount];

        for (int i = 0; i < rowsCount; i++)
        {
            _vectors[i] = new Vector(columnsCount);
        }
    }

    public Matrix(Matrix matrix)
    {
        if (matrix.RowsCount == 0)
        {
            throw new ArgumentException($"Rows count {matrix.RowsCount} should be > 0");
        }

        if (matrix.ColumnsCount == 0)
        {
            throw new ArgumentException($"Columns count {matrix.ColumnsCount} should be > 0");
        }

        _vectors = new Vector[matrix.RowsCount];

        for (int i = 0; i < matrix.RowsCount; i++)
        {
            _vectors[i] = new Vector(matrix._vectors[i]);
        }
    }

    public Matrix(double[,] matrix)
    {
        if (matrix.GetLength(1) == 0)
        {
            throw new ArgumentException($"Rows count {matrix.GetLength(1)} should be > 0");
        }

        if (matrix.GetLength(0) == 0)
        {
            throw new ArgumentException($"Columns count {matrix.GetLength(0)} should be > 0");
        }

        _vectors = new Vector[matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            _vectors[i] = new Vector(matrix.GetLength(1));

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                _vectors[i][j] = matrix[i, j];
            }
        }
    }

    public Matrix(Vector[] vectors)
    {
        if (vectors.Length == 0)
        {
            throw new ArgumentException($"Rows count {vectors.Length} should be > 0");
        }

        if (vectors[0].Size == 0)
        {
            throw new ArgumentException($"Columns count {vectors[0].Size} should be > 0");
        }

        _vectors = new Vector[vectors.Length];

        for (int i = 0; i < vectors.Length; i++)
        {
            _vectors[i] = new Vector(vectors[i]);
        }
    }

    public int RowsCount
    {
        get { return _vectors.Length; }
    }

    public int ColumnsCount
    {
        get { return _vectors[0].Size; }
    }

    public Vector GetRow(int rowIndex)
    {
        if (rowIndex < 0)
        {
            throw new ArgumentException(nameof(rowIndex), $"Row index {rowIndex} should be >= 0");
        }

        if (rowIndex >= _vectors.Length)
        {
            throw new ArgumentException(nameof(rowIndex), $"Row index {rowIndex} should be < rows count {_vectors.Length}");
        }

        Vector vector = new Vector(_vectors.Length);

        for (int i = 0; i < ColumnsCount; i++)
        {
            vector[i] = _vectors[rowIndex][i];
        }

        return vector;
    }

    public void SetRow(int rowIndex, double[] vector)
    {
        if (rowIndex < 0)
        {
            throw new ArgumentException(nameof(rowIndex), $"Row index {rowIndex} should be >= 0");
        }

        if (rowIndex >= RowsCount)
        {
            throw new ArgumentException(nameof(rowIndex), $"Row index {rowIndex} should be < rows count {_vectors.Length}");
        }

        if (vector.Length != RowsCount)
        {
            throw new ArgumentException($"Vector length {vector.Length} should be = matrix rows count {_vectors.Length}");
        }

        for (int i = 0; i < _vectors[0].Size; i++)
        {
            _vectors[rowIndex][i] = vector[i];
        }
    }

    public Vector GetColumn(int columnIndex)
    {
        if (columnIndex < 0)
        {
            throw new ArgumentException(nameof(columnIndex), $"Column index {columnIndex} should be >= 0");
        }

        if (columnIndex >= ColumnsCount)
        {
            throw new ArgumentException(nameof(columnIndex), $"Column index {columnIndex} should be < columns count {ColumnsCount}");
        }

        Vector vector = new Vector(RowsCount);

        for (int i = 0; i < ColumnsCount; i++)
        {
            vector[i] = _vectors[columnIndex][i];
        }

        return vector;
    }

    public void Transpose()
    {
        if (ColumnsCount != RowsCount)
        {
            throw new ArgumentException($"Rows count {RowsCount} should be = columns count {ColumnsCount}");
        }

        for (int i = 0; i < RowsCount; i++)
        {
            for (int j = i + 1; j < ColumnsCount; j++)
            {
                double temp = _vectors[i][j];
                _vectors[i][j] = _vectors[j][i];
                _vectors[j][i] = temp;
            }
        }
    }

    public void Product(double scalar)
    {
        for (int i = 0; i < RowsCount; i++)
        {
            for (int j = 0; j < ColumnsCount; j++)
            {
                _vectors[i][j] *= scalar;
            }
        }
    }

    public Matrix GetMinor(int rowIndex, int columnIndex)
    {
        Matrix minor = new Matrix(RowsCount - 1, ColumnsCount - 1);

        int minorRow = 0;
        int minorColumn = 0;

        for (int i = 0; i < RowsCount; i++)
        {
            if (i != rowIndex)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    if (j != columnIndex)
                    {
                        minor._vectors[minorRow][minorColumn] = _vectors[i][j];
                        minorColumn++;
                    }
                }

                minorColumn = 0;
                minorRow++;
            }
        }

        return minor;
    }

    public double Determinant()
    {
        if (RowsCount != ColumnsCount)
        {
            throw new ArgumentException($"Rows count {RowsCount} should be = columns count {ColumnsCount}");
        }

        if (_vectors.Length == 1)
        {
            return _vectors[0][0];
        }

        if (_vectors.Length == 2)
        {
            return _vectors[0][0] * _vectors[1][1] - _vectors[1][0] * _vectors[0][1];
        }

        double det = 0;
        int sign = 1;

        for (int i = 0; i < ColumnsCount; i++)
        {
            det += sign * _vectors[0][i] * GetMinor(0, i).Determinant();
            sign = -sign;
        }

        return det;
    }

    public override string ToString()
    {
        string s = "{";

        for (int i = 0; i < RowsCount; i++)
        {
            s += "{";

            for (int j = 0; j < ColumnsCount; j++)
            {
                s += _vectors[i][j].ToString();

                if (j < ColumnsCount - 1)
                {
                    s += ", ";
                }
            }

            s += "}";

            if (i < RowsCount - 1)
            {
                s += ", ";
            }
        }

        s += "}";

        return s;
    }

    public void Product(double[] vector)
    {
        if (vector.Length == 0)
        {
            throw new ArgumentException($"Vector size {vector.Length} should be > 0");
        }

        if (vector.Length > _vectors[0].Size)
        {
            throw new ArgumentException($"Vector size {vector.Length} should be <= matrix columns count {_vectors.GetLength(0)}");
        }

        if (vector.Length != _vectors.Length)
        {
            throw new ArgumentException($"Vector length {vector.Length} should be = matrix rows count {_vectors.Length}");
        }

        for (int i = 0; i < _vectors.Length; i++)
        {
            for (int j = 0; j < _vectors[0].Size; j++)
            {
                _vectors[i][j] *= vector[i];
            }
        }
    }

    public void Sum(Matrix matrix)
    {
        if (matrix.RowsCount == 0)
        {
            throw new ArgumentException($"Rows count should be > 0");
        }

        if (matrix.ColumnsCount == 0)
        {
            throw new ArgumentException($"Columns count should be > 0");
        }

        if (matrix.ColumnsCount > _vectors[0].Size)
        {
            throw new ArgumentException($"Added matrix columns count {matrix.ColumnsCount} should be <= matrix columns count {_vectors[0].Size}");
        }

        if (matrix.RowsCount > _vectors.Length)
        {
            throw new ArgumentException($"Added matrix rows count {matrix.RowsCount} should be <= matrix rows count {_vectors.Length}");
        }

        for (int i = 0; i < matrix.RowsCount; i++)
        {
            for (int j = 0; j < matrix.ColumnsCount; j++)
            {
                _vectors[i][j] += matrix._vectors[i][j];
            }
        }
    }

    public void Difference(Matrix matrix)
    {
        if (matrix.RowsCount == 0)
        {
            throw new ArgumentException($"Rows count should be > 0");
        }

        if (matrix.ColumnsCount == 0)
        {
            throw new ArgumentException($"Columns count should be > 0");
        }

        if (matrix.ColumnsCount > _vectors.Length)
        {
            throw new ArgumentException($"Deductible matrix columns count {matrix._vectors.GetLength(0)} should be <= matrix columns count {_vectors.GetLength(0)}");
        }

        if (matrix.RowsCount > _vectors.Length)
        {
            throw new ArgumentException($"Deductible matrix rows count {matrix._vectors.GetLength(1)} should be <= matrix rows count {_vectors.GetLength(1)}");
        }

        for (int i = 0; i < matrix.RowsCount; i++)
        {
            for (int j = 0; j < matrix.ColumnsCount; j++)
            {
                _vectors[i][j] -= matrix._vectors[i][j];
            }
        }
    }

    public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
    {
        Matrix matrix = new Matrix(matrix1);

        matrix.Sum(matrix2);

        return matrix;
    }

    public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
    {
        Matrix matrix = new Matrix(matrix1);

        matrix.Difference(matrix2);

        return matrix;
    }

    public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.RowsCount == 0)
        {
            throw new ArgumentException($"Matrix1 rows count should be > 0");
        }

        if (matrix1.ColumnsCount == 0)
        {
            throw new ArgumentException($"Matrix1 columns count should be > 0");
        }

        if (matrix2.RowsCount == 0)
        {
            throw new ArgumentException($"Matrix2 rows count should be > 0");
        }

        if (matrix2.ColumnsCount == 0)
        {
            throw new ArgumentException($"Matrix2 columns count should be > 0");
        }

        if (matrix1.ColumnsCount < matrix2.ColumnsCount)
        {
            throw new ArgumentException($"Deductible matrix columns count {matrix1.ColumnsCount} should be <= matrix columns count {matrix2.ColumnsCount}");
        }

        if (matrix1.RowsCount < matrix2.RowsCount)
        {
            throw new ArgumentException($"Deductible matrix rows count {matrix1.RowsCount} should be <= matrix rows count {matrix2.RowsCount}");
        }

        Matrix productMatrix = new Matrix(matrix1);

        for (int i = 0; i < matrix2.RowsCount; i++)
        {
            for (int j = 0; j < matrix2.ColumnsCount; j++)
            {
                productMatrix._vectors[i][j] *= matrix2._vectors[i][j];
            }
        }

        return productMatrix;
    }
}