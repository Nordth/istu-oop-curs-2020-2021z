using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp
{
    public class Room
    {
        public int roomNumber { get; private set; }

        private int roomStatus;
        private int chek;
        public Client client;
        static int count = 1;

        public Room()
        {
            this.roomNumber = count;
            this.roomStatus = 0;
            this.client = null;
            this.chek = 0;
            count++;
        }

        public int GetRoomStatus()
        {
            return roomStatus;
        }

        public void SetRoomStatus(int status)
        {
            this.roomStatus = status;
        }

        public int GetChek()
        {
            return chek;
        }

        public void SetChek(int chek)
        {
            this.chek = chek;
        }
    }
}
