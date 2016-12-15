using ContactsMVCApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ContactsMVCApp.Models
{
    // Data managing class which holds all the logic operation(CRUD) for Both tables(ContactPersons and Companies)
    public class DataManager
    {

        private SqlConnection _con;

        //Connection method which instantiate Sql connection
        public void connection()
        {
            string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ContactPersonsDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            _con = new SqlConnection(ConnectionString);
        }


        //Get all contact persons from database
        public List<ContactPerson> GetAllPersons()
        {
            connection();
            List<ContactPerson> persons = new List<ContactPerson>();

            SqlCommand com = new SqlCommand("SELECT * from ContactPersons INNER JOIN Companies ON ContactPersons.CompanyId = Companies.Id", _con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            _con.Open();
            da.Fill(dt);
            _con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                persons.Add
                    (
                        new ContactPerson
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            Email = Convert.ToString(dr["Email"]),
                            Telephone = Convert.ToInt32(dr["Telephone"]),
                            CompanyId = Convert.ToInt32(dr["CompanyId"]),
                            CompanyName =Convert.ToString(dr["CompanyName"])



                        }
                    );
            }

            return persons;

        }

        //Add new contact person to the database table
        public bool AddContactPerson(CreateContactPersonViewModel p)
        {
            connection();
            SqlCommand com = new SqlCommand("INSERT into ContactPersons values(@FirstName, @LastName, @Email, @Telephone, @SelectedCompanyId)", _con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@FirstName", p.FirstName);
            com.Parameters.AddWithValue("@LastName", p.LastName);
            com.Parameters.AddWithValue("@Email", p.Email);
            com.Parameters.AddWithValue("@Telephone", p.Telephone);
            com.Parameters.AddWithValue("@SelectedCompanyId", p.SelectedCompanyId);

            _con.Open();
            int i = com.ExecuteNonQuery();
            _con.Close();
            if (i >= 1)
            {
                return true;
            }else
            {
                return false;
            }
        }
        //update Contact Persons
        public bool UpdateContactPerson(UpdateContactPersonViewModel vm)
        {
            connection();
            SqlCommand com = new SqlCommand("UPDATE ContactPersons SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Telephone=@Telephone WHERE Id = @Id", _con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@Id", vm.Id);
            com.Parameters.AddWithValue("@FirstName", vm.FirstName);
            com.Parameters.AddWithValue("@LastName", vm.LastName);
            com.Parameters.AddWithValue("@Email", vm.Email);
            com.Parameters.AddWithValue("@Telephone", vm.Telephone);

            _con.Open();
            int i = com.ExecuteNonQuery();
            _con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteContactPerson(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DELETE from ContactPersons WHERE Id=@Id", _con);

            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@Id", Id);

            _con.Open();
            int i = com.ExecuteNonQuery();
            _con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }






        /********************************************
            Company Related Logic and methods
        **********************************************/

        //Get all companies
        public List<Company> GetAllCompanies()
        {
            connection();
            List<Company> companies = new List<Company>();

            SqlCommand com = new SqlCommand("SELECT * from Companies", _con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            _con.Open();
            da.Fill(dt);
            _con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                companies.Add
                    (
                        new Company
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            CompanyName = Convert.ToString(dr["CompanyName"]),


                        }

                    );
            }

            return companies;

        }





        //Add New Company
        public bool AddCompany(CreateCompanyViewModel c)
        {
            connection();
            SqlCommand com = new SqlCommand("INSERT into Companies values(@CompanyName)", _con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@CompanyName", c.CompanyName);


            _con.Open();
            int i = com.ExecuteNonQuery();
            _con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //update Company
        public bool UpdateCompany(UpdateCompanyViewModel vm)
        {
            connection();
            SqlCommand com = new SqlCommand("UPDATE Companies SET CompanyName=@CompanyName WHERE Id=@Id", _con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@Id", vm.Id);
            com.Parameters.AddWithValue("@CompanyName", vm.CompanyName);


            _con.Open();
            int i = com.ExecuteNonQuery();
            _con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        //Delete company from the database table
        public bool DeleteCompany(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DELETE from Companies WHERE Id=@Id", _con);

            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@Id", Id);

            _con.Open();
            int i = com.ExecuteNonQuery();
            _con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }



    }
}