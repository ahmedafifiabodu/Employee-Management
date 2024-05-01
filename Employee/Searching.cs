using Employee;

namespace Employees
{
    internal class Searching
    {
        private static readonly List<long> NationalID = new();
        private static readonly List<string> EmpolyeeNames = new();
        internal static List<Employees> employeeList = new();

        internal Searching()
        {
        }

        #region Indexer

        #region Setters & Getters

        public Employees this[long nationalID]
        {
            get
            {
                for (int emp = 0; emp < NationalID.Count; ++emp)
                {
                    if (NationalID[emp] == nationalID)
                        return employeeList[emp];
                }
                return null!;
            }

            set => NationalID.Add(nationalID);
        }

        public List<Employees> this[string Name]
        {
            get
            {
                List<Employees> employeesWithSameName = new();
                for (int emp = 0; emp < EmpolyeeNames.Count; ++emp)
                {
                    if (EmpolyeeNames[emp] == Name)
                        employeesWithSameName.Add(employeeList[emp]);
                }

                /*
                if (employeesWithSameName.Count > 0)
                {
                    return employeesWithSameName;
                }
                else
                {
                    return null;
                }
                */

                return employeesWithSameName.Count > 0 ? employeesWithSameName : null!;
            }

            set => EmpolyeeNames.Add(Name!);
        }

        public Employees this[Employees Employees]
        {
            get
            {
                for (int emp = 0; emp < employeeList.Count; ++emp)
                {
                    if (employeeList[emp] == Employees)
                        return employeeList[emp];
                }
                return null!;
            }

            set
            {
                employeeList.Add(Employees);
            }
        }

        #endregion Setters & Getters

        #region Setter

        public Employees this[int index, long nationalID]
        {
            set => NationalID[index] = nationalID;
        }

        public Employees this[int index, string name]
        {
            set => EmpolyeeNames[index] = name;
        }

        public Employees this[int index, int date, int month, int year]
        {
            set
            {
                employeeList[index].HiringDates.Date = date;
                employeeList[index].HiringDates.Month = month;
                employeeList[index].HiringDates.Year = year;
            }
        }

        #endregion Setter

        #region Getter

        public List<Employees> this[int date, int month, int year]
        {
            get
            {
                List<Employees> employeesWithSameHiringDate = new();

                for (int emp = 0; emp < employeeList.Count; ++emp)
                {
                    if (employeeList[emp].HiringDates.Date == date &&
                        employeeList[emp].HiringDates.Month == month &&
                        employeeList[emp].HiringDates.Year == year)
                    {
                        employeesWithSameHiringDate.Add(employeeList[emp]);
                    }
                }

                return employeesWithSameHiringDate.Count > 0 ? employeesWithSameHiringDate : null!;
            }
        }

        public long this[int ID]
        {
            get
            {
                for (int emp = 0; emp < employeeList.Count; ++emp)
                {
                    if (employeeList[emp].ID == ID)
                        return NationalID[emp];
                }
                return -1;
            }
        }

        public string this[double salary]
        {
            get
            {
                for (int emp = 0; emp < employeeList.Count; ++emp)
                {
                    if (employeeList[emp].Salary == salary)
                        return EmpolyeeNames[emp];
                }
                return "";
            }
        }

        public List<Employees> this[Gender gender]
        {
            get
            {
                List<Employees> employeesWithSameGender = new();
                for (int emp = 0; emp < employeeList.Count; ++emp)
                {
                    if (employeeList[emp].Genders == gender)
                        employeesWithSameGender.Add(employeeList[emp]);
                }
                return employeesWithSameGender.Count > 0 ? employeesWithSameGender : null!;
            }
        }

        #endregion Getter

        #endregion Indexer
    }
}