using System;
using System.Collections.Generic;
using System.Text;

namespace Parus.Library.Model
{
    class Tag : ValueType<string>
    {
        public Tag(string value) : base(value)
        {
        }
    }
}
