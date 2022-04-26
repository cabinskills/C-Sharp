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

    public class StatusResponseModel2
    {
        public string Message { set; get; }
        public bool Status { set; get; }

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
        public ResponseModel2 Get(int id)
        {
            ResponseModel2 _objResponseModel = new ResponseModel2();

            string query = @"
                            select * from
                            city where id=@id
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("phonebookDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
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

        // POST api/<CityController>
        [HttpPost]
        public StatusResponseModel2 Post(City citydata)
        {

            StatusResponseModel2 _objResponseModel = new StatusResponseModel2();

            string query = @"
                           insert into city
                           (cityname,country_id,population,rating,points)
                    values (@cityname,@country_id,@population,@rating, @points)
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("phonebookDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cityname", citydata.Cityname);
                    myCommand.Parameters.AddWithValue("@country_id", citydata.CountryId);
                    myCommand.Parameters.AddWithValue("@population", citydata.Population);
                    myCommand.Parameters.AddWithValue("@rating", citydata.Rating);
                    myCommand.Parameters.AddWithValue("@points", citydata.Points);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }


            _objResponseModel.Status = true;
            _objResponseModel.Message = "City Data Inserted successfully";
            return _objResponseModel;

        }

        // PUT api/<CityController>/5
        [HttpPut]
        public StatusResponseModel2 Put(City citydata)
        {

            StatusResponseModel2 _objResponseModel = new StatusResponseModel2();

            string query = @"
                           update city set
                           cityname = @cityname ,
                           country_id = @country_id,
                           population = @population,rating = @rating, points=@points 
                           where id=@id
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("phonebookDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", citydata.Id);
                    myCommand.Parameters.AddWithValue("@cityname", citydata.Cityname);
                    myCommand.Parameters.AddWithValue("@country_id", citydata.CountryId);
                    myCommand.Parameters.AddWithValue("@population", citydata.Population);
                    myCommand.Parameters.AddWithValue("@rating", citydata.Rating);
                    myCommand.Parameters.AddWithValue("@points", citydata.Points);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }


            _objResponseModel.Status = true;
            _objResponseModel.Message = "City Data Inserted successfully";
            return _objResponseModel;

        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public StatusResponseModel2 Delete(int id)
        {
            StatusResponseModel2 _objResponseModel = new StatusResponseModel2();

            string query = @"
                           delete from city where id=@id
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("phonebookDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }


            _objResponseModel.Status = true;
            _objResponseModel.Message = "City Data Deleted successfully";
            return _objResponseModel;
        } 


    }
}
