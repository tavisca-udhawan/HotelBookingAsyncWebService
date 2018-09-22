using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementServices
{
    public interface IRepository
    {
        List<Room> GetHotel(string id);
    }
}
