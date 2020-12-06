// <copyright file="Menu.cs" company="Z3VJC0">
// Copyright (c) Z3VJC0. All rights reserved.
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
        private readonly Methods met = new Methods();

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
        }

        /// <summary>
        /// changing medal menu.
        /// </summary>
        /// <param name="doctroLogic">medallogic.</param>
        public void ChangeingMenuMedal(DirectorLogic doctroLogic)
        {
            var mmenu = new ConsoleMenu()
                .Add(">>KATEGÓRIA MÓDOSÍTÁSA", () => this.met.ChangeMedalCategory(doctroLogic))
                .Add(">>FOKOZAT MÓDOSÍTÁSA", () => this.met.ChangeMedalDegree(doctroLogic))
                .Add(">>VISSZA A FŐ MENÜBE", ConsoleMenu.Close);
            mmenu.Show();
        }

        /// <summary>
        /// owner menu.
        /// </summary>
        /// <param name="ownerLogic">ownerLogic.</param>
        public void OwnerMenu(OwnerLogic ownerLogic)
        {
            var dmenu = new ConsoleMenu()
                .Add(">>ÖSSZES GAZDA KILISTÁZÁSA", () => Methods.ListAllOwner(ownerLogic))
                .Add(">>ÖSSZES KUTYA KIÍRÁSA", () => Methods.ListAllDog(ownerLogic))
                .Add(">>BELÉPÉS GAZDA NÉVVEL", () => this.LoginWithOwner(ownerLogic))
                .Add(">>VISSZA A FŐ MENÜBE", ConsoleMenu.Close);
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
                .Add(">>ÉRMEK LISTÁZÁSA", () => Methods.ListAllMedal(directotLogic))
                .Add(">>MÓDOSÍTÁSOK", () => this.ChangeingMenuMedal(directotLogic))
                .Add(">>ÚJ MEDÁL KIOSZTÁSA", () => this.met.AddNewMedal(directotLogic, ownerLogic))
                .Add(">>MEDÁL VISSZAVONÁSA", () => this.met.RemoveMedalById(directotLogic))
                .Add(">>A FOKOZATOKBÓL ENNYIT NYERTEK", () => Methods.PrintList(directotLogic.DegreeNumb()))
                .Add(">>A FOKOZATOKBÓL ENNYIT NYERTEK ASYNC", () => Methods.ProcessTaskData(directotLogic.DegreeNumbAsync()))
                .Add(">>VISSZA A FŐ MENÜBE", ConsoleMenu.Close);
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
                .Add(">>ÖSSZES ORVOS LISTÁZÁSA", () => Methods.ListAllDoctors(doctorLogic))
                .Add(">>ÖSSZES BEAVATKOZÁS LISTÁZÁSA", () => Methods.ListAllIntervention(doctorLogic))
                .Add(">>BELÉPÉS NÉVVEL", () => this.LogiWithDoctor(doctorLogic, ownerLogic))
                .Add(">>VISSZA A FŐ MENÜBE", ConsoleMenu.Close);
            imenu.Show();
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
                .Add(">>TELEFONSZÁM MEGVÁLTOZATÁSA", () => Methods.DoctorPhoneNum(doctorLogic, name))
                .Add(">>VISSZA", ConsoleMenu.Close);
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
                .Add(">>KUTYA ÖRÖKBEFOGADÁSA", () => Methods.AddNewDog(ownerLogic, name))
                .Add(">>KUTYA ÖRÖKBE ADÁSA (TÖRLÉSE)", () => this.met.RemoveDogById(ownerLogic))
                .Add(">>VISSZA", ConsoleMenu.Close);
            mmenu.Show();
        }

        /// <summary>
        /// login method.
        /// </summary>
        /// <param name="ownerLogic">ownerLogic.</param>
        public void LoginWithOwner(OwnerLogic ownerLogic)
        {
            Methods.PrintMessage("KÉREM A GAZDA NEVÉT AMIVEL BE AKAR LÉPNI -> ");
            string name = new Investigator<Dog>().CorrectOwnerLogin(ownerLogic);
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
                .Add(">>SAJÁT KUTYÁID KILISTÁZÁSA", () => Methods.GetYourDogs(ownerLogic, name))
                .Add(">>KUTYÁID KÖZÜL EGY KILISTÁZÁSA", () => this.met.GetDogById(ownerLogic, name))
                .Add(">>KUTYÁID ÉRMEI", () => Methods.PrintList(ownerLogic.DogsMedals(name)))
                .Add(">>KUTYÁID ÉRMEI ASYNC", () => Methods.ProcessTaskData(ownerLogic.DogMedalsAsync(name)))
                .Add(">>KUTYÁID BEAVATKOZÁSAI", () => Methods.PrintList(ownerLogic.DogsInterventions(name)))
                .Add(">>KUTYÁID BEAVATKOZÁSAI ASYNC", () => Methods.ProcessTaskData(ownerLogic.DogInterventionsAsync(name)))
                .Add(">>MÓDOSÍTÁSOK", () => this.ChangeingMenuDog(ownerLogic, name))
                .Add(">>VISSZA A FŐ MENÜBE", ConsoleMenu.Close);
            lomenu.Show();
        }

        /// <summary>
        /// doctor login.
        /// </summary>
        /// <param name="doctorLogic">doctorLogic.</param>
        /// <param name="ownerLogic">ownerLogic.</param>
        public void LogiWithDoctor(DoctorLogic doctorLogic, OwnerLogic ownerLogic)
        {
            Methods.PrintMessage("KÉREM AZ ORVOS NEVÉT -> ");
            string name = new Investigator<Intervention>().CorrectDoctorLogin(doctorLogic);
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
                .Add(">>ÖSSZES BEAVATKOZAS AMIT VÉGZETT", () => Methods.AllInterventionByDoctor(doctorLogic, name))
                .Add(">>EGY BEAVATKOZÁSS LISTÁZÁSA", () => this.met.GetInterventionById(doctorLogic, name))
                .Add(">>MÓDOSÍTÁSOK", () => this.ChangeingDoctroMenu(doctorLogic, ownerLogic, name))
                .Add(">>VISSZA A FŐ MENÜBE", ConsoleMenu.Close);
            imenu.Show();
        }
    }
}
