using AsyncHotel.DataAccessLayer;
using AsyncHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AsyncHotel.Controllers
{
    public class ValuesController : ApiController
    {
        HttpClient client = new HttpClient();

        static List<HotelDetails> entireList = new List<HotelDetails>();
        HotelDetails JsonList = new HotelDetails();
        List<HotelDetails> HotelList = new List<HotelDetails>();
        [Route("get")]
        [HttpGet]
        public List<HotelDetails> Get()
        {
            ReadJson obj = new ReadJson();
            Logger.GetInstance.LogMessage("Get call executing");
            return obj.GetAllHotels();
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<List<HotelDetails>> Get(int id)
        {
            await Task.Run(async () =>
            {
                Logger.GetInstance.LogMessage("Getting data from WCF Service");
                client.BaseAddress = new Uri("http://localhost:63833");
                HttpResponseMessage response = await client.GetAsync("HotelService.svc/Hotel/" + id.ToString() + "");
                if (response.IsSuccessStatusCode)
                {
                    HotelList = await response.Content.ReadAsAsync<List<HotelDetails>>();

                }
            });
            await Task.Run(() =>
            {
                Logger.GetInstance.LogMessage("Getting Data from JSON");
                ReadJson json = new ReadJson();

                JsonList = json.GetHotelById(id);
            });
            for (int i = 0; i < HotelList.Count; i++)
            {

                HotelDetails entireObject = new HotelDetails();
                entireObject.ID = JsonList.ID;
                entireObject.Name = JsonList.Name;
                entireObject.roomId = HotelList[i].roomId;
                entireObject.Address = JsonList.Address;
                entireObject.Amenities = JsonList.Amenities;
                entireObject.roomType = HotelList[i].roomType;
                entireObject.availableRooms = HotelList[i].availableRooms;
                entireObject.image = JsonList.image;
                entireObject.price = HotelList[i].price;
                entireList.Add(entireObject);
            }
            Logger.GetInstance.LogMessage("Returning all details");
            return entireList;
        }

        [Route("post/{roomID}")]
        [HttpPost]
        public IHttpActionResult Post(int roomID)
        {
            Logger.GetInstance.LogMessage("Post call executing");
            SqlRepository addData = new SqlRepository();
            HotelDetails data = new HotelDetails();
            for (var i = 0; i < entireList.Count; i++)
            {
                if (entireList[i].roomId == roomID)
                {
                    data = entireList[i];

                }
            }
            bool result = addData.AddDetails(data);
            if (result == true)
            {
                Logger.GetInstance.LogMessage("Data saved successfully");
                return Ok("Data saved successfully");
            }
            Logger.GetInstance.LogMessage("Invalid");
            return BadRequest("Invalid");
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
