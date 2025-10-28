using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StoredProcedure123.Data;
using StoredProcedure123.Models;
using System.Text;

namespace StoredProcedure123.Controllers
{
    public class PersonController : Controller
    {
        public StoredProcDbContext _context;
        public IConfiguration _config;
        public PersonController(StoredProcDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult SearchPerson()
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchPerson";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Person> model = new List<Person>();
                while (sdr.Read())
                {
                    var details = new Person();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.PhoneNumber = sdr["PhoneNumber"].ToString();
                    details.Email = sdr["Email"].ToString();
                    details.Address = sdr["Address"].ToString();
                    model.Add(details);
                }

                return new JsonResult(model);
            }


        }
    }
}