-- ???? ??????????
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Username NVARCHAR(15) NOT NULL,
    Password NVARCHAR(20) NOT NULL,
    Status smallint,
    PriorityLevel INT
);

-- ???? ????? ??????
CREATE TABLE TaskTypes (
    TaskTypeID INT PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL,
    DateOfCreation DATE,
    Color NVARCHAR(50),
    Description NVARCHAR(200),
    UserID INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- ???? ?????????
CREATE TABLE Settings (
    SettingsID INT PRIMARY KEY
);

-- ???? ??????
CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Status smallint,
    PriorityLevel smallint,
    DueDate DATE,
    TaskTypeID INT,
    BaseTaskID INT,
    FOREIGN KEY (TaskTypeID) REFERENCES TaskTypes(TaskTypeID),
    FOREIGN KEY (BaseTaskID) REFERENCES Tasks(TaskID) -- ????? ????? (task ????? ??? task ???)
);
