using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace W3W
{
    public class What3WordsAutoSuggestOptions
    {

        public What3WordsAutoSuggestOptions() { }

        public What3WordsAutoSuggestOptions(What3WordsAutoSuggestOptions src)
        {
            Copy(src);
        }


        /// <summary>
        /// Gets or sets the number of AutoSuggest results to return. A maximum of 100 results can 
        /// be specified, if a number greater than this is requested, this will be truncated to the 
        /// maximum. The default is 3;
        /// </summary>
        public uint Limit { get; set; } = 3;

        /// <summary>
        /// Gets or sets the location with to rank results in order of closeness of the 
        /// <see cref="Focus"/>.
        /// </summary>
        /// <remarks>
        /// Longitude is allowed to wrap arounf the 180 line, so 361 is equivalnt to 1.
        /// </remarks>
        public LatLng Focus { get; set; } = null;

        /// <summary>
        /// Gets or sets the number of results within the results set that will have a focus.
        /// </summary>
        /// <remarks>
        /// Must be less than or equal to <see cref="Limit"/>
        /// </remarks>
        public uint FocusLimit { get; set; } = 0;

        /// <summary>
        /// Restricts AutoSuggest to only return results inside the countries codes specified.
        /// </summary>
        /// <remarks>
        /// Countrys are specified using their twwo-letter ISO 3166-1 alpha-2 code.
        /// </remarks>
        public List<string> ClipToCountries { get; set; } = null;

        /// <summary>
        /// Gets or sets the bounding box to clip results to.
        /// </summary>
        public BoundingBox ClipToBoundingBox { get; set; } = null;

        /// <summary>
        /// Gets or sets the circle to clip results to.
        /// </summary>
        public Circle ClipToCircle { get; set; } = null;

        /// <summary>
        /// Gets the collection of points that make up the polygon to clip results to.
        /// </summary>
        /// <remarks>
        /// The polygon should be closed, i.e. the first element should be repeated as the last 
        /// element; also this list should contain at least 4 entries and is limited up to 25 pairs.
        /// </remarks>
        public List<LatLng> ClipToPolygon { get; set; } = null;

        /// <summary>
        /// Gets or sets the two-letter language code of the fallback language.
        /// </summary>
        /// <remarks>
        /// Can be helpful to the input is particularly messy.
        /// </remarks>
        public string Language { get; set; } = "EN";

        /// <summary>
        /// Gets or sets a value indicating whether AutoSuggest should prefer results on land to 
        /// those at sea.
        /// </summary>
        public bool PreferLand { get; set; } = true;


        /// <summary>
        /// Copies the specified source <see cref="What3WordsAutoSuggestOptions"/> instance.
        /// </summary>
        /// <param name="src">The source instance.</param>
        public virtual void Copy(What3WordsAutoSuggestOptions src)
        {
            this.ClipToBoundingBox = src.ClipToBoundingBox;
            this.ClipToCircle = ClipToCircle;
            this.Focus = src.Focus;
            this.FocusLimit = src.FocusLimit;
            this.Limit = src.Limit;

            this.ClipToCountries = src.ClipToCountries == null ? null : new List<string>(src.ClipToCountries);
            this.ClipToPolygon = src.ClipToPolygon == null ? null : new List<LatLng>(src.ClipToPolygon);
        }
    }
}
