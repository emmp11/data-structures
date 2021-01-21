using System;
using DataStructures;

namespace HastTable.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashtable1 = new HashTable(5);

            hashtable1.Insert(new Person() { Name = "Key1", Age = 9 });
            hashtable1.Insert(new Person() { Name = "Key2", Age = 2 });
            hashtable1.Insert(new Person() { Name = "Key3", Age = 10 });
            hashtable1.Insert(new Person() { Name = "Key4", Age = 100 });

            System.Console.WriteLine(hashtable1.Search("Key5").ToString());
            System.Console.WriteLine();
            
            hashtable1.Insert(new Person() { Name = "Key5", Age = 1001 });
            
            System.Console.WriteLine(hashtable1.Search("Key1").ToString());
            System.Console.WriteLine(hashtable1.Search("Key2").ToString());
            System.Console.WriteLine(hashtable1.Search("Key3").ToString());
            System.Console.WriteLine(hashtable1.Search("Key4").ToString());
            System.Console.WriteLine(hashtable1.Search("Key5").ToString());
            System.Console.WriteLine();
            
            // Update existing values
            hashtable1.Insert(new Person(){ Name="Key3", Age=-3 });
            
            System.Console.WriteLine(hashtable1.Search("Key3").ToString());
            System.Console.WriteLine();
        }
    }
}