using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace ContactManager
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Write number of option you need and press Enter to continue");
                Console.WriteLine("1 - Add new contact");
                Console.WriteLine("2 - Update contact");
                Console.WriteLine("3 - Delete contact");
                Console.WriteLine("4 - View all contacts");
                Console.WriteLine("5 - Exit");
                Console.WriteLine("-----------------------------------------------------------");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("-----------------------------------------------------------");
                        Contact con = new Contact();
                        Console.WriteLine("Please write contact's name:");
                        con.name = Console.ReadLine();
                        Console.WriteLine("Please write contact's last name:");
                        con.lastName = Console.ReadLine();
                        Console.WriteLine("Please write contact's phone number:");
                        con.phoneNumber = Console.ReadLine();
                        Console.WriteLine("Please write contact's address:");
                        con.address = Console.ReadLine();
                        Console.WriteLine(CSV.SaveCSV(con));
                        break;
                    case "2":
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine("Write phone number that you want to update:");
                        string phNum = Console.ReadLine();
                        con = new Contact();
                        Console.WriteLine("Please write new contact's name:");
                        con.name = Console.ReadLine();
                        Console.WriteLine("Please write new contact's last name:");
                        con.lastName = Console.ReadLine();
                        Console.WriteLine("Please write new contact's phone number:");
                        con.phoneNumber = Console.ReadLine();
                        Console.WriteLine("Please write new contact's address:");
                        con.address = Console.ReadLine();
                        Console.WriteLine(CSV.UpdateCSV(phNum, con));
                        break;
                    case "3":
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine("Write phone number that you want to delete:");
                        Console.WriteLine(CSV.DeleteCSV(Console.ReadLine()));
                        break;
                    case "4":
                        Console.WriteLine("-----------------------------------------------------------");
                        List<Contact> conList = CSV.ReadCSV();
                        if (conList.Count == 0)
                        {
                            Console.WriteLine("Contact list is empty");
                        }
                        else
                        {
                            for (int i = 0; i < conList.Count; i++)
                            {
                                Console.WriteLine(conList[i].name + " " + conList[i].lastName + " " + conList[i].phoneNumber + " " + conList[i].address);
                            }
                        }
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
