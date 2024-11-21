using System;
using System.Data.SqlClient; // Make sure this is included
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Log_In_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            string name = textBox1.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Enter Details");
            }
            else
            {
                if (Regex.IsMatch(name, "[^a-zA-Z ]") || Regex.IsMatch(id, "[^0-9 ]") || id.Length != 8)
                {
                    MessageBox.Show("Hello!! Please recheck your entered Name or ID");
                }
                else
                {
                    // Database connection string
                    string connectionString = "Server=DESKTOP-GK5ID45\\SQLEXPRESS;Database=MyFirstDatabase;Integrated Security=True;";
                  //  string connectionString = "Server=DESKTOP-GK5ID45\\SQLEXPRESS;Database=MyFirstDatabase; Integrated Security=True;";

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            // Open the connection
                            connection.Open();

                            // SQL query to insert data
                            string query = "INSERT INTO Users (ID, Name) VALUES (@ID, @Name)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Add parameters to the SQL query
                                command.Parameters.AddWithValue("@ID", id);
                                command.Parameters.AddWithValue("@Name", name);

                                // Execute the query
                                int result = command.ExecuteNonQuery();

                                // Check if the insert was successful
                                if (result > 0)
                                {
                                    MessageBox.Show("You have successfully entered Name and ID....Kudos!!!!!!");
                                }
                               // DESKTOP - GK5ID45SQLEXPRESS.
                             
                                else
                                {
                                    MessageBox.Show("Failed to insert data."); 
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Your existing logic here
        }
    }
}
