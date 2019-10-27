using System;
using System.Linq;

namespace Autocomplete.WindowUI.UI.Helpers
{
    public static class StringOperation
    {
        public static string ReplaceLastOccurrence(string source, string find, string replace)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("Inappropriate argument passed", nameof(source));
            }

            if (string.IsNullOrWhiteSpace(find))
            {
                throw new ArgumentException("Inappropriate argument passed", nameof(find));
            }

            int place = source.LastIndexOf(find, StringComparison.InvariantCulture);
            if (place == -1)
            {
                return source;
            }

            string result = source.Remove(place, find.Length).Insert(place, replace);
            return result;
        }

        public static string LastWord(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("Inappropriate argument passed", nameof(source));
            }

            string result = source.Split().Last();
            return result;
        }
    }
}
