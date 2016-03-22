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

### TODO (as of 2016 March 22 : Dori C.)

- (medium priortity) need to check code for handling errors and null references.
- (high priority) need to write Unity-side code to handle applying assets to a scene and building asset bundles.

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

### CONTACT 
Dori Chan : doric@moback.com

:metal: :metal:
