using Employee;

namespace Employees
{
    internal class Employees : IComparable<Employees>
    {
        #region Hiring Date

        public class HiringDate
        {
            private int date;
            private int month;
            private int year;

            public HiringDate(int date, int month, int year)
            {
                this.date = date;
                this.month = month;
                this.year = year;
            }

            #region Getters & Setters

            // Date
            public int Date
            {
                get { return date; }
                set { date = value; }
            }

            // Month
            public int Month
            {
                get { return month; }
                set { month = value; }
            }

            // Year
            public int Year
            {
                get { return year; }
                set { year = value; }
            }

            #endregion Getters & Setters
        }

        #endregion Hiring Date

        private int id;
        private Security_Level securityLevel;
        private double salary;
        private Gender gender;
        private HiringDate hiringDate;

        public Employees(int id, Security_Level securityLevel, double salary, Gender gender, int date, int month, int year)
        {
            this.id = id;
            this.securityLevel = securityLevel;
            this.salary = salary;
            this.gender = gender;
            hiringDate = new HiringDate(date, month, year);
        }

        #region Getter & Setter

        // ID
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        // Security Level
        public Security_Level SecurityLevel
        {
            get { return securityLevel; }
            set { securityLevel = value; }
        }

        // Salary
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        // Gender
        public Gender Genders
        {
            get { return gender; }
            set { gender = value; }
        }

        // Hiring Date
        public HiringDate HiringDates
        {
            get { return hiringDate; }
            set { hiringDate = value; }
        }

        #endregion Getter & Setter

        private static string GetGenderString(string gender)
        {
            return gender == "M" ? "Male" : (gender == "F" ? "Female" : "Unknown");
        }

        public override string ToString()
        {
            string salary = string.Format("{0:C1}", this.salary);
            Searching getEmp = new();

            return $"\n" +
                    $"National ID: {getEmp[id]}.\n" +
                    $"ID: {id}.\n" +
                    $"Name: {getEmp[this.salary]}.\n" +
                    $"Security Level: {securityLevel}.\n" +
                    $"Salary: {salary}.\n" +
                    $"Gender: {GetGenderString(Genders.ToString())}.\n" +
                    $"Hiring Date: {hiringDate.Date}/{hiringDate.Month}/{hiringDate.Year}.";
        }

        public int CompareTo(Employees? other)
        {
            int result = HiringDates.Year.CompareTo(other?.HiringDates.Year);
            if (result == 0)
            {
                result = HiringDates.Month.CompareTo(other?.HiringDates.Month);
                if (result == 0)
                {
                    result = HiringDates.Date.CompareTo(other?.HiringDates.Date);
                }
            }
            return result;
        }
    }
}