using System;
using System.Collections.Generic;
using System.Text;

namespace Parus.Library
{
    interface TrackCollection
    {
        /* Methods for inspecting/viewing the contents of the collection "broadly" */
        uint CountTracks { get; }

        ArtistCollection Artists();
        AlbumCollection Albums();
        TagCollection Tags();

        /* reserved for possible groupedByXXX() methods
         * 
         * Philipe: my preference is not to expose these kinds of operations, should be able to design
         * the interface of Library and the associated collections such that any non-library code should
         * not need to fiddle with these datastructures in such a way...
         */
    }
}
