// <copyright file="Methods.cs" company="Z3VJC0">
// Copyright (c) Z3VJC0. All rights reserved.
// </copyright>

namespace KutyaVerseny.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ConsoleTools;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Logic;

    /// <summary>
    /// methods class what u can use from the menu.
    /// </summary>
    public class Methods
    {
        private Investigator<Medal> invesmedal = new Investigator<Medal>();
        private Investigator<Dog> invesdog = new Investigator<Dog>();
        private Investigator<Intervention> invesinters = new Investigator<Intervention>();

        /// <summary>
        /// print messege out.
        /// </summary>
        /// <param name="msg">messege.</param>
        public static void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// get your dogs.
        /// </summary>
        /// <param name="ownerLogic">ownerLogic.</param>
        /// <param name="name">name of owner.</param>
        public static void GetYourDogs(OwnerLogic ownerLogic, string name)
        {
            if (ownerLogic != null)
            {
                foreach (var item in ownerLogic.GetYourDogs(name))
                {
                    Console.WriteLine(item.ToString());
                }

                Console.ReadLine();
            }
        }

        /// <summary>
        /// doctor number change.
        /// </summary>
        /// <param name="doctorLogic">doctorLogic.</param>
        /// <param name="name">name.</param>
        public static void DoctorPhoneNum(DoctorLogic doctorLogic, string name)
        {
            if (doctorLogic != null)
            {
                PrintMessage("KÉREM AZ ÚJ TELEFONSZÁMOT -> ");
                int num = int.Parse(Console.ReadLine(), null);
                foreach (var item in doctorLogic.GetAllIntervention().ToList())
                {
                    if (item.Doctor == name)
                    {
                        int id = (int)item.InterventionId;
                        doctorLogic.ChangeInterventionDocPhone(id, num);
                    }
                }
            }
        }

        /// <summary>
        /// number of the degrees.
        /// </summary>
        /// <param name="directorLogic">directorLogic.</param>
        public static void DegreeNumb(DirectorLogic directorLogic)
        {
            if (directorLogic != null)
            {
                directorLogic.DegreeNumb();
            }
        }

        /// <summary>
        /// print out the non croud methods resutl.
        /// </summary>
        /// <param name="input">list string.</param>
        public static void PrintList(List<string> input)
        {
            if (input != null)
            {
                foreach (var item in input)
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// print out the task non croud.
        /// </summary>
        /// <typeparam name="T">generc.</typeparam>
        /// <param name="task">tack.</param>
        public static void ProcessTaskData<T>(Task<T> task)
        {
            Task<T> call = task;
            if (call != null)
            {
                call.Wait();
                T result = call.Result;
                foreach (var item in result as List<string>)
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// get the owner's dog's medal's.
        /// </summary>
        /// <param name="ownerLogic">ownerLogic.</param>
        /// <param name="name">name.</param>
        public static void DogsMedal(OwnerLogic ownerLogic, string name)
        {
            if (ownerLogic != null)
            {
                ownerLogic.DogsMedals(name);
            }
        }

        /// <summary>
        /// get the owner's do's intervention's.
        /// </summary>
        /// <param name="ownerLogic">ownerLogic.</param>
        /// <param name="name">name.</param>
        public static void DogsInterventions(OwnerLogic ownerLogic, string name)
        {
            if (ownerLogic != null)
            {
                ownerLogic.DogsInterventions(name);
            }
        }

        /// <summary>
        /// list all doctors.
        /// </summary>
        /// <param name="doctorLogic">doctorLogic.</param>
        public static void ListAllDoctors(DoctorLogic doctorLogic)
        {
            if (doctorLogic != null)
            {
                List<string> owners = doctorLogic.AllDoctor();
                foreach (var item in owners)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();
            }
        }

        /// <summary>
        /// give the intervetions of doctor.
        /// </summary>
        /// <param name="doctorLogic">doctorlogic.</param>
        /// <param name="name">nem of doctor.</param>
        public static void AllInterventionByDoctor(DoctorLogic doctorLogic, string name)
        {
            if (doctorLogic != null)
            {
                foreach (var item in doctorLogic.AllInterventionForDoc(name))
                {
                    Console.WriteLine(item.ToString());
                }

                Console.ReadLine();
            }
        }

        /// <summary>
        /// List All Intervention.
        /// </summary>
        /// <param name="doctroLogic">intervention log.</param>
        public static void ListAllIntervention(DoctorLogic doctroLogic)
        {
            if (doctroLogic != null)
            {
                PrintMessage("\n:: ALLL INTERVENTIONS ::\n");
                doctroLogic.GetAllIntervention().ToList()
                    .ForEach(x => System.Console.WriteLine(x.ToString()));
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Add a new dog.
        /// </summary>
        /// <param name="ownerLogic">doglog.</param>
        /// <param name="name">name.</param>
        public static void AddNewDog(OwnerLogic ownerLogic, string name)
        {
            PrintMessage("GIVE THE DATA OF THE DOG");
            Dog d = new Dog();
            PrintMessage("DOG NAME -> ");
            d.DogName = Console.ReadLine();
            PrintMessage("OWNER NAME -> ");
            d.OwnerName = name;
            PrintMessage("GENDER -> ");
            d.Gender = Console.ReadLine();
            PrintMessage("BREED -> ");
            d.Breed = Console.ReadLine();
            if (ownerLogic != null)
            {
                d.ChipNum = ownerLogic.GetAllDogs().Count + 1;
                ownerLogic.AddDog(d);
            }
        }

        /// <summary>
        /// list all meda.
        /// </summary>
        /// <param name="dirctorLogic">medalog.</param>
        public static void ListAllMedal(DirectorLogic dirctorLogic)
        {
            if (dirctorLogic != null)
            {
                Methods.PrintMessage("\n:: ALL MEDALS ::\n");
                dirctorLogic.GetAllMedal().ToList()
                    .ForEach(x => System.Console.WriteLine(x.ToString()));
                Console.ReadLine();
            }
        }

        /// <summary>
        /// list all god.
        /// </summary>
        /// <param name="ownerLogic">log.</param>
        public static void ListAllDog(OwnerLogic ownerLogic)
        {
            if (ownerLogic != null)
            {
                Methods.PrintMessage("\n:: ALL DOGS ::\n");
                ownerLogic.GetAllDogs().ToList()
                    .ForEach(x => System.Console.WriteLine(x.ToString()));
                Console.ReadLine();
            }
        }

        /// <summary>
        /// list all owners, you can login with his name.
        /// </summary>
        /// <param name="ownerLogic">owner logic.</param>
        public static void ListAllOwner(OwnerLogic ownerLogic)
        {
            if (ownerLogic != null)
            {
                List<string> owners = ownerLogic.AllOwner();
                foreach (var item in owners)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();
            }
        }

        /// <summary>
        /// Add a new medal.
        /// </summary>
        /// <param name="directorLogic">medallogic.</param>
        /// <param name="ownerLogic">doglogic.</param>
        public void AddNewMedal(DirectorLogic directorLogic, OwnerLogic ownerLogic)
        {
            if (directorLogic != null && ownerLogic != null)
            {
                PrintMessage("GIVE THE DATA OF THE MEDAL:");
                Medal m = new Medal();
                Methods.PrintMessage("NAME OF THE RACE -> ");
                m.RaceName = Console.ReadLine();
                Methods.PrintMessage("NAME OF THE CATEGORY -> ");
                m.Category = Console.ReadLine();
                Methods.PrintMessage("NAME OF THE DEGREE -> ");
                m.Degree = Console.ReadLine();
                Methods.PrintMessage("ID OF THE DOG WHO WIN IT -> ");
                m.DogChipNum = this.invesdog.IdNumber(ownerLogic.GetAllDogs().ToList());
                Methods.PrintMessage("NUMBER OF STARTERS -> ");
                m.MedalId = directorLogic.GetAllMedal().Count + 1;
                m.StartersNum = int.Parse(Console.ReadLine(), null);
                directorLogic.AddMedal(m);
            }
        }

        /// <summary>
        /// change medal category.
        /// </summary>
        /// <param name="directroLogic">medallogic.</param>
        public void ChangeMedalCategory(DirectorLogic directroLogic)
        {
            if (directroLogic != null)
            {
                int id = this.invesmedal.IdNumber(directroLogic.GetAllMedal().ToList());
                PrintMessage("New name of Category ->");
                string categor = Console.ReadLine();
                directroLogic.ChangeMedalCategory(id, categor);
            }
        }

        /// <summary>
        /// Change medal degree.
        /// </summary>
        /// <param name="directorLogic">medal logic.</param>
        public void ChangeMedalDegree(DirectorLogic directorLogic)
        {
            if (directorLogic != null)
            {
                int id = this.invesmedal.IdNumber(directorLogic.GetAllMedal().ToList());
                PrintMessage(">> NEW DEGREE:");
                string degree = Console.ReadLine();
                directorLogic.ChangeMedalDegree(id, degree);
            }
        }

        /// <summary>
        /// get a medal according to id.
        /// </summary>
        /// <param name="diredtorLogic">medallogic.</param>
        public void GetMedalById(DirectorLogic diredtorLogic)
        {
            if (diredtorLogic != null)
            {
                PrintMessage("ID OF THE MEDAL WHAT YOU WANT TO LIST");
                int id = this.invesmedal.IdNumber(diredtorLogic.GetAllMedal().ToList());
                var med = diredtorLogic.GetMedal(id);
                PrintMessage(med.ToString());
                Console.ReadLine();
            }
        }

        /// <summary>
        /// remove a medal according to id.
        /// </summary>
        /// <param name="directorLogic">medallogic.</param>
        public void RemoveMedalById(DirectorLogic directorLogic)
        {
            if (directorLogic != null)
            {
                Methods.PrintMessage("ID OF THE REMOVING MEDAL");
                int id = this.invesmedal.IdNumber(directorLogic.GetAllMedal().ToList());
                Medal rm = directorLogic.GetMedal(id);
                directorLogic.RemoveMedal(rm);
            }
        }

        /// <summary>
        /// change the dog name.
        /// </summary>
        /// <param name="ownerLogic">doglogic.</param>
        public void ChangeDogName(OwnerLogic ownerLogic)
        {
            if (ownerLogic != null)
            {
                PrintMessage("ID OF DOG");
                int id = this.invesdog.IdNumber(ownerLogic.GetAllDogs().ToList());
                Methods.PrintMessage(">> NEW DEGREE:");
                string name = Console.ReadLine();
                ownerLogic.ChangeDogName(id, name);
            }
        }

        /// <summary>
        /// get a dog by id.
        /// </summary>
        /// <param name="ownerLogic">ownerLogic.</param>
        /// <param name="name">name.</param>
        public void GetDogById(OwnerLogic ownerLogic, string name)
        {
            if (ownerLogic != null)
            {
                while (true)
                {
                    Methods.PrintMessage("KUTYÁD ID-JA -> ");
                    int id = this.invesdog.IdNumber(ownerLogic.GetAllDogs().ToList());
                    var dog = ownerLogic.GetYourDogByChip(id);
                    if (!(dog.OwnerName == name))
                    {
                        Methods.PrintMessage("NEM A TE KUTYÁD, ADJ MEG MÁS ID-T ->");
                    }
                    else
                    {
                        Console.WriteLine(dog.ToString());
                        break;
                    }
                }

                Console.ReadLine();
            }
        }

        /// <summary>
        /// dog remove.
        /// </summary>
        /// <param name="ownerLogic">doglocig.</param>
        public void RemoveDogById(OwnerLogic ownerLogic)
        {
            if (ownerLogic != null)
            {
                Methods.PrintMessage("ID OF THE REMOVING MEDAL");
                int id = this.invesdog.IdNumber(ownerLogic.GetAllDogs().ToList());
                Dog rm = ownerLogic.GetYourDogByChip(id);
                ownerLogic.RemoveDog(rm);
            }
        }

        /// <summary>
        /// change intervention description.
        /// </summary>
        /// <param name="doctorLogic">intervention log.</param>
        /// <param name="name">name.</param>
        public void ChangeInterventionDescript(DoctorLogic doctorLogic, string name)
        {
            int id = 0;
            if (doctorLogic != null)
            {
                while (true)
                {
                    PrintMessage("BEAVATKOZÁS ID-JA -> ");
                    id = this.invesinters.IdNumber(doctorLogic.GetAllIntervention().ToList());
                    if (!(doctorLogic.GetIntervention(id).Doctor == name))
                    {
                        PrintMessage("EZT A BEAVATKZÁST NEM TE VÉGEZTED EL, ADDJ MEG EGY ÚJ ID-T");
                    }
                    else
                    {
                        break;
                    }
                }

                PrintMessage(">> NEW DESCRIPTION :");
                string desc = Console.ReadLine();
                doctorLogic.ChangeInterventionDescript(id, desc);
            }
        }

        /// <summary>
        /// add a new interventon.
        /// </summary>
        /// <param name="doctorLogic">intervention logic.</param>
        /// <param name="ownerLogic">dog logic.</param>
        public void AddNewIntervention(DoctorLogic doctorLogic, OwnerLogic ownerLogic)
        {
            if (doctorLogic != null && ownerLogic != null)
            {
                PrintMessage("GIVE THE DATA OF THE INTERVENTION");
                Intervention i = new Intervention();
                PrintMessage("DESCRIPTION -> ");
                i.Desript = Console.ReadLine();
                i.InterventionId = doctorLogic.GetAllIntervention().ToList().Count + 1;
                PrintMessage("COST -> ");
                i.Cost = int.Parse(Console.ReadLine(), null);
                PrintMessage("NAME OF DOCTOR -> ");
                i.Doctor = Console.ReadLine();
                Console.WriteLine();
                i.DoctorPhone = int.Parse(Console.ReadLine(), null);
                PrintMessage("DOG CHIP NUMBER -> ");
                i.DogChipNum = this.invesdog.IdNumber(ownerLogic.GetAllDogs().ToList());
                doctorLogic.Add(i);
            }
        }

        /// <summary>
        /// get intervention by id.
        /// </summary>
        /// <param name="doctorLogic">intervention logic.</param>
        /// <param name="name">name.</param>
        public void GetInterventionById(DoctorLogic doctorLogic, string name)
        {
            if (doctorLogic != null)
            {
                while (true)
                {
                    PrintMessage("ID OF THE INTERVENTION WHAT YOU WANT TO LIST");
                    int id = this.invesinters.IdNumber(doctorLogic.GetAllIntervention().ToList());
                    Intervention interv = doctorLogic.GetIntervention(id);
                    if (!(interv.Doctor == name))
                    {
                        PrintMessage("Ez az ID-u beavatkozás nem a tiéd, adj meg egy újat -> ");
                    }
                    else
                    {
                        Console.WriteLine(interv.ToString());
                        break;
                    }
                }

                Console.ReadLine();
            }
        }

        /// <summary>
        /// remove intervention by id.
        /// </summary>
        /// <param name="doctorLogic">intervention logic.</param>
        /// <param name="name">name.</param>
        public void RemoveInterventionById(DoctorLogic doctorLogic, string name)
        {
            if (doctorLogic != null)
            {
                int id;
                while (true)
                {
                    PrintMessage("ID  A TÖRLENDŐ BEAVATKOZÁSNAK");
                    id = this.invesinters.IdNumber(doctorLogic.GetAllIntervention().ToList());
                    if (!(doctorLogic.GetIntervention(id).Doctor == name))
                    {
                        PrintMessage("EZT A BEAVATKOZÁST NEM TE VÉGEZTED EL, ADJ MEG MÁS ID-T!");
                    }
                    else
                    {
                        break;
                    }
                }

                Intervention rm = doctorLogic.GetIntervention(id);
                doctorLogic.Remov(rm);
            }
        }

        /// <summary>
        /// neutering a dog.
        /// </summary>
        /// <param name="ownerLogic">ownerlogic.</param>
        /// <param name="doctorLogic">doctrologic.</param>
        public void Neutering(OwnerLogic ownerLogic, DoctorLogic doctorLogic)
        {
            if (doctorLogic != null && ownerLogic != null)
            {
                PrintMessage("KUTYA ID-JA AKIT IVARTALANÍTANI KELL ->");
                int id = this.invesdog.IdNumber(ownerLogic.GetAllDogs().ToList());
                doctorLogic.DogNeutering(id);
            }
        }
    }
}
