namespace Terrasoft.Core.Process.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using OTP_Training_Interfaces;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.UI.WebControls.Controls;

	#region Class: ProcessUserTask_Calculator

	/// <exclude/>
	public partial class ProcessUserTask_Calculator
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {

			ConstructorArgument ca = new ConstructorArgument("userConnection", UserConnection);
			ICalculator calculator = ClassFactory.Get<ICalculator>(
				 "SecondImplementation", ca);


			if (Operation == "Add")
			{
				Result = calculator.Add(A, B);
			} else if(Operation == "Sub")
			{
				Result = calculator.Subtract(A, B);
			}
			
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public override ProcessElementNotification GetNotificationData() {
			return base.GetNotificationData();
		}

		#endregion

	}

	#endregion

}

