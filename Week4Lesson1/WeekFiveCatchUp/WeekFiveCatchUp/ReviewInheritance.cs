using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekFiveCatchUp
{
    public class ReviewInheritance
    {

        public static void ReviewBaseClasses()
        {
            /*Warrior warrior = new Warrior("Conan");
            warrior.Attack();
            Warrior archer = new Archer("Birgitte", "Silver Bow");
            archer.Attack();

            Archer warArcher = (Archer)archer;
            warArcher.Attack();*/

            Parent parent = new Parent("Kyle");
            parent.ToString();

            Child child = new Child("Liam", 25);

            Parent derivedParent = new Child("Galway", 25);
            Console.WriteLine(parent.ToString());
            Console.WriteLine(child.ToString());
            Console.WriteLine(derivedParent.ToString());
        }
    }

    public class Parent
    {
        public string Name { get; set; }

        public Parent(string name)
        {
            Console.WriteLine("The parent is being constructed first!");
            Name = name;
        }

        override public string ToString()
        {
            return $"The parent's name is: {Name}";
        }
    }

    public class Child: Parent
    {
        public int Age
        { get; set; }

        public Child(string name, int age): base(name)
        {
            Console.WriteLine($"The child named {base.Name} is being constructed second!");
            Age = age;
        }

        public string ToString()
        {
            return $"{Name} is {Age} years old.";
        }
    }
}
