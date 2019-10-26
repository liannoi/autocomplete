using Autocomplete.DAL;
using Autocomplete.DAL.DataObjects;
using Autocomplete.DAL.DataServices;
using Autocomplete.WindowUI.UI.BL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows;

namespace Autocomplete.WindowUI.UI.BL.ViewModels
{
    public sealed partial class DashboardViewModel
    {
        private IAsyncResult asyncFindSuggestions;
        private IAsyncResult asyncInitialize;
        private IAsyncResult asyncIncrement;
        private IAsyncResult asyncAddSuggestion;

        private void AsyncAddSuggestion(string str)
        {
            AddSuggestionAsync.AddSuggestionAsyncDelegate addSuggestion = AddSuggestion;
            asyncAddSuggestion = addSuggestion.BeginInvoke(str, CallbackAddSuggestion, null);
        }

        private void CallbackAddSuggestion(IAsyncResult iAsyncResult)
        {
            AsyncResult asyncResult = iAsyncResult as AsyncResult;
            AddSuggestionAsync.AddSuggestionAsyncDelegate caller = asyncResult.AsyncDelegate as AddSuggestionAsync.AddSuggestionAsyncDelegate;
            caller.EndInvoke(iAsyncResult);
        }

        private void AsyncIncrement()
        {
            IncrementAsync.IncrementAsyncDelegate increment = IncrementValue;
            asyncIncrement = increment.BeginInvoke(CallbackIncrement, null);
        }

        private void CallbackIncrement(IAsyncResult iAsyncResult)
        {
            AsyncResult asyncResult = iAsyncResult as AsyncResult;
            IncrementAsync.IncrementAsyncDelegate caller = asyncResult.AsyncDelegate as IncrementAsync.IncrementAsyncDelegate;
            caller.EndInvoke(iAsyncResult);
        }

        private void AsyncInitialize()
        {
            InitializeAsync.InitializeAsyncDelegate initialize = DataServices.Initialize;
            asyncInitialize = initialize.BeginInvoke(false, CallbackInitialize, null);
        }

        private void CallbackInitialize(IAsyncResult iAsyncResult)
        {
            AsyncResult asyncResult = iAsyncResult as AsyncResult;
            InitializeAsync.InitializeAsyncDelegate caller = asyncResult.AsyncDelegate as InitializeAsync.InitializeAsyncDelegate;
            caller.EndInvoke(iAsyncResult);
        }

        private void AsyncFindSuggestions()
        {
            if (Value != 100)
            {
                MessageBox.Show("asd");
                return;
            }

            FindSuggestionAsync.FindSuggestionAsyncDelegate findSuggestion = russianWordsSuggestionService.Find;
            asyncFindSuggestions = findSuggestion.BeginInvoke(Buffer.Split().Last(), Consts.CountSuggestions, CallbackFindSuggestions, null);
        }

        private void CallbackFindSuggestions(IAsyncResult iAsyncResult)
        {
            AsyncResult asyncResult = iAsyncResult as AsyncResult;
            FindSuggestionAsync.FindSuggestionAsyncDelegate caller = asyncResult.AsyncDelegate as FindSuggestionAsync.FindSuggestionAsyncDelegate;
            caller.EndInvoke(iAsyncResult);

            List<string> collection = russianWordsSuggestionService.Suggestions;
            try
            {
                FirstSuggestion.Word = collection[0];
                SecondSuggestion.Word = collection[1];
                ThirdSuggestion.Word = collection[2];
            }
            catch (InvalidOperationException)
            {
                return;
            }
        }
    }
}
