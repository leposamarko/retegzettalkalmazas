// <copyright file="Methods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ConsoleTools;
    using KutyaVerseny.Data.Models;
    using KutyaVerseny.Logic;

    /// <summary>
    /// methods class what u can use from the menu.
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Methods"/> class.
        /// </summary>
        public Methods()
        {
        }

        /// <summary>
        /// list all god.
        /// </summary>
        /// <param name="ownerLogic">log.</param>
        public void ListAllDog(OwnerLogic ownerLogic)
        {
            System.Console.WriteLine("\n:: ALL DOGS ::\n");
            ownerLogic.GetAllDogs().ToList()
                .ForEach(x => System.Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        /// <summary>
        /// list all meda.
        /// </summary>
        /// <param name="dirctorLogic">medalog.</param>
        public void ListAllMedal(DirectorLogic dirctorLogic)
        {
            System.Console.WriteLine("\n:: ALL MEDALS ::\n");
            dirctorLogic.GetAllMedal().ToList()
                .ForEach(x => System.Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        /// <summary>
        /// List All Intervention.
        /// </summary>
        /// <param name="doctroLogic">intervention log.</param>
        public void ListAllIntervention(DoctorLogic doctroLogic)
        {
            System.Console.WriteLine("\n:: ALLL INTERVENTIONS ::\n");
            doctroLogic.GetAllIntervention().ToList()
                .ForEach(x => System.Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        /// <summary>
        /// change medal category.
        /// </summary>
        /// <param name="directroLogic">medallogic.</param>
        public void ChangeMedalCategory(DirectorLogic directroLogic)
        {
            int id = Investigator<Medal>.IdNumber(directroLogic.GetAllMedal().ToList());
            Console.WriteLine("New name of Category ->");
            string categor = Console.ReadLine();
            directroLogic.ChangeMedalCategory(id, categor);
        }

        /// <summary>
        /// Change medal degree.
        /// </summary>
        /// <param name="directorLogic">medal logic.</param>
        public void ChangeMedalDegree(DirectorLogic directorLogic)
        {
            int id = Investigator<Medal>.IdNumber(directorLogic.GetAllMedal().ToList());
            Console.WriteLine(">> NEW DEGREE:");
            string degree = Console.ReadLine();
            directorLogic.ChangeMedalDegree(id, degree);
        }

        /// <summary>
        /// Add a new medal.
        /// </summary>
        /// <param name="directorLogic">medallogic.</param>
        /// <param name="ownerLogic">doglogic.</param>
        public void AddNewMedal(DirectorLogic directorLogic, OwnerLogic ownerLogic)
        {
            Console.WriteLine("GIVE THE DATA OF THE MEDAL:");
            Medal m = new Medal();
            Console.WriteLine("NAME OF THE RACE -> ");
            m.RaceName = Console.ReadLine();
            Console.WriteLine("NAME OF THE CATEGORY -> ");
            m.Category = Console.ReadLine();
            Console.WriteLine("NAME OF THE DEGREE -> ");
            m.Degree = Console.ReadLine();
            Console.WriteLine("ID OF THE DOG WHO WIN IT -> ");
            m.DogChipNum = Investigator<Dog>.IdNumber(ownerLogic.GetAllDogs().ToList());
            Console.WriteLine("NUMBER OF STARTERS -> ");
            m.MedalId = directorLogic.GetAllMedal().Count + 1;
            m.StartersNum = int.Parse(Console.ReadLine());
            directorLogic.AddMedal(m);
        }

        /// <summary>
        /// get a medal according to id.
        /// </summary>
        /// <param name="diredtorLogic">medallogic.</param>
        public void GetMedalById(DirectorLogic diredtorLogic)
        {
            Console.WriteLine("ID OF THE MEDAL WHAT YOU WANT TO LIST");
            int id = Investigator<Medal>.IdNumber(diredtorLogic.GetAllMedal().ToList());
            var med = diredtorLogic.GetMedal(id);
            Console.WriteLine(med.ToString());
            Console.ReadLine();
        }

        /// <summary>
        /// remove a medal according to id.
        /// </summary>
        /// <param name="directorLogic">medallogic.</param>
        public void RemoveMedalById(DirectorLogic directorLogic)
        {
            Console.WriteLine("ID OF THE REMOVING MEDAL");
            int id = Investigator<Medal>.IdNumber(directorLogic.GetAllMedal().ToList());
            Medal rm = directorLogic.GetMedal(id);
            directorLogic.RemoveMedal(rm);
        }

        /// <summary>
        /// change the dog name.
        /// </summary>
        /// <param name="ownerLogic">doglogic.</param>
        public void ChangeDogName(OwnerLogic ownerLogic)
        {
            Console.WriteLine("ID OF DOG");
            int id = Investigator<Dog>.IdNumber(ownerLogic.GetAllDogs().ToList());
            Console.WriteLine(">> NEW DEGREE:");
            string name = Console.ReadLine();
            ownerLogic.ChangeDogName(id, name);
        }

        /// <summary>
        /// Add a new dog.
        /// </summary>
        /// <param name="ownerLogic">doglog.</param>
        /// <param name="name">name.</param>
        public void AddNewDog(OwnerLogic ownerLogic, string name)
        {
            Console.WriteLine("GIVE THE DATA OF THE DOG");
            Dog d = new Dog();
            Console.WriteLine("DOG NAME -> ");
            d.DogName = Console.ReadLine();
            Console.WriteLine("OWNER NAME -> ");
            d.OwnerName = name;
            Console.WriteLine("GENDER -> ");
            d.Gender = Console.ReadLine();
            Console.WriteLine("BREED -> ");
            d.Breed = Console.ReadLine();
            d.ChipNum = ownerLogic.GetAllDogs().Count + 1;
            ownerLogic.AddDog(d);
        }

        /// <summary>
        /// get a dog by id.
        /// </summary>
        /// <param name="ownerLogic">ownerLogic.</param>
        /// <param name="name">name.</param>
        public void GetDogById(OwnerLogic ownerLogic, string name)
        {
            while (true)
            {
                Console.WriteLine("KUTYÁD ID-JA -> ");
                int id = Investigator<Dog>.IdNumber(ownerLogic.GetAllDogs().ToList());
                var dog = ownerLogic.GetYourDogByChip(id);
                if (!dog.OwnerName.Equals(name))
                {
                    Console.WriteLine("NEM A TE KUTYÁD, ADJ MEG MÁS ID-T ->");
                }
                else
                {
                    Console.WriteLine(dog.ToString());
                    break;
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// dog remove.
        /// </summary>
        /// <param name="ownerLogic">doglocig.</param>
        public void RemoveDogById(OwnerLogic ownerLogic)
        {
            Console.WriteLine("ID OF THE REMOVING MEDAL");
            int id = Investigator<Dog>.IdNumber(ownerLogic.GetAllDogs().ToList());
            Dog rm = ownerLogic.GetYourDogByChip(id);
            ownerLogic.RemoveDog(rm);
        }

        /// <summary>
        /// change intervention description.
        /// </summary>
        /// <param name="doctorLogic">intervention log.</param>
        /// <param name="name">name.</param>
        public void ChangeInterventionDescript(DoctorLogic doctorLogic, string name)
        {
            int id;
            while (true)
            {
                Console.WriteLine("BEAVATKOZÁS ID-JA -> ");
                id = Investigator<Intervention>.IdNumber(doctorLogic.GetAllIntervention().ToList());
                if (!doctorLogic.GetIntervention(id).Doctor.Equals(name))
                {
                    Console.WriteLine("EZT A BEAVATKZÁST NEM TE VÉGEZTED EL, ADDJ MEG EGY ÚJ ID-T");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(">> NEW DESCRIPTION :");
            string desc = Console.ReadLine();
            doctorLogic.ChangeInterventionDescript(id, desc);
        }

        /// <summary>
        /// add a new interventon.
        /// </summary>
        /// <param name="doctorLogic".>intervention logic.</param>
        /// <param name="ownerLogic">dog logic.</param>
        public void AddNewIntervention(DoctorLogic doctorLogic, OwnerLogic ownerLogic)
        {
            Console.WriteLine("GIVE THE DATA OF THE INTERVENTION");
            Intervention i = new Intervention();
            Console.WriteLine("DESCRIPTION -> ");
            i.Desript = Console.ReadLine();
            i.InterventionId = doctorLogic.GetAllIntervention().ToList().Count + 1;
            Console.WriteLine("COST -> ");
            i.Cost = int.Parse(Console.ReadLine());
            Console.WriteLine("NAME OF DOCTOR -> ");
            i.Doctor = Console.ReadLine();
            Console.WriteLine();
            i.DoctorPhone = int.Parse(Console.ReadLine());
            Console.WriteLine("DOG CHIP NUMBER -> ");
            i.DogChipNum = Investigator<Dog>.IdNumber(ownerLogic.GetAllDogs().ToList());
            doctorLogic.Add(i);
        }

        /// <summary>
        /// get intervention by id.
        /// </summary>
        /// <param name="doctorLogic">intervention logic.</param>
        /// <param name="name">name.</param>
        public void GetInterventionById(DoctorLogic doctorLogic, string name)
        {
            while (true)
            {
                Console.WriteLine("ID OF THE INTERVENTION WHAT YOU WANT TO LIST");
                int id = Investigator<Intervention>.IdNumber(doctorLogic.GetAllIntervention().ToList());
                Intervention interv = doctorLogic.GetIntervention(id);
                if (!interv.Doctor.Equals(name))
                {
                    Console.WriteLine("Ez az ID-u beavatkozás nem a tiéd, adj meg egy újat -> ");
                }
                else
                {
                    Console.WriteLine(interv.ToString());
                    break;
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// remove intervention by id.
        /// </summary>
        /// <param name="doctorLogic">intervention logic.</param>
        /// <param name="name">name.</param>
        public void RemoveInterventionById(DoctorLogic doctorLogic, string name)
        {
            int id;
            while (true)
            {
                Console.WriteLine("ID  A TÖRLENDŐ BEAVATKOZÁSNAK");
                id = Investigator<Intervention>.IdNumber(doctorLogic.GetAllIntervention().ToList());
                if (!doctorLogic.GetIntervention(id).Doctor.Equals(name))
                {
                    Console.WriteLine("EZT A BEAVATKOZÁST NEM TE VÉGEZTED EL, ADJ MEG MÁS ID-T!");
                }
                else
                {
                    break;
                }
            }

            Intervention rm = doctorLogic.GetIntervention(id);
            doctorLogic.Remov(rm);
        }

        /// <summary>
        /// list all owners, you can login with his name.
        /// </summary>
        /// <param name="ownerLogic">owner logic.</param>
        public void ListAllOwner(OwnerLogic ownerLogic)
        {
            List<string> owners = ownerLogic.AllOwner();
            foreach (var item in owners)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// get your dogs.
        /// </summary>
        /// <param name="ownerLogic">ownerLogic.</param>
        /// <param name="name">name of owner.</param>
        public void GetYourDogs(OwnerLogic ownerLogic, string name)
        {
            foreach (var item in ownerLogic.GetYourDogs(name))
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// get the owner's dog's medal's.
        /// </summary>
        /// <param name="ownerLogic">ownerLogic.</param>
        /// <param name="name">name.</param>
        public void DogsMedal(OwnerLogic ownerLogic, string name)
        {
            ownerLogic.DogsMedals(name);
        }

        /// <summary>
        /// get the owner's do's intervention's.
        /// </summary>
        /// <param name="ownerLogic">ownerLogic.</param>
        /// <param name="name">name.</param>
        public void DogsInterventions(OwnerLogic ownerLogic, string name)
        {
            ownerLogic.DogsInterventions(name);
        }

        /// <summary>
        /// list all doctors.
        /// </summary>
        /// <param name="doctorLogic">doctorLogic.</param>
        public void ListAllDoctors(DoctorLogic doctorLogic)
        {
            List<string> owners = doctorLogic.AllDoctor();
            foreach (var item in owners)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// give the intervetions of doctor.
        /// </summary>
        /// <param name="doctorLogic">doctorlogic.</param>
        /// <param name="name">nem of doctor.</param>
        public void AllInterventionByDoctor(DoctorLogic doctorLogic, string name)
        {
            foreach (var item in doctorLogic.AllInterventionForDoc(name))
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// neutering a dog.
        /// </summary>
        /// <param name="ownerLogic">ownerlogic.</param>
        /// <param name="doctorLogic">doctrologic.</param>
        public void Neutering(OwnerLogic ownerLogic, DoctorLogic doctorLogic)
        {
            Console.WriteLine("KUTYA ID-JA AKIT IVARTALANÍTANI KELL ->");
            int id = Investigator<Dog>.IdNumber(ownerLogic.GetAllDogs().ToList());
            doctorLogic.DogNeutering(id);
        }

        /// <summary>
        /// doctor number change.
        /// </summary>
        /// <param name="doctorLogic">doctorLogic.</param>
        /// <param name="name">name.</param>
        public void DoctorPhoneNum(DoctorLogic doctorLogic, string name)
        {
            Console.WriteLine("KÉREM AZ ÚJ TELEFONSZÁMOT -> ");
            int num = int.Parse(Console.ReadLine());
            foreach (var item in doctorLogic.GetAllIntervention().ToList())
            {
                if (item.Doctor.Equals(name))
                {
                    int id = (int)item.InterventionId;
                    doctorLogic.ChangeInterventionDocPhone(id, num);
                }
            }
        }

        /// <summary>
        /// number of the degrees.
        /// </summary>
        /// <param name="directorLogic">directorLogic.</param>
        public void DegreeNumb(DirectorLogic directorLogic)
        {
            directorLogic.DegreeNumb();
        }
    }
}
