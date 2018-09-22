using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagementServices
{
    public class Repository:IRepository
    {
        public List<Room> GetHotel(string id)
        {
            try
            {
                List<Room> rooms = new List<Room>();
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                var session = cluster.Connect("HotelDetailsDB");
               var command = session.Execute("select * from \"RoomDetails\" where hotelid=" + Convert.ToInt32(id) + " ALLOW FILTERING");
                foreach(var room in command)
                {
                    Room details = new Room();
                    details.availableRooms = Convert.ToInt32(room["availablerooms"]);
                    details.roomType = room["roomtype"].ToString();
                    details.roomId = Convert.ToInt32(room["roomid"]);
                    details.price = Convert.ToInt32(room["price"]);
                    rooms.Add(details);
                }
                if (rooms.Count > 0)
                    return rooms;
                else
                {
                    Room details = new Room();
                    details.availableRooms = 0;
                    details.roomType ="Not Available";
                    details.roomId = 0;
                    details.price = 0;
                    rooms.Add(details);
                    return rooms;
                }
                    
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}