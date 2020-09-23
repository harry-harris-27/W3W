using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W3W
{
    public class What3WordsAutoSuggestOptionsBuilder
    {

        private readonly What3WordsAutoSuggestOptions instance = new What3WordsAutoSuggestOptions();


        public What3WordsAutoSuggestOptions CreateInstance()
        {
            return new What3WordsAutoSuggestOptions(instance);
        }

        public What3WordsAutoSuggestOptionsBuilder Limit(uint limit)
        {
            instance.Limit = limit;
            return this;
        }

        public What3WordsAutoSuggestOptionsBuilder Focus(LatLng focus, uint focusLimit = 0)
        {
            instance.Focus = focus;
            instance.FocusLimit = focusLimit;
            return this;
        }

        public What3WordsAutoSuggestOptionsBuilder ClipToBoundingBox(BoundingBox boundingBox)
        {
            instance.ClipToBoundingBox = boundingBox;
            return this;
        }

        public What3WordsAutoSuggestOptionsBuilder ClipToCircle(Circle circle)
        {
            instance.ClipToCircle = circle;
            return this;
        }

        public What3WordsAutoSuggestOptionsBuilder ClipToCountry(params string[] countries)
        {
            instance.ClipToCountries = new List<string>(countries);
            return this;
        }

        public What3WordsAutoSuggestOptionsBuilder ClipToPolygon(params LatLng[] polygon)
        {
            instance.ClipToPolygon = new List<LatLng>(polygon);
            return this;
        }

        public What3WordsAutoSuggestOptionsBuilder PreferLand(bool preferLand)
        {
            instance.PreferLand = preferLand;
            return this;
        }

        public What3WordsAutoSuggestOptionsBuilder Language(string languageCode)
        {
            instance.Language = languageCode;
            return this;
        }
    }
}
