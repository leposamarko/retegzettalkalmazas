// <copyright file="Investigator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Program
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KutyaVerseny.Data.Models;

    /// <summary>
    /// id investigator class.
    /// </summary>
    /// <typeparam name="T">dog, medal or Intervention.</typeparam>
    public static class Investigator<T>
        where T : class
    {
        /// <summary>
        /// medtod of the correct id.
        /// </summary>
        /// <param name="m">list of the medal, dog or intervention.</param>
        /// <returns>id.</returns>
        #pragma warning disable CA1000 // Do not declare static members on generic types
        public static int IdNumber(List<T> m)
        #pragma warning restore CA1000 // Do not declare static members on generic types
        {
            #pragma warning disable CA1062 // Validate arguments of public methods
            Type t = m.GetType();
            #pragma warning restore CA1062 // Validate arguments of public methods
            int id;
            while (true)
            {
                Console.WriteLine("ID range: 1, " + m.Count + " ->");
                #pragma warning disable CA1305 // Specify IFormatProvider
                id = int.Parse(Console.ReadLine());
                if (id > 0 && id <= m.Count)
                {
                    break;
                }
                else
                {
                    #pragma warning disable CA1303 // Do not pass literals as localized parameters
                    Console.WriteLine("THE ID NUMBER IS INVALID");
                    #pragma warning restore CA1303 // Do not pass literals as localized parameters
                }
            }

            return id;
        }

        //internal static int IdNumber(List<Intervention> lists)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
