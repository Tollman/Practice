using Practice.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Practice.Client
{
	public partial class CarWindow : Form
	{
		private Ilog logger;

		public CarWindow()
		{
			InitializeComponent();

			string typeStr = ConfigurationManager.AppSettings["CurrentLogger"];
			Type type = Type.GetType(typeStr);
			logger = (Ilog)Activator.CreateInstance(type);
			Load += CarWindow_Load;
		}

		private void CarWindow_Load(object sender, EventArgs e)
		{
			MessageBox.Show(logger.GetType().ToString());
		}

		public List<IMonster> objects = new List<IMonster>();

		void Method()
		{
			logger.Log("");
			if (logger is ICleanable)
			{
				(logger as ICleanable).Clean();
			}

			objects.Add(new MyClass());
			objects.Add(new MyClass2());

			foreach (var item in objects)
			{
				item.Kill();
			}
		}
	}

	public interface Ilog
	{
		void Log(string msg);
	}

	public interface ICleanable
	{
		void Clean();
	}

	public class ConsoleLogger : Ilog
	{
		public void Log(string msg)
		{
			Console.WriteLine(msg);
		}
	}

	public class FileLogger : Ilog, ICleanable
	{
		public void Log(string msg)
		{
			using (var sw = System.IO.File.AppendText(@"D:\1.txt"))
			{
				sw.WriteLine(msg);
			}
		}

		public void Clean()
		{
			System.IO.File.Delete(@"D:\1.txt");
		}
	}

	public interface IMonster
	{
		void Kill();
	}

	class MyClass : IMonster
	{
		public void Kill()
		{
			//dsfsdfs
		}
	}

	class MyClass2 : IMonster
	{
		public void Kill()
		{
			//dsfsdfs
		}
	}
}
