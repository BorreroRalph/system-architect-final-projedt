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
        string con = "Server=localhost;Database=fiberview;Uid=root;Pwd=;";
        MySqlConnection connection;
        public Form2()
        {
            InitializeComponent();
            ReadAndDeserializeJson();
            connection = new MySqlConnection(con);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ReadAndDeserializeJson();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

            this.Hide();
            this.Dispose();
        }
        private string GetNextAvailableBoat(List<FerryScheduleItem> scheduleItems, string currentBoat)
        {
            foreach (var scheduleItem in scheduleItems)
            {
                if (scheduleItem.Boat_name != currentBoat)
                {
                    return scheduleItem.Boat_name;
                }
            }
            return currentBoat; // If no other boat found, return the current boat
        }
        private void add(string passengerInfo)
        {
           
            try
            {

                
                foreach (var scheduleItem in ferrySchedule.ferry_schedule)
                {
                    int maxCapacity = int.Parse(scheduleItem.Max_capacity);
                    string boatName = scheduleItem.Boat_name;
                    string destination = GetDestinationFromJSON(scheduleItem);
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

                    string currentHour = currentTime.ToString("HH:mm");
                    MySqlCommand countCommand = connection.CreateCommand();
                    int rowCount = Convert.ToInt32(countCommand.ExecuteScalar());
                    DataTable table = new DataTable();

                    if (rowCount <= maxCapacity || currentTime <= schedTime1 || currentTime <= schedTime2 || currentTime <= schedTime3)
                    {
                        // SELECT from the new boat's table
                        string query = "SELECT * FROM 'MB D'Invaders'";
                        MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);                        
                        adapter.Fill(table);
                        connection.Open();
                        list.DataSource = table;
                        connection.Close();

                    }
                    else if (rowCount <= maxCapacity || currentTime <= schedTime4 || currentTime <= schedTime5 || currentTime <= schedTime6)
                    {
                        string query = "SELECT * FROM 'MB Ron Jayredine'";
                        MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                        adapter.Fill(table);
                        connection.Open();
                        list.DataSource = table;
                        connection.Close();
                    }
                    else if (rowCount <= maxCapacity || currentTime <= schedTime7 || currentTime <= schedTime8 || currentTime <= schedTime9)
                    {
                        string query = "SELECT * FROM 'MB Water Bus Lucila'";
                        MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                        adapter.Fill(table);
                        connection.Open();
                        list.DataSource = table;
                        connection.Close();
                    }
                    else if (rowCount <= maxCapacity || currentTime <= schedTime10 || currentTime <= schedTime11 || currentTime <= schedTime12)
                    {
                        string query = "SELECT * FROM 'MB SJ Zion'";
                        MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                        adapter.Fill(table);
                        connection.Open();
                        list.DataSource = table;
                        connection.Close();
                    }
                    else if (rowCount <= maxCapacity || currentTime <= schedTime13 || currentTime <= schedTime14 || currentTime <= schedTime15)
                    {
                        string query = "SELECT * FROM 'MB Genne Love'";
                        MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                        adapter.Fill(table);
                        connection.Open();
                        list.DataSource = table;
                        connection.Close();
                    }
                        

                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
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
