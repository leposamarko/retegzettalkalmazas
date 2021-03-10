using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using KutyaVerseny.Data.Models;
using KutyaVerseny.Logic;
using KutyaVerseny.Repository;
using KutyaVerseny.WpfApplication.Data;

namespace KutyaVerseny.WpfApplication.Logic
{
    public class DogLogiWpf
    {
        IEditorService editor;
        private OwnerLogic OwnerLogic;
        IMessenger messengerService;

        public DogLogiWpf(IMessenger messengerService)
        {
            Db Ctx = new Db();
            DogRepository dogRepo = new DogRepository(Ctx);
            MedalRepository medalRepo = new MedalRepository(Ctx);
            InterventionRepository intRepo = new InterventionRepository(Ctx);
            OwnerLogic ownerLogic = new OwnerLogic(dogRepo, intRepo, medalRepo);
            this.messengerService = messengerService;
        }

        public void AddDog(IList<DogWpf> list)
        {
            DogWpf newDog = new DogWpf();
           
            if (editor.EditPlayer(newDog) == true)
            {
                list.Add(newDog);
                Dog entity = newDog.ConvertToEntity();
                OwnerLogic.AddDog(entity);
                messengerService.Send("ADD OK", "LogicResult");
            }
            else
            {
                messengerService.Send("ADD CANCEL", "LogicResult");
            }
        }

        public IEnumerable<DogWpf> GetAllDog()
        {
            var retEntity = OwnerLogic.GetAllDogs();
            return retEntity.Select((dog) => new DogWpf(dog));
        }

        public void DelDog(IList<DogWpf> list, DogWpf dog)
        {
            if(dog != null && list.Remove(dog))
            {
                Dog d = dog.ConvertToEntity();
                OwnerLogic.RemoveDog(d);
                messengerService.Send("DELETE OK", "LogicResult");
            }
            else
            {
                messengerService.Send("DELETE FAILD", "LogicResult");
            }
        }

        public void ModPlayer()
        {

        }
    }
}
