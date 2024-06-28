# TimeTrack Employee Management System

TimeTrack Employee Management System is a comprehensive solution designed to streamline the management of employee records, time tracking, and various HR-related operations. It offers a robust set of features to handle employee data, calculate durations for work tasks, and facilitate efficient searching and management of employee information.

## Overview

This system is built to cater to businesses looking for an efficient way to manage employee details, work hours, and security levels within their organization. It leverages modern programming practices to ensure high performance, reliability, and ease of use. Whether you're a small business or a large enterprise, TimeTrack Employee Management System provides the tools you need to maintain an organized and efficient workforce.

## Features

- **Employee Management**: Add, edit, and view employee records with comprehensive details.
- **Duration Tracking**: Calculate and manage durations for work-related tasks with precision.
- **Advanced Searching**: Quickly find employee records based on various criteria such as ID, name, hiring date, and more.
- **Security Levels**: Assign and manage security levels to employees, enhancing data security and access control.
- **Gender and Hiring Date Analysis**: Filter and sort employees based on gender and hiring dates.
- **Customizable Employee Comparisons**: Compare employees based on hiring dates or other criteria to aid in decision-making processes.

## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

- .NET 6.0 SDK or later
- Visual Studio 2022 or any compatible IDE that supports .NET development

### Installation

1. Clone the repo.
2. Open the solution file (`TimeTrack.sln`) in Visual Studio.
3. Restore NuGet packages.
4. Build the solution to verify everything is set up correctly.
5. Run the application.

## Usage

To use the TimeTrack Employee Management System, start by adding employee records through the provided interface. You can then perform operations such as searching for employees, calculating work durations, and editing employee details as needed. Refer to the script documentation for detailed usage of specific functionalities.

## Scripts Highlight

### Duration.cs

This script defines the `Duration` class, which encapsulates time durations with properties for seconds, minutes, and hours, and includes methods for manipulating these durations.

### Employees.cs

Defines the `Employees` class, which models an employee with properties such as ID, security level, salary, gender, and hiring date. It includes functionality for comparing employees based on their hiring dates.

### Employee/Program.cs

The main entry point for the Employee management system. It includes methods for adding employees, viewing employee details, and editing employee information.

### Enum.cs

Contains the `Security_Level` and `Gender` enums used throughout the project to define constants for security levels and gender.

### Searching.cs

Implements the `Searching` class, which provides functionality to search and manipulate employee records based on various criteria like national ID, name, hiring date, and more.

### Task 6/Program.cs

The main entry point for a specific task or module within the project. It outlines the structure and available methods without implementation details.

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

Distributed under the MIT License. See `LICENSE` for more information.

## Acknowledgments

- The .NET community for providing invaluable resources and support.
- All contributors who have helped to make this project better.