
using ConsoleTables;
using Colors.Net;
using static Colors.Net.StringStaticMethods;
using HW13.Service;
using HW13.Entity;
using HW13.Enum;
using Microsoft.Identity.Client.Extensions.Msal;
using HW13.MyMemory;
using HW13.Dto;
using HW13.FramWork;
ServiceAuthentication serviceAuthentication = new ServiceAuthentication();
ServiceUser serviceUser = new ServiceUser();
User user = new User();
Book book = new Book();

int option;
int option1;
while (true)
{
    try
    {
        do
        {

            Console.Clear();
            ColoredConsole.WriteLine($"{White("1:Login ")}");
            ColoredConsole.WriteLine($"{White("2:Register ")}");
            ColoredConsole.Write($"{Blue("please Enter your option : ")}");
            option1 = int.Parse(Console.ReadLine());
            switch (option1)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Register();
                    break;
                default:
                    break;
            }


        } while (option1 < 3);
    }
    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"{Red("Select an option.")}");

    }
    Console.ReadKey();
}

void Login()
{
    try
    {
        Console.Clear();
        ColoredConsole.WriteLine($"{Yellow("*************Login*************")}");
        ColoredConsole.WriteLine($"{Yellow("*******************************")}");
        ColoredConsole.Write($"{Blue("Please Enter UserName:")}");
        string userName = Console.ReadLine();
        ColoredConsole.Write($"{Blue("Please Enter Password :")}");
        string password = Console.ReadLine();
        password = SecurityHelper.EncryptString(password, "HW13project");
        var result =serviceAuthentication.Login(userName,password);

        if (result.IsSuccess)
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Green(result.IsMessage)}");

            Console.ReadKey();

            

            try
            {
                if(MemoryDb.CurrentUser.Role == EnumRole.Member)
                {
                    Console.Clear();
                    
                    ColoredConsole.WriteLine($"{Yellow("*******List of books have borrowed*******")}");
                    ColoredConsole.WriteLine($"{Yellow("*****************************************")}");
                    
                    var Book = serviceUser.GetListOfUserBook(MemoryDb.CurrentUser.Id);
                    ConsoleTable.From<GetBookLibraryDto>(Book)
                        .Configure(o => o.NumberAlignment = Alignment.Right)
                        .Write(Format.Minimal);
                    Console.ReadKey();
                    do
                    {


                        Console.Clear();
                        ColoredConsole.WriteLine($"{White("1:Borrow book ")}");
                        ColoredConsole.WriteLine($"{White("2:Return book ")}");
                        ColoredConsole.WriteLine($"{White("3:Get List of Library book")}");
                        ColoredConsole.WriteLine($"{White("4:Get List of user book ")}");
                        ColoredConsole.WriteLine($"{White("5:Exit ")}");
                        
                        ColoredConsole.WriteLine($"{Yellow("******************************")}");
                        ColoredConsole.Write($"{Blue("please Enter your option :")}");
                        option = int.Parse(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Borrow();
                                break;
                            case 2:
                                Return();
                                break;
                            case 3:
                                ListOfLibrary();
                                break;
                            case 4:
                                ListOfuser();
                                break;
                            case 5:
                                Exit();
                                break;
                      
                            default:
                                break;
                        }


                    } while (option < 5);

                }
                else if(MemoryDb.CurrentUser.Role == EnumRole.Admin)
                {
                    do
                    {


                        Console.Clear();
                        
                        ColoredConsole.WriteLine($"{White("1:Show list of all books")}");
                        ColoredConsole.WriteLine($"{White("2:Show list of all users ")}");
                        ColoredConsole.WriteLine($"{White("3:Exit ")}");

                        ColoredConsole.WriteLine($"{Yellow("******************************")}");
                        ColoredConsole.Write($"{Blue("please Enter your option :")}");
                        option = int.Parse(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                ShowAllBook();
                                break;
                            case 2:
                                ShowAllUser();
                                break;
                            case 3:
                                Exit();
                                break;
                          

                            default:
                                break;
                        }


                    } while (option < 3);

                
                }



            }
            catch (Exception ex)
            {
                ColoredConsole.WriteLine($"{Red("Select an option.")}");

            }
            

        }


        else
        {

            ColoredConsole.WriteLine($"{Red(result.IsMessage)}");

            Console.ReadKey();
        }
    }
    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"{Red("Please complete the form.")}");

        Console.ReadKey();



    }


    Console.ReadKey();
}
void Register()
{
    try
    {
        Console.Clear();
        ColoredConsole.WriteLine($"{Yellow("***********Register*************")}");
        ColoredConsole.WriteLine($"{Yellow("********************************")}");
        ColoredConsole.Write($"{Blue("Please Enter UserName:")}");
        string userName = Console.ReadLine();
        ColoredConsole.Write($"{Blue("Please Enter Password :")}");
        string password = Console.ReadLine();

        string password1 = SecurityHelper.EncryptString(password, "HW13project");
        ColoredConsole.Write($"{Blue("please Enter role(1:Admin ,2:Member): ")}");
        EnumRole role = (EnumRole)Enum.Parse(typeof(EnumRole), Console.ReadLine());
        user.UserName = userName;
        user.Password = password1;
        user.Role = role;
        var result = serviceAuthentication.Register(user);

        if (result.IsSuccess)
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Green(result.IsMessage)}");
            Console.ReadKey();
            Login();
            Console.ReadKey();

        }
        else
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Red(result.IsMessage)}");


            Console.ReadKey();
        }
    }
    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"{Red("Please complete the form.")}");

        Console.ReadKey();



    }


    Console.ReadKey();
}
void Borrow()
{
    try
    {
        Console.Clear();
        ColoredConsole.WriteLine($"{Yellow("*****Borrowing a book of the library*****")}");
        ColoredConsole.WriteLine($"{Yellow("*****************************************")}");
        var book1 = serviceUser.GetListOfLibraryBook();
        ConsoleTable.From<GetBookLibraryDto>(book1)
            .Configure(o => o.NumberAlignment = Alignment.Right)
            .Write(Format.Minimal);
        ColoredConsole.Write($"{Blue("Which book do you want? ")}");
        int id = int.Parse(Console.ReadLine());
       var result= serviceUser.BorrowBook(id, MemoryDb.CurrentUser.Id);
        if (result.IsSuccess)
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Green(result.IsMessage)}");

            Console.ReadKey();

        }
        else
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Red(result.IsMessage)}");


            Console.ReadKey();
        }
    }
    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"{Red("Select a Book.")}");

        Console.ReadKey();



    }

    Console.ReadKey();

}
void Return()
{
    try
    {
        Console.Clear();
        ColoredConsole.WriteLine($"{Yellow("*****Returning a book to the library*****")}");
        ColoredConsole.WriteLine($"{Yellow("*****************************************")}");
        var book2 = serviceUser.GetListOfUserBook(MemoryDb.CurrentUser.Id);
        ConsoleTable.From<GetBookLibraryDto>(book2)
            .Configure(o => o.NumberAlignment = Alignment.Right)
            .Write(Format.Minimal);
       
        ColoredConsole.Write($"{Blue("Which book do you want? ")}");
        int id = int.Parse(Console.ReadLine());
       var result= serviceUser.ReturnBook(id);
        if (result.IsSuccess)
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Green(result.IsMessage)}");

            Console.ReadKey();

        }
        else
        {
            ColoredConsole.WriteLine($"{Yellow("******************************")}");
            ColoredConsole.WriteLine($"{Red(result.IsMessage)}");


            Console.ReadKey();
        }
    }
    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"{Red("Select a Book.")}");

        Console.ReadKey();



    }

    
    Console.ReadKey();
}
void ListOfLibrary()
{
    Console.Clear();
    ColoredConsole.WriteLine($"{Yellow("*****List of books available in the library*****")}");
    ColoredConsole.WriteLine($"{Yellow("************************************************")}");
    var Book = serviceUser.GetListOfLibraryBook();
    ConsoleTable.From<GetBookLibraryDto>(Book)
        .Configure(o => o.NumberAlignment = Alignment.Right)
        .Write(Format.Minimal);
    Console.ReadKey();
}
void ListOfuser()
{
    Console.Clear();
    ColoredConsole.WriteLine($"{Yellow("*******List of books have borrowed*******")}");
    ColoredConsole.WriteLine($"{Yellow("*****************************************")}");
    var Book = serviceUser.GetListOfUserBook(MemoryDb.CurrentUser.Id);
    ConsoleTable.From<GetBookLibraryDto>(Book)
        .Configure(o => o.NumberAlignment = Alignment.Right)
        .Write(Format.Minimal);
    Console.ReadKey();
}
void ShowAllBook()
{
    Console.Clear();
    ColoredConsole.WriteLine($"{Yellow("**********List of books Library**********")}");
    ColoredConsole.WriteLine($"{Yellow("*****************************************")}");
    var Book = serviceUser.ShowBooks();
    ConsoleTable.From<GetBookDto>(Book)
        .Configure(o => o.NumberAlignment = Alignment.Right)
        .Write(Format.Minimal);
    Console.ReadKey();
}
void ShowAllUser()
{
    Console.Clear();
    ColoredConsole.WriteLine($"{Yellow("***************List of Users*************")}");
    ColoredConsole.WriteLine($"{Yellow("*****************************************")}");
    var User = serviceUser.ShowUser();
    ConsoleTable.From<GetUserDto>(User)
        .Configure(o => o.NumberAlignment = Alignment.Right)
        .Write(Format.Minimal);
    Console.ReadKey();
}
void Exit()
{
    MemoryDb.CurrentUser = null;
    ColoredConsole.WriteLine($"{Red("Logout.")}");
}