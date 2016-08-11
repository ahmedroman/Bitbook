using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BBWebAPp.Models;

namespace BBWebAPp.Core.DAL
{
    public class StatusGateway:CommonGateway
    {
        public int SaveStatus(Status status)
        {
            string query = String.Format("INSERT INTO Status(Post, Date, PersonId, PersonName) VALUES('{0}','{1}',{2}, '{3}')",
                status.Post, status.Date, status.PersonId, status.PersonName);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }
        public int DeleteStatus(int? statusId)
        {
            string query = String.Format("DELETE FROM Status WHERE Id={0}", statusId);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }

        public List<Status> GetAllStatus()
        {
            List<Status> statusList = new List<Status>();
            string query = String.Format("SELECT * FROM Status ORDER BY Date DESC");
            command= new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Status status = new Status();
                    status.Id = Convert.ToInt32(reader["Id"]);
                    status.Post = reader["Post"].ToString();
                    status.Date = Convert.ToDateTime(reader["Date"]);
                    status.PersonId = Convert.ToInt32(reader["PersonId"]);
                    status.PersonName = reader["PersonName"].ToString();
                    statusList.Add(status);
                }
            }
            reader.Close();
            conn.Close();
            return statusList;
        }
        public List<Status> GetStatusByPersonId(int? id)
        {
            List<Status> statusList = new List<Status>();
            string query = String.Format("SELECT * FROM Status WHERE PersonId={0} ORDER BY Date DESC", id);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Status status = new Status();
                    status.Id = Convert.ToInt32(reader["Id"]);
                    status.Post = reader["Post"].ToString();
                    status.Date = Convert.ToDateTime(reader["Date"]);
                    status.PersonId = Convert.ToInt32(reader["PersonId"]);
                    status.PersonName = reader["PersonName"].ToString();

                    statusList.Add(status);
                }
            }
            reader.Close();
            conn.Close();
            return statusList;
        }
    }
}