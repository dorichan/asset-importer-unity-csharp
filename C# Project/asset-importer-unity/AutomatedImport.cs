using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBXImport
{
    public class AutomatedImport
    {
		string unityApplicationPath = null;
		string assetPath = null;
		string projectPath = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
			AutomatedImport nProgram = new AutomatedImport ();
			nProgram.QueryUsers ();
        }

		/// <summary>
		/// Queries the user for the required paths. Also, moves the asset into the selected Unity project.
		/// </summary>
		private void QueryUsers()
		{
			unityApplicationPath = GetUnityPath ();
			assetPath = GetAssetPath();
			projectPath = GetProjectPath();

			if (unityApplicationPath != null && assetPath != null && projectPath != null) { 
				// Move the asset folder into the Unity project and reset the assetPath to the new path in the Unity project.
				Directory.Move (assetPath, projectPath + "/Assets/" + Path.GetFileName (assetPath));
				Console.WriteLine (projectPath + "/Assets/" + Path.GetFileName (assetPath));
				assetPath = projectPath + "/Assets/" + Path.GetFileName (assetPath);

				RunImport ();
			} else {
				MessageBox.Show ("Error: Not all files selected! Exiting program.");
			}
		}

		/// <summary>
		/// Gets the path to the Unity application on the users computer.
		/// </summary>
		private string GetUnityPath()
		{
			OpenFileDialog path = new OpenFileDialog ();
			path.Title = "Select Unity Application";
			path.InitialDirectory = "C:\\";
			path.RestoreDirectory = true;
			// Do not allow multi-select.
			path.Multiselect = false;

			if (path.ShowDialog () == DialogResult.OK) {
				return path.FileName;
			} else {
				return null;
			}
		}

		/// <summary>
		/// Gets the path to the asset that needs to be imported and converted.
		/// </summary>
		private string GetAssetPath()
		{
//			OpenFileDialog path = new OpenFileDialog ();
//			path.Title = "Select FBX file";
//			path.InitialDirectory = "C:\\";
//			path.RestoreDirectory = true;
//			// Allow the user to select multiple assets to import and convert.
//			path.Multiselect = true;
//
//			if (path.ShowDialog () == DialogResult.OK) { 
//				return path.FileName;
//			} else {
//				return null;
//			}

			FolderBrowserDialog aPath = new FolderBrowserDialog ();
			aPath.Description = "Select the Asset Folder";
			aPath.ShowNewFolderButton = false;

			if (aPath.ShowDialog () == DialogResult.OK) {
				return aPath.SelectedPath;
			} else {
				return null;
			}
		}

		/// <summary>
		/// Gets the path to the project that contains the scripts necessary to convert the imported assets to asset bundles.
		/// Requires that a Unity project already exists that is prepared to convert assets into asset bundles.
		/// Suggested File Name: fbx-import-project. Requres: ImportFBX script in Editor folder.
		/// </summary>
		private string GetProjectPath()
		{
			FolderBrowserDialog selectedFolder = new FolderBrowserDialog ();
			selectedFolder.Description = "Select the Unity Project";
			selectedFolder.ShowNewFolderButton = false;

			if (selectedFolder.ShowDialog () == DialogResult.OK) {
				return selectedFolder.SelectedPath;
			} else {
				return null;
			}
		}

		/// <summary>
		/// Runs the code necessary to import the assets into Unity and prepares them for conversion to asset bundles.
		/// </summary>
		private void RunImport()
		{
			var process = new Process();
			var startInfo = new ProcessStartInfo();

			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			startInfo.FileName = unityApplicationPath;

			startInfo.Arguments =  "-projectPath " + projectPath + " -executeMethod ImportFBX.Import " + assetPath;
			process.StartInfo = startInfo;
			process.Start();
		}
    }
}
