using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BBWebAPp.Core.DAL
{
    public class ProfilePicGateway:CommonGateway
    {
        public int SaveProfilePic(ProfilePic profilePic)
        {
            command = new SqlCommand("SaveProfilePic", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter paramCaption = new SqlParameter() { 
                ParameterName = "@Caption",
                Value = profilePic.Caption
            };
            command.Parameters.Add(paramCaption);
            SqlParameter paramPic = new SqlParameter() { 
                ParameterName = "@Pic",
                Value = profilePic.Pic
            };
            command.Parameters.Add(paramPic);
            SqlParameter paramPersonId = new SqlParameter() { 
                ParameterName = "@PersonId",
                Value = profilePic.Personid
            };
            command.Parameters.Add(paramPersonId);
            SqlParameter paramNewId = new SqlParameter() { 
                ParameterName = "@NewId",
                Value = -1,
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(paramNewId);

            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            if(affectedRow > 0){
                return Convert.ToInt32(command.Parameters["@NewId"].Value);
            }

            return affectedRow;
        }
        public int UpdateProfilePic(ProfilePic profilePic)
        {
            command = new SqlCommand("UpdateProfilePic", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter pramCaption = new SqlParameter() { 
                ParameterName = "@Caption",
                Value = profilePic.Caption
            };
            command.Parameters.Add(pramCaption);
            SqlParameter pramPic = new SqlParameter() { 
                ParameterName = "@Pic",
                Value = profilePic.Pic
            };
            command.Parameters.Add(pramPic);
            SqlParameter pramPersonId = new SqlParameter() { 
                ParameterName = "@PersonId",
                Value = profilePic.Personid
            };
            command.Parameters.Add(pramPersonId);
            SqlParameter paramNewId = new SqlParameter()
            {
                ParameterName = "@NewId",
                Value = -1,
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(paramNewId);

            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            
            return affectedRow;
        }
        public ProfilePic GetProfilePicById(int? id)
        {
            ProfilePic profilePic = null;
            command = new SqlCommand("GetProPicById", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter pramId = new SqlParameter() { 
                ParameterName = "@Id",
                Value = id
            };
            command.Parameters.Add(pramId);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    profilePic = new ProfilePic();
                    profilePic.Id = Convert.ToInt32(reader["Id"]);
                    profilePic.Caption = reader["Caption"].ToString();
                    profilePic.Pic = (byte[])reader["Pic"];
                    profilePic.Personid = Convert.ToInt32(reader["Personid"]);

                }
            }
            reader.Close();
            conn.Close();
            return profilePic;
        }
        public ProfilePic GetProfilePicByPrsonId(int? personId)
        {
            ProfilePic profilePic = null;
            command = new SqlCommand("GetProPicByPersonId", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter pramId = new SqlParameter()
            {
                ParameterName = "@PersonId",
                Value = personId
            };
            command.Parameters.Add(pramId);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    profilePic = new ProfilePic();
                    profilePic.Id = Convert.ToInt32(reader["Id"]);
                    profilePic.Caption = reader["Caption"].ToString();
                    profilePic.Pic = (byte[])reader["Pic"];
                    profilePic.Personid = Convert.ToInt32(reader["Personid"]);

                }
            }
            reader.Close();
            conn.Close();
            return profilePic;
        }

    }
}