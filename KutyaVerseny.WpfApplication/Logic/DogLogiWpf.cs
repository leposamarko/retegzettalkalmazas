// <copyright file="DogLogiWpf.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.WpfApplication.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Messaging;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Logic;
    using KutyaVerseny.Repository;
    using KutyaVerseny.WpfApplication.Data;

    /// <summary>
    /// doglogic.
    /// </summary>
    public class DogLogiWpf : IDogLogiWpf
    {
        private IEditorService editor;
        private IOwnerLogic ownerLogic;
        private IMessenger messengerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DogLogiWpf"/> class.
        /// </summary>
        /// <param name="messengerService">vmi.</param>
        /// <param name="editors">editors.</param>
        public DogLogiWpf(IMessenger messengerService, IEditorService editors)
        {
            this.ownerLogic = new OwnerLogic(Factory.DogRepo, Factory.IntRepo, Factory.MedRepo);
            this.messengerService = messengerService;
            this.editor = editors;
        }

        /// <summary>
        /// Add dog method.
        /// </summary>
        /// <param name="list">list of dog.</param>
        public void AddDog(IList<DogWpf> list)
        {
            DogWpf newDog = new DogWpf();

            if (this.editor.EditPlayer(newDog) == true && list != null)
            {
                var idlist = this.ownerLogic.GetAllDogs().ToList();
                int newid = (int)idlist[idlist.Count - 1].ChipNum;
                newDog.ChipNum = newid + 1;
                list.Add(newDog);
                this.ownerLogic.AddDog(newDog.ConvertToEntity());
                this.messengerService.Send("ADD OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("ADD CANCEL", "LogicResult");
            }
        }

        /// <summary>
        /// getallmethod.
        /// </summary>
        /// <returns>alldogs.</returns>
        public IList<DogWpf> GetAllDog()
        {
            if (this.ownerLogic != null)
            {
                IList<DogWpf> result = new List<DogWpf>();
                var retEntity = this.ownerLogic.GetAllDogs();
                foreach (var item in retEntity)
                {
                    DogWpf d = new DogWpf();
                    d.ChipNum = item.ChipNum;
                    d.DogName = item.DogName;
                    d.Gender = item.Gender;
                    d.OwnerName = item.OwnerName;
                    d.Breed = item.Breed;
                    result.Add(d);
                }

                return result;
            }
            else
            {
                this.messengerService.Send("SOMETHING WRONG", "LogicResult");
                return null;
            }
        }

        /// <summary>
        /// delete a dog.
        /// </summary>
        /// <param name="list">list.</param>
        /// <param name="dog">dog.</param>
        public void DelDog(IList<DogWpf> list, DogWpf dog)
        {
            if (dog != null && list != null && list.Remove(dog))
            {
                int id = (int)dog.ChipNum;
                Dog rm = this.ownerLogic.GetYourDogByChip(id);
                this.ownerLogic.RemoveDog(rm);
                this.messengerService.Send("DELETE OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("DELETE FAILD", "LogicResult");
            }
        }

        /// <summary>
        /// modify dog.
        /// </summary>
        /// <param name="dogToModi">dot to mody.</param>
        public void ModyDog(DogWpf dogToModi)
        {
            if (dogToModi == null)
            {
                this.messengerService.Send("EDIT FAILED", "LogicResult");
                return;
            }

            DogWpf clone = new DogWpf();
            clone.CopyFrom(dogToModi);
            if (this.editor.EditPlayer(clone) == true)
            {
                dogToModi.CopyFrom(clone);

                this.ownerLogic.ChangeDogName((int)dogToModi.ChipNum, dogToModi.DogName);
                this.ownerLogic.ChangeOwnerName((int)dogToModi.ChipNum, dogToModi.OwnerName);
                this.ownerLogic.ChangeBreed((int)dogToModi.ChipNum, dogToModi.Breed);
                this.messengerService.Send("MODIFY OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("MODIFY CANCEL", "LogciResult");
            }
        }
    }
}