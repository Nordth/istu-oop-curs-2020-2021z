using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelApp
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void bookingBtn_Click(object sender, EventArgs e)
        {
            if (textBox1 == null || textBox2 == null)
            {
                throw new NullReferenceException();
            }
            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0)
            {
                if (Form1.db.count < 10)
                {
                    Form1.db.ToBookRoom(textBox1.Text, textBox2.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Все номера заняты!");
                    this.Close();
                }
            }
            else
            {
                label1.BackColor = Color.Red;
                label2.BackColor = Color.Red;
            }
        }
    }
}
