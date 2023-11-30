using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using ZXing;
using MySql.Data.MySqlClient;

namespace FiberView
{
    public partial class Form1 : Form
    {
        string con = "http://localhost/phpmyadmin/index.php?route=/database/structure&server=1&db=fiberview";
        public Form1()
        {
            InitializeComponent();
            ReadAndDeserializeJson();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ReadAndDeserializeJson();
        }

        private void ReadAndDeserializeJson()
        {
            try
            {
                string jsonFile = "fiberview.json";
                //string directoryPath = @"C:\Users\asus\source\repos\FiberView\fiberview.json"; 

                //string fullPath = Path.Combine(directoryPath, jsonFilePath);
                string jsonData = File.ReadAllText(jsonFile);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var ferrySchedule = JsonSerializer.Deserialize<List<FerrySchedule>>(jsonData, options);

                MessageBox.Show("Accessed");
                
                schedule.AutoGenerateColumns = true;
                schedule.DataSource = ferrySchedule;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (JsonException)
            {
                Console.WriteLine("Error deserializing JSON.");
            }
        }
    }
   
    public class FerrySchedule
    {
        public string boat_name { get; set; }
        public int max_capacity { get; set; }
        public List<Departures> departures { get; set; }
        
    }
    public class Departures
    {
        public DateTime time { get; set; }
        public string destination { get; set; }
    }
}
