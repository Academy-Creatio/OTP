using OTP_Training_Interfaces;
using Terrasoft.Core;
using Terrasoft.Core.Factories;

namespace OTP_Training.Files.cs
{
	[DefaultBinding(typeof(ICalculator), Name = "FirstImplementation")]
	public class Calculator : ICalculator
	{
		public UserConnection _userConnection;

		public int Add(int a, int b)
		{
			return a + b;
		}

		public void Init(UserConnection userconnection)
		{
			throw new System.NotImplementedException();
		}

		public int Subtract(int a, int b)
		{
			return a - b;
		}
	}

	[DefaultBinding(typeof(ICalculator), Name = "SecondImplementation")]
	public class CalculatorTwo : ICalculator
	{
		private UserConnection _userConnection;

		public CalculatorTwo(UserConnection userConnection)
		{
			_userConnection = userConnection;
		}


		public void Init(UserConnection userConnection)
		{
			_userConnection = userConnection;
		}

		public int Add(int a, int b)
		{
			return a + b;
		}

		public int Subtract(int a, int b)
		{
			if(_userConnection == null)
			{
				throw new System.NullReferenceException("UserConnection cannot be null");
			}
			return a - b;
		}
	}
}
