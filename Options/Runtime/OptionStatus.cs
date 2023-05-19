namespace GCore.Runtime.OptionsLib.Runtime
{
	/// <summary>
	/// <see cref="OptionStatus"/> defines the states of <see cref="Option{TReturn}"/>'s state for enum base checking...
	/// </summary>
	public enum OptionStatus
	{
		/// <summary>
		/// <see cref="None"/> defines that option has no data wrapped in it...
		/// </summary>
		None = 0,

		/// <summary>
		/// <see cref="Success"/> mean data is wrapped successfully & ready to use...
		/// </summary>
		Success = 2,

		/// <summary>
		/// <see cref="Error"/> conveys some error is occured & data is can't be used & error message can be used for panics...
		/// </summary>
		Error = 4,
	}
}