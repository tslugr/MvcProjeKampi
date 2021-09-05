using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface ISkillService
    {
        List<SkillUser> GetList();
        void SkillAddBL(SkillUser skilluser);
        SkillUser GetByID(int id);
        void SkillDelete(SkillUser skilluser);
        void SkillUpdate(SkillUser skilluser);
    }
}
