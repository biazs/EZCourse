using System;
using System.Collections.Generic;

namespace EZCourse.Models.Entities
{
    public partial class Permission
    {
        public int Id { get; set; }
        public int? Code { get; set; }
        public DateTime? Time { get; set; }
    }
}
