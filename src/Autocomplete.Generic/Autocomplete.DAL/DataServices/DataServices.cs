namespace Autocomplete.DAL.DataServices
{
    public static class DataServices
    {
        public static BaseRussianDictionary RussianDictionary { get; private set; }

        public static void Initialize(bool isMock)
        {
            if (isMock)
            {
                RussianDictionary = new Mock.RussianDictionaryDataService();
            }
            else
            {
                RussianDictionary = new File.RussianDictionaryDataService();
            }
        }
    }
}
