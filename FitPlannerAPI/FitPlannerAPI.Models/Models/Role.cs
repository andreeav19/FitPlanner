﻿using FitPlannerAPI.Models.Base;

namespace FitPlannerAPI.Models.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        // Navigation property
        public virtual ICollection<User> Users { get; set; }
    }
}
