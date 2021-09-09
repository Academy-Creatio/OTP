using OTP.DTO;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Terrasoft.Core;
using Terrasoft.Web.Common;

namespace OTP
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class DemoServiceTwo : BaseService
	{

		#region Methods : REST
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, 
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public Person PostMethodName(Person person)
		{

			return new Person
			{
				Name = person.Name + " Krylov",
				Email = person.Email
			};
		}	  
		
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, 
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public Person PostMethodJs(Guid id)
		{
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var contact = schema.CreateEntity(UserConnection);
			contact.FetchFromDB("Id", id, new string[] { "Name", "Email" });

			return new Person
			{
				Name = contact.GetTypedColumnValue<string>("Name"),
				Email = contact.GetTypedColumnValue<string>("Email")
			};
			
		}

		[OperationContract]
		[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		public string GetMethodname()
		{
			
			return "Ok Returened from Clio";
		}

		#endregion
	}
}



