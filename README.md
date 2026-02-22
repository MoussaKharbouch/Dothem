# Dothem

**Dothem** is a lightweight and efficient task management application designed to help individuals organize their daily tasks effectively. It provides robust features, such as adding tasks, managing priorities, tracking progress, and saving data locally for better control and privacy.

---

## **Table of Contents**
1. [Overview](#overview)
2. [Core Features](#core-features)
    - [Task Management](#task-management)
    - [Task Status](#task-status)
    - [Task Prioritization](#task-prioritization)
    - [Local Storage](#local-storage)
3. [System Structure](#system-structure)
    - [Business Layer](#business-layer)
    - [Data Layer](#data-layer)
    - [Presentation Layer](#presentation-layer)
4. [Requirements](#requirements)
5. [Installation and Setup](#installation-and-setup)
    - [Database Configuration](#database-configuration)
    - [Building and Running the Project](#building-and-running-the-project)
6. [Future Enhancements](#future-enhancements)

---

## **Overview**

The **Dothem** application was built to simplify task management by offering users powerful tools to create, manage, and track their daily tasks. The application features an intuitive design, effective data storage locally on the user's machine, and functionalities tailored to improve organization and productivity.

---

## **Core Features**

### **Task Management**
- Add new tasks quickly with details, including descriptive names and optional notes for better clarity.
  
### **Task Status**
- Each task can have one of the following statuses:
  - **Pending:** Tasks that are yet to begin.
  - **In Progress:** Tasks currently being worked on.
  - **Completed:** Tasks that are successfully finished.

### **Task Prioritization**
- Tasks can be assigned priority levels:
  - **Low**
  - **Medium**
  - **High**

### **Local Storage**
- All tasks and their statuses are securely stored locally in a database on the user's machine.

---

## **System Structure**

The repository follows a layered architecture approach:

### **1. Business Layer**
Located in the [`BUSINESS_LAYER`](https://github.com/MoussaKharbouch/Dothem/tree/main/BUSINESS_LAYER) directory, this layer contains the application logic.  
It is responsible for:
- Deciding how to handle user commands and requests.
- Communicating with the data layer to fetch or persist information.
- Managing validations (e.g., ensuring a task isn’t marked complete on creation).

### **2. Data Layer**
The [`DATA_LAYER`](https://github.com/MoussaKharbouch/Dothem/tree/main/DATA_LAYER) directory encapsulates database-related interactions, including:
- Data access methods.
- Classes for managing and querying task entries stored in the database.
- The backup of the database is provided under [DB_Backup.sql](https://github.com/MoussaKharbouch/Dothem/blob/main/DB_Backup.sql) for initializing project data.

### **3. Presentation Layer**
The [`PRESENTATION_LAYER`](https://github.com/MoussaKharbouch/Dothem/tree/main/PRESENTATION_LAYER) directory deals with:
- The graphical user interface (GUI) of the application.
- Ensuring a smooth user experience with an intuitive and clean design.
- Includes views and forms for creating, editing, and deleting tasks.

---

## **Requirements**

- **Task Registration:** Add detailed tasks with descriptive fields.
- **Task Status:** Tasks must have distinguishable statuses like "In Progress", "Completed", or "Pending".
- **Task Importance:** Assign tasks as low, medium, or high priority.
- **Local Login:** User authentication using local credentials.
- **Database Storage:** All task-related information is stored in a local SQL Server database.

---

## **Installation and Setup**

### **1. Prerequisites**
- Windows OS
- [Visual Studio](https://visualstudio.microsoft.com/) (2019 or later recommended).
- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework) installed on your system.
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) for managing the database.

### **2. Database Configuration**
1. Restore the database using the provided [`DB_Backup.sql`](https://github.com/MoussaKharbouch/Dothem/blob/main/DB_Backup.sql) file:
    - Open SQL Server Management Studio (SSMS).
    - Open the `DB_Backup.sql` file.
    - Run the query to set up the database.

2. Verify the database schema for task-related tables:
    - Ensure there are tables for `tasks` with fields for title, status, and priority.
    - Double-check that any necessary relationships between tables are implemented correctly.

### **3. Build and Run the Solution**
1. Open the `Dothem.sln` file in Visual Studio.
2. Restore NuGet packages and ensure all dependencies are installed.
3. Build the solution to compile the application.
4. Run the project using the Visual Studio debugging tools.

---

## **Future Enhancements**

We envision adding advanced features to the application in the future:
- **Recurring Tasks:** Enable users to schedule recurring tasks (daily, weekly, monthly).
- **Notification System:** Set up reminders and notifications for pending tasks.
- **Search and Filter Options:** Introduce advanced filters for better task management.