using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBIvancheva
{
    internal class Stuff1
    {
        public readonly static string connectionString = @"Data Source=DESKTOP-M7EVVNL\SQLEXPRESS;Initial Catalog=dataBaseEngine;Integrated Security=True";
        public class Patient
        {
            public string CardID { get; set; }
            public string FullName { get; set; }
            public char Gender { get; set; }
            public string DateOfBirth { get; set; }
            public string Adress { get; set; }
            public string PhoneNumber { get; set; }
        }

        public class Methods
        {
            public static Patient GetPatientByID(string ID)
            {
                Patient patient = new Patient();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select * from Patients where CardID = @ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("ID", ID);  
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    patient.CardID = reader["CardID"].ToString();
                    patient.FullName = reader["FullName"].ToString();
                    patient.Gender = reader["Gender"].ToString()[0];
                    patient.DateOfBirth = reader["DateOfBirth"].ToString().Substring(0,10);
                    patient.Adress = reader["Adress"].ToString();
                    patient.PhoneNumber = reader["PhoneNumber"].ToString();
                }
                return patient;
            }
            
            public static void AddPatient(Patient patient)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "insert into Patients " +
                        "values (@ID, @FullName, @Gender, @DateOfBirth, @Adress, @PhoneNumber)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("ID", patient.CardID);
                    command.Parameters.AddWithValue("FullName", patient.FullName);
                    command.Parameters.AddWithValue("Gender", patient.Gender);
                    command.Parameters.AddWithValue("DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("Adress", patient.Adress);
                    command.Parameters.AddWithValue("PhoneNumber", patient.PhoneNumber);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            public static void UpdatePatient(Patient patient)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "update Patients set FullName = @FullName, " +
                        "Gender = @Gender, DateOfBirth = @DateOfBirth, Adress = @Adress, PhoneNumber = @PhoneNumber " +
                        "where CardID = @ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("ID", patient.CardID);
                    command.Parameters.AddWithValue("FullName", patient.FullName);
                    command.Parameters.AddWithValue("Gender", patient.Gender);
                    command.Parameters.AddWithValue("DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("Adress", patient.Adress);
                    command.Parameters.AddWithValue("PhoneNumber", patient.PhoneNumber);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            public static void DeletePatient(string CardID)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "delete from Patients where CardID = @ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("ID", CardID);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
