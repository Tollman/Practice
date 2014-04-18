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
		public static ICarRepository carRepo;
		public static ITypeRepository typeRepo;
		public static IInfoRepository infoRepo;

		static Program()
		{
			string typeStr1 = ConfigurationManager.AppSettings["trunkRepository"];
			string typeStr2 = ConfigurationManager.AppSettings["carRepository"];
			string typeStr3 = ConfigurationManager.AppSettings["typeRepository"];
			string typeStr4 = ConfigurationManager.AppSettings["infoRepository"];
			Type type1 = Type.GetType(typeStr1);
			Type type2 = Type.GetType(typeStr2);
			Type type3 = Type.GetType(typeStr3);
			Type type4 = Type.GetType(typeStr4);
			trunkRepo = (ITrunkRepository)Activator.CreateInstance(type1);
			carRepo = (ICarRepository)Activator.CreateInstance(type2);
			typeRepo = (ITypeRepository)Activator.CreateInstance(type3);
			infoRepo = (IInfoRepository)Activator.CreateInstance(type4);
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
