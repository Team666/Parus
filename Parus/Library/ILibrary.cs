using System;
using System.Collections.Generic;
using System.Text;

namespace Parus.Library
{
    interface ILibrary
    {
        TrackCollection Everything { get; }

        TrackCollection AllMatching(TagExpression tagExpression);
    }
}
