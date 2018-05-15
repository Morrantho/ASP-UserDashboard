using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace UserDashboard.Models{
	public class Post:BaseEntity{
		public string Text{set;get;}
		public int UserId{set;get;}
		public User User{set;get;}

		public Post(){

		}
		
		public Post(string text){
		}
	}
}
