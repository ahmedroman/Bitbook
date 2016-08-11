using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBWebAPp.Core.DAL;
using BBWebAPp.Models;

namespace BBWebAPp.Core.BLL
{
    public class StatusManager
    {
        StatusGateway statusGateway = new StatusGateway();
        public int SaveStatus(Status status)
        {
            return statusGateway.SaveStatus(status);
        }
        public int DeleteStatus(int? statusId)
        {
            return statusGateway.DeleteStatus(statusId);
            
        }
        public List<Status> GetAllStatus()
        {
            return statusGateway.GetAllStatus();
        }
        public List<Status> GetStatusByPersonId(int? id) 
        {
            return statusGateway.GetStatusByPersonId(id);
        }

    }
}