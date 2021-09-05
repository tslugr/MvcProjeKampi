using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserTalent
    {
        [Key]
        public int TalentID { get; set; }

        [StringLength(100)]
        public string TalentTitle { get; set; }
        public byte TalentLevel { get; set; }

        public string SocialMedia { get; set; }
        public int? UserID { get; set; }
        public virtual SkillUser SkillUser { get; set; }
    }
}
