using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Logic
{
    /// <summary>
    /// Represent Diagonal Matrix.
    /// </summary>
    /// <typeparam name="T">Elements type.</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initialized a DiagonalMatrix with a specified size.
        /// </summary>
        /// <param name="size">Size.</param>
        public DiagonalMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Initialized a DiagonalMatrix from the array of values.
        /// </summary>
        /// <param name="values">Values.</param>
        public DiagonalMatrix(T[,] values)
        {
            if (ReferenceEquals(values, null))
            {
                throw new ArgumentNullException($"{nameof(values)} mustn't be null.");
            }

            if (IsDiagonal(values))
            {
                throw new ArgumentException($"{nameof(values)} must be diagonal.");
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
        /// Change elemet at the given position.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index.</param>
        /// <param name="value">New value.</param>
        public override void ChangeElement(int i, int j, T value)
        {
            if (i != j)
            {
                throw new ArgumentException($"Element {nameof(i)},{nameof(j)} is not diagonal.");
            }

            base.ChangeElement(i, j, value);
        }

        /// <summary>
        /// Checks wether the matix is diagonal.
        /// </summary>
        /// <param name="matrix">Sourse matrix.</param>
        /// <returns></returns>
        private bool IsDiagonal(T[,] matrix)
        {
            if (!IsSquare(matrix))
            {
                return false;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != j && !matrix[i, j].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
