using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker {
    public partial class Leaderboard : Form {
        String username;
        public Leaderboard(String username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            String connectionString = "Server=34.170.142.59;Database=Poker;User Id=root;Password=PokerChip;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            // get the top 10 users
            String query = "SELECT username, amount FROM Users ORDER BY amount DESC LIMIT 10";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int i = 1;
            while (reader.Read())
            {
                String username = reader.GetString(0);
                int amount = reader.GetInt32(1);
                label1.Text += i + ": " + username + " - " + amount + "\n";
                i++;
            }
            reader.Close();
            // get current user
            query = "SELECT username, amount FROM Users WHERE username = @username";
            command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                String username = reader.GetString(0);
                int amount = reader.GetInt32(1);
                label2.Text = "You: " + username + " - " + amount;
                i++;
                // change color on label2
                label2.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(username);
            form.Show();
            this.Hide();
        }
    }
}
