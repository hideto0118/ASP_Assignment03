using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Car
/// </summary>
public class Car
{
    private int _vin;
    private string _make;
    private string _model;
    private int _year;
    private string _color;
    private int _mileage;
    private int _accidents;
    private string _totalDamage;
    private decimal _price;
    private string _description;

    public Car(int vin, string make, string model, int year, string color, int mileage, int accidents,
        string totalDamage, decimal price, string description)
    {
        _vin = vin;
        _make = make;
        _model = model;
        _year = year;
        _color = color;
        _mileage = mileage;
        _accidents = accidents;
        _totalDamage = totalDamage;
        _price = price;
        _description = description;
    }


    public static List<Car> find_all()
    {
        string connectionString = "Data Source=.;Initial Catalog=ASP_Assignment03;Integrated Security=True";
        List<Car> cars = new List<Car>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            String queryString = "Select * From Cars";
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Car car = new Car(
                    Convert.ToInt32(reader[0].ToString()),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    Convert.ToInt32(reader[3].ToString()),
                    reader[4].ToString(),
                    Convert.ToInt32(reader[5].ToString()),
                    Convert.ToInt32(reader[6].ToString()),
                    reader[7].ToString(),
                    Convert.ToDecimal(reader[8].ToString()),
                    reader[9].ToString()
                );
                cars.Add(car); 
            }
        }
        return cars;
    }

    //using (SqlConnection myConnection new SqlConnection("Your connection string")) 
    //{ 
    //    SqlCommand myCommand = new SqlCommand("INSERT INTO ... VALUES ...", myConnection);
    //myConnection.Open(); 
    //    myCommand.ExecuteNonQuery(); 
    //}



    public int VIN
    {
        get { return _vin; }
        set { _vin = value; }
    }

    public string Make
    {
        get { return _make; }
        set { _make = value; }
    }

    public string Model
    {
        get { return _model; }
        set { _model = value; }
    }

    public int Year
    {
        get { return _year; }
        set { _year = value; }
    }

    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public int Mileage
    {
        get { return _mileage; }
        set { _mileage = value; }
    }

    public int Accidents
    {
        get { return _accidents; }
        set { _accidents = value; }
    }

    public string TotalDamage
    {
        get { return _totalDamage; }
        set { _totalDamage = value; }
    }

    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }


}