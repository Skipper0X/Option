using System;

namespace Options.Runtime
{
	/// <summary>
	/// Type Option represents an optional value: every Option is either Some and contains a value, or None, and does not
	/// </summary>
	public readonly ref struct Option<TReturn>
	{
		private readonly TReturn _ok;
		public readonly string Err;
		public readonly OptionStatus Status;

		/// <summary>
		/// Private .ctor to restrict creation of this type only through factory methods for proper results.. 
		/// </summary>
		private Option(OptionStatus status, TReturn ok, string error)
		{
			_ok = ok;
			Err = error;
			Status = status;
		}

		/// <summary>
		/// <see cref="UnWrap"/> provides the internally wrapped value in this option..
		/// </summary>
		/// <returns><see cref="TReturn"/>'s typeOf Instance</returns>
		public TReturn UnWrap() => _ok;

		/// <summary>
		/// <see cref="UnWrapOr()"/> provides the internally wrapped value if <see cref="OptionStatus"/> is Success
		/// otherwise returns the default value for current type...
		/// </summary>
		/// <returns><see cref="TReturn"/>'s typeOf Instance</returns>
		public TReturn UnWrapOr() => UnWrapOr(default);

		/// <summary>
		/// UnwrapOr(default) provides the internally wrapped value if <see cref="OptionStatus"/> is Success
		/// otherwise returns the given default value...
		/// </summary>
		/// <param name="default">default value to return in case of failure</param>
		/// <returns><see cref="TReturn"/>'s typeOf Instance</returns>
		public TReturn UnWrapOr(TReturn @default) => Status == OptionStatus.Success ? _ok : @default;

		/// <summary>
		/// <see cref="UnWrapOrGetFrom"/> provides the internally wrapped value if <see cref="OptionStatus"/> is Success
		/// otherwise gets value from the given provider & returns that...
		/// </summary>
		/// <param name="provider"></param>
		/// <returns></returns>
		public TReturn UnWrapOrGetFrom(Func<TReturn> provider) => Status == OptionStatus.Success ? _ok : provider();

		/// <summary>
		/// <see cref="None"/> returns a <see cref="Option{TReturn}"/> with all none cases & no data...
		/// </summary>
		public static Option<TReturn> None => new(OptionStatus.None, default, default);

		/// <summary>
		/// <see cref="Ok"/> provides the <see cref="Option{TReturn}"/> with Success & Given Ok Data...
		/// </summary>
		/// <param name="ok">Data to wrap in option</param>
		/// <returns>InstanceOf <see cref="Option{TReturn}"/></returns>
		public static Option<TReturn> Ok(TReturn ok) => new(OptionStatus.Success, ok, default);

		/// <summary>
		/// <see cref="Error"/> creates an instanceOf <see cref="Option{TReturn}"/> with the given error & error status 
		/// </summary>
		/// <param name="error">error to use for panics</param>
		/// <returns>InstanceOf <see cref="Option{TReturn}"/></returns>
		public static Option<TReturn> Error(string error) => new(OptionStatus.Error, default, error);
	}
}