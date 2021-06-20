using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AbilityManager : IAbilityService
    {
        IAbilityDal _abilityDal;

        public AbilityManager(IAbilityDal abilityDal)
        {
            _abilityDal = abilityDal;
        }

        public void AbilityAdd(Ability ability)
        {
            _abilityDal.Insert(ability);
        }

        public void AbilityDelete(Ability ability)
        {
            _abilityDal.Delete(ability);
        }

        public void AbilityUpdate(Ability ability)
        {
            _abilityDal.Update(ability);
        }

        public Ability GetById(int id)
        {
            return _abilityDal.Get(x => x.AbiltyID == id);
        }

        public List<Ability> GetList()
        {
            return _abilityDal.List();
        }
    }
}
