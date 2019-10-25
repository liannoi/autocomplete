using Autocomplete.DAL.DataServices;

namespace Autocomplete.ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataServices.Initialize(true);
        }
    }
}
