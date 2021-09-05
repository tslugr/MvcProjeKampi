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
    public class ITalentManager : ITalentService
    {
        ITalentDal _talentDal;

        public ITalentManager(ITalentDal talentDal)
        {
            _talentDal = talentDal;
        }

        public UserTalent GetByID(int id)
        {
            return _talentDal.Get(x => x.UserID == id);
        }

        public List<UserTalent> GetList()
        {
            return _talentDal.List();
        }

        public void UserTalentAddBL(UserTalent usertalent)
        {
            throw new NotImplementedException();
        }

        public void UserTalentDelete(UserTalent usertalent)
        {
            throw new NotImplementedException();
        }

        public void UserTalentUpdate(UserTalent usertalent)
        {
            throw new NotImplementedException();
        }
    }
}
