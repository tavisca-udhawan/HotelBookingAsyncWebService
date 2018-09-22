using AsyncHotel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AsyncHotel.DataAccessLayer
{
    public class SqlRepository
    {
        public bool AddDetails(HotelDetails data)
        {
            try
            {
                Logger.GetInstance.LogMessage("Adding Data to HotelBooking Table");
                using (var connection = new SqlConnection("Data Source=TAVRENTDESK04;Initial Catalog=HotelBookingDB;User ID=sa;Password=test123!@#"))
                {
                    connection.Open();
                    string command = "INSERT INTO HotelBookings(hotelId,roomId,hotelName,hotelAddress,rooms,roomType,price,amenities,image) VALUES(@Id,@roomId,@Name,@Address,@rooms,@Type,@price,@amenities,@image)";
                    SqlCommand cmd = new SqlCommand(command, connection);
                    cmd.Parameters.AddWithValue("@Id", data.ID);
                    cmd.Parameters.AddWithValue("@roomId", data.roomId);
                    cmd.Parameters.AddWithValue("@Name", data.Name);
                    cmd.Parameters.AddWithValue("@Address", data.Address);
                    cmd.Parameters.AddWithValue("@rooms", 1);
                    cmd.Parameters.AddWithValue("@Type", data.roomType);
                    cmd.Parameters.AddWithValue("@price", data.price);
                    cmd.Parameters.AddWithValue("@amenities", data.Amenities);
                    cmd.Parameters.AddWithValue("@image", data.image);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    Logger.GetInstance.LogMessage("Data Inserted Successfully");
                    CassendraRepository updation = new CassendraRepository();
                    updation.updateData(data);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}