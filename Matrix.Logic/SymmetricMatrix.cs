using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Logic
{
    /// <summary>
    /// Represent Symmetric Matrix.
    /// </summary>
    /// <typeparam name="T">Elements type.</typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initialized a SymmetricMatrix with a specified size.
        /// </summary>
        /// <param name="size">Size.</param>
        public SymmetricMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Initialized a SymmetricMatrix from the array of values.
        /// </summary>
        /// <param name="values">Values.</param>
        public SymmetricMatrix(T[,] values)
        {
            if (ReferenceEquals(values, null))
            {
                throw new ArgumentNullException($"{nameof(values)} mustn't be null.");
            }

            if (IsSymmetric(values))
            {
                throw new ArgumentException($"{nameof(values)} must be symmetric.");
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
            this.values[j, i] = value;
            base.ChangeElement(i, j, value);
        }

        /// <summary>
        /// Checks wether the matix is symmetric.
        /// </summary>
        /// <param name="matrix">Sourse matrix.</param>
        private bool IsSymmetric(T[,] matrix)
        {
            if (!IsSquare(matrix))
            {
                return false;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == (dynamic)matrix[j, i])
                        return true;
                }
            }

            return false;
        }
    }
}
