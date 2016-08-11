using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BBWebAPp.Core.DAL
{
    public class PersonGateway:CommonGateway
    {
        public int SavePerson(Person person) 
        {
            string query = String.Format("INSERT INTO Person(Name, Email, Password, Gender) VALUES('{0}','{1}','{2}','{3}');SELECT SCOPE_IDENTITY();",
                person.Name, person.Email, person.Password, person.Gender);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();
            return affectedRow;
        }
        public Person GetPersonByEmail(string email)
        {
            Person person = null;
            string query = String.Format("SELECT * FROM Person WHERE Email='{0}'", email);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    person = new Person();
                    person.Id = Convert.ToInt32(reader["Id"]);
                    person.Name = reader["Name"].ToString();
                    person.Email = reader["Email"].ToString();
                    person.Password = reader["Password"].ToString();
                    person.Gender = reader["Gender"].ToString();
                }
            }
            reader.Close();
            conn.Close();
            return person;
        }
        public Person GetPersonById(int? id)
        {
            Person person = null;
            string query = String.Format("SELECT * FROM Person WHERE Id={0}", id);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    person = new Person();
                    person.Id = Convert.ToInt32(reader["Id"]);
                    person.Name = reader["Name"].ToString();
                    person.Email = reader["Email"].ToString();
                    //person.Password = reader["Password"].ToString();
                    person.Gender = reader["Gender"].ToString();
                    person.Address = reader["Address"].ToString();
                    person.School = reader["School"].ToString();
                    person.Relationship = reader["Relationship"].ToString();
                    person.Work = reader["Work"].ToString();
                    person.Hobby = reader["Hobby"].ToString();
                    person.Language = reader["Language"].ToString();
                }
            }
            reader.Close();
            conn.Close();
            return person;
        }
        public int UpdatePerson(Person person)
        {
            string query = String.Format("UPDATE Person SET Address='{0}', School='{1}', Relationship='{2}', Work='{3}', Hobby='{4}', Language='{5}'",
                person.Address, person.School, person.Relationship, person.Work, person.Hobby, person.Language);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }
        public List<Person> GetPersonByName(string name)
        {
            List<Person> personList = new List<Person>();
            string query = String.Format("SELECT * FROM Person WHERE NAME LIKE '%{0}%'", name);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Person person = new Person();
                    person = new Person();
                    person.Id = Convert.ToInt32(reader["Id"]);
                    person.Name = reader["Name"].ToString();
                    //person.Password = reader["Password"].ToString();
                    personList.Add(person);
                }
            }
            reader.Close();
            conn.Close();
            return personList;
        }

    }
}