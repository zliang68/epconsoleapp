# Erm Power Development Task 

Given a list of CSV files in two file types: LP and TOU
* LP file value column header: 'Data Value'
* TOU file value column header: 'Energy'

The task is to:

* Calculate the median value of each file
* Find exceeding values either 20% height than the median value of 20% lower than the median value
* Display exceeding values to Console in following format (datetime from the record):
```
fileName datetime dataValue medianValue 
```

## This is a console program developed in .Net Core 2.202

Visual Studio 2019 solution is used to develop the console program.

## How to run the program

Open the solution in Visual Studio 2019, update AppSetting.json to set CsvFilePath to path of target CSV file,
* press F5 to run the program from Visual Studio; or
* navigate to '.\ConsoleEPTest\bin\debug\netcoreapp2.2 folder, run: dotnet run ConsoleEPTest.dll

## Solution structure

There are three projects in this solution:
* ConsoleEPTest - contains main program using CsvFileLib;
* CsvFileLib - contains constants, models and services;
* UnitTests - Unit tests using CsvFileLib to test its services.

## Author

* David Liang
