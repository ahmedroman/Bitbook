using BBWebAPp.Core.DAL;
using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BBWebAPp.Core.BLL
{
    public class CoverPicManager
    {
        CoverPicGateway coverPicGateway = new CoverPicGateway();
        public int SaveCoverPic(CoverPic coverPic)
        {
            return coverPicGateway.SaveCoverPic(coverPic);
        }
        public int UpdateCoverPic(CoverPic coverPic)
        {
            return coverPicGateway.UpdateCoverPic(coverPic);
        }
        public CoverPic GetCoverPicById(int? id)
        {
            return coverPicGateway.GetCoverPicById(id);
        }
        public CoverPic GetCoverPicByPrsonId(int? personId)
        {
            return coverPicGateway.GetCoverPicByPrsonId(personId);
        }
        public byte[] FileToByteArray(HttpPostedFileBase file)
        {
            Stream stream = file.InputStream;
            BinaryReader reader = new BinaryReader(stream);
            return reader.ReadBytes((int)stream.Length);
        }


    }
}