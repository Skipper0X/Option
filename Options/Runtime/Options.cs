namespace GCore.Runtime.OptionsLib.Runtime
{
	/// <summary>
	/// <see cref="Options"/> Is A Factory To Create <see cref="Option{TReturn}"/> With Respective Response....
	/// </summary>
	public static class Options
	{
		/// <summary>
		/// <see cref="None{TReturn}"/> returns a <see cref="Option{TReturn}"/> with all none cases & no data...
		/// </summary>
		public static Option<TReturn> None<TReturn>() => new(OptionStatus.None, default, default);

		/// <summary>
		/// <see cref="Ok{TReturn}"/> provides the <see cref="Option{TReturn}"/> with Success & Given Ok Data...
		/// </summary>
		/// <param name="ok">Data to wrap in option</param>
		/// <returns>InstanceOf <see cref="Option{TReturn}"/></returns>
		public static Option<TReturn> Ok<TReturn>(TReturn ok) => new(OptionStatus.Success, ok, default);

		/// <summary>
		/// <see cref="Error{TReturn}"/> creates an instanceOf <see cref="Option{TReturn}"/> with the given error & error status 
		/// </summary>
		/// <param name="error">error to use for panics</param>
		/// <returns>InstanceOf <see cref="Option{TReturn}"/></returns>
		public static Option<TReturn> Error<TReturn>(string error) => new(OptionStatus.Error, default, error);
	}
}