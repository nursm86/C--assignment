using Flights.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flights
{
    public partial class Form1 : Form
    {
        public static int Bid = 0;
        public static List<FlightEntity> flightEntities = new List<FlightEntity>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FlightEntity flightEntity = new FlightEntity { Id = ++Bid, FlightName = textBox1.Text, TakeOffTime = dateTimePicker1.Value };
            flightEntities.Add(flightEntity);
            MessageBox.Show("Flight Added");
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FlightEntity oldflight = flightEntities.Where(w => w.Id == Int32.Parse(label8.Text)).FirstOrDefault();
            oldflight.FlightName = textBox4.Text;
            oldflight.TakeOffTime = dateTimePicker2.Value;
            MessageBox.Show("Flight Updated");
            Form1 f = new Form1();
            f.Show();
            this.Hide();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FlightEntity oldflight = flightEntities.Where(w => w.Id == Int32.Parse(label8.Text)).FirstOrDefault();
            flightEntities.Remove(oldflight);
            MessageBox.Show("Deleted");
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label8.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = flightEntities;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
