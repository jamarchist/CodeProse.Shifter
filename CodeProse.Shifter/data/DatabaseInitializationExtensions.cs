﻿using System.Data;
using System.IO;
using Dapper;

namespace CodeProse.Shifter.data
{
    public static class DatabaseInitializationExtensions
    {
        public static void CreateTables(this IDbConnection connection)
        {
            connection.CreateUsersTable();
            connection.CreateScheduledShiftsTable();
            connection.CreateAssignedShiftsTable();
        }

        public static void DropAndRecreateDatabase(string databaseName)
        {
            if (File.Exists(databaseName))
            {
                File.Delete(databaseName);
            }
        }

        private static void CreateUsersTable(this IDbConnection connection)
        {
            connection.Execute(@"
CREATE TABLE IF NOT EXISTS Users 
(
    Id GUID PRIMARY KEY NOT NULL, 
    UserName NVARCHAR(100) NOT NULL, 
    Password NVARCHAR(100),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    UNIQUE (FirstName, LastName),
    UNIQUE (Email),
    UNIQUE (UserName)
);");            
        }

        private static void CreateAssignedShiftsTable(this IDbConnection connection)
        {
            connection.Execute(@"
CREATE TABLE IF NOT EXISTS AssignedShifts
(
    ScheduledShiftId GUID NULL
,   Day INTEGER NOT NULL
,   Month INTEGER NOT NULL
,   Year INTEGER NOT NULL
,   StartHour INTEGER NOT NULL
,   StartMinute INTEGER NOT NULL
,   EndHour INTEGER NOT NULL
,   EndMinute INTEGER NOT NULL
,   UserId NVARCHAR(20) NOT NULL
,   PRIMARY KEY (Day, Month, Year, StartHour, StartMinute, EndHour, EndMinute, UserId)
,   FOREIGN KEY (ScheduledShiftId) REFERENCES ScheduledShifts (Id)
);");
        }

        private static void CreateScheduledShiftsTable(this IDbConnection connection)
        {
            connection.Execute(@"
CREATE TABLE IF NOT EXISTS ScheduledShifts
(
    Id GUID PRIMARY KEY NOT NULL
,   StartHour INTEGER NOT NULL
,   StartMinute INTEGER NOT NULL
,   EndHour INTEGER NOT NULL
,   EndMinute INTEGER NOT NULL
,   RepeatsOnMonday BIT NOT NULL DEFAULT 0
,   RepeatsOnTuesday BIT NOT NULL DEFAULT 0
,   RepeatsOnWednesday BIT NOT NULL DEFAULT 0
,   RepeatsOnThursday BIT NOT NULL DEFAULT 0
,   RepeatsOnFriday BIT NOT NULL DEFAULT 0
,   RepeatsOnSaturday BIT NOT NULL DEFAULT 0
,   RepeatsOnSunday BIT NOT NULL DEFAULT 0
,   StartDate DATETIME NOT NULL
,   EndDate DATETIME NOT NULL
);");
        }
    }
}