namespace Autocomplete.DAL.DataServices
{
    public static class DataServices
    {
        public static BaseRussianDictionary BaseRussianDictionary { get; private set; }

        public static void Initialize(bool isMock)
        {
            if (isMock)
            {
                BaseRussianDictionary = new Mock.RussianDictionaryDataService();
            }
            else
            {
                BaseRussianDictionary = new File.RussianDictionaryDataService();
            }
        }
    }
}
