# asset-importer-unity-csharp

IDE: Xamarin Studio 5.10.3 / Language: C# / OSX and Windows

The goal of this program is to import FBX, OBJ, MAT, MTL, PNG, and other asset files into Unity from a local location
on the user's disk. The program does this by requiring the user to put all assets into a clearly labeled folder and select
that folder, the location of the Unity application being used, and the location of the Unity project that contains the scripts
necessary for converstion to asset bundles. 

### REQUIRED

So, what is required: 

- folder clearly labeled by the user that contains all assets
- the paths of the Unity application and the Unity project being used for import, the folder containing the assets
- the Unity project must have the scripts written for applying the assets to a scene and then creating an asset bundle

### INSTRUCTIONS ###

1. Open the .csproj file and run the program in Xamarin Studio.
2. You will be prompted to select your Unity application. Select your Unity application. If using Mac, select Unity.app > Contents > MacOS > Unity. Choosing an alias of the Unity app will not work.
3. You will be prompted to select the folder containing the assets you wish to import. Select the folder.
4. You will be prompted to select the Unity project containg the necessary Import scripts that will convert the imported files to an asset bundle. Select that project folder. Needs to be the root folder.
5. The import and asset bundle conversion process will automatically take over and an asset bundle will be created inside of the Unity project at: Unity Project -> Assets -> Asset Bundles.

### TODO (as of 2016 March 24 : Dori C.)

- (low priortity) need to check code for handling errors and null references.
- (high priority) need to hard code the Unity app, the asset folder, and Unity project paths. In the future, these will no longer need to be chosen by a user.

### ISSUES 
**[Selecting the correct Unity application path on a Mac]**

When selecting the Unity application path on OS X, the /Applications/ folder will be the initial directory. The correct path is: 

> /Applications/Unity.app/Contents/MacOS/Unity

**[Hard coding the Unity and Unity project applications in future push]**

The majority of the import and asset bundle creation code will be on an AWS Server and web app. This code will need to be translated and moved.

**[Unable to run program on OS X (System.x missing errors)]**

Ensure that mscorlib.dll is added to the project references: 

  *Step 1:* right-click on the csproj file in the solution window 

  *Step 2:* select 'Edit References' 
  
  *Step 3:* go to '.Net Packages' 
  
  *Step 4:* click 'Browse' and navigate to the following location:
  
> /Library/Frameworks/Mono.framework/Versions/4.2.3/lib/mono/4.5/mscorlib.dll

**[Cannot move directories across volumes on Windows]**

The program will not be able to move files from one volume to another. For example, moving a directory from C:/ drive to E:/ drive will not work. The assets folders have to be in the same volume.

### CONTACT 
Dori Chan : doric@moback.com

:metal: :metal:
