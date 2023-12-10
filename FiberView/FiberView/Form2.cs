using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Text.Json;
using System.IO;

namespace FiberView
{
    public partial class Form2 : Form
    {
        FerrySchedule ferrySchedule;
        
        public Form2()
        {
            InitializeComponent();
            ReadAndDeserializeJson();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ReadAndDeserializeJson();
            load();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

            this.Hide();
            this.Dispose();
        }
        
        private void load()
        {            
            var database = new database();
            try
            {
                if (database.connect_db())
                {

                    DateTime currentTime = DateTime.Now;

                    DateTime schedTime1 = DateTime.Today.AddHours(8);
                    DateTime schedTime2 = DateTime.Today.AddHours(10).AddMinutes(30);
                    DateTime schedTime3 = DateTime.Today.AddHours(14).AddMinutes(15);

                    DateTime schedTime4 = DateTime.Today.AddHours(9);
                    DateTime schedTime5 = DateTime.Today.AddHours(11).AddMinutes(30);
                    DateTime schedTime6 = DateTime.Today.AddHours(15).AddMinutes(45);

                    DateTime schedTime7 = DateTime.Today.AddHours(7).AddMinutes(45);
                    DateTime schedTime8 = DateTime.Today.AddHours(10);
                    DateTime schedTime9 = DateTime.Today.AddHours(13).AddMinutes(30);

                    DateTime schedTime10 = DateTime.Today.AddHours(8).AddMinutes(30);
                    DateTime schedTime11 = DateTime.Today.AddHours(12);
                    DateTime schedTime12 = DateTime.Today.AddHours(16).AddMinutes(15);

                    DateTime schedTime13 = DateTime.Today.AddHours(9).AddMinutes(15);
                    DateTime schedTime14 = DateTime.Today.AddHours(11).AddMinutes(45);
                    DateTime schedTime15 = DateTime.Today.AddHours(14).AddMinutes(30);
                    
                    

                    if (currentTime <= schedTime1 || currentTime <= schedTime2 || currentTime <= schedTime3)
                    {                        
                        string query = "SELECT * FROM `mb d'invaders`";
                        MySqlCommand cmd = new MySqlCommand(query);
                        cmd.Connection = database.connection;
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        BindingSource bind = new BindingSource();
                        bind.DataSource = table;
                        
                        list.DataSource = table;
                        database.close_db();
                    }
                    else if (currentTime <= schedTime4 || currentTime <= schedTime5 || currentTime <= schedTime6)
                    {
                        string query = "SELECT * FROM `mb ron jayredine`";
                        MySqlCommand cmd = new MySqlCommand(query);
                        cmd.Connection = database.connection;
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        BindingSource bind = new BindingSource();
                        bind.DataSource = table;
                        
                        list.DataSource = table;
                        database.close_db();
                    }
                    else if (currentTime <= schedTime7 || currentTime <= schedTime8 || currentTime <= schedTime9)
                    {
                        string query = "SELECT * FROM `mb water bus lucila`";
                        MySqlCommand cmd = new MySqlCommand(query);
                        cmd.Connection = database.connection;
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        BindingSource bind = new BindingSource();
                        bind.DataSource = table;
                        
                        list.DataSource = table;
                        database.close_db();
                    }
                    else if (currentTime <= schedTime10 || currentTime <= schedTime11 || currentTime <= schedTime12)
                    {
                        string query = "SELECT * FROM `mb sj zion`";
                        MySqlCommand cmd = new MySqlCommand(query);
                        cmd.Connection = database.connection;
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        BindingSource bind = new BindingSource();
                        bind.DataSource = table;
                        
                        list.DataSource = table;
                        database.close_db();
                    }
                    else if (currentTime <= schedTime13 || currentTime <= schedTime14 || currentTime <= schedTime15)
                    {
                        string query = "SELECT * FROM `mb genne love`";
                        MySqlCommand cmd = new MySqlCommand(query);
                        cmd.Connection = database.connection;
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        BindingSource bind = new BindingSource();
                        bind.DataSource = table;
                        
                        list.DataSource = table;
                        database.close_db();
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }                    
                        
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                database.close_db();
            }
        }

        private bool TimeConditionMet(List<DeparturesList> departures, string specifiedTime)
        {
            // Check if any departure time matches the specified time
            foreach (var departure in departures)
            {
                if (departure.Time == specifiedTime)
                {
                    return true; // Match found
                }
            }
            return false; // No match found
        }
        private string GetDestinationFromJSON(FerryScheduleItem scheduleItem)
        {
            // Example: Extracting the first destination from DeparturesList
            if (scheduleItem.Departures != null && scheduleItem.Departures.Count > 0)
            {
                return scheduleItem.Departures[0].Destination;
            }
            return ""; // Return default if no destination found
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

        public class FerrySchedule
        {
            public List<FerryScheduleItem> ferry_schedule { get; set; }
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

        private void list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
