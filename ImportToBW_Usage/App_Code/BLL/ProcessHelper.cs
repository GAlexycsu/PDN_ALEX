using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Management;
using System.Diagnostics;

/// <summary>
/// Summary description for ProcessHelper
/// </summary>
public class ProcessHelper
{
	public ProcessHelper()
	{
		
	}
    public string GetProcessOwner(int processId)
    {
        string query = "Select * From Win32_Process Where ProcessID = " + processId;
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
        ManagementObjectCollection processList = searcher.Get();

        foreach (ManagementObject obj in processList)
        {
            string[] argList = new string[] { string.Empty, string.Empty };
            int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
            if (returnVal == 0)
            {
                return argList[1] + "\\" + argList[0];   // return DOMAIN\user
            }
        }
        return "NO OWNER";
    }
    public void KillProcessByNameAndUser(string ProcessName, string ProcessUserName, int HasStartedForHours)
    {
        Process[] foundProcesses = Process.GetProcessesByName(ProcessName);
        Console.WriteLine(foundProcesses.Length.ToString() + " processes found.");
        string strMessage = string.Empty;
        foreach (Process p in foundProcesses)
        {
            string UserName = GetProcessOwner(p.Id);
            strMessage = string.Format("Process Name: {0} | Process ID: {1} | User Name : {2} | StartTime {3}",
                                             p.ProcessName, p.Id.ToString(), UserName, p.StartTime.ToString());
            //Console.WriteLine(strMessage);
            bool TimeExpired = (p.StartTime.AddHours(HasStartedForHours) < DateTime.Now) || HasStartedForHours == 0;
            bool PrcoessUserName_Is_Matched = UserName.Equals(ProcessUserName);

            if ((ProcessUserName.ToLower() == "all" && TimeExpired) ||
                 PrcoessUserName_Is_Matched && TimeExpired)
            {
                p.Kill();
                //Console.WriteLine("Process ID " + p.Id.ToString() + " is killed.");
            }
        }
    }
}