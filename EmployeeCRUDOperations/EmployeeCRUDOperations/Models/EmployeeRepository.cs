using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace EmployeeCRUDOperations.Models
{
    // to connect with the database
    public class EmployeeRepository
    {
        // create a public method to get all employee details
       
        public List<Employee>GetEmployees()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
            string query = "select * from tblEmployee";
            SqlCommand cmd = new SqlCommand(query, con);
            List<Employee> empList = new List<Employee>();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Employee employee = new Employee()
                {
                    ID = (int)dr[0],
                    Name = dr[1].ToString(),
                    Location = dr[2].ToString(),
                    Salary = (int)dr[3],
                    DeptId=(int)dr[4]


                };
                empList.Add(employee);
            }
            con.Close();
            return empList;


        }


        // create a public method to get all employee details
        public bool AddEmployee(Employee employee)
        {
           
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
            string query = "insert into tblEmployee(ID,Name,Location,Salary,DeptId) values(@ID,@Name,@Location,@Salary,@DeptId)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", employee.ID);
            cmd.Parameters.AddWithValue("@Name", employee.Name);
            cmd.Parameters.AddWithValue("@Location", employee.Location);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@DeptId", employee.DeptId);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            
            con.Close();
            return  result > 0 ? true : false; ;


        }

        // create a public method to get all employee details
        public bool DeleteEmp(int ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
            string query = "delete from tblEmployee where ID=@ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            
            con.Open();
            int result = cmd.ExecuteNonQuery();

            con.Close();
            return result > 0 ? true : false ;


        }


        // create a public method to get all employee details by Emp Id
        public Employee GetEmployeesById(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
            string query = "select * from tblEmployee where ID=@ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            Employee employee = null;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                 employee = new Employee()
                {
                    ID = (int)dr[0],
                    Name = dr[1].ToString(),
                    Location = dr[2].ToString(),
                    Salary = (int)dr[3],
                    DeptId = (int)dr[4]


                };
              
            }
            con.Close();
            return employee;


        }


        // create a public method to update employee details
        public bool EditEmployee(Employee employee)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
            string query = "update tblEmployee set Name=@Name,Location=@Location,Salary=@Salary,DeptId=@DeptId where  ID=@ID ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", employee.ID);
            cmd.Parameters.AddWithValue("@Name", employee.Name);
            cmd.Parameters.AddWithValue("@Location", employee.Location);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@DeptId", employee.DeptId);
            con.Open();
            int result = cmd.ExecuteNonQuery();

            con.Close();
            return result > 0 ? true : false; ;


        }

    }
}