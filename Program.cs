using System;

namespace GetInformation
{
    class Program
    {
        static void Main(string[] args)
        { string firstname, lastname, gender, birthyear, mobilenumber = string.Empty;
            string message = string.Empty;
            int age = 0;
            bool isregister = default;

            while (true)
            {
                if (IsExit(message))
                {
                    PrintExit();
                    break;
                }
                
                firstname = UserDataHandler(nameof(firstname));
                PrintUserOutput("FirstName", firstname);
                ShowReverseString("FirstName", firstname);
                PrintSeperator();

                lastname = UserDataHandler(nameof(lastname));
                PrintUserOutput("LastName", lastname);
                ShowReverseString("LastName", lastname);
                PrintSeperator();

                birthyear = UserDataHandler(nameof(birthyear));
                age = CalculateAge(birthyear);
                PrintUserOutput("Age", age.ToString());
                PrintSeperator();

                mobilenumber = CheckMobileNumber(nameof(mobilenumber));
                PrintUserOutput("MobileNumber", mobilenumber);
                PrintSeperator();

                gender = GetGender(nameof(gender));
                PrintUserOutput("Gender", gender);
                PrintSeperator();

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                PrintProfile(name: firstname, family: lastname, age: age, phone: mobilenumber);

                isregister = IsRegister(gender:gender,age:age);
                PrintIsRegister(isregister);
                message = ShowFirstMessage();
            }
        }

        static string ShowFirstMessage()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            string message ="\nPlease Press Enter for Continue or Type E  for Exit from App";
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            message =GetStringDataFromUser();
            return message;
        }
        static bool IsExit(string str)
        {
            if (str == "e" || str == "exit")
                return true;
            else
                return false;
        }

        static void PrintExit()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("You Exit From App. * have a good day! *");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void PrintUserOutput(string property, string str)
        {
            Console.WriteLine($"Your {property} is : {str}");
        }

        static void PrintSeperator()
          => Console.WriteLine("**********************\n");

        static string GetStringDataFromUser()
        {
            string userInput = Console.ReadLine() ?? "";
            userInput = userInput.Trim();
            userInput = userInput.Replace(" ", "");
            userInput = userInput.ToLower();
            return userInput;
        }
        static void PrintProfile(string name,string family,int age,string phone)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            PrintUserOutput("firstname", name);
            PrintUserOutput("lastname", family);
            PrintUserOutput("age", age.ToString());
            PrintUserOutput("mobilenumber", phone);
        }

        static string GetMessage(string property)
            => $"Please Enter Your {property}!";

        static void PrintMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }
        static string UserDataHandler(String property)
        {
            Console.WriteLine(GetMessage(property));
            string userData = GetStringDataFromUser();

            while (string.IsNullOrEmpty(userData))
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(GetMessage(property));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                userData = GetStringDataFromUser();
            }
            return userData;
        }

        static void ShowReverseString (string property,string str)
        {
            var strarr = str.ToCharArray();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write($"\nYour {property} Reverse is : ");
            for (int i = strarr.Length - 1; i >= 0; i--)
            {
                Console.Write($" {strarr[i]}");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n");
        }

        static int CalculateAge (string birthYear)
        {
            int age,year = 0;
            int thisyear = 1403;
            birthYear = FaToEnNum(birthYear);
            bool isnumber = int.TryParse(birthYear, out year);
            while (isnumber == false)
            {
                birthYear = UserDataHandler("birthyear");
                isnumber = int.TryParse(birthYear, out year);
            }
            if (birthYear.Length == 2 && !birthYear.StartsWith("13"))
            {
                birthYear = "13" + birthYear;
                year = Convert.ToInt32(birthYear);
            }
            age = thisyear - year;
            return age;
        }

        static string CheckMobileNumber(string mobileNumber)
        {
            ulong phonenumber = 0;
            string message = string.Empty;
            bool isnumber = false;
            bool flag = false;
            bool check = false;
            while (flag != true || isnumber != true || check != true)
            {
                mobileNumber = UserDataHandler(nameof(mobileNumber));
                mobileNumber = FaToEnNum(mobileNumber);

                if (mobileNumber.StartsWith("+98"))
                    mobileNumber = mobileNumber.Replace("+98", "0");

                if (mobileNumber.StartsWith("0098"))
                    mobileNumber = mobileNumber.Replace("0098", "0");

                if (mobileNumber.StartsWith("098"))
                    mobileNumber = mobileNumber.Replace("098", "0");

                if (mobileNumber.Length == 10 && !mobileNumber.StartsWith("0"))
                {
                    mobileNumber = "0" + mobileNumber;
                }
                flag = mobileNumber.StartsWith("09");
                if (flag == false)
                {
                   message="! Your Mobile Number should be start with 09!";
                   PrintMessage(message);
                }

                isnumber = ulong.TryParse(mobileNumber, out phonenumber);
                if (isnumber == false)
                {
                    message="! Please Enter Your mobileNumber Corectly";
                    PrintMessage(message);
                }

                if (mobileNumber.Length != 11)
                {
                    message="! Your mobileNumber Lenght Should be 11 digit";
                    PrintMessage(message);
                    check = false;
                }
                else
                    check = true;
                
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
               
            }
            return mobileNumber;
        }
        static string GetGender(string gender)
        {
            string str = "Gender :'F' for Female OR 'M' for Male OR 'N' for Not To Say";
             while (gender != "f" && gender != "m" && gender != "n")
                gender = UserDataHandler(str);
            switch (gender)
            {
                case "m":
                    gender = "Male";
                    break;
                case "f":
                    gender = "Femail";
                    break;
                case "n":
                    gender = "Not To Say";
                    break;
                default:
                    gender = "";
                    break;
            }
            return gender;
        }
        static bool IsRegister (string gender,int age)
        {
            bool isRegister=default;
            if (gender == "Femail" && age >= 15)
                isRegister = true;
            else if (gender == "Male" && age >= 18)
                isRegister = true;
            else isRegister = false;
            return isRegister;
        }
        static void PrintIsRegister(bool isRegister)
        {
            if (isRegister)
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
