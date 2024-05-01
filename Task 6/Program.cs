using System.Text;

namespace Task_6
{
    internal class Program
    {
        private static readonly List<Duration> durationList = new();

        private static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            while (true)
            {
                Console.WriteLine(
                    "Press 'S' to add seconds.\n" +
                    "Press 'M' to add minutes.\n" +
                    "Press 'H' to add hours.\n" +
                    "Press 'A' to add durations.\n" +
                    "Press 'U' to subtract durations.\n" +
                    "Press 'C' to compare.\n" +
                    "Press 'V' to view.\n" +
                    "Press 'B' to cast a duration into DateTime format.\n" +
                    "Press 'I' to check if the duration has been started or not.\n" +
                    "Press 'Q' to quit.\n");

                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (key)
                {
                    case 'S':
                    case 's':
                        AddSeconds();
                        break;

                    case 'M':
                    case 'm':
                        AddMinutes();
                        break;

                    case 'H':
                    case 'h':
                        AddHours();
                        break;

                    case 'A':
                    case 'a':
                        while (true)
                        {
                            ViewUsingOverrideToString();

                            Console.WriteLine(
                                "\nPress 'A' to add 2 duration.\n" +
                                "Press 'P' to add a duration and a number.\n" +
                                "Press 'H' to add a number and a duration.\n" +
                                "Press '+' to make duration++.\n" +
                                "Press 'B' to return back.\n" +
                                "Press 'Q' to quit.\n");

                            char Addkey = Console.ReadKey().KeyChar;
                            Console.WriteLine();

                            switch (Addkey)
                            {
                                case 'A':
                                case 'a':
                                    Add2Duration();
                                    break;

                                case 'P':
                                case 'p':
                                    AddDurationAndNumber();
                                    break;

                                case 'H':
                                case 'h':
                                    AddNumberAndDuration();
                                    break;

                                case '+':
                                    AddDurationPlusPlus();
                                    break;

                                case 'B':
                                case 'b':
                                    Console.Clear();
                                    break;

                                case 'Q':
                                case 'q':
                                    return;

                                default:
                                    Console.WriteLine("\nInvalid input.\n");
                                    break;
                            }
                            break;
                        }
                        break;

                    case 'U':
                    case 'u':
                        while (true)
                        {
                            ViewUsingOverrideToString();
                            Console.WriteLine(
                                "Press 'S' to subtract 2 duration.\n" +
                                "Press 'D' to subtract a duration and a number.\n" +
                                "Press 'F' to subtract a number and a duration.\n" +
                                "Press 'N' to make a duration in negetive.\n" +
                                "Press '-' to make duration--.\n" +
                                "Press 'B' to return back.\n" +
                                "Press 'Q' to quit.\n");

                            char Addkey = Console.ReadKey().KeyChar;
                            Console.WriteLine();

                            switch (Addkey)
                            {
                                case 'S':
                                case 's':
                                    Subtract2Duration();
                                    break;

                                case 'D':
                                case 'd':
                                    SubtractDurationWithNumber();
                                    break;

                                case 'F':
                                case 'f':
                                    SubtractNumberWithDuration();
                                    break;

                                case 'N':
                                case 'n':
                                    SubtractDurationMinus();
                                    break;

                                case '-':
                                    SubtractDurationMinusMinus();
                                    break;

                                case 'B':
                                case 'b':
                                    Console.Clear();
                                    break;

                                case 'Q':
                                case 'q':
                                    return;

                                default:
                                    Console.WriteLine("\nInvalid input.\n");
                                    break;
                            }
                            break;
                        }
                        break;

                    case 'C':
                    case 'c':
                        ComapreDuration1WithDuration2();
                        break;

                    case 'V':
                    case 'v':
                        ViewUsingOverrideToString();
                        break;

                    case 'B':
                    case 'b':
                        DurationInDateTime();
                        break;

                    case 'I':
                    case 'i':
                        CheckIfAllEqualZero();
                        break;

                    case 'Q':
                    case 'q':
                        return;

                    default:
                        Console.WriteLine("\nInvalid input.\n");
                        break;
                }
            }
        }

        #region Inserting And Viewing

        private static void AddSeconds()
        {
            Console.Clear();
            Console.Write("Seconds (must be integer): \n" +
                          "\tEnter Seconds: ");

            int initialCursorLeft = Console.CursorLeft;
            int initialCursorTop = Console.CursorTop;

            StringBuilder inputStringBuilder = new();

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (inputStringBuilder.Length > 0)
                    {
                        inputStringBuilder.Remove(inputStringBuilder.Length - 1, 1);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    }
                }
                else
                {
                    inputStringBuilder.Append(keyInfo.KeyChar);
                }

                Console.SetCursorPosition(initialCursorLeft, initialCursorTop);
                Console.Write(inputStringBuilder.ToString() + " seconds");
                Console.SetCursorPosition(initialCursorLeft + inputStringBuilder.Length, initialCursorTop);
            } while (true);

            string coordinates = inputStringBuilder.ToString();

            if (int.TryParse(coordinates, out int x))
            {
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("\nInvalid input. Enter one or two or three integers separated by commas. Please try again.\n");
                Console.ReadKey();
                AddSeconds();
                return;
            }

            if (coordinates.Length != 0)
            {
                Duration seconds = new(0, x);
                durationList.Add(seconds);
            }
        }

        private static void AddMinutes()
        {
            Console.Clear();
            Console.Write("Minutes (must be integer): \n" +
                          "\tEnter Minutes: ");

            int initialCursorLeft = Console.CursorLeft;
            int initialCursorTop = Console.CursorTop;

            StringBuilder inputStringBuilder = new();

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (inputStringBuilder.Length > 0)
                    {
                        inputStringBuilder.Remove(inputStringBuilder.Length - 1, 1);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    }
                }
                else
                {
                    inputStringBuilder.Append(keyInfo.KeyChar);
                }

                Console.SetCursorPosition(initialCursorLeft, initialCursorTop);
                Console.Write(inputStringBuilder.ToString() + " Minutes");
                Console.SetCursorPosition(initialCursorLeft + inputStringBuilder.Length, initialCursorTop);
            } while (true);

            string coordinates = inputStringBuilder.ToString();

            if (float.TryParse(coordinates, out float x))
            {
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("\nInvalid input. Enter one or two or three integers separated by commas. Please try again.\n");
                Console.ReadKey();
                AddMinutes();
                return;
            }

            if (coordinates.Length != 0)
            {
                Duration minutes = new(1, x);
                durationList.Add(minutes);
            }
        }

        private static void AddHours()
        {
            Console.Clear();
            Console.Write("Hours (must be integer): \n" +
                          "\tEnter Hours: ");

            int initialCursorLeft = Console.CursorLeft;
            int initialCursorTop = Console.CursorTop;

            StringBuilder inputStringBuilder = new();

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (inputStringBuilder.Length > 0)
                    {
                        inputStringBuilder.Remove(inputStringBuilder.Length - 1, 1);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    }
                }
                else
                {
                    inputStringBuilder.Append(keyInfo.KeyChar);
                }

                Console.SetCursorPosition(initialCursorLeft, initialCursorTop);
                Console.Write(inputStringBuilder.ToString() + " Hours");
                Console.SetCursorPosition(initialCursorLeft + inputStringBuilder.Length, initialCursorTop);
            } while (true);

            string coordinates = inputStringBuilder.ToString();

            if (float.TryParse(coordinates, out float x))
            {
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("\nInvalid input. Enter one or two or three integers separated by commas. Please try again.\n");
                Console.ReadKey();
                AddHours();
                return;
            }

            if (coordinates.Length != 0)
            {
                Duration hours = new(2, x);
                durationList.Add(hours);
            }
        }

        private static void ViewUsingOverrideToString()
        {
            Console.Clear();
            if (durationList.Count == 0)
            {
                Console.WriteLine(
                    "*************************************************\n" +
                    "\tThe point list is empty.\n" +
                    "*************************************************\n");
            }
            else
            {
                Console.WriteLine("*************************************************\n");
                foreach (var duration in durationList)
                {
                    Console.WriteLine($"\tDuration {durationList.IndexOf(duration)}: " + duration.ToString());
                }
                Console.WriteLine("\n*************************************************\n");
            }
        }

        #endregion Inserting And Viewing

        #region ADD

        private static void Add2Duration()
        {
            if (durationList.Count == 0)
            {
                Console.WriteLine("\nThe list is empty.\n");
            }
            else
            {
                int x;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Index 1 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out x) && x < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                int y;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Index 2 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out y) && y < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                int z;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"The Result Index 3 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out z) && z < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                durationList[z] = durationList[x] + durationList[y];
                Console.WriteLine($"The result in index {z} has a new duration: {durationList[z]}.\n");
            }
        }

        private static void AddDurationAndNumber()
        {
            if (durationList.Count == 0)
            {
                Console.WriteLine("\nThe list is empty.\n");
            }
            else
            {
                int x;
                while (true)
                {
                    ViewUsingOverrideToString();

                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Index 1 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out x) && x < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                double y;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Enter number (must be either integer/float): ");

                    if (double.TryParse(Console.ReadLine(), out y))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                int z;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"The Result Index 3 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out z) && z < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                durationList[z] = durationList[x] + y;
                Console.WriteLine($"The result in index {z} has a new duration: {durationList[z]}.\n");
            }
        }

        private static void AddNumberAndDuration()
        {
            if (durationList.Count == 0)
            {
                Console.WriteLine("\nThe list is empty.\n");
            }
            else
            {
                int x;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Index 1 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out x) && x < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                double y;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Enter number (must be either integer/float): ");

                    if (double.TryParse(Console.ReadLine(), out y))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                int z;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"The Result Index 3 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out z) && z < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                durationList[z] = y + durationList[x];
                Console.WriteLine($"The result in index {z} has a new duration: {durationList[z]}.\n");
            }
        }

        private static void AddDurationPlusPlus()
        {
            if (durationList.Count == 0)
            {
                Console.WriteLine("\nThe list is empty.\n");
            }
            else
            {
                int x;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Index 1 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out x) && x < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                durationList[x]++;
                Console.WriteLine($"The result in index {x} has a new duration: {durationList[x]}.\n");
            }
        }

        #endregion ADD

        #region Subtract

        private static void Subtract2Duration()
        {
            if (durationList.Count == 0)
            {
                Console.WriteLine("\nThe list is empty.\n");
            }
            else
            {
                int x;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Index 1 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out x) && x < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                int y;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Index 2 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out y) && y < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                int z;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"The Result Index 3 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out z) && z < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                durationList[z] = durationList[x] - durationList[y];
                Console.WriteLine($"The result in index {z} has a new duration: {durationList[z]}.\n");
            }
        }

        private static void SubtractDurationWithNumber()
        {
            if (durationList.Count == 0)

            {
                Console.WriteLine("\nThe list is empty.\n");
            }
            else
            {
                int x;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Index 1 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out x) && x < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                double y;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Enter number (must be either integer/float): ");

                    if (double.TryParse(Console.ReadLine(), out y))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                int z;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"The Result Index 3 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out z) && z < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                durationList[z] = durationList[x] - y;
                Console.WriteLine($"The result in index {z} has a new duration: {durationList[z]}.\n");
            }
        }

        private static void SubtractNumberWithDuration()
        {
            if (durationList.Count == 0)
            {
                Console.WriteLine("\nThe list is empty.\n");
            }
            else
            {
                int x;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Index 1 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out x) && x < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                double y;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Enter number (must be either integer/float): ");

                    if (double.TryParse(Console.ReadLine(), out y))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                int z;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"The Result Index 3 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out z) && z < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                durationList[z] = y - durationList[x];
                Console.WriteLine($"The result in index {z} has a new duration: {durationList[z]}.\n");
            }
        }

        private static void SubtractDurationMinusMinus()
        {
            if (durationList.Count == 0)
            {
                Console.WriteLine("\nThe list is empty.\n");
            }
            else
            {
                int x;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Index 1 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out x) && x < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                durationList[x]--;
                Console.WriteLine($"The result in index {x} has a new duration: {durationList[x]}.\n");
            }
        }

        private static void SubtractDurationMinus()
        {
            if (durationList.Count == 0)
            {
                Console.WriteLine("\nThe list is empty.\n");
            }
            else
            {
                int x;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Index 1 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out x) && x < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                durationList[x] = -durationList[x];

                Console.WriteLine($"The result in index {x} has a new duration: {durationList[x]}.\n");
            }
        }

        #endregion Subtract

        #region IF

        private static void CheckIfAllEqualZero()
        {
            if (durationList.Count == 0)
            {
                Console.WriteLine("\nThe list is empty.\n");
            }
            else
            {
                int x;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Index 1 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out x) && x < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                if (durationList[x])
                {
                    Console.WriteLine($"The duration in index {x} have been started already. The duration: {durationList[x]}.\n");
                }
                else
                {
                    Console.WriteLine($"The duration in index {x} have not been started yet. The duration: {durationList[x]}.\n");
                }
            }
        }

        #endregion IF

        #region Compare

        private static void ComapreDuration1WithDuration2()
        {
            if (durationList.Count == 0)
            {
                Console.WriteLine("\nThe list is empty.\n");
            }
            else
            {
                int x;
                while (true)
                {
                    Console.Clear();
                    Console.Write(
                        $"List size: {durationList.Count}.\n" +
                        $"Index 1 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out x) && x < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                int y;
                while (true)
                {
                    Console.Clear();
                    Console.Write(
                        $"List size: {durationList.Count}.\n" +
                        $"Index 2 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out y) && y < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                if (durationList[x] > durationList[y])
                {
                    Console.WriteLine($"Duration {durationList[x].Hours}hr:{durationList[x].Minutes}min:{durationList[x].Seconds}sec in Index {x}" +
                        $" is bigger then Duration {durationList[y].Hours}hr:{durationList[y].Minutes}min:{durationList[y].Seconds}sec in Index {y}.\n");
                }
                else if (durationList[x] < durationList[y])
                {
                    Console.WriteLine($"Duration {durationList[x].Hours}hr:{durationList[x].Minutes}min:{durationList[x].Seconds}sec in Index {x}" +
                         $" is smaller then Duration {durationList[y].Hours}hr:{durationList[y].Minutes}min:{durationList[y].Seconds}sec in Index {y}.\n");
                }
                else
                {
                    Console.WriteLine($"Duration {durationList[x].Hours}hr:{durationList[x].Minutes}min:{durationList[x].Seconds}sec in Index {x}" +
                         $" is equal then Duration {durationList[y].Hours}hr:{durationList[y].Minutes}min:{durationList[y].Seconds}sec in Index {y}.\n");
                }
            }
        }

        #endregion Compare

        #region DateTime

        private static void DurationInDateTime()
        {
            if (durationList.Count == 0)
            {
                Console.WriteLine("\nThe list is empty.\n");
            }
            else
            {
                int x;
                while (true)
                {
                    ViewUsingOverrideToString();
                    Console.Write(
                        $"\nList size: {durationList.Count}.\n" +
                        $"Index 1 (must be integer): ");

                    if (int.TryParse(Console.ReadLine(), out x) && x < (durationList.Count))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Enter integer and in the range of the list. Please try again.\n");
                        Console.ReadKey();
                    }
                }

                //DateTime Obj = (DateTime)

                DateTime obj = (DateTime)durationList[x];

                Console.WriteLine($"The result in index {x} has been converted into DateTime format: {obj}.\n");
            }
        }

        #endregion DateTime
    }
}