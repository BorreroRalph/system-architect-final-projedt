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
using System.Globalization;

namespace FiberView
{
    public partial class Form1 : Form
    {
        FerrySchedule ferrySchedule;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        
        string con = "Server=localhost;Database=fiberview;Uid=root;Pwd=;";
        MySqlConnection connection; 
        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
            
            connection = new MySqlConnection(con);
            ReadAndDeserializeJson();
            form2 = new Form2();
            form2.FormClosed += Form2_FormClosed;
        }
        private void scan_Click(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                        if (videoDevices.Count == 0)
                        {
                            MessageBox.Show("No video devices found.");
                            return;
                        }

                        videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                        videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                        videoSource.Start();
        }
        

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

                // Display the camera feed in a PictureBox
                if (camera.InvokeRequired)
                {
                    camera.Invoke(new Action<Bitmap>(UpdatePictureBox), bitmap);
                }
                else
                {
                    UpdatePictureBox(bitmap);
                }

                // Decode QR codes
                var reader = new BarcodeReader();
                Result result = reader.Decode(bitmap);
                if (result != null)
                {
                    string[] info = result.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (info.Length >= 2)
                    {
                        string firstName = info[0];
                        string lastName = info[1];
                        string passengerInfo = $"{firstName} {lastName}";
                        ShowDecodedInfo($"First Name: {firstName}\nLast Name: {lastName}");
                    }
                    else
                    {
                        ShowDecodedInfo("QR code does not contain valid first name and last name information.");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowDecodedInfo($"An error occurred: {ex.Message}");
            }
        }

        private void UpdatePictureBox(Bitmap bitmap)
        {
            try
            {
                // Assign the cloned image to the PictureBox
                camera.Image = (Bitmap)bitmap.Clone();
            }
            catch (Exception ex)
            {
                // Handle any exceptions occurring during the update process
                Console.WriteLine($"Error updating PictureBox: {ex.Message}");
            }
        }

        private void ShowDecodedInfo(string message)
        {
            if (lblDecodedInfo.InvokeRequired)
            {
                lblDecodedInfo.Invoke(new Action<string>(ShowDecodedInfo), message);
            }
            else
            {
                lblDecodedInfo.Text = message;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }

        private void add (string passengerInfo)
        {
           
            try{
                
                connection.Open();
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
                countCommand.CommandText = $"SELECT COUNT(*) FROM {boatName}";
                int rowCount = Convert.ToInt32(countCommand.ExecuteScalar());
                    
                if (rowCount <= maxCapacity || currentTime <= schedTime1 || currentTime <= schedTime2 || currentTime <= schedTime3)
                { 
                        // Insert into the new boat's table
                        string query = "INSERT INTO 'MB D'Invaders'(passenger, destination) VALUES (@passengerInfo, @destination)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@passengerInfo", passengerInfo);
                        command.Parameters.AddWithValue("@destination", destination);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected for MB D'Invaders: {rowsAffected}");
                        rowCount = 0;
                    }
                    else if (rowCount <= maxCapacity || currentTime <= schedTime4 || currentTime <= schedTime5 || currentTime <= schedTime6)
                    {
                        string query = "INSERT INTO 'MB Ron Jayredine'(passenger, destination) VALUES (@passengerInfo, @destination)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@passengerInfo", passengerInfo);
                        command.Parameters.AddWithValue("@destination", destination);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected for MB Ron Jayredine: {rowsAffected}");
                        rowCount = 0;
                    }
                    else if (rowCount <= maxCapacity || currentTime <= schedTime7 || currentTime <= schedTime8 || currentTime <= schedTime9)
                    {
                        string query = "INSERT INTO 'MB Water Bus Lucila'(passenger, destination) VALUES (@passengerInfo, @destination)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@passengerInfo", passengerInfo);
                        command.Parameters.AddWithValue("@destination", destination);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected for MB Water Bus Lucila: {rowsAffected}");
                        rowCount = 0;
                    }
                    else if (rowCount <= maxCapacity || currentTime <= schedTime10 || currentTime <= schedTime11 || currentTime <= schedTime12)
                    {
                        string query = "INSERT INTO 'MB SJ Zion'(passenger, destination) VALUES (@passengerInfo, @destination)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@passengerInfo", passengerInfo);
                        command.Parameters.AddWithValue("@destination", destination);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected for MB SJ Zion: {rowsAffected}");
                        rowCount = 0;
                    }
                    else if (rowCount <= maxCapacity || currentTime <= schedTime13 || currentTime <= schedTime14 || currentTime <= schedTime15)
                    {
                        string query = "INSERT INTO 'MB Genne Love'(passenger, destination) VALUES (@passengerInfo, @destination)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@passengerInfo", passengerInfo);
                        command.Parameters.AddWithValue("@destination", destination);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected for MB Genne Love: {rowsAffected}");
                        rowCount = 0;
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
            DateTime currentTime = DateTime.ParseExact(specifiedTime, "HH:mm", CultureInfo.InvariantCulture);

            // Check if any departure time is greater than or equal to the specified time
            foreach (var departure in departures)
            {
                // Convert departure time to a DateTime object for comparison
                DateTime departureTime = DateTime.ParseExact(departure.Time, "HH:mm", CultureInfo.InvariantCulture);

                // Compare DateTime objects
                if (departureTime == currentTime)
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
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show(); // Show Form1 when Form2 is closed
        }
        private void Next_Click(object sender, EventArgs e)
        {
            form2.Show();

            this.Hide();
            
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
}