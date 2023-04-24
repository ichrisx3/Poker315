using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker {
    public partial class Signup : Form {
        public Signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please enter a username and password.");
                return;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }
            if (textBox2.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters.");
                return;
            }
            if (textBox1.Text.Length > 20)
            {
                MessageBox.Show("Username must be less than 20 characters.");
                return;
            }
            // username can not have special characters
            if (textBox1.Text.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Username can only contain letters and numbers.");
                return;
            }
            String username = textBox1.Text;
            byte[] inputBytes = Encoding.UTF8.GetBytes(textBox2.Text);
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(inputBytes);
            string hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
            String password = hash;
            String connectionString = "Server=34.170.142.59;Database=Poker;User Id=root;Password=PokerChip;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            // update users table with new user
            String query = "INSERT INTO Users (username, password, amount) VALUES (@username, @password, 500)";
            // try catch
            MySqlCommand command;
            try
            {
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Username already exists.");
                return;
            }
            connection.Close();
            Form1 form = new Form1(username);
            form.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }
    }
}
