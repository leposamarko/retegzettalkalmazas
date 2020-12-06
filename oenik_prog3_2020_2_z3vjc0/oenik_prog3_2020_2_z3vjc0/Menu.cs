// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Program
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ConsoleTools;
    using KutyaVerseny.Data.Models;
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
        /// owner menu.
        /// </summary>
        /// <param name="ownerLogic">ownerLogic.</param>
        public void OwnerMenu(OwnerLogic ownerLogic)
        {
            var dmenu = new ConsoleMenu()
                .Add(">>ÖSSZES GAZDA KILISTÁZÁSA", () => this.met.ListAllOwner(ownerLogic))
                .Add(">>ÖSSZES KUTYA KIÍRÁSA", () => this.met.ListAllDog(ownerLogic))
                .Add(">>BELÉPÉS GAZDA NÉVVEL", () => this.LoginWithOwner(ownerLogic))
                .Add(">>BACK TO MAIN MENU", ConsoleMenu.Close);
            dmenu.Show();
        }

        /// <summary>
        /// medal menu.
        /// </summary>
        /// <param name="directotLogic">medalLogic.</param>
        /// <param name="ownerLogic">dogLogic.</param>
        public void DirectorMenu(DirectorLogic directotLogic, OwnerLogic ownerLogic)
        {
            var dmenu = new ConsoleMenu()
                .Add(">>ÉRMEK LISTÁZÁSA", () => this.met.ListAllMedal(directotLogic))
                .Add(">>MÓDOSÍTÁSOK", () => this.ChangeingMenuMedal(directotLogic))
                .Add(">>ÚJ MEDÁL KIOSZTÁSA", () => this.met.AddNewMedal(directotLogic, ownerLogic))
                .Add(">>MEDÁL VISSZAVONÁSA", () => this.met.RemoveMedalById(directotLogic))
                .Add(">>A FOKOZATOKBÓL ENNYIT NYERTEK", () => this.met.PrintList(directotLogic.DegreeNumb()))
                .Add(">>A FOKOZATOKBÓL ENNYIT NYERTEK ASYNC", () => this.met.ProcessTaskData(directotLogic.DegreeNumbAsync()))
                .Add(">>BACK TO MAIN MENU", ConsoleMenu.Close);
            dmenu.Show();
        }

        /// <summary>
        /// intervention menu.
        /// </summary>
        /// <param name="doctorLogic">intlog.</param>
        /// <param name="ownerLogic">dogLogic.</param>
        public void DoctorMenu(DoctorLogic doctorLogic, OwnerLogic ownerLogic)
        {
            var imenu = new ConsoleMenu()
                .Add(">>ÖSSZES ORVOS LISTÁZÁSA", () => this.met.ListAllDoctors(doctorLogic))
                .Add(">>ÖSSZES BEAVATKOZÁS LISTÁZÁSA", () => this.met.ListAllIntervention(doctorLogic))
                .Add(">>BELÉPÉS NÉVVEL", () => this.LogiWithDoctor(doctorLogic, ownerLogic))
                .Add(">>BACK TO MAIN MENU", ConsoleMenu.Close);
            imenu.Show();
        }

        /// <summary>
        /// changing medal menu.
        /// </summary>
        /// <param name="doctroLogic">medallogic.</param>
        public void ChangeingMenuMedal(DirectorLogic doctroLogic)
        {
            var mmenu = new ConsoleMenu()
                .Add(">>CHANGE CATEGORY", () => this.met.ChangeMedalCategory(doctroLogic))
                .Add(">>CHANGE DEGREE", () => this.met.ChangeMedalDegree(doctroLogic))
                .Add(">>BACK TO MEDAL MENU", ConsoleMenu.Close);
            mmenu.Show();
        }

        /// <summary>
        /// changing menu of doctor.
        /// </summary>
        /// <param name="doctorLogic">doctorLogic.</param>
        /// <param name="ownerLogic">ownerLogic.</param>
        /// <param name="name">name.</param>
        public void ChangeingDoctroMenu(DoctorLogic doctorLogic, OwnerLogic ownerLogic, string name)
        {
            var imenu = new ConsoleMenu()
                .Add(">>LEÍRÁS MEGVÁLTOZTATÁSA", () => this.met.ChangeInterventionDescript(doctorLogic, name))
                .Add(">>BEAVATKOZÁS TÖRLÉSE", () => this.met.RemoveInterventionById(doctorLogic, name))
                .Add(">>KUTYA IVARTALANÍTÁSA", () => this.met.Neutering(ownerLogic, doctorLogic))
                .Add(">>TELEFONSZÁM MEGVÁLTOZATÁSA", () => this.met.DoctorPhoneNum(doctorLogic, name))
                .Add(">>BACK TO INTERVENTION MENU", ConsoleMenu.Close);
            imenu.Show();
        }

        /// <summary>
        /// ChangeingMenuDog.
        /// </summary>
        /// <param name="ownerLogic">dogLogic.</param>
        /// <param name="name">name.</param>
        public void ChangeingMenuDog(OwnerLogic ownerLogic, string name)
        {
            var mmenu = new ConsoleMenu()
                .Add(">>KUTYA ÁTNEVEZÉSE", () => this.met.ChangeDogName(ownerLogic))
                .Add(">>KUTYA ÖRÖKBEFOGADÁSA", () => this.met.AddNewDog(ownerLogic, name))
                .Add(">>KUTYA ÖRÖKBE ADÁSA (TÖRLÉSE)", () => this.met.RemoveDogById(ownerLogic))
                .Add(">>BACK TO DOG MENU", ConsoleMenu.Close);
            mmenu.Show();
        }

        /// <summary>
        /// login method.
        /// </summary>
        /// <param name="ownerLogic">ownerLogic.</param>
        public void LoginWithOwner(OwnerLogic ownerLogic)
        {
            Console.WriteLine("KÉREM A GAZDA NEVÉT AMIVEL BE AKAR LÉPNI -> ");
            string name = Investigator<Dog>.CorrectOwnerLogin(ownerLogic);
            this.LoginOwnerMenu(name, ownerLogic);
        }

        /// <summary>
        /// login owner menu.
        /// </summary>
        /// <param name="name">name of owner.</param>
        /// <param name="ownerLogic">ownerLogic.</param>
        public void LoginOwnerMenu(string name, OwnerLogic ownerLogic)
        {
            var lomenu = new ConsoleMenu()
                .Add(">>SAJÁT KUTYÁID KILISTÁZÁSA", () => this.met.GetYourDogs(ownerLogic, name))
                .Add(">>KUTYÁID KÖZÜL EGY KILISTÁZÁSA", () => this.met.GetDogById(ownerLogic, name))
                .Add(">>KUTYÁID ÉRMEI", () => this.met.PrintList(ownerLogic.DogsMedals(name)))
                .Add(">>KUTYÁID ÉRMEI ASYNC", () => this.met.ProcessTaskData(ownerLogic.DogMedalsAsync(name)))
                .Add(">>KUTYÁID BEAVATKOZÁSAI", () => this.met.PrintList(ownerLogic.DogsInterventions(name)))
                .Add(">>KUTYÁID BEAVATKOZÁSAI ASYNC", () => this.met.ProcessTaskData(ownerLogic.DogInterventionsAsync(name)))
                .Add(">>MÓDOSÍTÁSOK", () => this.ChangeingMenuDog(ownerLogic, name))
                .Add(">>BACK TO MAIN MENU", ConsoleMenu.Close);
            lomenu.Show();
        }

        /// <summary>
        /// doctor login.
        /// </summary>
        /// <param name="doctorLogic">doctorLogic.</param>
        /// <param name="ownerLogic">ownerLogic.</param>
        public void LogiWithDoctor(DoctorLogic doctorLogic, OwnerLogic ownerLogic)
        {
            Console.WriteLine("KÉREM AZ ORVOS NEVÉT -> ");
            string name = Investigator<Intervention>.CorrectDoctorLogin(doctorLogic);
            this.LoginDoctroMenu(doctorLogic, ownerLogic, name);
        }

        /// <summary>
        /// login doctormenu.
        /// </summary>
        /// <param name="doctorLogic">doctorLogic.</param>
        /// <param name="ownerLogic">ownerLogic.</param>
        /// <param name="name">doctor name.</param>
        public void LoginDoctroMenu(DoctorLogic doctorLogic, OwnerLogic ownerLogic, string name)
        {
            var imenu = new ConsoleMenu()
                .Add(">>ÖSSZES BEAVATKOZAS AMIT VÉGZETT", () => this.met.AllInterventionByDoctor(doctorLogic, name))
                .Add(">>EGY BEAVATKOZÁSS LISTÁZÁSA", () => this.met.GetInterventionById(doctorLogic, name))
                .Add(">>MÓDOSÍTÁSOK", () => this.ChangeingDoctroMenu(doctorLogic, ownerLogic, name))
                .Add(">>BACK TO MAIN MENU", ConsoleMenu.Close);
            imenu.Show();
        }
    }
}
