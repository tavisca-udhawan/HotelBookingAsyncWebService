using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsyncHotel.Models
{
    public class HotelDetails
    {
        public int ID { get; set; }
        public int roomId { get; set; }
        public string Name { get; set; }
        public string Amenities { get; set; }
        public string Address { get; set; }
        public string roomType { get; set; }
        public int availableRooms { get; set; }
        public int price { get; set; }

        public string image { get; set; }
    }
}