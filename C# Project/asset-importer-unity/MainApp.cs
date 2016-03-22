using System;

namespace AREN
{
	public class MainApp
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main ()
		{
			AutomatedImport nProgram = new AutomatedImport ();
			nProgram.QueryUsers ();
		}
	}
}
