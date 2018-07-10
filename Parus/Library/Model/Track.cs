using Parus.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parus.Core.Library.Model
{
    public class Track
    {
        Track(string title, string trackId)
        {
            Title = title;
            Id = trackId;
        }

        public TrackTitle Title { get; }
        public TrackId Id { get; }
    }
}