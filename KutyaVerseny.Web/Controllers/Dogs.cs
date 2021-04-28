// <copyright file="Dogs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using KutyaVerseny.Logic;
    using KutyaVerseny.Web.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// dog class.
    /// </summary>
    public class Dogs : Controller
    {
        private readonly IOwnerLogic logic;
        private readonly IMapper mapper;
        private readonly DogListViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dogs"/> class.
        /// Dogs ctor.
        /// </summary>
        /// <param name="logic">logic.</param>
        /// <param name="mapper">mapper.</param>
        public Dogs(IOwnerLogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;

            this.vm = new DogListViewModel();
            this.vm.EditedDog = new Models.Dog();

            var dogs = logic.GetAllDogs();
            this.vm.ListOfDog = mapper.Map<IList<Data.Models.Dog>, List<Web.Models.Dog>>(dogs);
        }

        /// <summary>
        /// index.
        /// </summary>
        /// <returns>view.</returns>
        public IActionResult Index()
        {
            this.ViewData["editACtion"] = "AddNew";
            return this.View("DogsIndex", this.vm);
        }

        // GET: Cars/Details/5

        /// <summary>
        /// details.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <returns>view.</returns>
        public IActionResult Details(int id)
        {
            return this.View("DogsDetails", this.GetDogModel(id));
        }

        // GET: Cars/Remove/5

        /// <summary>
        /// remove.
        /// </summary>
        /// <param name="id">dog id.</param>
        /// <returns>view.</returns>
        public IActionResult Remove(int id)
        {
            this.TempData["editResult"] = "Delete FAIL";
            Data.Models.Dog rm = this.logic.GetYourDogByChip(id);
            this.logic.RemoveDog(rm);
            this.TempData["editResult"] = "Delete OK";
            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Cars/Edit/5

        /// <summary>
        /// Edit.
        /// </summary>
        /// <param name="id">id of dog.</param>
        /// <returns>view.</returns>
        public IActionResult Edit(int id)
        {
            this.ViewData["editACtion"] = "Edit";
            this.vm.EditedDog = this.GetDogModel(id);
            return this.View("DogsIndex", this.vm);
        }

        // POST: Cars/Edit + 1 car + editActon

        /// <summary>
        /// edit.
        /// </summary>
        /// <param name="dog">dot to edit.</param>
        /// <param name="editAction">action.</param>
        /// <returns>view.</returns>
        [HttpPost]
        public IActionResult Edit(Models.Dog dog, string editAction)
        {
            if (this.ModelState.IsValid && dog != null)
            {
                this.TempData["editResult"] = "Edit OK";
                if (editAction == "AddNew")
                {
                    Data.Models.Dog d = new Data.Models.Dog() { DogName = dog.DogName, Gender = dog.Gender, OwnerName = dog.OwnerName, Breed = dog.Breed };
                    var idlist = this.logic.GetAllDogs().ToList();
                    int newid = (int)idlist[idlist.Count - 1].ChipNum;
                    d.ChipNum = newid + 1;
                    this.logic.AddDog(d);
                }
                else
                {
                    this.logic.ChangeBreed(dog.ChipNum, dog.Breed);
                    this.logic.ChangeDogName(dog.ChipNum, dog.DogName);
                    this.logic.ChangeOwnerName(dog.ChipNum, dog.OwnerName);
                }

                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                this.ViewData["editAction"] = "Edit";
                this.vm.EditedDog = dog;
                return this.View("CarsIndex", this.vm);
            }
        }

        private Models.Dog GetDogModel(int id)
        {
            Data.Models.Dog oneDog = this.logic.GetYourDogByChip(id);
            return this.mapper.Map<Data.Models.Dog, Models.Dog>(oneDog);
        }
    }
}
