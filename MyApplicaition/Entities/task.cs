using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyApplicaition.Entities
{
    [Table("task")]
    public class task
    {

        [Column("tid")]
        [Key]
        public int tid { get; set; }

        [Column("eid")]
        [ForeignKey("eid")]
        public int eid { get; set; }

        [Column("tname")]
        [Key]
        public string tname { get; set; }

        [Column("createdts")]
        [Key]
        public DateTime createdts { get; set; }

        [Column("lastupdatedby")]
        [Key]
        public string lastupdatedby { get; set; }

    }
}