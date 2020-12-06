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
        public static void ChangeingMenuMedal(DirectorLogic doctroLogic)
        {
            var mmenu = new ConsoleMenu()
                .Add(">>CHANGE CATEGORY", () => Methods.ChangeMedalCategory(doctroLogic))
                .Add(">>CHANGE DEGREE", () => Methods.ChangeMedalDegree(doctroLogic))
                .Add(">>BACK TO MEDAL MENU", ConsoleMenu.Close);
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
                .Add(">>ÉRMEK LISTÁZÁSA", () => Methods.ListAllMedal(directotLogic))
                .Add(">>MÓDOSÍTÁSOK", () => this.ChangeingMenuMedal(directotLogic))
                .Add(">>ÚJ MEDÁL KIOSZTÁSA", () => Methods.AddNewMedal(directotLogic, ownerLogic))
                .Add(">>MEDÁL VISSZAVONÁSA", () => Methods.RemoveMedalById(directotLogic))
                .Add(">>A FOKOZATOKBÓL ENNYIT NYERTEK", () => Methods.PrintList(directotLogic.DegreeNumb()))
                .Add(">>A FOKOZATOKBÓL ENNYIT NYERTEK ASYNC", () => Methods.ProcessTaskData(directotLogic.DegreeNumbAsync()))
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
                .Add(">>ÖSSZES ORVOS LISTÁZÁSA", () => Methods.ListAllDoctors(doctorLogic))
                .Add(">>ÖSSZES BEAVATKOZÁS LISTÁZÁSA", () => Methods.ListAllIntervention(doctorLogic))
                .Add(">>BELÉPÉS NÉVVEL", () => this.LogiWithDoctor(doctorLogic, ownerLogic))
                .Add(">>BACK TO MAIN MENU", ConsoleMenu.Close);
            imenu.Show();
        }

        /// <summary>
        /// changing menu of doctor.
        /// </summary>
        /// <param name="doctorLogic">doctorLogic.</param>
        /// <param name="ownerLogic">ownerLogic.</param>
        /// <param name="name">name.</param>
        public static void ChangeingDoctroMenu(DoctorLogic doctorLogic, OwnerLogic ownerLogic, string name)
        {
            var imenu = new ConsoleMenu()
                .Add(">>LEÍRÁS MEGVÁLTOZTATÁSA", () => Methods.ChangeInterventionDescript(doctorLogic, name))
                .Add(">>BEAVATKOZÁS TÖRLÉSE", () => Methods.RemoveInterventionById(doctorLogic, name))
                .Add(">>KUTYA IVARTALANÍTÁSA", () => Methods.Neutering(ownerLogic, doctorLogic))
                .Add(">>TELEFONSZÁM MEGVÁLTOZATÁSA", () => Methods.DoctorPhoneNum(doctorLogic, name))
                .Add(">>BACK TO INTERVENTION MENU", ConsoleMenu.Close);
            imenu.Show();
        }

        /// <summary>
        /// ChangeingMenuDog.
        /// </summary>
        /// <param name="ownerLogic">dogLogic.</param>
        /// <param name="name">name.</param>
        public static void ChangeingMenuDog(OwnerLogic ownerLogic, string name)
        {
            var mmenu = new ConsoleMenu()
                .Add(">>KUTYA ÁTNEVEZÉSE", () => Methods.ChangeDogName(ownerLogic))
                .Add(">>KUTYA ÖRÖKBEFOGADÁSA", () => Methods.AddNewDog(ownerLogic, name))
                .Add(">>KUTYA ÖRÖKBE ADÁSA (TÖRLÉSE)", () => Methods.RemoveDogById(ownerLogic))
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
        public static void LoginOwnerMenu(string name, OwnerLogic ownerLogic)
        {
            var lomenu = new ConsoleMenu()
                .Add(">>SAJÁT KUTYÁID KILISTÁZÁSA", () => Methods.GetYourDogs(ownerLogic, name))
                .Add(">>KUTYÁID KÖZÜL EGY KILISTÁZÁSA", () => Methods.GetDogById(ownerLogic, name))
                .Add(">>KUTYÁID ÉRMEI", () => Methods.PrintList(ownerLogic.DogsMedals(name)))
                .Add(">>KUTYÁID ÉRMEI ASYNC", () => Methods.ProcessTaskData(ownerLogic.DogMedalsAsync(name)))
                .Add(">>KUTYÁID BEAVATKOZÁSAI", () => Methods.PrintList(ownerLogic.DogsInterventions(name)))
                .Add(">>KUTYÁID BEAVATKOZÁSAI ASYNC", () => Methods.ProcessTaskData(ownerLogic.DogInterventionsAsync(name)))
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
                .Add(">>ÖSSZES BEAVATKOZAS AMIT VÉGZETT", () => Methods.AllInterventionByDoctor(doctorLogic, name))
                .Add(">>EGY BEAVATKOZÁSS LISTÁZÁSA", () => Methods.GetInterventionById(doctorLogic, name))
                .Add(">>MÓDOSÍTÁSOK", () => this.ChangeingDoctroMenu(doctorLogic, ownerLogic, name))
                .Add(">>BACK TO MAIN MENU", ConsoleMenu.Close);
            imenu.Show();
        }
    }
}
