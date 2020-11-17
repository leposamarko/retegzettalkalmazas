// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Program
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ConsoleTools;
    using KutyaVerseny.Logic;

    /// <summary>
    /// menu class.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
        }

        private readonly Methods met = new Methods();

        /// <summary>
        /// dogmenu.
        /// </summary>
        /// <param name="dogLogic">doglogic.</param>
        public void DogMenu(DogLogic dogLogic)
        {
            var dmenu = new ConsoleMenu()
                .Add(">>LIST ALL DOG", () => this.met.ListAllDog(dogLogic))
                .Add(">>CHANGING MENU", () => this.ChangeingMenuDog(dogLogic))
                .Add(">>ADD A NEW MEDAL", () => this.met.AddNewDog(dogLogic))
                .Add(">>LIST A MEDAL FROM ID", () => this.met.GetDogById(dogLogic))
                .Add(">>REMOVE A MEDAL BY ID", () => this.met.RemoveDogById(dogLogic))
                .Add(">>BACK TO MAIN MENU", ConsoleMenu.Close);
            dmenu.Show();
        }

        /// <summary>
        /// changing medal menu.
        /// </summary>
        /// <param name="medalLogic">medallogic.</param>
        public void ChangeingMenuMedal(MedalLogic medalLogic)
        {
            var mmenu = new ConsoleMenu()
                .Add(">>CHANGE CATEGORY", () => this.met.ChangeMedalCategory(medalLogic))
                .Add(">>CHANGE DEGREE", () => this.met.ChangeMedalDegree(medalLogic))
                .Add(">>BACK TO MEDAL MENU", ConsoleMenu.Close);
            mmenu.Show();
        }

        /// <summary>
        /// medal menu.
        /// </summary>
        /// <param name="medalLogic">medalLogic.</param>
        /// <param name="dogLogic">dogLogic.</param>
        public void MedalMenu(MedalLogic medalLogic, DogLogic dogLogic)
        {
            var mmenu = new ConsoleMenu()
                .Add(">>LIST ALL MEDAL", () => this.met.ListAllMedal(medalLogic))
                .Add(">>CHANGING MENU", () => this.ChangeingMenuMedal(medalLogic))
                .Add(">>ADD A NEW MEDAL", () => this.met.AddNewMedal(medalLogic, dogLogic))
                .Add(">>LIST A MEDAL FROM ID", () => this.met.GetMedalById(medalLogic))
                .Add(">>REMOVE A MEDAL BY ID", () => this.met.RemoveMedalById(medalLogic))
                .Add(">>BACK TO MAIN MENU", ConsoleMenu.Close);
            mmenu.Show();
        }

        /// <summary>
        /// intervention menu.
        /// </summary>
        /// <param name="intlog">intlog.</param>
        /// <param name="dogLogic">dogLogic.</param>
        public void InterventionMenu(InterventionLogic intlog, DogLogic dogLogic)
        {
            var imenu = new ConsoleMenu()
                .Add(">>LIST ALL MEDAL", () => this.met.ListAllIntervention(intlog))
                .Add(">>CHANGING MENU", () => this.ChangeingIntervention(intlog))
                .Add(">>ADD A NEW INTERVENTION", () => this.met.AddNewIntervention(intlog, dogLogic))
                .Add(">>LIST AN INTERVENTION FROM ID", () => this.met.GetInterventionById(intlog))
                .Add(">>REMOVE A INTERVENTION BY ID", () => this.met.RemoveInterventionById(intlog))
                .Add(">>BACK TO MAIN MENU", ConsoleMenu.Close);
            imenu.Show();
        }

        /// <summary>
        /// Changeing Intervention menu.
        /// </summary>
        /// <param name="intLog">intLog.</param>
        public void ChangeingIntervention(InterventionLogic intLog)
        {
            var imenu = new ConsoleMenu()
                .Add(">>CHANGE PHONE NUMBER", () => this.met.ChangeInterventionDescript(intLog))
                .Add(">>CHANGE DOCTOR NAMEN", () => this.met.ChangeDocName(intLog))
                .Add(">>BACK TO INTERVENTION MENU", ConsoleMenu.Close);
        }

        /// <summary>
        /// ChangeingMenuDog.
        /// </summary>
        /// <param name="dogLogic">dogLogic.</param>
        public void ChangeingMenuDog(DogLogic dogLogic)
        {
            var mmenu = new ConsoleMenu()
                .Add(">>CHANGE DOG NAME", () => this.met.ChangeDogName(dogLogic))
                .Add(">>CHANGE DOG OWNER'S NAME", () => this.met.ChangeOwnerName(dogLogic))
                .Add(">>BACK TO DOG MENU", ConsoleMenu.Close);
            mmenu.Show();
        }
    }
}
