using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Logic
{
    /// <summary>
    /// represent Matrix.
    /// </summary>
    /// <typeparam name="T">Elements type.</typeparam>
    public class Matrix<T> : IEnumerable<T>
    {
        #region Fields
        /// <summary>
        /// Matrix values.
        /// </summary>
        public T[,] values;
        /// <summary>
        /// Number of rows of matrix.
        /// </summary>
        private int rowSize;
        /// <summary>
        /// Number of columns of matrix.
        /// </summary>
        private int columnSize;
        /// <summary>
        /// Default size.
        /// </summary>
        private const int defaultSize = 3;
        #endregion

        #region Properties
        /// <summary>
        /// Get the numbers of rows.
        /// </summary>
        public int RowSize
        {
            get => this.rowSize;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"{nameof(value)} must be more than 1");
                }

                this.rowSize = value;
            }
        }

        /// <summary>
        /// Get the numbers of columns.
        /// </summary>
        public int ColumnSize
        {
            get => this.columnSize;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"{nameof(value)} must be more than 1");
                }

                this.columnSize = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initialized a matrix with default size.
        /// </summary>
        public Matrix()
        {
            this.rowSize = defaultSize;
            this.columnSize = defaultSize;
            this.values = new T[defaultSize, defaultSize];
        }

        /// <summary>
        /// Initialized a matrix with a specified numbers of rows and columns.
        /// </summary>
        /// <param name="rowSize">Number of rows.</param>
        /// <param name="columnSize">Number of columns.</param>
        public Matrix(int rowSize, int columnSize)
        {
            this.rowSize = rowSize;
            this.columnSize = columnSize;
            this.values = new T[rowSize, columnSize];
        }

        /// <summary>
        /// Initialized a matrix from the array of values.
        /// </summary>
        /// <param name="values">Values.</param>
        public Matrix(T[,] values)
        {
            if (ReferenceEquals(values, null))
            {
                throw new ArgumentNullException($"{nameof(values)} mustn't be null.");
            }

            this.values = new T[values.GetLength(0), values.GetLength(1)];
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    this.values[i, j] = values[i, j];
                }
            }

        }

        #endregion

        #region Change element event
        /// <summary>
        /// Occurs when matrix changed element.
        /// </summary>
        public event EventHandler<MatrixElementChangedEventArgs<T>> ElementChanged;

        protected virtual void OnElementChanged(object source, MatrixElementChangedEventArgs<T> args) =>
            ElementChanged?.Invoke(this, args);

        #endregion

        #region Methods
        /// <summary>
        /// Change elemet at the given position.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index.</param>
        /// <param name="value">New value.</param>
        public virtual void ChangeElement(int i, int j, T value)
        {
            IndexValid(i,j);
            this.values[i, j] = value;
            OnElementChanged(this, new MatrixElementChangedEventArgs<T>(i, j, value));
        }

        /// <summary>
        /// Get or set elemet at the given position.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index.</param>
        /// <returns></returns>
        public T this[int i, int j]
        {
            get
            {
                IndexValid(i,j);
                return this.values[i, j];
            }

            set
            {
                IndexValid(i,j);
                this.ChangeElement(i, j, value);
            }
        }
       
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in values)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Checks the index validity.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index.</param>
        private void IndexValid(int i, int j)
        {
            if (i < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(i)} must be more or equal zero.");
            }

            if (j < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(j)} must be more or equal zero.");
            }

            if (i > RowSize)
            {
                throw new ArgumentOutOfRangeException($"{nameof(i)} must be less than row size.");
            }

            if (i > ColumnSize)
            {
                throw new ArgumentOutOfRangeException($"{nameof(i)} must be less than column size.");
            }
        }
        #endregion

    }
}