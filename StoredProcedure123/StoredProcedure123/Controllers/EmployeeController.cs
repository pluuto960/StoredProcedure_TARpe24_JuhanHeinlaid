using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StoredProcedure123.Data;
using StoredProcedure123.Models;
using System.Text;

namespace StoredProcedure123.Controllers
{
    public class EmployeeController : Controller
    {
        public StoredProcDbContext _context;
        public IConfiguration _confiq;


        public EmployeeController
            (
                StoredProcDbContext context,
                IConfiguration config
            )
        {
            _context = context;
            _confiq = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        //teha uus meetod, mis kutsub esile stored procedure


        [HttpGet]
        public IActionResult DynamicSQL()
        {
            string connectionStr = _confiq.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }

                return View(model);
           }
        }

        [HttpPost]
        public IActionResult DynamicSQL(string firstName, string lastName, string gender, int salary)
        {
            string connectionStr = _confiq.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                StringBuilder sbCommand = new StringBuilder("SELECT * FROM Employees WHERE 1=1");

                if (!string.IsNullOrEmpty(firstName))
                {
                    sbCommand.Append(" AND FirstName=@FirstName");
                    SqlParameter param = new
                    SqlParameter("@FirstName", firstName);
                    cmd.Parameters.Add(param);
                }

                if (!string.IsNullOrEmpty(lastName))
                {
                    sbCommand.Append(" AND LastName=@LastName");
                    SqlParameter param = new
                    SqlParameter("@LastName", lastName);
                    cmd.Parameters.Add(param);
                }
                if (!string.IsNullOrEmpty(gender))
                {
                    sbCommand.Append(" AND Gender=@Gender");
                    SqlParameter param = new
                    SqlParameter("@Gender", gender);
                    cmd.Parameters.Add(param);
                }
                if (salary != 0)
                {
                    sbCommand.Append(" AND Salary=@Salary");
                    SqlParameter param = new
                    SqlParameter("@Salary", salary);
                    cmd.Parameters.Add(param);
                }
                cmd.CommandText = sbCommand.ToString();
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }

                return View(model);
            }
        }

        [HttpGet]
        public IActionResult SearchDynamicSQL()
        {
            string connectionStr = _confiq.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployeesBadDynamicSQL";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }

                return View(model);
            }
        }

        [HttpPost]
        public IActionResult SearchWithDynamicSQL(string firstName, string lastName, string gender, int salary)
        {
            string connectionStr = _confiq.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                StringBuilder sbCommand = new StringBuilder("SELECT * FROM Employees WHERE 1=1");

                if (!string.IsNullOrEmpty(firstName))
                {
                    sbCommand.Append(" AND FirstName=@FirstName");
                    SqlParameter param = new
                    SqlParameter("@FirstName", firstName);
                    cmd.Parameters.Add(param);
                }

                if (!string.IsNullOrEmpty(lastName))
                {
                    sbCommand.Append(" AND LastName=@LastName");
                    SqlParameter param = new
                    SqlParameter("@LastName", lastName);
                    cmd.Parameters.Add(param);
                }
                if (!string.IsNullOrEmpty(gender))
                {
                    sbCommand.Append(" AND Gender=@Gender");
                    SqlParameter param = new
                    SqlParameter("@Gender", gender);
                    cmd.Parameters.Add(param);
                }
                if (salary != 0)
                {
                    sbCommand.Append(" AND Salary=@Salary");
                    SqlParameter param = new
                    SqlParameter("@Salary", salary);
                    cmd.Parameters.Add(param);
                }
                cmd.CommandText = sbCommand.ToString();
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }

                return View(model);
            }
        }
    }
}
