// Copyright 2019 Maksym Liannoi
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Autocomplete.DAL;
using Autocomplete.DAL.DataObjects.Delegates;
using Autocomplete.DAL.DataServices;
using Autocomplete.WindowUI.UI.BL.BusinessObjects;
using Autocomplete.WindowUI.UI.Helpers;
using System;
using System.Collections.Generic;
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

            MessageBox.Show("Dictionary loaded successfully.");
        }

        private void AsyncFindSuggestions()
        {
            if (Value != 100)
            {
                MessageBox.Show("Wait for the dictionary to load.");
                return;
            }

            FindSuggestionAsync.FindSuggestionAsyncDelegate findSuggestion = russianWordsSuggestionService.Find;
            asyncFindSuggestions = findSuggestion.BeginInvoke(StringOperation.LastWord(Buffer), Consts.CountSuggestions, CallbackFindSuggestions, null);
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
                // This block must be empty.
            }
        }
    }
}
