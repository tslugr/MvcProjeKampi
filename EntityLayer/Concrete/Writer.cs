﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //Yazar tablosu
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }

        [StringLength(50)]
        public string WriterName { get; set; }

        [StringLength(50)]
        public string WriterSurName { get; set; }

        [StringLength(250)]
        public string WriterImage { get; set; }

        [StringLength(100)]
        public string WriterAbout { get; set; }

        [StringLength(200)]
        public string WriterMail { get; set; }

        public byte[] WriterPasswordHash { get; set; }
        public byte[] WriterPasswordSalt { get; set; }

        [StringLength(50)]
        public string WriterTitle { get; set; }
		
		[StringLength(1)]
        public string WriterRole { get; set; }

        public bool WriterStatus { get; set; }

        //Yazar Başlık ilişkisi
        public ICollection<Heading> Headings { get; set; }

        //Yazar İçerik ilişkisi

        public ICollection<Content> Contents { get; set; }


    }
}
