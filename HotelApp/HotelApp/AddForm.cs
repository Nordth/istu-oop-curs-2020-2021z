using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelApp
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        public HotelDB HotelDB
        {
            get => default;
            set
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1 == null || textBox2 == null)
            {
                throw new NullReferenceException();
            }
            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0)
            {
                if(Form1.db.count < 10)
                {
                    Form1.db.AddNewClient(textBox1.Text, textBox2.Text);
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
                firstName.BackColor = Color.Red;
                lastName.BackColor = Color.Red;
            }
        }
    }
}
