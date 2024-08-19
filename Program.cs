using System;

namespace GetInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string FirstName, LastName, Gender, BirtheYear, MobileNumber = default;
            int Age, Year = 0;
            ulong Number = 0;
            int ThisYear = 1403;
            bool isnumber, flag, check = default;
            Console.WriteLine("Please Enter Your First Name!");
            FirstName = Console.ReadLine();
            while (string.IsNullOrEmpty(FirstName))
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please Enter Your FirstName");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                FirstName = Console.ReadLine();
            }
            FirstName = FirstName.Trim();
            FirstName = FirstName.Replace(" ", "");
            FirstName = FirstName.ToLower();
            ReverseStr(FirstName);

            Console.WriteLine("\n\nPlease Enter Your LastName!");
            LastName = Console.ReadLine();
            while (string.IsNullOrEmpty(LastName))
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please Enter Your Last Name");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                LastName = Console.ReadLine();
            }
            LastName = LastName.Trim();
            LastName = LastName.Replace(" ", "");
            LastName = LastName.ToLower();
            ReverseStr(LastName);
            
            Console.WriteLine("\n\nPlease Enter Your birth Year!");
            BirtheYear = Console.ReadLine();
            BirtheYear=FaToEnNum(BirtheYear);
            isnumber = int.TryParse(BirtheYear, out Year);
            while (isnumber == false)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please Enter Your birth Year Corectly!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                BirtheYear = Console.ReadLine();
                isnumber = int.TryParse(BirtheYear, out Year);
            }
            if (BirtheYear.Length == 2 && !BirtheYear.StartsWith("13"))
            {
                BirtheYear = "13" + BirtheYear;
                Year = Convert.ToInt32(BirtheYear);
            }
            Age = ThisYear - Year;

            Console.WriteLine("Please Enter 'F' for Female OR 'M' for Male Or 'N' for Not To Say");
            Gender = Console.ReadLine();
            Gender = Gender.ToUpper();

            while (Gender != "F" && Gender != "M" && Gender != "N")
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please Enter 'F' for Female OR 'M' for Male");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Gender = Console.ReadLine();
                Gender = Gender.ToUpper();
            }
            switch (Gender)
            {
                case "M":
                    Gender = "Mail";
                    break;
                case "F":
                    Gender = "Femail";
                    break;
                case "N":
                    Gender = "Not To Say";
                    break;
                default:
                    Gender = "";
                    break;
            }
            
            isnumber = false;
            flag = false;
            check = false;
            Console.WriteLine("\nPlease Enter Your Mobile Number!");
            while (flag != true || isnumber != true || check != true)
            {
                MobileNumber = Console.ReadLine();
                MobileNumber =FaToEnNum(MobileNumber);

                if (MobileNumber.StartsWith("+98"))
                    MobileNumber = MobileNumber.Replace("+98", "0");

                if (MobileNumber.StartsWith("0098"))
                    MobileNumber = MobileNumber.Replace("0098", "0");

                if (MobileNumber.StartsWith("098"))
                    MobileNumber = MobileNumber.Replace("098", "0");

                if (MobileNumber.Length == 10 && !MobileNumber.StartsWith("0"))
                {
                    MobileNumber = "0" + MobileNumber;
                }
                flag = MobileNumber.StartsWith("09");
                if (flag == false)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("! Your Mobile Number should be start with 09!");
                }

                isnumber = ulong.TryParse(MobileNumber, out Number);
                if (isnumber == false)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("! Please Enter Your MobileNumber Corectly");
                }

                if (MobileNumber.Length != 11)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("! Your MobileNumber Lenght Should be 11 digit");
                    check = false;
                }
                else
                    check = true;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nYour Name is : {FirstName} {LastName}");
            Console.WriteLine($"Your Mobile Number is : {MobileNumber}");
            Console.WriteLine($"Your Gender is {Gender} and You Are {Age} Year's Old");

            if (Gender == "Femail" && Age >= 15)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You Can Register in Our Site.");
            }
            else if (Gender == "Male" && Age >= 18)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You Can Register in Our Site.");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You Can Not Register in Our Site.");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void ReverseStr(string name)
        {
            var Name = name.ToCharArray();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("\nYour Name Reverse is : ");
            for (int i = Name.Length - 1; i >= 0; i--)
            {
                Console.Write($" {Name[i]}");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static string  FaToEnNum(string str)
            {
                string StrNum="";
                var item=str.ToCharArray();
                for (int i = 0; i < item.Length; i++)
                {
                    string ragahm=item[i].ToString();
                    switch (ragahm)
                    {
                        case "۰" :
                            ragahm.Replace("۰","0");
                            break;
                        case "۱":
                            ragahm.Replace("۱","1");
                            break;
                        case "۲":
                            ragahm.Replace("۲","2");
                            break;
                        case "۳":
                            ragahm.Replace("۳","3");
                            break;
                        case "۴":
                            ragahm.Replace("۴","4");
                            break;
                        case "۵":
                            ragahm.Replace("۵","5");
                            break;
                        case "۶":
                            ragahm.Replace("۶","6");
                            break;
                        case "۷":
                            ragahm.Replace("۷","7");
                            break;
                        case "۸":
                            ragahm.Replace("۸","8");
                            break;
                        case "۹":
                            ragahm.Replace("۹","9");
                            break;
                    }
                    StrNum+=ragahm;
                }
                return StrNum;
            }

    }
}
