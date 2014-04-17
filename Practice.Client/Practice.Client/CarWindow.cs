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
			string data = System.IO.File.ReadAllText(@"G:\StorageScp2.cs");

			MySb sb = new MySb(data);
			int gen = GC.GetGeneration(sb);
			StringBuilder sb2 = new StringBuilder(data);
			int gen2 = GC.GetGeneration(sb2);

			MessageBox.Show(logger.GetType().ToString());

			try
			{
				Do3();
			}
			catch (MyException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void Do3()
		{
			throw new MyException("Hello from exception");

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

	[Serializable]
	public class MyException : ApplicationException
	{
		public MyException(string msg)
			: base(msg)
		{

		}
	}

	public class MySb
	{
		private char[] array;

		public MySb(string input)
		{
			array = new char[input.Length];

			for (int i = 0; i < input.Length; i++)
			{
				array[i] = input[i];
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
