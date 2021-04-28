using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelApp
{
    public partial class Score : Form
    {
        public int count = 6;
        public Score()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 == null)
            {
                throw new NullReferenceException();
            }
            if (radioButton1.Checked)
            {
                ShowInfo(textBox1.Text);
            }
            else if (radioButton2.Checked)
            {
                GetLockedRooms();
            }
            else if (radioButton3.Checked)
            {
                foreach(var room in Form1.db.rooms)
                {
                    CreateTableInfo(room);
                }
            }
        }

        private void GetLockedRooms()
        {
            foreach (var room in Form1.db.rooms)
            {
                if (room.GetRoomStatus() != 0)
                {
                    CreateTableInfo(room);
                }
            }
        }

        private void CreateTableInfo(Room room)
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle
            {
                Height = 50,
                SizeType = SizeType.Absolute
            });
            if(table.Height < 400)
            {
                table.Height += 50;
            }
            Label[] lb = new Label[]
            {
                        new Label(),
                        new Label(),
                        new Label(),
                        new Label(),
                        new Label()
            };
            if (room.client == null)
            {
                lb[0].Text = room.roomNumber.ToString();
                lb[1].Text = "";
                lb[2].Text = "";
                lb[3].Text = room.GetRoomStatus().ToString();
                lb[4].Text = room.GetChek().ToString();
            }
            else
            {
                lb[0].Text = room.roomNumber.ToString();
                lb[1].Text = room.client.firstName;
                lb[2].Text = room.client.lastName;
                lb[3].Text = room.GetRoomStatus().ToString();
                lb[4].Text = room.GetChek().ToString();
            }
            for (int i = 0; i < 5; i++)
            {
                table.Controls.Add(lb[i]);
                table.SetColumn(lb[i], count);
                count++;
            }
            label4.Visible = false;
            textBox1.Visible = false;
            groupBox1.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            button1.Visible = false;
            label1.Visible = true;
            table.Visible = true;
        }

        private void ShowInfo(string roomNumStr)
        {
            int roomNum;
            bool isNum = int.TryParse(textBox1.Text, out roomNum);
            if (isNum && roomNum > 0 && roomNum <= Form1.db.rooms.Length)
            {
                CreateTableInfo(Form1.db.rooms[roomNum - 1]);
                
            }
            else
            {
                MessageBox.Show("Некорректно введен номер комнаты");
            }
        }
    }
}
