using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Logic
{
    public class MatrixElementChangedEventArgs<T>
    {
        public int RowIndex { get; }

        public int ColumnIndex { get; }

        public T Value { get; }

        public MatrixElementChangedEventArgs(int i, int j, T value)
        {
            this.RowIndex = i;
            this.ColumnIndex = j;
            Value = value;
        }

    }
}
