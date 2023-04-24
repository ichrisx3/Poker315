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

    public partial class Form1 : Form {
        String username;
        public Form1(String username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String connectionString = "Server=34.170.142.59;Database=Poker;User Id=root;Password=PokerChip;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            String query = "SELECT Amount From Users WHERE username = '" + username + "'";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int amount = 0;
            while (reader.Read())
            {
                amount = reader.GetInt32(0);
            }
            reader.Close();
            label3.Text = "Amount: " + amount;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // label1.Text = username;

            if (textBox1.Text.Equals("")) { 
                MessageBox.Show("Please enter an amount");
                return;
            }

            String connectionString = "Server=34.170.142.59;Database=Poker;User Id=root;Password=PokerChip;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            String query = "SELECT Amount From Users WHERE username = '" + username + "'";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int amount = 0;
            while (reader.Read())
            {
                amount = reader.GetInt32(0);
            }
            reader.Close();
            
            int num = Int32.Parse(textBox1.Text);
            if (amount == 0 && num > 1)
            {
                MessageBox.Show("You can only bet 1");
                return;
            }
            else if (num > amount && num != 1)
            {
                MessageBox.Show("You do not have enough money");
                return;
            }

            if (amount != 0)
            {
                String query2 = "UPDATE Users SET Amount = Amount - " + num + " WHERE username = '" + username + "'";
                MySqlCommand command2 = new MySqlCommand(query2, connection);
                command2.ExecuteNonQuery();
            }
            

            Deck deck = new Deck();
            deck.shuffle();

            Card card1 = deck.GetCard(0);
            Card card2 = deck.GetCard(1);
            Card card3 = deck.GetCard(2);
            Card card4 = deck.GetCard(3);
            Card card5 = deck.GetCard(4);

            // Royal flush
            /*card1 = new Card(Value.A, Suit.Hearts);
            card2 = new Card(Value.K, Suit.Hearts);
            card3 = new Card(Value.Q, Suit.Hearts);
            card4 = new Card(Value.J, Suit.Hearts);
            card5 = new Card(Value.Ten, Suit.Hearts);*/

            List<Card> hand = new List<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Sort();
            PokerRank rank = new PokerRank(hand);
            rank.Evaluate();

            CardToPic pic1 = new CardToPic(card1.ToString());
            CardToPic pic2 = new CardToPic(card2.ToString());
            CardToPic pic3 = new CardToPic(card3.ToString());
            CardToPic pic4 = new CardToPic(card4.ToString());
            CardToPic pic5 = new CardToPic(card5.ToString());

            pictureBox1.Image = pic1.getPic();
            pictureBox2.Image = pic2.getPic();
            pictureBox3.Image = pic3.getPic();
            pictureBox4.Image = pic4.getPic();
            pictureBox5.Image = pic5.getPic();

            // a multiple bet system for each poker rank
            int bet = 0;
            if (rank.getRank().Equals("RoyalFlush"))
            {
                bet = 100;
            }
            else if (rank.getRank().Equals("StraightFlush"))
            {
                bet = 50;
            }
            else if (rank.getRank().Equals("FourOfAKind"))
            {
                bet = 25;
            }
            else if (rank.getRank().Equals("FullHouse"))
            {
                bet = 10;
            }
            else if (rank.getRank().Equals("Flush"))
            {
                bet = 8;
            }
            else if (rank.getRank().Equals("Straight"))
            {
                bet = 5;
            }
            else if (rank.getRank().Equals("ThreeOfAKind"))
            {
                bet = 4;
            }
            else if (rank.getRank().Equals("TwoPair"))
            {
                bet = 3;
            }
            else if (rank.getRank().Equals("Pair"))
            {
                bet = 2;
            }
            else
            {
                bet = 0;
            }

            label1.Text = rank.getRank();
            String query3 = "UPDATE Users SET Amount = Amount + " + (num * bet) + " WHERE username = '" + username + "'";
            MySqlCommand command3 = new MySqlCommand(query3, connection);
            command3.ExecuteNonQuery();

            MySqlCommand mySqlCommand= new MySqlCommand(query, connection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                amount = mySqlDataReader.GetInt32(0);
            }
            mySqlDataReader.Close();
            connection.Close();
            label3.Text = "Amount: " + (amount);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Leaderboard from = new Leaderboard(this.username);
            from.Show();
            this.Hide();
        }
    }
}
