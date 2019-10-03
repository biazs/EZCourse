using System;
using System.Collections.Generic;

namespace EZCourse.Models.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public UserCredential UserCredential { get; internal set; }
    }
}
