using System;
using System.Collections.Generic;
using System.Text;

namespace W3W
{
    public static class What3WordsAutoSuggestOptionsBuilderExtensions
    {
        public static What3WordsAutoSuggestOptionsBuilder ClipToBoundingBox(this What3WordsAutoSuggestOptionsBuilder builder, 
            double swLat, double swLng, double neLat, double neLng)
        {
            builder.ClipToBoundingBox(new LatLng(swLat, swLng), new LatLng(neLat, neLng));
            return builder;
        }

        public static What3WordsAutoSuggestOptionsBuilder ClipToBoundingBox(this What3WordsAutoSuggestOptionsBuilder builder,
            LatLng southWest, LatLng northEast)
        {
            builder.ClipToBoundingBox(new BoundingBox(southWest, northEast));
            return builder;
        }
    }
}
