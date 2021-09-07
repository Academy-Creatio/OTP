using Terrasoft.Core;

namespace OTP_Training_Interfaces
{

	/// <summary>
	/// Provides basic calculator functions
	/// </summary>
	/// <remarks>
	/// <example>
	/// You can instantiate an instance of the class with the following constructor
	/// <code>
	/// ConstructorArgument ca = new ConstructorArgument("userConnection", UserConnection);
	/// ICalculator calculator = ClassFactory.Get&lt;ICalculator&gt;("SecondImplementation", ca);
	/// </code>
	/// If constructor is not called, make sure to call <see cref="Init(UserConnection)">Init</see> method with UserConnection
	/// <code>
	/// ICalculator calculator = ClassFactory.Get&lt;ICalculator&gt;("SecondImplementation");
	/// calculator.Init(UserConnection);
	/// </code>
	/// </example>
	/// </remarks>
	public interface ICalculator
	{
		
		/// <summary>
		/// Adds two integers
		/// </summary>
		/// <param name="a">First number to add</param>
		/// <param name="b">Second number to add</param>
		/// <returns>A+B</returns>
		int Add(int a, int b);

		/// <summary>
		/// Subtracts B from A
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns>A-B</returns>
		/// <exception cref="System.NullReferenceException">Thrown when <c>UserConection</c> is not set</exception>
		int Subtract(int a, int b);

		/// <summary>
		/// Initializes instance of a calculator instance with UserConnection
		/// </summary>
		/// <param name="userconnection"></param>
		/// <remarks>
		/// Avoid calling this method if class is instantiated with a constructor
		/// </remarks>
		void Init(UserConnection userconnection);
	}
}
