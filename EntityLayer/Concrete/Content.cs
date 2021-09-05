using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //İçerik Tablosu
   public class Content
    {
        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)]
        public string CountentValue { get; set; }


        public DateTime CountentDate { get; set; }
        public bool ContentStatus { get; set; }

        //Başlık-iÇERİK Tablosuyla ilişki
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }

        //Yazar tablosuyla ilişki
        //Nullable type ? işareti ile ekledik writter id null değer alabilir.
        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
