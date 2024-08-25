namespace SegFault.Backend.SEGFAULT;

public class SEGFAULT
{
	public unsafe static void Main(string[] args)
	{
		if (args.Contains("--unsafe"))
		{
			System.Runtime.InteropServices.Marshal.FreeHGlobal(IntPtr.Zero);
		}
	}
}