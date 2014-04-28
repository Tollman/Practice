using Practice.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace Practice.Client
{
	static class Program
	{
		internal static string TrunkUrl;
        internal static string CarUrl;
        internal static string TypeUrl;
        internal static string InfoUrl;

		static Program()
		{
			TrunkUrl = ConfigurationManager.AppSettings["trunkServiceUrl"];
            CarUrl = ConfigurationManager.AppSettings["carServiceUrl"];
            TypeUrl = ConfigurationManager.AppSettings["typeServiceUrl"];
            InfoUrl = ConfigurationManager.AppSettings["infoServiceUrl"];
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.ThreadException += Application_ThreadException;
			//Application.Run(new MainWindow());
			Application.Run(new MainWindow());
		}

		static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			if (e.Exception != null)
			{

			}
		}
	}
}
