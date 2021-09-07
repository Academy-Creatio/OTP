using System.Runtime.Serialization;

namespace OTP.DTO
{
	[DataContract]
	public class Person
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name= "email")]
		public string Email { get; set; }
	}
}



