using System;
using System.Collections.Generic;

namespace MyApplicaition.Models
{
    public partial class Tasks
    {
        public int Tid { get; set; }
        public int? Eid { get; set; }
        public string Tname { get; set; }
        public DateTime? Createdts { get; set; }
        public string Lastupdatedby { get; set; }

        public Emp E { get; set; }
    }
}
