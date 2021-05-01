# GTD Desk

Windows app for organizing "Getting Things Done" projects

## CLI

Project is starting as a console app aka command line interface.

Run `GTDDesk_CLI.exe` to start.
- Currently lists the first task from each project

## Folder and File Structure

The app expects to find text files in the `Directory` and in its subdirectories. Each text file is one GTD project. Tasks in each file are separated by one or more blank lines.

## Configuration

Add a text file called `appsettings.json` in the directory where the `exe` lives.

Template:
```
{
	"Directory": "full_path_to_directory_containing_project_files",
	"IncludeSubDirectories": false
}
```

**Directory** is required.  

**IncludeSubDirectories** defaults to `false`. If true, subdirectories of `Directory` will be recursively searched for more projects.
