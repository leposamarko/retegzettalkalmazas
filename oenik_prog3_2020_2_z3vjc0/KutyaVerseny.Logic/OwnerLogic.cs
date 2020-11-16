// <copyright file="OwnerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Repository;

    /// <summary>
    /// class of owner logic.
    /// </summary>
    public class OwnerLogic : IOwnerLogic
    {
        private DogRepository dogRepo;
        private InterventionRepository intRepo;
        private MedalRepository medalRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerLogic"/> class.
        /// </summary>
        /// <param name="repo">repo.</param>
        public OwnerLogic(DogRepository repo, InterventionRepository intRepo, MedalRepository medalRepo)
        {
            this.dogRepo = repo;
            this.intRepo = intRepo;
            this.medalRepo = medalRepo;
        }

        public void AddDog(Dog d)
        {
            this.dogRepo.Add(d);
        }

        public void ChangeDogName(int id, string name)
        {
            this.dogRepo.ChangeName(id, name);
        }

        public IList<Dog> GetAllDogs()
        {
            return this.dogRepo.GetAll().ToList();
        }

        public IList<Intervention> GetAllIntervention(int chipnumb)
        {
            return this.intRepo.GetAll().Where(x => x.DogChipNum.GetHashCode().Equals(chipnumb)).ToList();
        }

        public IList<Medal> GetAllMedal(int chipnumb)
        {
            return this.medalRepo.GetAll().Where(x => x.DogChipNum.GetHashCode().Equals(chipnumb)).ToList();
        }

        public Dog GetYourDogByChip(int id)
        {
            return this.dogRepo.GetOne(id);
        }

        public IList<Dog> GetYourDogs(string name)
        {
            return this.dogRepo.GetAll().Where(x => x.OwnerName.Equals(name)).ToList();
        }

        public void RemoveDog(Dog d)
        {
            this.dogRepo.Remove(d);
        }
    }
}
