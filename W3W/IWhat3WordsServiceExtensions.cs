using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace W3W
{
    public static class IWhat3WordsServiceExtensions
    {
        private const string WHAT_3_WORDS_REGEX = "^/*[^0-9`~!@#$%^&*()+\\-_=\\[{\\}\\\\|'<,.>?/\";:£§º©®\\s]{1,}[・.。][^0-9`~!@#$%^&*()+\\-_=\\[{\\}\\\\|'<,.>?/\";:£§º©®\\s]{1,}[・.。][^0-9`~!@#$%^&*()+\\-_=\\[{\\}\\\\|'<,.>?/\";:£§º©®\\s]{1,}$";


        public static Task<What3WordsConversion> ConvertAsync(this IWhat3WordsService what3WordsService, double latitude, double longitude)
        {
            return what3WordsService.ConvertAsync(latitude, longitude, "en");
        }

        public static bool IsAddressValid(this IWhat3WordsService what3WordsService, string words)
        {
            return Regex.IsMatch(words, WHAT_3_WORDS_REGEX);
        }
    }
}
