using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Logic
{
    /// <summary>
    /// Represent Square Matrix.
    /// </summary>
    /// <typeparam name="T">Elements type.</typeparam>
    public class SquareMatrix<T> : Matrix<T>
    {
        /// <summary>
        /// Size of Square Matrix
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Initialized a SquareMatrix with a default size.
        /// </summary>
        /// <param name="size">Size.</param>
        public SquareMatrix() : base()
        {
            this.Size = this.RowSize;
        }

        /// <summary>
        /// Initialized a SquareMatrix with a specified size.
        /// </summary>
        /// <param name="size">Size.</param>
        public SquareMatrix(int size) : base(size, size)
        {
            this.Size = this.RowSize;
        }

        /// <summary>
        /// Initialized a SquareMatrix from the array of values.
        /// </summary>
        /// <param name="values">Values.</param>
        public SquareMatrix(T[,] values) 
        {
            if (ReferenceEquals(values, null))
            {
                throw new ArgumentNullException($"{nameof(values)} mustn't be null.");
            }

            if (!IsSquare(values))
            {
                throw new ArgumentException($"{nameof(values)} must have the same numbers of rows and colums.");
            }

            this.Size = values.GetLength(0);

            this.values = new T[values.GetLength(0), values.GetLength(1)];

            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    this.values[i, j] = values[i, j];
                }
            }
        }

        /// <summary>
        /// Checks wether the matix is square.
        /// </summary>
        /// <param name="matrix">Sourse matrix.</param>
        internal bool IsSquare(T[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
