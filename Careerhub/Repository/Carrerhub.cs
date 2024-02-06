using CareerHub.utility;
using System.Data.SqlClient;

namespace CareerHub.Repository
{
    internal class Carrerhub:ICareerhubImpl
    {
        string databaseConnectionString = DBConnectionUtility.GetConnectionString();
            SqlConnection sqlConnection = null;
            //SqlCommand cmd = null;
            private object _careerHub;

            public void Careerhub()
            {
                SqlCommand sqlCommand = new SqlCommand();
            }

            public void InsertJob(int jobId, int companyId, string jobTitle, string jobDescription, string jobLocation, decimal salary, string jobType, DateTime postedDate)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(databaseConnectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("INSERT INTO Jobs (JobId,CompanyId, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) VALUES (@JobId,@CompanyId, @JobTitle, @JobDescription, @JobLocation, @Salary, @JobType, @PostedDate)", connection))
                        {
                            command.Parameters.AddWithValue("@JobId", jobId);
                            command.Parameters.AddWithValue("@CompanyId", companyId);
                            command.Parameters.AddWithValue("@JobTitle", jobTitle);
                            command.Parameters.AddWithValue("@JobDescription", jobDescription);
                            command.Parameters.AddWithValue("@JobLocation", jobLocation);
                            command.Parameters.AddWithValue("@Salary", salary);
                            command.Parameters.AddWithValue("@JobType", jobType);
                            command.Parameters.AddWithValue("@PostedDate", postedDate);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while inserting the job: {ex.Message}");
                }


            }

            public void InsertCompany(int companyId, string companyName, string location)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(databaseConnectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("INSERT INTO Companies (CompanyId, CompanyName, Location) VALUES (@CompanyId, @CompanyName, @Location)", connection))
                        {
                            command.Parameters.AddWithValue("@CompanyId", companyId);
                            command.Parameters.AddWithValue("@CompanyName", companyName);
                            command.Parameters.AddWithValue("@Location", location);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Company inserted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Error: Company not inserted.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while inserting the company: {ex.Message}");
                }
            }
    }
}
