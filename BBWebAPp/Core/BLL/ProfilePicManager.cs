using BBWebAPp.Core.DAL;
using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BBWebAPp.Core.BLL
{
    public class ProfilePicManager
    {
        ProfilePicGateway profilePicGateway = new ProfilePicGateway();
        public int SaveProfilePic(ProfilePic profilePic)
        {
            return profilePicGateway.SaveProfilePic(profilePic);
        }
        public int UpdateProfilePic(ProfilePic profilePic)
        {
            return profilePicGateway.UpdateProfilePic(profilePic);
        }
        public ProfilePic GetProfilePicById(int? id)
        {
            return profilePicGateway.GetProfilePicById(id);
        }
        public ProfilePic GetProfilePicByPrsonId(int? personId)
        {
            return profilePicGateway.GetProfilePicByPrsonId(personId);
        }
        //local
        public byte[] FileToByteArray(HttpPostedFileBase file)
        {
            Stream stream = file.InputStream;
            BinaryReader reader = new BinaryReader(stream);
            return reader.ReadBytes((int)stream.Length);
        }
    }
}