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
    public class MatrixOperation<T> : MatrixVisitor<T>
    {
        /// <summary>
        /// Result matrix.
        /// </summary>
        public SquareMatrix<T> ResultMatrix { get; private set; }

        /// <summary>
        /// Add Rule.
        /// </summary>
        private readonly Func<T, T, T> addRule;

        /// <summary>
        /// Constructor with add rule.
        /// </summary>
        /// <param name="addRule"> Add rule.</param>
        public MatrixOperation(Func<T, T, T> addRule)
        {
            this.addRule = addRule ?? throw new ArgumentNullException($"{nameof(addRule)} mustn't be null.");
        }

        /// <summary>
        /// Sum ot two SquareMatrix.
        /// </summary> 
        /// <param name="firstMatrix">First matrix</param>
        /// <param name="secondMatrix">Second matrix.</param>
        /// <returns>Sum of two matrix.</returns>
        protected override SquareMatrix<T> Visit(SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
            => this.Add(firstMatrix, secondMatrix);

        /// <summary>
        /// Sum ot two SymmetricMatrix.
        /// </summary> 
        /// <param name="firstMatrix">First matrix</param>
        /// <param name="secondMatrix">Second matrix.</param>
        /// <returns>Sum of two matrix.</returns>
        protected override SquareMatrix<T> Visit(SymmetricMatrix<T> firstMatrix, SymmetricMatrix<T> secondMatrix)
            => this.Add(firstMatrix, secondMatrix);

        /// <summary>
        /// Sum ot two DiagonalMatrix.
        /// </summary> 
        /// <param name="firstMatrix">First matrix</param>
        /// <param name="secondMatrix">Second matrix.</param>
        /// <returns>Sum of two matrix.</returns>
        protected override SquareMatrix<T> Visit(DiagonalMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix)
            => this.Add(firstMatrix, secondMatrix);

        /// <summary>
        /// Calculate sum ot two matrix.
        /// </summary> 
        /// <param name="firstMatrix">First matrix</param>
        /// <param name="secondMatrix">Second matrix.</param>
        /// <returns>Sum of two matrix.</returns>
        private SquareMatrix<T> Add(SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
        {
            MatrixValidate(firstMatrix, secondMatrix);
            if (firstMatrix.Size != secondMatrix.Size)
            {
                throw new ArgumentException($"{nameof(firstMatrix)} and {nameof(secondMatrix)} must have same size.");
            }

            this.ResultMatrix = new SquareMatrix<T>(firstMatrix.Size);
            for (int i = 0; i < firstMatrix.Size; i++)
            {
                for (int j = 0; j < firstMatrix.Size; j++)
                {
                    this.ResultMatrix[i, j] = addRule(firstMatrix[i, j], secondMatrix[i, j]);
                }
            }

            return ResultMatrix;
        }

        /// <summary>
        /// Checks the matrix validity.
        /// </summary>
        /// <param name="firstMatrix">First matrix</param>
        /// <param name="secondMatrix">Second matrix.</param> 
        private void MatrixValidate(SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
        {
            if (firstMatrix == null)
            {
                throw new ArgumentNullException($"{nameof(firstMatrix)} mustn't be null.");
            }

            if (secondMatrix == null)
            {
                throw new ArgumentNullException($"{nameof(secondMatrix)} mustn't be null.");
            }
        }
    }
}
