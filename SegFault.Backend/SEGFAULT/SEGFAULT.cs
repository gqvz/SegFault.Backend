namespace SegFault.Backend.SEGFAULT;

public class SEGFAULT
{
	public static void Main(string[] args)
	{
	System.Runtime.InteropServices.Marshal.FreeHGlobal(IntPtr.MaxValue);
	}
}