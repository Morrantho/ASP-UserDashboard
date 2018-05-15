using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace UserDashboard.Models{
	public abstract class BaseEntity{
		[Key]
		public int Id{get;set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
	}
}
