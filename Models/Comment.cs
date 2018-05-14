using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace UserDashboard.Models{
	public class Comment:BaseEntity{
		public string text{set;get;}
		public Post post{set;get;}
		public User user{set;get;}
	}
}
