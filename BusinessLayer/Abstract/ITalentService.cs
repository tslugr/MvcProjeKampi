using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITalentService
    {
        List<UserTalent> GetList();
        void UserTalentAddBL(UserTalent usertalent);
        UserTalent GetByID(int id);
        void UserTalentDelete(UserTalent usertalent);
        void UserTalentUpdate(UserTalent usertalent);
    }
}
