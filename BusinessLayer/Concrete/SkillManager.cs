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
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public SkillUser GetByID(int id)
        {
            return _skillDal.Get(x => x.UserID == id);
        }

        public List<SkillUser> GetList()
        {
            return _skillDal.List();
        }

        public void SkillAddBL(SkillUser skilluser)
        {
            throw new NotImplementedException();
        }

        public void SkillDelete(SkillUser skilluser)
        {
            throw new NotImplementedException();
        }

        public void SkillUpdate(SkillUser skilluser)
        {
            throw new NotImplementedException();
        }
    }
}
