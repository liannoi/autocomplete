// Copyright 2020 Maksym Liannoi
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

using Autocomplete.DAL.DataObjects.Dictionaries;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Autocomplete.DAL.Helpers
{
    public static class BinarySerializationDictionary
    {
        public static TObject Deserialize<TObject>(string filePath) where TObject : class
        {
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream) as TObject;
        }

        public static void Serialize<TObject>(this TObject baseDictionary) where TObject : class
        {
            BaseDictionaryObject dictionary = baseDictionary as BaseDictionaryObject;
            FileStream stream = TryCreateFileStream(dictionary.FilePath);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, baseDictionary);
        }

        private static FileStream TryCreateFileStream(string filePath)
        {
            FileStream stream;
            try
            {
                stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(Consts.DictionariesDirectoryName);
                stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            }

            return stream;
        }
    }
}
