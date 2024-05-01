using Employee;

namespace Employees
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine(
                    "Press 'A' to add a new employee.\n" +
                    "Press 'V' to view.\n" +
                    "Press 'E' to edit information.\n" +
                    "Press 'S' to search.\n" +
                    "Press 'Q' to quit.\n");

                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (key)
                {
                    case 'A':
                    case 'a':
                        AddEmployee();
                        break;

                    case 'V':
                    case 'v':
                        ViewUsingOverrideToString();
                        break;

                    case 'E':
                    case 'e':
                        while (true)
                        {
                            ViewUsingOverrideToString();

                            Console.WriteLine(
                                "Press 'I' to edit the National IDs'.\n" +
                                "Press 'N' to edit the Name.\n" +
                                "Press 'H' to edit the Hiring Date.\n" +
                                "Press 'B' to return back.\n");

                            char EditKey = Console.ReadKey().KeyChar;
                            Console.WriteLine();

                            switch (EditKey)
                            {
                                case 'I':
                                case 'i':
                                    EditEmployee(0);
                                    break;

                                case 'N':
                                case 'n':
                                    EditEmployee(1);
                                    break;

                                case 'H':
                                case 'h':
                                    EditEmployee(2);
                                    break;

                                case 'B':
                                case 'b':
                                    break;

                                case 'Q':
                                case 'q':
                                    return;
                            }
                            break;
                        }
                        break;

                    case 'S':
                    case 's':
                        Console.Clear();
                        if (Searching.employeeList.Count == 0)
                        {
                            Console.WriteLine("The employee list is empty !!\n");
                        }
                        else
                        {
                            Search();
                        }
                        break;

                    case 'Q':
                    case 'q':
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input. Press 'A' to add, 'V' to view, 'S' to search, 'Q' to quit.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        private static void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine
                ("*************************************************\n" +
                "Enter employee details: \n");

            int id;
            while (true)
            {
                Console.Write("\tID (must be an integer): ");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    if (IsIdAlreadyUsed(id))
                    {
                        Console.WriteLine($"\n\tID {id} is already in use. Please enter a different ID.\n");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\n\tInvalid input. ID must be an integer. Please try again.\n");
                }
            }

            Console.Write("\tName: ");
            string name = Console.ReadLine()!;

            Security_Level securityLevel;
            while (true)
            {
                Console.Write("\tSecurity Level (must be Administrator or IT or HumanResoure or SecurityOfficer): ");
                string userInput = Console.ReadLine()!;
                bool isNum = int.TryParse(userInput, out int input);

                if (isNum)
                {
                    Console.WriteLine(
                        "\n\tInvalid input." +
                        "Please enter the input as a string, not an integer." +
                        "Please try again.\n");
                }
                else if (Enum.TryParse(userInput, out securityLevel))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(
                        "\n\tInvalid input. " +
                        "Security Level must be Administrator or IT or HumanResoure or SecurityOfficer." +
                        "Please try again.\n");
                }
            }

            double salary;
            while (true)
            {
                Console.Write("\tSalary (must be an float or integer): ");
                if (double.TryParse(Console.ReadLine(), out salary))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\tInvalid input. Security Level must be an float. Please try again.\n");
                }
            }

            Gender genderInput;
            while (true)
            {
                Console.Write("\tGender (M/F): ");
                char gender = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                bool isNum = char.IsDigit(gender);

                if (isNum)
                {
                    Console.WriteLine(
                        "\n\tInvalid input." +
                        "Please enter the Gender as (M/F), not an integer." +
                        "Please try again.\n");
                }
                else if (Enum.TryParse(gender.ToString(), out genderInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(
                        "\n\tInvalid input. " +
                        "Security Level must be (M/F)." +
                        "Please try again.\n");
                }
            }

            Console.Write("\tEnter Hiring Date: \n");

            int date;
            while (true)
            {
                Console.Write("\t\tDate (must be an integer): ");
                if (int.TryParse(Console.ReadLine(), out date) && date >= 1 && date <= 31)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\t\tInvalid input. Security Level must be an integer. Please try again.\n");
                }
            }

            int month;
            while (true)
            {
                Console.Write("\t\tMonth (must be an integer): ");
                if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\t\tInvalid input. Security Level must be an integer. Please try again.\n");
                }
            }

            int year;
            while (true)
            {
                Console.Write("\t\tYear (must be an integer): ");
                if (int.TryParse(Console.ReadLine(), out year) && year >= 1900 && year <= 2005)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\t\tInvalid input. Security Level must be an integer. Please try again.\n");
                }
            }

            Random random = new();
            long NationalID = random.Next(1000, 9999);

            Employees employeeSearch = new(id, securityLevel, salary, genderInput, date, month, year);

            Searching setEmpolyee = new();
            setEmpolyee[NationalID] = employeeSearch;
            setEmpolyee[name] = Searching.employeeList;
            setEmpolyee[employeeSearch] = employeeSearch;

            Searching.employeeList = Searching.employeeList.OrderBy(e => e).ToList();

            Console.WriteLine
                ("\tEmployee added successfully." +
                "\n*************************************************\n");
        }

        private static void ViewUsingOverrideToString()
        {
            if (Searching.employeeList.Count == 0)
            {
                Console.WriteLine("The employee list is empty !!\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("*************************************************");
                foreach (var employee in Searching.employeeList)
                {
                    Console.WriteLine(employee.ToString());
                }
                Console.WriteLine("\n*************************************************\n");
            }
        }

        private static bool IsIdAlreadyUsed(int id)
        {
            return Searching.employeeList.Any(employee => employee.ID == id);
        }

        private static bool IsNationalIDAlreadyUsed(long NationalID, Searching obj)
        {
            return Searching.employeeList.Any(employee => obj[NationalID] == employee);
        }

        private static void Search()
        {
            while (true)
            {
                ViewUsingOverrideToString();

                Console.WriteLine(
                    "Press 'I' to search by National IDs'.\n" +
                    "Press 'N' to search by Name.\n" +
                    "Press 'H' to search by Hiring Date.\n" +
                    "Press 'G' to search by Gender.\n" +
                    "Press 'B' to return back.\n");

                Searching Obj = new();
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (key)
                {
                    case 'I':
                    case 'i':
                        while (true)
                        {
                            Console.Clear();
                            Console.Write("National IDs (must be an integer): ");
                            if (long.TryParse(Console.ReadLine(), out long NationalIDs))
                            {
                                //long num = phoneBook1["OLa"];

                                Console.WriteLine(Obj[NationalIDs]!.ToString() + "\n");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid input. ID must be an integer. Please try again.\n");
                            }
                        }
                        break;

                    case 'N':
                    case 'n':

                        Console.Clear();
                        Console.Write("Name: ");
                        string nameToSearch = Console.ReadLine()!;

                        List<Employees> employeesWithSameName = Obj[nameToSearch];
                        if (employeesWithSameName != null && employeesWithSameName.Count > 0)
                        {
                            Console.WriteLine("\nEmployees with the same name:");
                            Console.WriteLine("*************************************************");
                            foreach (var employee in employeesWithSameName)
                            {
                                Console.WriteLine(employee.ToString());
                            }
                            Console.WriteLine("*************************************************");
                        }
                        else
                        {
                            Console.WriteLine("No employees found with the specified name.");
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 'H':
                    case 'h':

                        Console.Clear();
                        Console.Write("Enter Hiring Date: \n");

                        int searchDate;
                        while (true)
                        {
                            Console.Write("\tDate (must be an integer): ");
                            if (int.TryParse(Console.ReadLine(), out searchDate) && searchDate >= 1 && searchDate <= 31)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\n\tInvalid input. Date must be an integer between 1 and 31. Please try again.\n");
                            }
                        }

                        int searchMonth;
                        while (true)
                        {
                            Console.Write("\tMonth (must be an integer): ");
                            if (int.TryParse(Console.ReadLine(), out searchMonth) && searchMonth >= 1 && searchMonth <= 12)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\n\tInvalid input. Month must be an integer between 1 and 12. Please try again.\n");
                            }
                        }

                        int searchYear;
                        while (true)
                        {
                            Console.Write("\tYear (must be an integer): ");
                            if (int.TryParse(Console.ReadLine(), out searchYear) && searchYear >= 1900 && searchYear <= 2005)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\n\tInvalid input. Year must be an integer between 1900 and 2005. Please try again.\n");
                            }
                        }

                        List<Employees> employeesWithSameHiringDate = Obj[searchDate, searchMonth, searchYear];
                        if (employeesWithSameHiringDate != null && employeesWithSameHiringDate.Count > 0)
                        {
                            Console.WriteLine("*************************************************");
                            Console.WriteLine("\nEmployees hired on the specified date:");
                            foreach (var employee in employeesWithSameHiringDate)
                            {
                                Console.WriteLine(employee.ToString());
                            }
                            Console.WriteLine("*************************************************");
                        }
                        else
                        {
                            Console.WriteLine("No employees found with the specified hiring date.");
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 'G':
                    case 'g':
                        while (true)
                        {
                            Console.Clear();
                            ViewUsingOverrideToString();

                            Console.Write("\tGender (M/F): ");
                            char gender = char.ToUpper(Console.ReadKey().KeyChar);
                            Console.WriteLine();

                            bool isNum = char.IsDigit(gender);

                            if (isNum)
                            {
                                Console.WriteLine(
                                    "\n\tInvalid input." +
                                    "Please enter the Gender as (M/F), not an integer." +
                                    "Please try again.\n");
                            }
                            else if (Enum.TryParse(gender.ToString(), out Gender genderInput))
                            {
                                List<Employees> employeesWithSameGender = Obj[genderInput];
                                if (employeesWithSameGender != null && employeesWithSameGender.Count > 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("*************************************************");
                                    Console.WriteLine("\nEmployees with same gender:");
                                    foreach (var employee in employeesWithSameGender)
                                    {
                                        Console.WriteLine(employee.ToString());
                                    }
                                    Console.WriteLine("\n*************************************************");
                                }
                                else
                                {
                                    Console.WriteLine("No employees found with the specified hiring date.");
                                }

                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine(
                                    "\n\tInvalid input. " +
                                    "Security Level must be (M/F)." +
                                    "Please try again.\n");
                            }
                        }
                        break;

                    case 'B':
                    case 'b':
                        Console.Clear();
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please try again.\n");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        private static void EditEmployee(int Choise)
        {
            Console.Clear();

            if (Searching.employeeList.Count == 0)
            {
                Console.WriteLine("The employee list is empty !!\n");
            }
            else
            {
                Searching Obj = new();

                if (Choise == 0)
                {
                    Console.Clear();
                    int x;
                    while (true)
                    {
                        ViewUsingOverrideToString();
                        Console.Write(
                            $"\nList size: {Searching.employeeList.Count}.\n" +
                            $"Enter the index you want to edit the National ID (must be integer): ");

                        if (int.TryParse(Console.ReadLine(), out x) && x < (Searching.employeeList.Count))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                            Console.ReadKey();
                        }
                    }

                    int NationalID;
                    while (true)
                    {
                        Console.Write("\tNational ID (must be an integer): ");
                        if (int.TryParse(Console.ReadLine(), out NationalID))
                        {
                            if (IsNationalIDAlreadyUsed(NationalID, Obj))
                            {
                                Console.WriteLine($"\n\tNational ID '{NationalID}' is already in use. Please enter a different National ID.\n");
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\tInvalid input. National ID must be an integer. Please try again.\n");
                        }
                    }

                    Obj[x, NationalID] = Searching.employeeList[x];

                    Console.WriteLine
                        ("\tEmployee National ID edited successfully." +
                        "\n*************************************************\n");
                }
                else if (Choise == 1)
                {
                    Console.Clear();
                    int x;
                    while (true)
                    {
                        ViewUsingOverrideToString();
                        Console.Write(
                            $"\nList size: {Searching.employeeList.Count}.\n" +
                            $"Enter the index you want to edit the National ID (must be integer): ");

                        if (int.TryParse(Console.ReadLine(), out x) && x < (Searching.employeeList.Count))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                            Console.ReadKey();
                        }
                    }

                    Console.Write("\tName: ");
                    string Name = Console.ReadLine()!;

                    Obj[x, Name!] = Searching.employeeList[x];

                    Console.WriteLine
                        ("\tEmployee Name edited successfully." +
                        "\n*************************************************\n");
                }
                else if (Choise == 2)
                {
                    Console.Clear();
                    int x;
                    while (true)
                    {
                        ViewUsingOverrideToString();
                        Console.Write(
                            $"List size: {Searching.employeeList.Count}.\n" +
                            $"Enter the index you want to edit the hiring date (must be integer): ");

                        if (int.TryParse(Console.ReadLine(), out x) && x < (Searching.employeeList.Count))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                            Console.ReadKey();
                        }
                    }

                    int date;
                    while (true)
                    {
                        Console.Write("\t\tDate (must be an integer): ");
                        if (int.TryParse(Console.ReadLine(), out date) && date >= 1 && date <= 31)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n\t\tInvalid input. Security Level must be an integer. Please try again.\n");
                        }
                    }

                    int month;
                    while (true)
                    {
                        Console.Write("\t\tMonth (must be an integer): ");
                        if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n\t\tInvalid input. Security Level must be an integer. Please try again.\n");
                        }
                    }

                    int year;
                    while (true)
                    {
                        Console.Write("\t\tYear (must be an integer): ");
                        if (int.TryParse(Console.ReadLine(), out year) && year >= 1900 && year <= 2005)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n\t\tInvalid input. Security Level must be an integer. Please try again.\n");
                        }
                    }

                    Obj[x, date, month, year] = Searching.employeeList[x];
                    Searching.employeeList = Searching.employeeList.OrderBy(e => e).ToList();

                    Console.WriteLine
                        ("\tEmployee Name edited successfully." +
                        "\n*************************************************\n");
                }
            }
        }
    }
}