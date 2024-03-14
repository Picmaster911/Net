namespace HW1
{
    internal class Person
    {
        protected string _name;
        protected string _surname;
        protected int _age;
        protected string _phone;

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public int Age { get => _age; set => _age = value; }
        public string Phone { get => _phone; set => _phone = value; }

        public Person(string name, string surname, int age, string phone)
        {
            _name = name;
            _surname = surname;
            _age = age;
            _phone = phone;
        }

        public virtual void Print ()
        {
            Console.WriteLine($"Surname is {Surname}, name is {Name}, age = {Age}, phone: {Phone}");
        }
    }
}
