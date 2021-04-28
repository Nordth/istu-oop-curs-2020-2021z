using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelApp
{
    public partial class AddServices : Form
    {
        string [] arrCheckBox;
        int count = 0;
        public AddServices()
        {
            InitializeComponent();
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(checkBox4);
            arrCheckBox = new string[Form1.db.services.Length-1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int roomNum;
            if (textBox1 == null)
            {
                throw new NullReferenceException();
            }
            bool isNum = int.TryParse(textBox1.Text, out roomNum);
            foreach (CheckBox chb in groupBox1.Controls)
            {
                if (chb.Checked)
                {
                    arrCheckBox[count] = chb.Text;
                    count++;
                }
            }

            if (isNum && roomNum > 0 && 
                roomNum <= Form1.db.rooms.Length && 
                Form1.db.rooms[roomNum - 1].GetRoomStatus() > 1)
            {
                Form1.db.AddServices(arrCheckBox, roomNum);
                this.Close();
            }
            else
            {
                MessageBox.Show("Номер введен не корректно, либо в данном номере ни кто не проживает");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Form1.db.services[0].serviceName + "\t" + Form1.db.services[0].servicePrice + "\n"
                            + Form1.db.services[1].serviceName + "\t" + Form1.db.services[1].servicePrice + "\n"
                            + Form1.db.services[2].serviceName + "\t" + Form1.db.services[2].servicePrice + "\n"
                            + Form1.db.services[3].serviceName + "\t" + Form1.db.services[3].servicePrice + "\n"
                            + Form1.db.services[4].serviceName + "\t" + Form1.db.services[4].servicePrice + "\n");
        }
    }
}
