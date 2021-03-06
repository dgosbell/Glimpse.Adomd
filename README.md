# Glimpse.Adomd
Glimpse support for ADOMD components

[![Build status](https://ci.appveyor.com/api/projects/status/ah7v9e26agnm67ql/branch/master?svg=true)](https://ci.appveyor.com/project/ogaudefroy/glimpse-adomd/branch/master) [![NuGet version](https://badge.fury.io/nu/Glimpse.Adomd.svg)](https://badge.fury.io/nu/Glimpse.Adomd)

![Screenshot](/doc/screenshot.png)

Requires the usage of [Microsoft.AnalysisServices.AdomdClient.Abstractions](https://github.com/ogaudefroy/Microsoft.AnalysisServices.AdomdClient.Abstractions) to support native component substitution.

## Setup
 - Replace your regular AdomdConnection with GlimpseAdomdConnection
 - You can create your command by
	 - Calling the CreateCommand method available in the connection
	 - Instantiating a new GlimpseAdomdCommand

## Usage
```C#
    using (var conn = new GlimpseAdomdConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [Date].[Calendar Year].[StrToMember(@CalendarYear)] on 0 FROM [Adventure Works];";
                var parameter = cmd.CreateParameter();
                parameter.ParameterName = "CalendarYear";
                parameter.Value = "CY 2012";
                cmd.Parameters.Add(parameter);
                return cmd.ExecuteCellSet();
            }
```