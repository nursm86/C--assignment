using Book.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book
{
    public partial class Form1 : Form
    {
        public static int Bid = 0;
        public static List<BookEntity> bookEntities = new List<BookEntity>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookEntity bookEntity = new BookEntity { Id = ++Bid, AuthorName = textBox1.Text, BookName = textBox2.Text };
            bookEntities.Add(bookEntity);
            MessageBox.Show("Book Added");
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bookEntities;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label8.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookEntity oldBook =  bookEntities.Where(w => w.Id == Int32.Parse(label8.Text)).FirstOrDefault();
            oldBook.AuthorName = textBox4.Text;
            oldBook.BookName = textBox3.Text;
            MessageBox.Show("Book Updated");
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookEntity oldBook = bookEntities.Where(w => w.Id == Int32.Parse(label8.Text)).FirstOrDefault();
            bookEntities.Remove(oldBook);
            MessageBox.Show("Deleted");
            Form1 f = new Form1();
            f.Show();
            this.Hide();
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
