using System;
using System.Collections.Generic;

namespace EZCourse.Models.Entities
{
    public partial class UserPermission
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
    }
}
