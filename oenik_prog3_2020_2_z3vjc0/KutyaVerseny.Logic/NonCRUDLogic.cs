using KutyaVerseny.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KutyaVerseny.Logic
{
    public class NonCRUDLogic
    {
        private readonly IDogRepository dogRepo;
        private readonly IMedalRepository medalRepo;
        private readonly IInterventionRepositry interRepo;

        public NonCRUDLogic(IDogRepository dogRepo, IMedalRepository medalRepo, IInterventionRepositry interRepo)
        {
            this.dogRepo = dogRepo;
            this.interRepo = interRepo;
            this.medalRepo = medalRepo;
        }

        public int AllCostOfIntervention()
        {
            int sum = 0;
            foreach (var item in interRepo.GetAll().ToList())
            {
                sum += item.Cost.Value;
            }

            return sum;
        }
    }
}
