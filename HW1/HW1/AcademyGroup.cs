using System.Xml.Linq;


namespace HW1
{
    internal class AcademyGroup
    {
        private Person[] _persons = new Person[0];
        private int _count = 0;

        public void Add(Person person)
        {
            Array.Resize(ref _persons, _persons.Length + 1);
            _persons[_count] = person;
            _count = _count + 1;
        }

        public void Remove(string surnamePerson)
        {
            var indexForRemove = _persons.ToList().FindIndex(person => person.Surname == surnamePerson);
            var personrList = _persons.ToList();
            if(indexForRemove != -1)
            {
                personrList.RemoveAt(indexForRemove);
                _persons = personrList.ToArray();
                _count = -1;
            }
        }

        public void Edite(string surnamePerson,string newSurname)
        {             
            var personrList = _persons.ToList();
            var personForEdite = personrList.Where(person => person.Surname == surnamePerson).FirstOrDefault();
            if (personForEdite != null)
            {
                personForEdite.Surname = newSurname;
                _persons = personrList.ToArray();
            }
        }
        public void Print()
        {
             _persons.ToList().ForEach(person =>  Console.WriteLine($"Student Name - {person.Name}: surname - {person.Surname}"));

        }
        public void SaveXls()
        {
            XElement carsXML = new XElement("Group");

            foreach (var person in _persons)
            {
                XElement itemPerson = new XElement("Student",
                    new XElement("Name", $"{person.Name}"),
                    new XElement("Surname", $"{person.Surname}"),
                    new XElement("Age", $"{person.Age}"),
                    new XElement("Phone", $"{person.Phone}")
                    );

                carsXML.Add(itemPerson);
            }
            carsXML.Save("Group.xml");

        }

        public void ReadXls()
        {
            List<Person> persons = new List<Person>();

            XElement groupXml = XElement.Load("Group.xml");
            if (groupXml != null)
            {
                foreach (XElement studentXml in groupXml.Elements("Student"))
                {
                    var name = studentXml.Element("Name").Value;
                    var surname = studentXml.Element("Surname").Value;
                    var age = int.Parse(studentXml.Element("Age").Value);
                    var phone = studentXml.Element("Phone").Value;
                    Person person = new Person(name, surname, age, phone);
                    persons.Add(person);
                }
                _persons = persons.ToArray();
            }
        }
    }
}
