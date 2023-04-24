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
    public partial class Login : Form {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Any(c => !char.IsLetterOrDigit(c))) {
                MessageBox.Show("Username and Password is incorrect");
            }
            byte[] inputBytes = Encoding.UTF8.GetBytes(textBox2.Text);
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(inputBytes);
            string hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
            String username = textBox1.Text;
            String password = hash;
            String connectionString = "Server=34.170.142.59;Database=Poker;User Id=root;Password=PokerChip;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            String query = "SELECT * FROM Users WHERE username = @username AND password = @password";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Login Successful");
                this.Hide();
                Form1 form1 = new Form1(username);
                form1.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username and Password is incorrect");
            }
            connection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
