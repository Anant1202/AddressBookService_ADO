using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_AddressBookServiceDB
{
    public class AddressBook
    {
        public static void CreateDatabase()
        {
            SqlConnection con = new SqlConnection("data source=DESKTOP-MC3EMTI; initial catalog=AddressBookServiceDB; integrated security=true");
            try
            {
                // writing sql query  
                SqlCommand cm = new SqlCommand("create database AddressBookServiceADO", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("database created  Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
        public int InsertIntoTable(AddressBookTable obj)
        {
            SqlConnection con = new SqlConnection("data source=DESKTOP-MC3EMTI; initial catalog=AddressBookServiceDB; integrated security=true");
            int result = 0;
            try
            {
                using (con)
                {
                    SqlCommand sqlCommand = new SqlCommand("SP_InsertintoTable", con);
                    //setting command type as Stored Procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", obj.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", obj.LastName);
                    sqlCommand.Parameters.AddWithValue("@Address", obj.Address);
                    sqlCommand.Parameters.AddWithValue("@City", obj.City);
                    sqlCommand.Parameters.AddWithValue("@State", obj.State);
                    sqlCommand.Parameters.AddWithValue("@zip", obj.zip);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Email", obj.Email);
                    sqlCommand.Parameters.AddWithValue("@addressBookName", obj.AddressBookName);
                    sqlCommand.Parameters.AddWithValue("@addressBookType", obj.Type);
                    con.Open();
                    //Executing the SQL query
                    result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Updated");
                    }
                    else
                    {
                        Console.WriteLine("Not Updated");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public int UpdateExistingContactBasedonName()
        {
            SqlConnection con = new SqlConnection("data source=DESKTOP-MC3EMTI; initial catalog=AddressBookServiceDB; integrated security=true");
            //Open Connection
            con.Open();
            string query = "Update AddressBookTable set Address = 'Pune' where FirstName = 'Karan'";
            //Pass query to TSql
            SqlCommand sqlCommand = new SqlCommand(query, con);
            int result = sqlCommand.ExecuteNonQuery();
            if (result != 0)
            {
                Console.WriteLine("Updated Contact");
            }
            else
            {
                Console.WriteLine("Not Updated");
            }

            //Close Connection
            con.Close();
            return result;
        }
        public int DeleteContactBasedonName()
        {
            SqlConnection con = new SqlConnection("data source=DESKTOP-MC3EMTI; initial catalog=AddressBookServiceDB; integrated security=true");
            //Open Connection
            con.Open();
            string query = "delete from AddressBookTable where FirstName = 'Karan' and LastName = 'Sharma'";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            int result = sqlCommand.ExecuteNonQuery();
            if (result != 0)
            {
                Console.WriteLine("Updated Contact");
            }
            else
            {
                Console.WriteLine("Not Updated");
            }

            //Close Connection
            con.Close();
            return result;
        }

        //For retrieving data we use SQLDataReader
        public void Display(SqlDataReader sqlDataReader)
        {
            AddressBookTable obj = new AddressBookTable();
            obj.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
            obj.LastName = Convert.ToString(sqlDataReader["LastName"]);
            obj.Address = Convert.ToString(sqlDataReader["Address"] + " " + sqlDataReader["City"] + " " + sqlDataReader["State"] + " " + sqlDataReader["zip"]);
            obj.PhoneNumber = Convert.ToInt64(sqlDataReader["PhoneNumber"]);
            obj.Email = Convert.ToString(sqlDataReader["email"]);
            obj.AddressBookName = Convert.ToString(sqlDataReader["AddressBookName"]);
            obj.Type = Convert.ToString(sqlDataReader["TypeOfAddressBook"]);
            Console.WriteLine("{0} || {1} || {2} || {3} || {4} || {5} || {6}", obj.FirstName, obj.LastName, obj.Address, obj.PhoneNumber, obj.Email, obj.AddressBookName, obj.Type);

        }
    }
}
    
