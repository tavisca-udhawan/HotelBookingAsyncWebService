using AsyncHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AsyncHotel
{
    public class ReadJson
    {
        public List<HotelDetails> GetAllHotels()
        {
            Logger.GetInstance.LogMessage("Getting all Hotels");
            List<HotelDetails> hotels = new List<HotelDetails>();
            using (StreamReader r = new StreamReader("c:/users/udhawan/source/repos/AsyncHotelApplication/AsyncHotelApplication/HotelAmenities.json"))
            {
                string json = r.ReadToEnd();
                List<HotelDetails> items = JsonConvert.DeserializeObject<List<HotelDetails>>(json);
                for (var index = 0; index < items.Count; index++)
                {
                    HotelDetails hotel = new HotelDetails();
                    hotel.ID = items[index].ID;
                    hotel.Name = items[index].Name;
                    hotel.Address = items[index].Address;
                    hotel.Amenities = items[index].Amenities;
                    hotel.image = items[index].image;
                    hotels.Add(hotel);
                }
                Logger.GetInstance.LogMessage("Returning all Hotels");
                return hotels;
            }
        }
        public HotelDetails GetHotelById(int id)
        {
            HotelDetails hotel = new HotelDetails();

            Logger.GetInstance.LogMessage("Searching hotel for a particular Hotel ID");
            using (StreamReader r = new StreamReader("c:/users/udhawan/source/repos/AsyncHotelApplication/AsyncHotelApplication/HotelAmenities.json"))
            {
                var flag = 0;
                string json = r.ReadToEnd();
                List<HotelDetails> items = JsonConvert.DeserializeObject<List<HotelDetails>>(json);
                for (var index = 0; index < items.Count; index++)
                {
                    if (items[index].ID == id)
                    {
                        hotel.ID = items[index].ID;
                        hotel.Name = items[index].Name;
                        hotel.Address = items[index].Address;
                        hotel.Amenities = items[index].Amenities;
                        hotel.image = items[index].image;
                        flag = 1;
                    }
                    if (flag == 1)
                        break;
                }
            }
            Logger.GetInstance.LogMessage("Returning Hotel By particular ID");
            return hotel;

        }

    }
}