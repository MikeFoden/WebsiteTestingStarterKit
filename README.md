# Website Testing Starter Kit

This project is all about making it as easy as possible to get on to writing the great websites, without being bogged down in getting your automated testing up and running.

The projects combines the power of the xUnit Testing Framework with the Selenium Web Driver in order to make sure everything is working as planned.

## Requirements

* .NET Version Manager (DNVM)
* Visual Studio will support running Tests in a GUI (see the [xUnit Documentation](https://xunit.github.io/docs/getting-started-dnx.html#run-tests-vs))

## Installation

Make sure you have .NET Version Manager (DNVM) command line tool installed (for installations check the [ASP.NET 5 Docs](https://docs.asp.net/en/latest/getting-started/index.html).

Once it is installed, make sure you perform a `dnu restore` to get all the packages.

This project has been defaulted to use the Firefox Driver so make sure you have that installed also.

From there, open a console/terminal and navigate to the Tests directory.

Run the command `dnx test` command to run the tests.

## Submitting Issues

If you find an issue, feel free to submit the issue directly to the [repository](https://github.com/MikeFoden/WebsiteTestingStarterKit/issues).