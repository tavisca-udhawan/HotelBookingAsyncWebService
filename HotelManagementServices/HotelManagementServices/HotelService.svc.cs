using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HotelManagementServices
{
   public class HotelService : IHotelService
    {
        public List<Room> hotelDetails(string id)
        {
            Repository repository = new Repository();
            //List<Room> list= repository.GetHotel(id);
            return repository.GetHotel(id);
        }
    }
}
