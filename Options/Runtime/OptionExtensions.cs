namespace GCore.Runtime.OptionsLib.Runtime
{
	public static class OptionExtensions
	{
		/// <summary>
		/// <see cref="ToOption{TReturn}"/> Is Going TO Create An Option & Wrap The Given Data In It,
		/// If The Data is default(As Per EqualityCompare) Then Option Will Return With Status: None & No Data...
		/// </summary>
		public static Option<TReturn> ToOption<TReturn>(this TReturn data)
		{
			if (data == null) return Options.None<TReturn>();
			return Options.Ok(data);
		}

		/// <summary>
		/// <see cref="ToReport{TReturn}"/> Is Going To Create A Report With Option's Data & Returns It..
		/// Note: Only Use When Using Inside Async Operations Cz Async Op Won't Let Us Use <see cref="Option{TReturn}"/> ref struct
		/// Inside It...
		/// </summary>
		public static OptionReport<TReturn> ToReport<TReturn>(this Option<TReturn> option)
			=> new(option.UnWrap(), option.Status);
	}
}