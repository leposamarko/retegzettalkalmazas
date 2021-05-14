// <copyright file="DogsApiController.cs" company="PlaceholderCompany">
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
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// dogapi.
    /// </summary>
    public class DogsApiController : Controller
    {
        private readonly IOwnerLogic logic;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DogsApiController"/> class.
        /// ctro.
        /// </summary>
        /// <param name="logic">logic.</param>
        /// <param name="mapper">mapper.</param>
        public DogsApiController(IOwnerLogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;
        }

        /// <summary>
        /// get all dog.
        /// </summary>
        /// <returns>list of dogs.</returns>
        [HttpGet] // GET DogsApi/all
        [ActionName("all")]
        public IEnumerable<Models.Dog> GetAll()
        {
            var dogs = this.logic.GetAllDogs();
            return this.mapper.Map<IList<Data.Models.Dog>, List<Models.Dog>>(dogs);
        }

        /// <summary>
        /// del one dog.
        /// </summary>
        /// <param name="id">id of dog.</param>
        /// <returns>apiresutl.</returns>
        [HttpGet]// Get DogApi/del/5
        [ActionName("del")]
        public ApiResult DelOneDog(int id)
        {
            Data.Models.Dog rm = this.logic.GetYourDogByChip(id);
            this.logic.RemoveDog(rm);
            return new ApiResult() { OpertaionResult = true };
        }

        /// <summary>
        /// add dog.
        /// </summary>
        /// <param name="dog">dog to add.</param>
        /// <returns>apiresult.</returns>
        [HttpPost]// POST DogsApi/ad + post 1 dog
        [ActionName("add")]
        public ApiResult AddOneDog(Models.Dog dog)
        {
            bool succes = true;
            if (dog != null)
            {
                try
                {
                    Data.Models.Dog d = new Data.Models.Dog() { DogName = dog.DogName, Gender = dog.Gender, OwnerName = dog.OwnerName, Breed = dog.Breed };
                    var idlist = this.logic.GetAllDogs().ToList();
                    int newid = (int)idlist[idlist.Count - 1].ChipNum;
                    d.ChipNum = newid + 1;
                    this.logic.AddDog(d);
                }
                catch (ArgumentException)
                {
                    succes = false;
                }
            }

            return new ApiResult() { OpertaionResult = succes };
        }

        /// <summary>
        /// modify dog.
        /// </summary>
        /// <param name="dog">dog to mody.</param>
        /// <returns>apiresult.</returns>
        [HttpPost]// POST DogsApi/mod + POST 1 car
        [ActionName("mod")]
        public ApiResult ModOneDog(Models.Dog dog)
        {
            if (dog != null)
            {
                this.logic.ChangeDogName(dog.ChipNum, dog.DogName);
                this.logic.ChangeOwnerName(dog.ChipNum, dog.OwnerName);
                this.logic.ChangeBreed(dog.ChipNum, dog.Breed);
            }

            return new ApiResult() { OpertaionResult = true };
        }

        /*
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// apiresutl.
        /// </summary>
        public class ApiResult
        {
            /// <summary>
            /// Gets or sets a value indicating whether result.
            /// </summary>
            public bool OpertaionResult { get; set; }
        }
        */
    }
}
