using Parus.Core.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parus.Core.Model
{
    public class AudioFile : MediaFile
    {
        public AudioFile(string fileName) : base(fileName)
        {
        }

        public Track Metadata { get; }

        // public TimeSpan Duration { get; }
    }
}
