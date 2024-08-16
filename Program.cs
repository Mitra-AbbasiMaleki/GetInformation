using System;

namespace GetInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string FirstName, LastName, Gender,BirtheYear, MobileNumber=default;
            int Age, Year=0;
            ulong Number=0;
            int ThisYear = 1403;
            bool isnumber,flag,check=default;
            Console.WriteLine("Please Enter Your First Name!");
            FirstName = Console.ReadLine();
            while (string.IsNullOrEmpty(FirstName))
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please Enter Your First Name");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                FirstName = Console.ReadLine();
            }
            FirstName=FirstName.Trim();
            FirstName=FirstName.Replace(" ","");
            FirstName=FirstName.ToLower();

            Console.WriteLine("Please Enter Your Last Name!");
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
            LastName=LastName.Trim();
            LastName=LastName.Replace(" ","");
            LastName=LastName.ToLower();
            
            // var Name=FirstName.ToArray();
            // for (int i = Name.length; i >=0; i--)
            // {
            //     Console.WriteLine($"Your Name Reverse is {Name[i]}");
            // }

            Console.WriteLine("Please Enter Your birth Year!");
            BirtheYear=Console.ReadLine();
            isnumber = int.TryParse(BirtheYear, out Year);
            while (isnumber == false)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please Enter Your birth Year Corectly!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                BirtheYear=Console.ReadLine();
                isnumber = int.TryParse(BirtheYear, out Year);
            }
            if (BirtheYear.Length == 2 && !BirtheYear.StartsWith("13"))
                {
                    BirtheYear="13"+BirtheYear;
                    Year=Convert.ToInt32(BirtheYear);
                }

            Age = ThisYear - Year;

            Console.WriteLine("Please Enter 'F' for Female OR 'M' for Male Or 'N' for Not To Say");
            Gender = Console.ReadLine();
            Gender=Gender.ToUpper();
            
            while (Gender != "F" && Gender != "M" && Gender != "N")
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please Enter 'F' for Female OR 'M' for Male");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Gender = Console.ReadLine();
                Gender=Gender.ToUpper();
            }
            switch (Gender)
            {   case "M":
                    Gender = "Mail";
                    break;
                case "F":
                    Gender = "Femail";
                    break;
                case "N":
                    Gender = "Not To Say";
                    break;      
                default:
                    Gender="";
                    break;
            }
            isnumber = false;
            flag = false;
            check = false;
            Console.WriteLine("\nPlease Enter Your Mobile Number!");
            while (flag != true || isnumber != true || check != true)
            {
                MobileNumber = Console.ReadLine();
                                
                if(MobileNumber.StartsWith("+98"))
                    MobileNumber=MobileNumber.Replace("+98","0");

                if(MobileNumber.StartsWith("0098"))
                    MobileNumber=MobileNumber.Replace("0098","0");

                if(MobileNumber.StartsWith("098"))
                    MobileNumber=MobileNumber.Replace("098","0");

                if (MobileNumber.Length == 10 && !MobileNumber.StartsWith("0"))
                {
                    MobileNumber="0"+MobileNumber;
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
            Console.WriteLine($"Your Name is : {FirstName} {LastName}");
            Console.WriteLine($"Your Mobile Number is : {MobileNumber}");
            Console.WriteLine($"Your Gender is {Gender} and You Are {Age} Year's Old") ;

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
                Console.BackgroundColor=ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You Can Not Register in Our Site.");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

