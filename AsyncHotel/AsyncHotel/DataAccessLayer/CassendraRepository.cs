using AsyncHotel.Models;
using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsyncHotel.DataAccessLayer
{
    public class CassendraRepository
    {
        public bool updateData(HotelDetails data)
        {
            try
            {
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                var session = cluster.Connect("HotelDetailsDB");
                var command = session.Execute("update \"RoomDetails\" set availablerooms=" + (data.availableRooms - 1) + " where roomid=" + data.roomId);
                Logger.GetInstance.LogMessage("Updated Data in Room details Table");
                return true;
            }
            catch (Exception ex)
            {
                Logger.GetInstance.LogMessage("Exception occured");
                return false;
            }
        }
    }
}