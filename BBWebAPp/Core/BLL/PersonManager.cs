using BBWebAPp.Core.DAL;
using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBWebAPp.Core.BLL
{
    public class PersonManager
    {
        PersonGateway personGateway = new PersonGateway();

        public int SavePerson(Person person)
        {
            return personGateway.SavePerson(person);
        }
        public Person GetPersonByEmail(string email)
        {
            return personGateway.GetPersonByEmail(email);
        }
        public Person GetPersonById(int? id)
        {
            return personGateway.GetPersonById(id);
        }
        public int UpdatePerson(Person person)
        {
            return personGateway.UpdatePerson(person); 
        }
        public List<Person> GetPersonByName(string name)
        {
            return personGateway.GetPersonByName(name);
        }
        //local
        public Person SuccessfullLogin(Person person)
        {
            Person existingPerson = GetPersonByEmail(person.Email);
            if (existingPerson != null)
            {
                return (person.Password == existingPerson.Password) ?  existingPerson: null;
            }
            return null;
        }
        public bool IsEmailExist(string email)
        {
            return GetPersonByEmail(email) != null;
        }
        
    }
}