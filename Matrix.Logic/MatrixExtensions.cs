using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Logic
{
    /// <summary>
    /// Matrix Extensions.
    /// </summary>
    public static class MatrixExtensions
    {
        /// <summary>
        /// Sum of two matricies.
        /// </summary>
        /// <typeparam name="T">Type of firstMatrix elements.</typeparam>
        /// <param name="firstMatrix">First matrix.</param>
        /// <param name="secondMatrix">Second matrix.</param>
        /// <param name="addRule">How add elements.</param>
        /// <returns></returns>
        public static Matrix<T> Add<T>(this Matrix<T> firstMatrix, Matrix<T> secondMatrix, Func<T,T,T> addRule)
        {
            if (firstMatrix == null)
            {
                throw new ArgumentNullException(nameof(firstMatrix));
            }

            if (secondMatrix == null)
            {
                throw new ArgumentNullException(nameof(secondMatrix));
            }

            var visitor = new MatrixOperation<T>(addRule);
            visitor.Visit(firstMatrix, secondMatrix);
            return visitor.ResultMatrix;
        }
    }
}
