﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DawApp.Models
{
    public partial class AspNetUserRoles
    {
        [Key]
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRoles Role { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
