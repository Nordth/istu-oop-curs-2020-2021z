using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelApp
{
    public partial class Form1 : Form
    {
        public static HotelDB db;
        public Form1()
        {
            InitializeComponent();
            db = new HotelDB(); 
        }

        private void AddClient_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();
        }

        private void BookingButton_Click(object sender, EventArgs e)
        {
            Booking bookingForm = new Booking();
            bookingForm.ShowDialog();
        }

        private void RemoveClientButton_Click(object sender, EventArgs e)
        {
            RemoveForm removeForm = new RemoveForm();
            removeForm.ShowDialog();
        }

        private void addService_Click(object sender, EventArgs e)
        {
            AddServices addServices = new AddServices();
            addServices.ShowDialog();
        }

        private void buttonScore_Click(object sender, EventArgs e)
        {
            Score score = new Score();
            score.ShowDialog();
        }
    }
}
