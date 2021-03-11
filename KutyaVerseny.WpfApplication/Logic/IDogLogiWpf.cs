using KutyaVerseny.WpfApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutyaVerseny.WpfApplication.Logic
{
    interface IDogLogiWpf
    {
        public void AddDog(IList<DogWpf> list);
        public IEnumerable<DogWpf> GetAllDog();
        public void DelDog(IList<DogWpf> list, DogWpf dog);
        public void ModyDog(DogWpf dogToModi);
    }
}
