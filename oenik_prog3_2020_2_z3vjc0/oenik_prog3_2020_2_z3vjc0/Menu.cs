// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/*namespace KutyaVerseny.Program
{
    using ConsoleTools;
    using KutyaVerseny.Logic;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KutyaVerseny.Program;
    public class Menuk
    {
        DogLogic dogLogic;
        MedalLogic medalLogic;
        InterventionLogic intlog;

        public Menuk(DogLogic dogLogic, MedalLogic medalLogic, InterventionLogic intlog)
        {
            this.dogLogic = dogLogic;
            this.medalLogic = medalLogic;
            this.intlog = intlog;
        }

        private void DogMenu(DogLogic dogLogic)
        {
            var dmenu = new ConsoleMenu()
                .Add(">>LIST ALL DOG", () => ListAllDog(dogLogic))
                .Add(">>BACK TO MAIN MENU", ConsoleMenu.Close);
            dmenu.Show();
        }

        private static void MedalMenu(MedalLogic medalLogic)
        {
            var mmenu = new ConsoleMenu()
                .Add(">>LIST ALL MEDAL", () => ListAllMedal(medalLogic))
                .Add(">>CHANGING MENU", () => ChangeingMenuMedal(medalLogic))
                .Add(">>EXIT", ConsoleMenu.Close);
            mmenu.Show();
        }

        private static void InterventionMenu(InterventionLogic intlog)
        {
            var imenu = new ConsoleMenu()
                .Add(">>LIST ALL MEDAL", () => ListAllIntervention(intlog))
                .Add(">>EXIT", ConsoleMenu.Close);
            imenu.Show();
        }

        public static void ChangeingMenuMedal(MedalLogic medalLogic)
        {
            var mmenu = new ConsoleMenu()
                .Add(">>CHANGE CATEGORY", () => ChangeMedalCategory(medalLogic))
                .Add(">>EXIT", ConsoleMenu.Close);
            mmenu.Show();
        }

    }
}
*/
