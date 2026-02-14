CREATE TABLE dbo.Users
(
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    [Password] NVARCHAR(255) NOT NULL,
    [Status] SMALLINT NOT NULL
);

CREATE TABLE dbo.TaskTypes
(
    TaskTypeID INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    DateOfCreation DATETIME NULL,
    Color NVARCHAR(50) NULL,
    [Description] NVARCHAR(500) NULL,
    UserID INT NULL,

    CONSTRAINT FK_TaskTypes_Users
        FOREIGN KEY (UserID)
        REFERENCES dbo.Users(UserID)
        ON DELETE SET NULL
);

CREATE TABLE dbo.Tasks
(
    TaskID INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(200) NOT NULL,
    [Description] NVARCHAR(1000) NULL,
    [Status] SMALLINT NOT NULL,
    PriorityLevel SMALLINT NULL,
    DueDate DATETIME NULL,
    TaskTypeID INT NOT NULL,

    CONSTRAINT FK_Tasks_TaskTypes
        FOREIGN KEY (TaskTypeID)
        REFERENCES dbo.TaskTypes(TaskTypeID)
        ON DELETE CASCADE
);

CREATE INDEX IX_Tasks_TaskTypeID
ON dbo.Tasks(TaskTypeID);

CREATE INDEX IX_TaskTypes_UserID
ON dbo.TaskTypes(UserID);
