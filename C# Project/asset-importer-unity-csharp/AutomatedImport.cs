using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AREN
{
	public class AutomatedImport
	{
		const string unityAssetRootPath = "/Assets/";
		string unityApplicationPath = null;
		string assetPath = null;
		string projectPath = null;

		/// <summary>
		/// Queries the user for the required paths. Also, moves the asset into the selected Unity project.
		/// </summary>
		public void QueryUsers ()
		{
			unityApplicationPath = GetUnityPath ();
			assetPath = GetAssetPath ();
			projectPath = GetProjectPath ();

			if (unityApplicationPath != null && assetPath != null && projectPath != null) { 
				// Move the asset folder into the Unity project and reset the assetPath to the new path in the Unity project.
				Directory.Move (assetPath, projectPath + unityAssetRootPath + Path.GetFileName (assetPath));
				assetPath = projectPath + unityAssetRootPath + Path.GetFileName (assetPath);

				RunImport ();
			} else {
				MessageBox.Show ("Error: Not all files selected! Exiting program.");
			}
		}

		/// <summary>
		/// Gets the path to the Unity application on the users computer.
		/// </summary>
		private static string GetUnityPath ()
		{
			OpenFileDialog path = new OpenFileDialog ();
			path.Title = "Select Your Unity Application";
			path.RestoreDirectory = true;
			path.Multiselect = false;

			if (Environment.OSVersion.Platform == PlatformID.MacOSX || Environment.OSVersion.Platform == PlatformID.Unix) {
				path.InitialDirectory = "/Applications/";
			} else {
				path.InitialDirectory = "/Desktop/";
			}
				
			if (path.ShowDialog () == DialogResult.OK) {
				return path.FileName;
			} else {
				return null;
			}
		}

		/// <summary>
		/// Gets the path to the asset that needs to be imported and converted.
		/// </summary>
		private static string GetAssetPath ()
		{
			FolderBrowserDialog aPath = new FolderBrowserDialog ();
			aPath.Description = "Select the Asset Folder to Export";
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
		private static string GetProjectPath ()
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
		private void RunImport ()
		{
			Process process = new Process ();
			ProcessStartInfo startInfo = new ProcessStartInfo ();

			startInfo.FileName = unityApplicationPath;
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			startInfo.Arguments = string.Format ("-projectPath {0} -quit -batchmode -nographics -executeMethod Import.HandleFiles {1}", projectPath, assetPath);
			process.StartInfo = startInfo;
			process.Start ();
		}
	}
}
	