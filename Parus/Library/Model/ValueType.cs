using System;
using System.Collections.Generic;
using System.Text;

namespace Parus.Library.Model
{
    public class ValueType<T>
    {
        protected ValueType(T value)
        {
            this.Value = value;
        }

        public T Value { get; }
    }
}
