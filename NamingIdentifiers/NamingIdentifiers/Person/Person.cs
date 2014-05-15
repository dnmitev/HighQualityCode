namespace NamingIdentifiers.Person
{
    using System;
    using System.Linq;

    public class Person
    {
        public Gender Sex { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public void CreatePerson(int personAge)
        {
            Person newPerson = new Person();

            newPerson.Age = personAge;

            if (personAge % 2 == 0)
            {
                newPerson.Name = "Chuck Norris";
                newPerson.Sex = Gender.Male;
            }
            else
            {
                newPerson.Name = "Charlize Teron";
                newPerson.Sex = Gender.Female;
            }
        }
    }
}