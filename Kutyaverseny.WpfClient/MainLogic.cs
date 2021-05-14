// <copyright file="MainLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kutyaverseny.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// main logic.
    /// </summary>
    internal class MainLogic
    {
        private string url = "https://localhost:44372/DogsApi/";
        private HttpClient client = new HttpClient();
        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        /// <summary>
        /// get dogs.
        /// </summary>
        /// <returns>list.
        /// </returns>
        public List<DogVM> ApiGetDogs()
        {
            string json = this.client.GetStringAsync(this.url + "all").Result;
            var list = JsonSerializer.Deserialize<List<DogVM>>(json, this.jsonOptions);
            return list;
        }

        /// <summary>
        /// api del dog.
        /// </summary>
        /// <param name="dog">dog to del.</param>
        public void ApiDelDog(DogVM dog)
        {
            bool success = false;
            if (dog != null)
            {
                string json = this.client.GetStringAsync(this.url + "del/" + dog.ChipNum.ToString()).Result;
                JsonDocument doc = JsonDocument.Parse(json);
                success = doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
            }

            SendMessage(success);
        }

        /// <summary>
        /// public edit dog.
        /// </summary>
        /// <param name="dog">dog to edit.</param>
        /// <param name="editorFunc">func.</param>
        public void EditDog(DogVM dog, Func<DogVM, bool> editorFunc)
        {
            DogVM clone = new DogVM();
            if (dog != null)
            {
                clone.CopyFrom(dog);
            }

            bool? success = editorFunc?.Invoke(clone);
            if (success == true)
            {
                if (dog != null)
                {
                    success = this.ApiEditDog(clone, true);
                }
                else
                {
                    success = this.ApiEditDog(clone, false);
                }

                SendMessage(success == true);
            }
        }

        /// <summary>
        /// sendmessege.
        /// </summary>
        /// <param name="success">succes.</param>
        private static void SendMessage(bool success)
        {
            string msg = success ? "Operation completed succesfully" : "Operation faild";
            Messenger.Default.Send(msg, "DogResult");
        }

        /// <summary>
        /// adi etid dog.
        /// </summary>
        /// <param name="dog">dog to esid.</param>
        /// <param name="isEditing">edit or add.</param>
        /// <returns>is ok.</returns>
        private bool ApiEditDog(DogVM dog, bool isEditing)
        {
            if (dog == null)
            {
                return false;
            }

            string myUrl = this.url + (isEditing ? "mod" : "add");
            Dictionary<string, string> postData = new Dictionary<string, string>();

            // if (isEditing)
            // {
            postData.Add("ChipNum", dog.ChipNum.ToString());

            // }
            postData.Add("OwnerName", dog.OwnerName.ToString());
            postData.Add("DogName", dog.DogName.ToString());
            postData.Add("Breed", dog.Breed.ToString());
            postData.Add("Gender", dog.Gender.ToString());

            string json = this.client.PostAsync(myUrl, new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
            JsonDocument doc = JsonDocument.Parse(json);
            return doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
        }
    }
}
