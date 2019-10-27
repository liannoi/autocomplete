using Autocomplete.WindowUI.UI.Helpers;

namespace Autocomplete.WindowUI.UI.BL.BusinessObjects
{
    public sealed class SuggestionBusinessObject : Bindable
    {
        private readonly string word = string.Empty;

        public bool HaveSuggestion
        {
            get => Word != null;
            set
            {
                // This block must be empty.
            }
        }

        public string Word
        {
            get => Get(word);
            set => Set(value);
        }
    }
}
