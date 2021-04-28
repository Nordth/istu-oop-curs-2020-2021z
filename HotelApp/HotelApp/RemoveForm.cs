using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelApp
{
    public partial class RemoveForm : Form
    {
        public RemoveForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int roomNum;
            if(textBox1 == null)
            {
                throw new NullReferenceException();
            }
            bool isNum = int.TryParse(textBox1.Text,out roomNum);
            if(isNum && roomNum > 0 && roomNum <= Form1.db.rooms.Length && Form1.db.rooms[roomNum -1].GetRoomStatus() != 0 )
            {
                MessageBox.Show(Form1.db.rooms[roomNum - 1].client.firstName + " " +
                                Form1.db.rooms[roomNum - 1].client.lastName + ".\n" +
                                "К оплате " + Form1.db.rooms[roomNum - 1].GetChek() + " рублей");
                Form1.db.RemoveClient(roomNum);
                this.Close();
            }
            else
            {
                MessageBox.Show("Номер введен не корректно, либо в данном номере ни кто не проживает");
            }
        }
    }
}
