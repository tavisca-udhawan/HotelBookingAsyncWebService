using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelManagementServices
{
    [DataContract]
    public class Room
    {
        [DataMember]
        public int roomId { get; set; }

        [DataMember]
        public string roomType { get; set; }

        [DataMember]
        public int availableRooms { get; set; }

        [DataMember]
        public int price{ get; set; }

    }
}