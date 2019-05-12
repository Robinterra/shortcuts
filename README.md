# C# Windows Shortcuts

This is a small project to create/read/modify Windows Shortcuts

## Getting Started

Run *make.bat* to compile *src/Shortcuts.cs* to dll File.
OR Include this *Shortcuts.cs* file in your Project.
The Shortcuts.cs is in namespace *System.IO*.

### Prerequisites

* Microsoft Windows Vista or higher
* Microsoft .NET Framework 4.0 or higher

## Running the tests

Run the make.bat and the Test will run.

### Break down into end to end tests

Create/Read/Modify in *C:\TEMP* a *test.lnk*.

## Built With

* C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe

## Example

### Create new Shortcut
```
Shortcuts shortcut = new Shortcuts (  );
shortcut.TargetPath = @"C:\Users\N0vu2\AppData\Local\Google\Chrome SxS\Application\chrome.exe";
shortcut.Arguments = "http://wiki.versalitic.com/index.php/Hauptseite";
shortcut.Write ( @"C:\Users\N0vu2\Desktop\myshortcut.lnk" );
```

### Modify a Shortcut
```
Shortcuts shortcut = new Shortcuts ( @"C:\Users\N0vu2\Desktop\myshortcut.lnk" );
shortcut.Arguments = "https://github.com";
shortcut.Write ( @"C:\Users\N0vu2\Desktop\myshortcut.lnk" );
```

## Authors

* **Robin D'Andrea** - *Robinterra* - [Robinterra](https://github.com/Robinterra)