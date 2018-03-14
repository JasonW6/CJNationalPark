using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;
using System.Data.SqlClient;

namespace NPGeek.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        readonly string connectionString;

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool AddSurveyResultToDB(Survey survey)
        {
            bool result = false;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) " +
                                                    "VALUES (@parkCode, @emailAddress, @state, @activityLevel);", conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return result;
        }

        public List<SurveyResult> GetAllSurveys()
        {
            List<SurveyResult> results = new List<SurveyResult>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT " +
                                                    "   p.parkName, " +
                                                    "   p.parkCode, " +
                                                    "   COUNT(*) as count " +
                                                    "FROM survey_result sr " +
                                                    "JOIN park p ON p.parkCode = sr.parkCode " +
                                                    "GROUP BY " +
                                                    "   p.parkCode, " +
                                                    "   p.parkName " +
                                                    "ORDER BY COUNT(*) DESC, p.parkName ASC;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyResult result = new SurveyResult();

                        result.ParkCode = Convert.ToString(reader["parkCode"]);
                        result.ParkName = Convert.ToString(reader["parkName"]);
                        result.VoteCount = Convert.ToInt32(reader["count"]);

                        results.Add(result);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return results;
        }
    }
}