using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DAOMSSQL
{
    class ResetDAO : IResetDAO
    {
        ResetDAO resetDAO = new ResetDAO();

        public static SqlCommand cmd = new SqlCommand();

        public IList<Flight> DeleteOverdueFlights()
        {
            IList<Flight> resultFlights = new List<Flight>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM FLIGHTS";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flight CurrentresultFlight = new Flight()
                        {
                            FLIGHT_ID = (int)reader["ID"],
                            AIRLINECOMPANY_ID = (int)reader["AIRLINECOMPANY_ID"],
                            ORIGIN_COUNTRY_CODE = (int)reader["ORIGIN_COUNTRY_CODE"],
                            DESTINATION_COUNTRY_CODE = (int)reader["DESTINATION_COUNTRY_CODE"],
                            DEPARTURE_TIME = (DateTime)reader["DEPARTURE_TIME"],
                            LANDING_TIME = (DateTime)reader["LANDING_TIME"],
                            REMAINING_TICKETS = (int)reader["REMAINING_TICKETS"]

                            
                        };
                        DateTime t1 = CurrentresultFlight.LANDING_TIME.;
                        DateTime t2 = DateTime.Now;
                        int sum = t1 - t2;
                        if ((t2 - t1) = 3)

                            resultFlights.Remove(CurrentresultFlight);
                    }
                }
            }
            return resultFlights;
        }
    }
}
