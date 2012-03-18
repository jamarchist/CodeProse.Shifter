using System.Data;
using System.IO;
using Dapper;

namespace CodeProse.Shifter.data
{
    public static class DatabaseInitializationExtensions
    {
        public static void CreateTables(this IDbConnection connection)
        {
            connection.CreateUsersTable();
            connection.CreateRecurringShiftTimesTable();
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
    RecurringShiftTimeId GUID NULL
,   Day INTEGER NOT NULL
,   Month INTEGER NOT NULL
,   Year INTEGER NOT NULL
,   StartHour INTEGER NOT NULL
,   StartMinute INTEGER NOT NULL
,   EndHour INTEGER NOT NULL
,   EndMinute INTEGER NOT NULL
,   UserId NVARCHAR(20) NOT NULL
,   PRIMARY KEY (Day, Month, Year, StartHour, StartMinute, EndHour, EndMinute, UserId)
,   FOREIGN KEY (RecurringShiftTimeId) REFERENCES RecurringShiftTimes (Id)
);");
        }

        private static void CreateRecurringShiftTimesTable(this IDbConnection connection)
        {
            connection.Execute(@"
CREATE TABLE IF NOT EXISTS RecurringShiftTimes
(
    Id GUID PRIMARY KEY NOT NULL
,   StartHour INTEGER NOT NULL
,   StartMinute INTEGER NOT NULL
,   EndHour INTEGER NOT NULL
,   EndMinute INTEGER NOT NULL
,   RepeatsOnMonday BIT NOT NULL
,   RepeatsOnTuesday BIT NOT NULL
,   RepeatsOnWednesday BIT NOT NULL
,   RepeatsOnThursday BIT NOT NULL
,   RepeatsOnFriday BIT NOT NULL
,   RepeatsOnSaturday BIT NOT NULL
,   RepeatsOnSunday BIT NOT NULL
,   StartDate DATETIME NOT NULL
,   EndDate DATETIME NOT NULL
);");
        }
    }
}