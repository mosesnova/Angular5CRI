using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Angular5CRI.Models
{
    public class EmployeeDataAccessLayer
    {
        string connectionString = "Data Source = NAOMI; Initial Catalog = Employee; Integrated Security = True";

        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> empList = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("select * from Employee", con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee emp = new Employee();
                    emp.emp_name = rdr["Emp_Name"].ToString();
                    emp.emp_id = Convert.ToInt32(rdr["Emp_Id"]);
                    empList.Add(emp);
                }

            }
            return empList;
        }

        public int AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insert into Employee (Emp_Name,Emp_City,Emp_Country)" + "values (@Emp_Name,'','');", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Emp_Name", employee.emp_name);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

    }
}
