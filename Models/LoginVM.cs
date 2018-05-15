using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace UserDashboard.Models{
	public class LoginVM{
		[Required]
		[MinLength(1)]
		[EmailAddress]
		public string email{set;get;}

		[Required]
		[DataType(DataType.Password)]
		[MinLength(8)]
		public string password{set;get;}
	}
}
