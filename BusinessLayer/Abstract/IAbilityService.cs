using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAbilityService
    {
        List<Ability> GetList();
        void AbilityAdd(Ability ability);
        Ability GetById(int id);
        void AbilityDelete(Ability ability);
        void AbilityUpdate(Ability ability);
    }
}
