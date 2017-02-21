using System;
using System.Collections.Generic;
using System.Text;

namespace Parus.Core.Model
{
    public abstract class MediaFile
    {
        protected MediaFile(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; }
    }
}
