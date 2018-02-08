﻿using System;
using static System.Console;
using Packt.CS7;
using PacktLibrary;
using System.Collections.Generic;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var sam = new Person
            {
                Name = "Sam",
                DOB = new DateTime(1972, 1, 27)
            };
            WriteLine(sam.Origin);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);

            WriteLine("*********************************");

            sam.FaveIceCream = "Chocolate Fudge";
            WriteLine($"Sam's favorite ice-cream flavor is  {sam.FaveIceCream}.");
            sam.FavePrimaryColor = "Red";
            WriteLine($"Sam's favorite primary color is  {sam.FavePrimaryColor}.");

            WriteLine("*********************************");

            var p1 = new Person();
            p1.Name = "Bob Smith";
            p1.DOB = new System.DateTime(1965, 12, 22);
            p1.FavHobby = "Lute";
            WriteLine($"{p1.Name} was born on {p1.DOB:dddd, d MMMM  yyyy}. Favorite hobby is {p1.FavHobby}.");
            p1.FavouriteAncientWonder =
                WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            WriteLine($"{p1.Name}'s favourite wonder is {p1.FavouriteAncientWonder}");

            p1.Children.Add(new Person { Name = "Alfred" });
            p1.Children.Add(new Person { Name = "Zoe" });
            WriteLine($"{p1.Name} has {p1.Children.Count} children:");
            for (int child = 0; child < p1.Children.Count; child++)
            {
                WriteLine($"  {p1.Children[child].Name}");
            }

            WriteLine($"{p1.Name} is a {Person.Species}");
            WriteLine($"{p1.Name} was born on {p1.HomePlanet}"); // readonly preferrable to const, I guess.

            WriteLine("*********************************");

            int a = 10;
            int b = 20;
            int c = 30;
            WriteLine($"Before: a = {a}, b = {b}, c = {c}");
            p1.PassingParameters(a, ref b, out c);
            WriteLine($"After: a = {a}, b = {b}, c = {c}");

            WriteLine("*********************************");

            // simplified C# 7 syntax for out parameters
            int d = 10;
            int e = 20;
            WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");
            p1.PassingParameters(d, ref e, out int f);
            WriteLine($"After: d = {d}, e = {e}, f = {f}");

            //WriteLine("*********************************");

            //var p3 = new Person();
            //WriteLine($"{p3.Name} was instantiated at {p3.Instantiated:hh:mm:ss} on { p3.Instantiated:dddd, d MMMM yyyy}");

            //WriteLine("*********************************");

            //var p4 = new Person("Aziz");
            //WriteLine($"{p4.Name} was instantiated at { p4.Instantiated:hh: mm: ss} on { p4.Instantiated:dddd, d MMMM yyyy}");

            //WriteLine("*********************************");

            //p1.WriteToConsole();
            //WriteLine(p1.GetOrigin());

            //WriteLine("*********************************");
            //WriteLine(p1.OptionalParameters());

            //WriteLine("*********************************");

            //Tuple<string, int> fruit4 = p1.GetFruitCS4();
            //WriteLine($"There are {fruit4.Item2} {fruit4.Item1}.");

            //(string, int) fruit7 = p1.GetFruitCS7();
            //WriteLine($"{fruit7.Item1}, {fruit7.Item2} there are.");

            //var fruitNamed = p1.GetNamedFruit();
            //WriteLine($"Are there {fruitNamed.Number} {fruitNamed.Name}?");

            //WriteLine("*********************************");

            ////var p2 = new Person
            ////{
            ////    Name = "Alice Jones",
            ////    DOB = new DateTime(1998, 3, 17),
            ////    FavHobby = "Piano"
            ////};
            ////WriteLine($"{p2.Name} was born on {p2.DOB:dddd, d MMMM  yyyy}. Favorite hobby is {p2.FavHobby}.");

            //WriteLine("*********************************");

            //BankAccount.InterestRate = 0.012M;

            //var ba1 = new BankAccount();
            //ba1.AccountName = "Mrs. Jones";
            //ba1.Balance = 2400;
            //WriteLine($"{ba1.AccountName} earned {ba1.Balance * BankAccount.InterestRate:C} interest.");

            //var ba2 = new BankAccount();
            //ba2.AccountName = "Ms. Gerrier"; 
            //ba2.Balance = 98;

            //WriteLine($"{ba2.AccountName} earned {ba2.Balance * BankAccount.InterestRate:C} interest.");


        }
    }
}