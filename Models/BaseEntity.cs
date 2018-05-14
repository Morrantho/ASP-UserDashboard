using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace UserDashboard.Models{
	public abstract class BaseEntity{
		[Key]
		public int id{get;set;}
        public DateTime createdAt{get;set;}
        public DateTime updatedAt{get;set;}
	}
}
