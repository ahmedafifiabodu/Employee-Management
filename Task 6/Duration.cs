namespace Task_6
{
    internal class Duration
    {
        private double Second;
        private int Minute;
        private int Hour;

        #region Gettters & Setters

        public double Seconds
        {
            get { return Second; }
            set { Second = value; }
        }

        public int Minutes
        {
            get { return Minute; }
            set { Minute = value; }
        }

        public int Hours
        {
            get { return Hour; }
            set { Hour = value; }
        }

        #endregion Gettters & Setters

        internal Duration(int hours, int mintue, double second)
        {
            Seconds = second;
            Minutes = mintue;
            Hours = hours;
        }

        internal Duration(int whatIsIt, double input)
        {
            if (whatIsIt == 0)
            {
                Hours = (int)input / 3600;
                double remainingSeconds = (int)input % 3600;
                Minute = (int)(remainingSeconds / 60);
                Second = Math.Round(remainingSeconds % 60, 1);
            }
            else if (whatIsIt == 1)
            {
                Hours = (int)input / 60;
                double TempMinutes = input % 60;
                double TempSecond = TempMinutes * 60;

                Minute = (int)(TempMinutes % 60);
                Second = Math.Round(TempSecond % 60, 1);
            }
            else
            {
                Hour = (int)input;
                Minute = (int)((input - Hour) * 60);
                Second = Math.Round(((input - Hour) * 60 - Minute) * 60, 1);
            }
        }

        internal Duration(double input)
        {
            Hours = (int)input / 3600;
            double remainingSeconds = (int)input % 3600;
            Minute = (int)(remainingSeconds / 60);
            Second = Math.Round(remainingSeconds % 60, 1);
        }

        public override string ToString()
        {
            //Hours: 1, Minutes :30, Seconds :20
            string point;

            if (Hour == 0 && Minute != 0)
                point = $"Minutes:{Minutes}, Second:{Second}.";
            else if (Hour == 0 && Minute == 0 && Second != 0)
                point = $"Second:{Second}.";
            else
                point = $"Hours:{Hour}, Minutes:{Minutes}, Second:{Second}";

            return point;
        }

        private static Duration FromSecond(double totalSeconds)
        {
            int hour = (int)(totalSeconds / 3600);
            int minute = (int)((totalSeconds % 3600) / 60);
            double second = totalSeconds % 60;

            return new Duration(hour, minute, second);
        }

        #region ADD

        public static Duration operator +(Duration duration1, Duration duration2)
        {
            double totalSecond =
                duration1.Hour * 3600 + duration1.Minute * 60 + duration1.Second +
                duration2.Hour * 3600 + duration2.Minute * 60 + duration2.Second;

            return Duration.FromSecond(totalSecond);
        }

        public static Duration operator +(Duration duration1, double number)
        {
            double totalSecond =
                duration1.Hour * 3600 + duration1.Minute * 60 + duration1.Second + number;

            return Duration.FromSecond(totalSecond);
        }

        public static Duration operator +(double number, Duration duration1)
        {
            double totalSecond =
                duration1.Hour * 3600 + duration1.Minute * 60 + duration1.Second + number;

            return Duration.FromSecond(totalSecond);
        }

        public static Duration operator ++(Duration duration1)
        {
            duration1.Minute++;

            if (duration1.Minute == 60)
            {
                duration1.Minute = 0;
                duration1.Hour++;
            }

            return duration1;
        }

        #endregion ADD

        #region Subtract

        public static Duration operator -(Duration duration1, Duration duration2)
        {
            double totalSecond =
                duration1.Hour * 3600 - duration1.Minute * 60 - duration1.Second -
                duration2.Hour * 3600 - duration2.Minute * 60 - duration2.Second;

            return Duration.FromSecond(Math.Max(totalSecond, 0));
        }

        public static Duration operator -(Duration duration1, double number)
        {
            double totalSecond =
                duration1.Hour * 3600 - duration1.Minute * 60 - duration1.Second - number;

            return Duration.FromSecond(Math.Max(totalSecond, 0));
        }

        public static Duration operator -(double number, Duration duration1)
        {
            double totalSecond =
                duration1.Hour * 3600 - duration1.Minute * 60 - duration1.Second - number;

            return Duration.FromSecond(Math.Max(totalSecond, 0));
        }

        public static Duration operator --(Duration duration1)
        {
            duration1.Minute--;

            if (duration1.Minute < 0)
            {
                duration1.Minute = 59;
                if (duration1.Minute > 0)
                {
                    duration1.Hour--;
                }
            }

            return new Duration(Math.Max(duration1.Hour, 0), duration1.Minute, duration1.Second);
        }

        public static Duration operator -(Duration duration)
        {
            return new Duration(-duration.Hour, -duration.Minute, -duration.Second);
        }

        #endregion Subtract

        #region Logical Operators

        public static bool operator >(Duration duration1, Duration duration2)
        {
            if (duration1.Hour > duration2.Hour)
                return true;

            if (duration1.Hour == duration2.Hour)
            {
                if (duration1.Minute > duration2.Minute)
                    return true;

                if (duration1.Minute == duration2.Minute)
                {
                    if (duration1.Second > duration2.Second)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }

            return false;
        }

        public static bool operator <(Duration duration1, Duration duration2)
        {
            if (duration1.Hour < duration2.Hour)
                return true;

            if (duration1.Hour == duration2.Hour)
            {
                if (duration1.Minute < duration2.Minute)
                    return true;

                if (duration1.Minute == duration2.Minute)
                {
                    if (duration1.Second < duration2.Second)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }

            return false;
        }

        public static bool operator <=(Duration duration1, Duration duration2)
        {
            if (duration1.Hour < duration2.Hour)
                return true;

            if (duration1.Hour == duration2.Hour)
            {
                if (duration1.Minute < duration2.Minute)
                    return true;

                if (duration1.Minute == duration2.Minute)
                {
                    if (duration1.Second < duration2.Second)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }

            return false;
        }

        public static bool operator >=(Duration duration1, Duration duration2)
        {
            if (duration1.Hour > duration2.Hour)
                return true;

            if (duration1.Hour == duration2.Hour)
            {
                if (duration1.Minute > duration2.Minute)
                    return true;

                if (duration1.Minute == duration2.Minute)
                {
                    if (duration1.Second > duration2.Second)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }

            return false;
        }

        #endregion Logical Operators

        #region DateTime

        public static explicit operator DateTime(Duration duration)
        {
            DateTime currentDateAndTime = DateTime.Now;

            TimeSpan timeOfDay = new(duration.Hour, duration.Minute, (int)duration.Second);

            DateTime resultDateTime = currentDateAndTime.Date + timeOfDay;

            return resultDateTime;
        }

        #endregion DateTime

        #region IF

        public static bool operator true(Duration duration)
        {
            return duration.Hour != 0 || duration.Minute != 0 || duration.Second != 0;
        }

        public static bool operator false(Duration duration)
        {
            return duration.Hour == 0 && duration.Minute == 0 && duration.Second == 0;
        }

        #endregion IF
    }
}