using System.Collections.Generic;

namespace ObjectSendingViaSerialization
{
    public class PersonHolder
    {
        private List<Person> _personList = null;
        public PersonHolder()
        {
            this.SetValuesToPersons();
        }

        public List<Person> GetPersonList()
        {
            return _personList;
        }
        private void SetValuesToPersons()
        {
            _personList = new List<Person>();
          //  Person A1 = new Person

          //Add the A1,A2 to the person List 
          //_personList.Add(A1);
        }
    }
}
