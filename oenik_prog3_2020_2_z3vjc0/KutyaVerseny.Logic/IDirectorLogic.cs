// <copyright file="IDirectorLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using KutyaVerseny.Data.Models;

    /// <summary>
    /// interface of director logic.
    /// </summary>
    public interface IDirectorLogic
    {
        /// <summary>
        /// method to change the degree of the medal.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="s">new medal degree.</param>
        void ChangeMedalDegree(int id, string s);

        /// <summary>
        /// method to change the race name.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="s">new race name.</param>
        void ChangeMedalRaceName(int id, string s);

        /// <summary>
        /// method to change the category.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="s">new cahtery name.</param>
        void ChangeMedalCategory(int id, string s);

        /// <summary>
        /// method to change the starters number on the race.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="db">new number of staters.</param>
        void ChangeMedalStratersNum(int id, int db);

        /// <summary>
        /// get all medal from database.
        /// </summary>
        /// <returns>all dogs.</returns>
        IList<Medal> GetAllMedal();

        /// <summary>
        /// Take a madal by id.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <returns>a medal.</returns>
        Medal GetMedal(int id);

        /// <summary>
        /// Add a new medal.
        /// </summary>
        /// <param name="m">medal.</param>
        void AddMedal(Medal m);

        /// <summary>
        /// remove medal by id.
        /// </summary>
        /// <param name="m">id of the medal.</param>
        void RemoveMedal(Medal m);

        /// <summary>
        /// retrun the lis of dogs, who won gold, silver or bronz medal in races.
        /// </summary>
        /// <param name="degree">medal degree.</param>
        /// <returns>list of dogs.</returns>
        List<Dog> DogsWithThisDegree(string degree);

        /// <summary>
        /// number of medals.
        /// </summary>
        /// <returns>string list.</returns>
        List<string> DegreeNumb();

        /// <summary>
        /// task of noncroud.
        /// </summary>
        /// <returns>list task.</returns>
        Task<List<string>> DegreeNumbAsync();
    }
}
