using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace UserDashboard.Models{
	public class Post:BaseEntity{
		public string text{set;get;}
		public User user{set;get;}
		public List<Comment> comments{set;get;}

		public Post(){
			comments = new List<Comment>();
		}
	}
}
