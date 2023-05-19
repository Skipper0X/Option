namespace GCore.Runtime.OptionsLib.Runtime
{
	/// <summary>
	/// <see cref="OptionReport{TReturn}"/> Is Struct Which Contains <see cref="Option{TReturn}"/> Data Which Can Be Stored
	/// On Heap, Or Can Be Used In Case Of Async/Await Operations...
	/// </summary>
	public readonly struct OptionReport<TReturn>
	{
		public readonly TReturn Data;
		public readonly OptionStatus Status;

		internal OptionReport(TReturn data, OptionStatus status)
		{
			Data = data;
			Status = status;
		}
	}
}