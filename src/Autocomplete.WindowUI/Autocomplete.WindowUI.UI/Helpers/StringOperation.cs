using System.Linq;

namespace Autocomplete.WindowUI.UI.Helpers
{
    public static class StringOperation
    {
        public static string ReplaceLastOccurrence(string source, string find, string replace)
        {
            int place = source.LastIndexOf(find);

            if (place == -1)
            {
                return source;
            }

            string result = source.Remove(place, find.Length).Insert(place, replace);
            return result;
        }

        public static string LastWord(string source)
        {
            string result = source.Split().Last();
            return result;
        }
    }
}
