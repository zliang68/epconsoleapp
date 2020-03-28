# EP Development Task 

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

## Development Notes

This console application is developed in .Net Core 2.202 using Visual Studio 2019.
* CSVHelper is used for CSV parsing
* XUnit is used for unit testing

## Solution structure

There are three projects in this solution:
* ConsoleEPTest - Main program to process files
* CsvFileLib - A library defines constants, models and services 
* UnitTests - Unit tests for this application

### Configuration

Appsetting.json is used to define configuration setting.
```
{
  "CsvFile": {
    "FilePath": "C:\\ErmPower\\SampleFiles",
    "LpFilePrefix": "LP_",
    "TouFilePrefix": "TOU_",
    "DetectPercentage": 20
  }
}
```

## How to run this application

### Within Visual Studio 
* Open the solution in Visual Studio 2019, 
* Update AppSetting.json to set CsvFilePath to path of target CSV file(s),
* press F5 to run the program

### From Commandline
* Open a Command Prompt window;
* Go to the folder containing ConsoleEPTest.dll, run following command: 
```
  dotnet run ConsoleEPTest.dll
```

## Author

* David Liang
