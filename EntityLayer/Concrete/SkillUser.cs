using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SkillUser
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(250)]
        public string UserDetails { get; set; }
        [StringLength(250)]
       
        public ICollection<UserTalent> Talents { get; set; }

    }
}
