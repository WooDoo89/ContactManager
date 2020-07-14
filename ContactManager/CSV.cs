using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContactManager
{
    static class CSV
    {
        public static List<Contact> ReadCSV()
        {
            Contact con = new Contact();
            List<Contact> conList = new List<Contact>();
            StreamReader reader = new StreamReader(File.OpenRead("./Contacts.csv"));
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (!String.IsNullOrWhiteSpace(line))
                {
                    string[] values = line.Split(',');
                    if (values.Length >= 4)
                    {
                        con.name = values[0];
                        con.lastName = values[1];
                        con.phoneNumber = values[2];
                        con.address = values[3];
                        conList.Add(con);
                        con = new Contact();
                    }
                }
            }
            reader.Close();
            return conList;
        }
        public static string SaveCSV(Contact con)
        {
            if(checkIfExists(con.phoneNumber) == true)
            {
                return "This contact already exists";
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("./Contacts.csv", true))
            {
                file.WriteLine(con.name + "," + con.lastName + "," + con.phoneNumber + "," + con.address);
            }
            return "Contact has been saved";
        }
        public static string DeleteCSV(string remove)
        {
            if(checkIfExists(remove) == false)
            {
                return "This phone number is not in the contact list";
            }
            List<String> lines = new List<string>();
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("./Contacts.csv");
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }
            lines.RemoveAll(l => l.Contains(remove));
            file.Close();
            using (System.IO.StreamWriter outfile = new System.IO.StreamWriter("./Contacts.csv"))
            {
                outfile.Write(String.Join(System.Environment.NewLine, lines.ToArray()));
            }
            return "Contact has been deleted";
        }
        public static string UpdateCSV(string phNumber, Contact con)
        {
            if (checkIfExists(phNumber) == false)
            {
                return "This phone number is not in the contact list";
            }
            List<Contact>conList = ReadCSV();
            for (int i = 0; i < conList.Count; i++)
            {
                if (conList[i].phoneNumber == phNumber)
                {
                    conList[i].name = con.name;
                    conList[i].lastName = con.lastName;
                    conList[i].phoneNumber = con.phoneNumber;
                    conList[i].address = con.address;
                }
            }
            using (System.IO.StreamWriter outfile = new System.IO.StreamWriter("./Contacts.csv", false))
            {
                for (int i = 0; i < conList.Count; i++)
                {
                    outfile.WriteLine(conList[i].name + "," + conList[i].lastName + "," + conList[i].phoneNumber + "," + conList[i].address);
                }
            }
            return "Contact has been updated";
        }
        private static bool checkIfExists(string phone)
        {
            int check = 0;
            List<Contact> conList = ReadCSV();
            for (int i = 0; i < conList.Count; i++)
            {
                if (conList[i].phoneNumber == phone)
                {
                    check = 1;
                    return true;
                }
            }
            if(check == 0)
            {
                return false;
            }
            return true;
        }
    }
}
