using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace UserDashboard.Models{
	public class Comment:BaseEntity{
		public string Text{set;get;}
		public int PostId{set;get;}
		public Post Post{set;get;}
		public int UserId{set;get;}
		public User User{set;get;}
	}
}
