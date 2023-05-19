using System;

namespace GCore.Runtime.OptionsLib.Runtime
{
	/// <summary>
	/// Type Option represents an optional value: every Option is either Some and contains a value, or None, and does not
	/// </summary>
	public readonly ref struct Option<TReturn>
	{
		public readonly string Error;
		public readonly OptionStatus Status;

		private readonly TReturn _ok;

		/// <summary>
		/// Private .ctor to restrict creation of this type only through factory methods for proper results.. 
		/// </summary>
		internal Option(OptionStatus status, TReturn ok, string error)
		{
			_ok = ok;
			Error = error;
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
		/// implicit operator to unwrap value direct into the left side...
		/// </summary>
		public static implicit operator TReturn(Option<TReturn> option) => option.UnWrap();
	}
}