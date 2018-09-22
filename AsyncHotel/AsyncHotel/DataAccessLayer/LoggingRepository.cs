﻿using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsyncHotel.DataAccessLayer
{
    public class LoggingRepository
    {
        public void AddLog(string message)
        {
            try
            {
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                var session = cluster.Connect("HotelDetailsDB");
                var command = session.Prepare("INSERT INTO \"Logging\" (id,message,time) VALUES (?,?,?)");
                var execution = command.Bind(Guid.NewGuid(), message, DateTime.Now.ToString());
                session.Execute(execution);
            }
            catch (Exception ex)
            {
                Logger.GetInstance.LogMessage("Exception occured");
               
            }
        }
    }
}