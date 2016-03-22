# asset-importer-unity

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

- (low priority) need to write in MacOS specific code. Currently, the file and folder open dialog code doesn't mesh well with Mac, resulting in hard-to-navigate UI.
- (medium priortity) need to check code for handling errors and null references.
- (high priority) need to write Unity-side code to handle applying assets to a scene and building asset bundles.

### PROBLEMS (as of 2016 March 22 : Dori C.)
- UI looks ugly on OS X (as outlined above in TODO section).

### CONTACT 
Dori Chan : doric@moback.com
