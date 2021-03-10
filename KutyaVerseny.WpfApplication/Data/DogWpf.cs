using GalaSoft.MvvmLight;
using KutyaVerseny.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutyaVerseny.WpfApplication.Data
{
    public class DogWpf : ObservableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DogWpf"/> class.
        /// </summary>
        public DogWpf()
        {
        }

        public DogWpf( Dog d)
        {
            ChipNum = d.ChipNum;
            DogName = d.DogName;
            Gender = d.Gender;
            Breed = d.Breed;
            BornDate = d.BornDate;
            OwnerName = d.OwnerName;
        }

        /// <summary>
        /// Gets or sets name of the dog.
        /// </summary>
        public string DogName { get; set; }

        /// <summary>
        /// Gets or sets gender of the dog.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets chip number of the medal.
        /// </summary>
        public decimal ChipNum { get; set; }

        /// <summary>
        /// Gets or sets breed of the dog.
        /// </summary>
        public string Breed { get; set; }

        /// <summary>
        /// Gets or sets born date of the dog.
        /// </summary>
        public DateTime? BornDate { get; set; }

        /// <summary>
        /// Gets or sets owner's name of the dog.
        /// </summary>
        public string OwnerName { get; set; }

        public Dog ConvertToEntity()
        {
            return new Dog() { ChipNum = this.ChipNum, BornDate = this.BornDate, OwnerName = this.OwnerName, Breed = this.Breed, Gender = this.Gender, DogName = this.DogName };
        }
    }
}
