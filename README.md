# Open Files With Default App

[![](https://img.shields.io/github/release/litefeel/OpenFilesWithDefaultApp.svg?label=latest%20version)](https://github.com/litefeel/OpenFilesWithDefaultApp/releases)
[![](https://img.shields.io/github/license/litefeel/OpenFilesWithDefaultApp.svg)](https://github.com/litefeel/OpenFilesWithDefaultApp/blob/upm/LICENSE.md)
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://paypal.me/litefeel)

Open Files With Default App is just perfect Unity asset plugin to open file with system default Application.


## Feature list:

* Open files with default application
* No runtime resources required
* No scripting required


## Install

#### Using npm (Ease upgrade in Package Manager UI)**Recommend**

Find the manifest.json file in the Packages folder of your project and edit it to look like this:
``` js
{
  "scopedRegistries": [
    {
      "name": "My Registry",
      "url": "https://registry.npmjs.org",
      "scopes": [
        "com.litefeel"
      ]
    }
  ],
  "dependencies": {
    "com.litefeel.openfileswithdefaultapp": "1.5.0",
    ...
  }
}
```

#### Using git

Find the manifest.json file in the Packages folder of your project and edit it to look like this:
``` js
{
  "dependencies": {
    "com.litefeel.openfileswithdefaultapp": "https://github.com/litefeel/OpenFilesWithDefaultApp.git#1.5.0",
    ...
  }
}
```

#### Using .zip file (for Unity 5.0+)

1. Download `Source code` from [Releases](https://github.com/litefeel/OpenFilesWithDefaultApp/releases)
2. Extract the package into  `$UnityProject/Packages` or `$UnityProject/Assets/Plugins`


## How to use?

1. Select `Edit > Preferences… > Open Files With Default App` from the menu
2. Input the file extensions, like txt
3. Double click txt file, will open it with default application


## Support

* Create issues by issues page (https://github.com/litefeel/OpenFilesWithDefaultApp/issues)
* Send email to me: litefeel@gmail.com
