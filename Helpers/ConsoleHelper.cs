	#region References

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace Timeliner.Helpers
{
	public static class ConsoleHelper
	{
		public const string CONST_BinPath = @"D:\bin";
		public const string CONST_WorkPath = @"D:\work";
		public const string CONST_DefaultProject = @"wa";
		public const string CONST_TempExtension = ".tmp";

		public static string GetTempFromExe(string exe)
		{
			return exe.Replace(".exe", CONST_TempExtension + ".exe");
		}

		public static string GetExeFromTemp(string tmp)
		{
			return tmp.Replace(CONST_TempExtension, "");
		}

		public static void PrintArgs(string[] args)
		{
			Console.WriteLine("Arguments:");

			for (int i = 0; i < args.Length; i++)
			{
				Console.WriteLine("{0} => {1}", i, args[i]);
			}
		}

		public static string GetArg(string[] args, int index)
		{
			if (args == null)
			{
				return null;
			}

			if (args.Length > index)
			{
				return args[index];
			}

			return null;
		}

		public static string GetWAPath(string path)
		{
			return string.Format(@"{0}\{1}\{2}", CONST_WorkPath, CONST_DefaultProject, path);
		}

		public static void SetTitle(string title)
		{
			Console.WriteLine("===============================================================================");
			Console.WriteLine(title);
			Console.Title = title;
		}

		public static Process RunProcess(string filename, string args = null, string workingDirectory = null, ProcessWindowStyle windowStyle = ProcessWindowStyle.Normal, bool waitForExit = false)
		{
			if (string.IsNullOrEmpty(workingDirectory))
			{
				workingDirectory = Path.GetDirectoryName(filename);
			}

			Process process = new Process
							  {
								  StartInfo =
									  {
										  FileName = filename,
										  Arguments = args,
										  WorkingDirectory = workingDirectory,
										  UseShellExecute = false,
										  RedirectStandardInput = true,
										  RedirectStandardOutput = true,
										  RedirectStandardError = true,
										  CreateNoWindow = true,
										  WindowStyle = windowStyle
									  }
							  };
			process.Start();

			if (waitForExit && !process.HasExited)
			{
				process.WaitForExit();
			}

			return process;
		}

		public static Process RunProcess(string filename, string[] args, string workingDirectory = null, ProcessWindowStyle windowStyle = ProcessWindowStyle.Normal, bool waitForExit = false)
		{
			return RunProcess(filename, string.Join(" ", args), workingDirectory, windowStyle, waitForExit);
		}

		public static string GetProcessResult(string filename, string args = null, string workingDirectory = null, ProcessWindowStyle windowStyle = ProcessWindowStyle.Normal)
		{
			Process process = RunProcess(filename, args, workingDirectory, windowStyle, true);
			string result = process.StandardOutput.ReadToEnd();
			process.Close();
			return result;
		}

		public static string GetProcessResult(string filename, string[] args, string workingDirectory = null, ProcessWindowStyle windowStyle = ProcessWindowStyle.Normal)
		{
			return GetProcessResult(filename, string.Join(" ", args), workingDirectory, windowStyle);
		}

		public static string GetBin(string binName)
		{
			return string.Format(@"{0}\{1}", CONST_BinPath, binName);
		}

		public static string GetCurrentDir()
		{
			return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
		}

		public static void CheckDirExists(string dir, bool throwException)
		{
			if (!Directory.Exists(dir))
			{
				if (throwException)
				{
					throw new DirectoryNotFoundException(string.Format("Directory {0} doesn't exist!", dir));
				}

				Directory.CreateDirectory(dir);
			}
		}

		public static void ShutDown()
		{
			Process.Start("shutdown.exe", "/p");
		}

		public static void Hibernate()
		{
			Process.Start("shutdown.exe", "/h");
		}

		public static void DieIfExists(Process process = null)
		{
			if (process == null)
				process = Process.GetCurrentProcess();

			if (Process.GetProcessesByName(process.ProcessName).Length > 1)
			{
				Die(process);
			}
		}

		public static void DieTemporary(Process process = null)
		{
			if (process == null)
				process = Process.GetCurrentProcess();

			if (process.ProcessName.EndsWith(CONST_TempExtension))
			{
				string filename = GetExeFromTemp(process.MainModule.FileName);
				DeleteExecutable(GetExeFromTemp(process.ProcessName), filename);
				File.Copy(process.MainModule.FileName, filename);
				Process.Start(filename);
				
			}
			else
			{
				string filename = GetTempFromExe(process.MainModule.FileName);
				DeleteExecutable(GetTempFromExe(process.ProcessName), filename);
			}
		}

		public static void DeleteExecutable(string processName, string filename)
		{
			if (!File.Exists(filename))
			{
				return;
			}

			DenyExecute(filename);

			Process.GetProcessesByName(processName)
				.Where(pr => pr.MainModule.FileName == filename)
				.ToList()
				.ForEach(Die);

			while (true)
			{
				try
				{
					File.Delete(filename);
					break;
				}
				catch (IOException)
				{
					Thread.Sleep(100);
				}
				catch (UnauthorizedAccessException)
				{
					Thread.Sleep(100);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private static void DenyExecute(string filename)
		{
			SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);

			FileSecurity security = File.GetAccessControl(filename);
			security.AddAccessRule(new FileSystemAccessRule(sid, FileSystemRights.ExecuteFile, AccessControlType.Deny));
			File.SetAccessControl(filename, security);
		}

		public static void Die(Process process = null)
		{
			if (process == null)
				process = Process.GetCurrentProcess();

			process.Kill();
		}

		public static void DieAll(Process process = null, bool leaveCurrent = false)
		{
			if (process == null)
				process = Process.GetCurrentProcess();

			DieAll(process.ProcessName, process.Id);
			
			if (!leaveCurrent)
				process.Kill();
		}

		public static void DieAll(string processName, int excludeProcessId = 0)
		{
			foreach (Process process1 in Process.GetProcessesByName(processName)
												.Where(process1 => excludeProcessId == 0 && process1.Id != excludeProcessId))
			{
				process1.Kill();
			}
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		private const int SW_MINIMIZE = 6;
		private const int SW_MAXIMIZE = 3;
		private const int SW_RESTORE = 9;

		public static IntPtr GetHandle(Process process = null)
		{
			if (process == null)
			{
				process = Process.GetCurrentProcess();
			}

			return process.MainWindowHandle;
		}

		public static void Minimize(Process process = null)
		{
			ShowWindow(GetHandle(process), SW_MINIMIZE);
		}

		public static void Maximize(Process process = null)
		{
			ShowWindow(GetHandle(process), SW_MAXIMIZE);
		}

		public static void Restore(Process process = null)
		{
			ShowWindow(GetHandle(process), SW_RESTORE);
		}
	}
}