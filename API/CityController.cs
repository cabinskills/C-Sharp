using DemoWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoWebAPI.Controllers
{

    public class ResponseModel2
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public List<dynamic> Data { set; get; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private IConfiguration _configuration;

        public CityController(IConfiguration config)
        {
            _configuration = config;
        }

        // GET: api/<CityController>
        [HttpGet]
        public ResponseModel2 Get()
        {
            ResponseModel2 _objResponseModel = new ResponseModel2();

            string query = @"
                            select * from
                            city
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("phonebookDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            List<dynamic> cityList = new List<dynamic>();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                City ctry = new City();
                ctry.Id = Convert.ToInt32(table.Rows[i]["id"]);
                ctry.Cityname = table.Rows[i]["cityname"].ToString();
                ctry.CountryId = Convert.ToInt32(table.Rows[i]["country_id"]); 
                ctry.Population = Convert.ToInt32(table.Rows[i]["population"]);
                ctry.Rating = Convert.ToInt32(table.Rows[i]["rating"]);
                ctry.Points = Convert.ToInt32(table.Rows[i]["points"]);
                cityList.Add(ctry);
            }


            _objResponseModel.Data = cityList;
            _objResponseModel.Status = true;
            _objResponseModel.Message = "City Data Received successfully";
            return _objResponseModel;

        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        } 


    }
}
