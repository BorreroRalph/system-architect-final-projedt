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
using System.Data.SqlClient;
using AForge.Video;
using AForge.Video.DirectShow;

namespace FiberView
{
    public partial class Form1 : Form
    {
        FerrySchedule ferrySchedule;
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
                string jsonFile = Path.Combine(Application.StartupPath, "fiberview.json");
                //string jsonFile = @"C:\Users\asus\Documents\GitHub\system_architecture\system-architect-final-projedt\FiberView\FiberView\fiberview.json";

                string jsonData = File.ReadAllText(jsonFile);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                ferrySchedule = JsonSerializer.Deserialize<FerrySchedule>(jsonData, options);
                

                if (ferrySchedule != null && ferrySchedule.ferry_schedule != null)
                {
                    // Clear existing rows and columns
                    schedule.Rows.Clear();
                    schedule.Columns.Clear();

                    // Define columns for Boat_name, Max_capacity, and Departures
                    schedule.Columns.Add("BoatNameColumn", "Boat Name");
                    schedule.Columns.Add("MaxCapacityColumn", "Max Capacity");
                    schedule.Columns.Add("DeparturesColumn", "Departures");

                    // Set the AutoSizeMode for each column to automatically adjust their widths
                    schedule.Columns["BoatNameColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    schedule.Columns["MaxCapacityColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    schedule.Columns["DeparturesColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                    foreach (var item in ferrySchedule.ferry_schedule)
                    {
                        // Add rows for Boat_name and Max_capacity
                        schedule.Rows.Add(item.Boat_name, item.Max_capacity);

                        // Display Departures for each FerryScheduleItem
                        string departures = "";
                        foreach (var departure in item.Departures)
                        {
                            departures += $"{departure.Time} - {departure.Destination}\n";
                        }

                        // Add a cell for Departures in the DataGridView
                        int rowIndex = schedule.Rows.Count - 1;
                        schedule.Rows[rowIndex].Cells["DeparturesColumn"].Value = departures;
                    }

                    // No need to set DataSource if manually adding rows and cells


                    //schedule.DataSource = ferrySchedule.ferry_schedule;
                }
                else
                {
                    Console.WriteLine("FerrySchedule is null or empty.");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found." + ex.Message);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error deserializing JSON." + ex.Message);
            }
        }
    }
   
    public class FerrySchedule
    {
        public  List<FerryScheduleItem> ferry_schedule { get; set; }
    }
    public class FerryScheduleItem
    {
        public string Boat_name { get; set; }
        public string Max_capacity { get; set; }
        public List<DeparturesList> Departures { get; set; }
        
    }
    public class DeparturesList
    {
        public string Time { get; set; }
        public string Destination { get; set; }
    }
}
