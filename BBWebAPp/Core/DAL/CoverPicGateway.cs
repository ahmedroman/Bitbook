using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BBWebAPp.Core.DAL
{
    public class CoverPicGateway:CommonGateway
    {
        public int SaveCoverPic(CoverPic coverPic)
        {
            command = new SqlCommand("SaveCoverePic", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter paramCaption = new SqlParameter()
            {
                ParameterName = "@Caption",
                Value = coverPic.Caption
            };
            command.Parameters.Add(paramCaption);
            SqlParameter paramPic = new SqlParameter()
            {
                ParameterName = "@Pic",
                Value = coverPic.Pic
            };
            command.Parameters.Add(paramPic);
            SqlParameter paramPersonId = new SqlParameter()
            {
                ParameterName = "@PersonId",
                Value = coverPic.Personid
            };
            command.Parameters.Add(paramPersonId);
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
            if (affectedRow > 0)
            {
                return Convert.ToInt32(command.Parameters["@NewId"].Value);
            }

            return affectedRow;
        }
        public int UpdateCoverPic(CoverPic coverPic)
        {
            command = new SqlCommand("UpdateCoverPic", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter pramCaption = new SqlParameter()
            {
                ParameterName = "@Caption",
                Value = coverPic.Caption
            };
            command.Parameters.Add(pramCaption);
            SqlParameter pramPic = new SqlParameter()
            {
                ParameterName = "@Pic",
                Value = coverPic.Pic
            };
            command.Parameters.Add(pramPic);
            SqlParameter pramPersonId = new SqlParameter()
            {
                ParameterName = "@PersonId",
                Value = coverPic.Personid
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

        public CoverPic GetCoverPicById(int? id)
        {
            CoverPic coverPic = null;
            command = new SqlCommand("GetCoverPicById", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter pramId = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = id
            };
            command.Parameters.Add(pramId);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    coverPic = new CoverPic();
                    coverPic.Id = Convert.ToInt32(reader["Id"]);
                    coverPic.Caption = reader["Caption"].ToString();
                    coverPic.Pic = (byte[])reader["Pic"];
                    coverPic.Personid = Convert.ToInt32(reader["Personid"]);

                }
            }
            reader.Close();
            conn.Close();
            return coverPic;
        }
        public CoverPic GetCoverPicByPrsonId(int? personId)
        {
            CoverPic coverPic = null;
            command = new SqlCommand("GetCoverPicByPersonId", conn);
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
                    coverPic = new CoverPic();
                    coverPic.Id = Convert.ToInt32(reader["Id"]);
                    coverPic.Caption = reader["Caption"].ToString();
                    coverPic.Pic = (byte[])reader["Pic"];
                    coverPic.Personid = Convert.ToInt32(reader["Personid"]);

                }
            }
            reader.Close();
            conn.Close();
            return coverPic;
        }
    }
}