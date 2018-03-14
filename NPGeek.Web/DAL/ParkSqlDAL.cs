using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;
using System.Data.SqlClient;

namespace NPGeek.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        readonly string connectionString;

        public ParkSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }



        public List<NationalPark> GetAllParks()
        {
            List<NationalPark> parks = new List<NationalPark>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"select * from park", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        NationalPark nationalPark = MapSqlRowToPark(reader);
                        
                        parks.Add(nationalPark);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return parks;
            
        }

        public NationalPark GetParkByParkCode(string parkCode)
        {
            throw new NotImplementedException();
        }


        private NationalPark MapSqlRowToPark(SqlDataReader reader)
        {

            NationalPark nationalPark = new NationalPark();
            nationalPark.ParkCode = Convert.ToString(reader["parkCode"]);
            nationalPark.ParkName = Convert.ToString(reader["parkName"]);
            nationalPark.State = Convert.ToString(reader["state"]);
            nationalPark.Acreage = Convert.ToInt32(reader["acreage"]);
            nationalPark.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
            nationalPark.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
            nationalPark.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
            nationalPark.Climate = Convert.ToString(reader["climate"]);
            nationalPark.YearFounded = Convert.ToInt32(reader["yearFounded"]);
            nationalPark.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
            nationalPark.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
            nationalPark.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
            nationalPark.ParkDecription = Convert.ToString(reader["parkDescription"]);
            nationalPark.EntryFee = Convert.ToInt32(reader["entryFee"]);
            nationalPark.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

            return nationalPark;
        }
    }
}