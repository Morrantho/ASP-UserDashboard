using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace UserDashboard.Models{
	public class RegisterVM{
		[Required]
		[MinLength(1)]
		[EmailAddress]
		public string email{set;get;}

		[Required]
		[MinLength(1)]
		public string first{set;get;}

		[Required]
		[MinLength(1)]
		public string last{set;get;}

		[Required]
		[DataType(DataType.Password)]
		[MinLength(8)]
		public string password{set;get;}

		[Required]
		[DataType(DataType.Password)]
		[MinLength(8)]
		[Compare("password")]
		public string confirm{set;get;}
	}
}
