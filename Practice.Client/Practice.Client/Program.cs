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
		public static ITrunkRepository trunkRepo;

		static Program()
		{
			string typeStr = ConfigurationManager.AppSettings["trunkRepository"];
			Type type = Type.GetType(typeStr);
			trunkRepo = (ITrunkRepository)Activator.CreateInstance(type);
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new MainWindow());
			Application.Run(new MainWindow());
		}
	}
}
