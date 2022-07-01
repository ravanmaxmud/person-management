using System;
using System.Collections.Generic;

namespace PersonManagement
{
    internal class Program
    {
           public static List<Person> persons = new List<Person>();
        static void Main(string[] args)
        {

            Console.WriteLine("Our available commands :");
            Console.WriteLine("/add-new-person");
            Console.WriteLine("/remove-person");
            Console.WriteLine("/show-persons");
            Console.WriteLine("/remove-all-persons");
            Console.WriteLine("/exit");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command : ");
                string command = Console.ReadLine();

                if (command == "/add-new-person")
                {
                    Console.Write("Please add person's name :");
                    string name = Console.ReadLine();

                    Console.Write("Please add person's surname :");
                    string lastName = Console.ReadLine();

                    Console.Write("Please add person's FIN code :");
                    string fin = Console.ReadLine();
                    Person person = AddNewPersons(name, lastName, fin);
                    
                    Console.WriteLine(person.GetInfo() + " - Added to system.");
                }
                else if (command == "/remove-person")
                {
                    Console.Write("To remove person, please enter his/her FIN code : ");
                    string fin = Console.ReadLine();
                    RemovePerson(fin);
                }
                else if (command == "/show-persons")
                {
                    Console.WriteLine("Persons in database : ");
                    ShowPersons();
                }
                else if (command == "/remove-all-persons")
                {
                    RemoveAllPersons();
                    Console.WriteLine("All Persons Removed Succesifully");
                }
                else if (command == "/exit")
                {
                    Console.WriteLine("Thanks for using our application!");
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found, please enter command from list!");
                    Console.WriteLine();
                }
            }
        }

        public static Person AddNewPersons(string name,string lastName,string fin)
        {
            Person person = new Person(name, lastName, fin);
            persons.Add(person);
            return person;   
        }
        public static void RemovePerson(string fin)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].FIN == fin)
                {
                    Console.WriteLine(persons[i].GetInfo());
                    persons.RemoveAt(i);
                    Console.WriteLine("Person removed successfully");
                }
            }
        }
        public static void ShowPersons()
        {
            foreach (Person person in persons)
            {
                Console.WriteLine(person.GetInfo());
            }
        }
        public static void RemoveAllPersons()
        {
            for (int i = 0; i <= persons.Count; i++)
            {
                persons.RemoveAt(0);
            }
        }
    }

    class Person
    {
        public static uint _idCounter = 1;
        public  uint Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FIN { get; set; }

        public Person(string name, string lastName, string fin)
        {
            Id = _idCounter;
            Name = name;
            LastName = lastName;
            FIN = fin;
            _idCounter++;
        }

        public string GetFullName()
        {
            return Name + " " + LastName;
        }

        public string GetInfo()
        {
            return Id+" "+ Name + " " + LastName + " " + FIN;
        }
    }
}
