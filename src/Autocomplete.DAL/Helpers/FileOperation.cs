using System.Collections.Generic;
using System.IO;

namespace Autocomplete.DAL.Helpers
{
    public static class FileOperation
    {
        public static IEnumerable<string> ReadByLine(string filePath)
        {
            List<string> lines = new List<string>();
            string line;
            using StreamReader reader = new StreamReader(filePath);
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
            
            return lines;
        }
    }
}
