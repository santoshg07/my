using System;
using System.Collections.Generic;

namespace MyApplicaition.Models
{
    public partial class Emp
    {
        public Emp()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int EId { get; set; }
        public string EName { get; set; }
        public int? EAge { get; set; }
        public double? ESalary { get; set; }
        public string EEmailid { get; set; }
        public string EPassword { get; set; }
        public DateTime? EDateofjoining { get; set; }
        public string ECreatedby { get; set; }
        public DateTime? ECreatedts { get; set; }
        public string ELastupdatedby { get; set; }
        public DateTime? ELastupdatedts { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
    }
}
