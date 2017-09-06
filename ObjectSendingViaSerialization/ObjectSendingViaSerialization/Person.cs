namespace ObjectSendingViaSerialization
{
    public class Person
    {
        private Gender _gender;

        public Gender Gender 
        {
            get { return _gender; }
            set { _gender = value; }
        }
        private Name _name;

        public Name Name
        {
            get { return _name; }
            set { _name = value; }
        }



    }
}
