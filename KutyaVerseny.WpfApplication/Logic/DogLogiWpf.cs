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
    using GalaSoft.MvvmLight.Messaging;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Logic;
    using KutyaVerseny.Repository;
    using KutyaVerseny.WpfApplication.Data;

    /// <summary>
    /// doglogic.
    /// </summary>
    public class DogLogiWpf
    {
        private IEditorService editor;
        private OwnerLogic ownerLogic = null;
        private IMessenger messengerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DogLogiWpf"/> class.
        /// </summary>
        /// <param name="messengerService">vmi.</param>
        public DogLogiWpf(IMessenger messengerService, IEditorService editors)
        {
            Db ctx = new Db();
            DogRepository dogRepo = new DogRepository(ctx);
            MedalRepository medalRepo = new MedalRepository(ctx);
            InterventionRepository intRepo = new InterventionRepository(ctx);
            OwnerLogic ownerLogic = new OwnerLogic(dogRepo, intRepo, medalRepo);
            this.messengerService = messengerService;
            this.editor = editors;
        }

        public DogLogiWpf()
        {
            Db ctx = new Db();
            DogRepository dogRepo = new DogRepository(ctx);
            MedalRepository medalRepo = new MedalRepository(ctx);
            InterventionRepository intRepo = new InterventionRepository(ctx);
            this.ownerLogic = new OwnerLogic(dogRepo, intRepo, medalRepo);
        }

        /// <summary>
        /// add dog method.
        /// </summary>
        /// <param name="list">add a dog.</param>
        public void AddDog(IList<DogWpf> list)
        {
            DogWpf newDog = new DogWpf();

            if (this.editor.EditPlayer(newDog) == true)
            {
                list.Add(newDog);
                Dog entity = newDog.ConvertToEntity();
                this.ownerLogic.AddDog(entity);
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
        public IEnumerable<DogWpf> GetAllDog()
        {
            var retEntity = this.ownerLogic.GetAllDogs();
            return retEntity.Select((dog) => new DogWpf(dog));
        }

        /// <summary>
        /// delete a dog.
        /// </summary>
        /// <param name="list">list.</param>
        /// <param name="dog">dog.</param>
        public void DelDog(IList<DogWpf> list, DogWpf dog)
        {
            if (dog != null && list.Remove(dog))
            {
                Dog d = dog.ConvertToEntity();
                this.ownerLogic.RemoveDog(d);
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
                this.messengerService.Send("MODIFY OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("MODIFY CANCEL", "LogciResult");
            }
        }
    }
}
