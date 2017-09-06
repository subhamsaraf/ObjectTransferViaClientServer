namespace Client
{
    public class Person
    {

        public PersonName name;
        public Person(string first, string last)
        {
            name = new PersonName();
            name.FirstName = first;
            name.LastName = last;

        }
        
        //private Gender _gender;

        //public Gender Gender
        //{
        //    get { return _gender; }
        //    set { _gender = value; }
        //}
        //private PersonName _name;

        //public PersonName Name
        //{
        //    get { return _name; }
        //    set { _name = name; }
        //}
        //public override string ToString()
        //{
        //    return ($"Name - {name.FirstName.ToString()}");
        //}
    }
}
