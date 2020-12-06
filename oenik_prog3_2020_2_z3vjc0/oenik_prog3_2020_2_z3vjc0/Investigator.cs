// <copyright file="Investigator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Program
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Logic;

    /// <summary>
    /// id investigator class.
    /// </summary>
    /// <typeparam name="T">dog, medal or Intervention.</typeparam>
    public class Investigator<T>
        where T : class
    {
        /// <summary>
        /// medtod of the correct id.
        /// </summary>
        /// <param name="m">list of the medal, dog or intervention.</param>
        /// <returns>id.</returns>
        public int IdNumber(List<T> m)
        {
            int id = 0;
            if (m != null)
            {
                while (true)
                {
                    Console.WriteLine("ID range: 1, " + m.Count + " ->");

                    id = int.Parse(Console.ReadLine(), null);
                    if (id > 0 && id <= m.Count)
                    {
                        break;
                    }
                    else
                    {
                        Methods.PrintMessage("THE ID NUMBER IS INVALID");
                    }
                }
            }
            return id;
        }

        /// <summary>
        /// method of the corect owner name login.
        /// </summary>
        /// <param name="ownerLogic">ownerLogic.</param>
        /// <returns>name of owner.</returns>
        public string CorrectOwnerLogin(OwnerLogic ownerLogic)
        {
            string name = string.Empty;
            if (ownerLogic != null)
            {
                while (true)
                {
                    name = Console.ReadLine();
                    if (ownerLogic.AllOwner().Contains(name))
                    {
                        Methods.PrintMessage("Helyes belépési név!");
                        break;
                    }
                    else
                    {
                        Methods.PrintMessage("Nincs ilyen belépési név, adj meg egy újat -> ");
                    }
                }
            }

            return name;
        }

        /// <summary>
        /// method for the correct doctro login.
        /// </summary>
        /// <param name="doctorLogic">doctorLogic.</param>
        /// <returns>name of doctro.</returns>
        public string CorrectDoctorLogin(DoctorLogic doctorLogic)
        {
            string name = string.Empty;
            if (doctorLogic != null)
            {
                while (true)
                {
                    name = Console.ReadLine();
                    if (doctorLogic.AllDoctor().Contains(name))
                    {
                        Methods.PrintMessage("Helyes belépési név!");
                        break;
                    }
                    else
                    {
                        Methods.PrintMessage("Nincs ilyen belépési név, adj meg egy újat -> ");
                    }
                }
            }

            return name;
        }
    }
}
