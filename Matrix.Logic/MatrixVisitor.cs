using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Logic
{
    /// <summary>
    /// Matrix visitors.
    /// </summary>
    /// <typeparam name="T">Elements type.</typeparam>
    public abstract class MatrixVisitor<T>
    {
        public void Visit(Matrix<T> firstMatrix, Matrix<T> secondMatrix) => this.Visit((dynamic)firstMatrix, (dynamic)secondMatrix);

        protected abstract SquareMatrix<T> Visit(SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix);

        protected abstract SquareMatrix<T> Visit(SymmetricMatrix<T> firstMatrix, SymmetricMatrix<T> secondMatrix);

        protected abstract SquareMatrix<T> Visit(DiagonalMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix);
    }

    
}
