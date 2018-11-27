using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyApplicaition.Entities
{
    [Table("emp")]
    public class emp
    {
        internal readonly string eemailid;

        [Column("e_id")]
        [Key]
        public int eid { get; set; }

        [Column("e_Name")]
        [Key]
        public string ename { get; set; }

        [Column("e_Age")]
        [Key]
        public int eage { get; set; }

        [Column("e_Salary")]
        [Key]
        public double esalary { get; set; }

        [Column("e_dateofjoining")]
        [Key]
        public DateTime edateofjoining { get; set; }

        [Column("e_createdby")]
        [Key]
        public string ecreatedby { get; set; }

        [Column("e_createdts")]
        [Key]
        public DateTime ecreatedts { get; set; }

        [Column("e_lastupdatedby")]
        [Key]
        public string elastupdatedby { get; set; }

        [Column("e_lastupdatedts")]
        [Key]
        public DateTime elastupdatets { get; set; }

        [Column("e_password")]
        [Key]
        public string epassword { get; set; }
    }
}