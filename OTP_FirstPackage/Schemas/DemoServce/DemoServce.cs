using OTP_Training_Interfaces;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Terrasoft.Core;
using Terrasoft.Core.Factories;
using Terrasoft.Web.Common;

namespace Otp
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class DemoService : BaseService
	{
		#region Methods : REST
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		public string PostMethodName()
		{

			ConstructorArgument ca = new ConstructorArgument("userConnection", UserConnection);
			ICalculator calculator = ClassFactory.Get<ICalculator>(
				 "SecondImplementation", ca);

			//calculator.Init(UserConnection);
			var result = calculator.Add(10, 15);
			calculator.Subtract(1, 1);

			return $"Result {result}";
		}

		[OperationContract]
		[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		public string GetMethodname()
		{
			return "Ok Get";
		}

		#endregion
	}
}



