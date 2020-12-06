// <copyright file="DirectorLogic.cs" company="Z3VJC0">
// Copyright (c) Z3VJC0. All rights reserved.
// </copyright>

namespace KutyaVerseny.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Repository;

    /// <summary>
    /// director logic class.
    /// </summary>
    public class DirectorLogic : IDirectorLogic
    {
        private IMedalRepository medalRepo;
        private IDogRepository dogRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectorLogic"/> class.
        /// </summary>
        /// <param name="repo">medalrepo.</param>
        /// <param name="dogrepo">dogrepo.</param>
        public DirectorLogic(IMedalRepository repo, IDogRepository dogrepo)
        {
            this.medalRepo = repo;
            this.dogRepo = dogrepo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectorLogic"/> class.
        /// </summary>
        /// <param name="repo">medalrepo.</param>
        public DirectorLogic(IMedalRepository repo)
        {
            this.medalRepo = repo;
        }

        /// <summary>
        /// method to change the degree of the medal.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="s">new medal degree.</param>
        public void ChangeMedalDegree(int id, string s)
        {
            this.medalRepo.ChangeDegree(id, s);
        }

        /// <summary>
        /// method to change the race name.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="s">new race name.</param>
        public void ChangeMedalRaceName(int id, string s)
        {
            this.medalRepo.ChangeRaceName(id, s);
        }

        /// <summary>
        /// method to change the category.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="s">new cahtery name.</param>
        public void ChangeMedalCategory(int id, string s)
        {
            this.medalRepo.ChangeCategory(id, s);
        }

        /// <summary>
        /// method to change the starters number on the race.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <param name="db">new number of staters.</param>
        public void ChangeMedalStratersNum(int id, int db)
        {
            this.medalRepo.ChangeStratersNum(id, db);
        }

        /// <summary>
        /// get all medal.
        /// </summary>
        /// <returns>all medal.</returns>
        public IList<Medal> GetAllMedal()
        {
            return this.medalRepo.GetAll().ToList();
        }

        /// <summary>
        /// get one medal by id.
        /// </summary>
        /// <param name="id">medal id.</param>
        /// <returns>a medal.</returns>
        public Medal GetMedal(int id)
        {
            return this.medalRepo.GetOne(id);
        }

        /// <summary>
        /// Add a new medal.
        /// </summary>
        /// <param name="m">medal.</param>
        public void AddMedal(Medal m)
        {
            this.medalRepo.Add(m);
        }

        /// <summary>
        /// Remove a medal.
        /// </summary>
        /// <param name="m">medal to remove.</param>
        public void RemoveMedal(Medal m)
        {
            this.medalRepo.Remove(m);
        }

        /// <summary>
        /// get the dogs whos won this type of medal.
        /// </summary>
        /// <param name="degree">type of medal.</param>
        /// <returns>dog list.</returns>
        public List<Dog> DogsWithThisDegree(string degree)
        {
            return this.dogRepo.GetAll().ToList();
        }

        /// <summary>
        /// number of medals.
        /// </summary>
        /// <returns>string list.</returns>
        public List<string> DegreeNumb()
        {
            var q3 = from b in this.medalRepo.GetAll()
                     group b by b.Degree into g
                     select new
                     {
                         Degree = g.Key,
                         CountWin = g.Count(),
                     };
            return q3.Select(x => $"Degree={x.Degree}, ConuntWin={x.CountWin}").ToList();
        }

        /// <summary>
        /// task.
        /// </summary>
        /// <returns>Task.</returns>
        public Task<List<string>> DegreeNumbAsync()
        {
            return Task.Run(() => this.DegreeNumb());
        }
    }
}
