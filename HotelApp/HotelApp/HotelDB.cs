using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp
{
    public class HotelDB
    {
        public Client[] clients;
        public Room[] rooms;
        public Service[] services;
        public int count;

        public HotelDB()
        {
            clients = new Client[1];
            rooms = new Room[10];
            count = 0;
            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = new Room();
            }
            services = new Service[] 
            {
                new Service("Аренда комнаты на сутки", 500),
                new Service("Завтрак", 50),
                new Service("Обед", 75),
                new Service("Ужин", 60),
                new Service("Аренда сауны", 100)
            };
        }

        public void AddNewClient(string firstName, string lastName)
        {
            Client newClient = new Client(firstName, lastName);
            Array.Resize(ref this.clients, this.clients.Length + 1);
            this.clients[this.clients.Length -1] = newClient;
            foreach(var room in rooms)
            {
                if(room.GetRoomStatus() != 2)
                {
                    if(room.client != null && firstName == room.client.firstName && lastName == room.client.lastName)
                    {
                        room.SetRoomStatus(2);
                        int chek = room.GetChek();
                        room.SetChek(chek += services[0].servicePrice);
                    }
                    else if (room.GetRoomStatus() == 0)
                    {
                        room.client = newClient;
                        room.SetRoomStatus(2);
                        int chek = room.GetChek();
                        room.SetChek(chek += services[0].servicePrice);
                        count++;
                    }
                    break;
                }
            }
        }

        public void RemoveClient(int roomNum)
        {
            foreach (var room in rooms)
            {
                if (room.roomNumber == roomNum)
                {
                    room.client = null;
                    room.SetRoomStatus(0);
                    room.SetChek(0);
                    count--;
                    break;
                }
            }
        }

        public void ToBookRoom(string firstName, string lastName)
        {
            Client newClient = new Client(firstName, lastName);
            Array.Resize(ref this.clients, this.clients.Length + 1);
            this.clients[this.clients.Length - 1] = newClient;
            foreach (var room in rooms)
            {
                if (room.GetRoomStatus() == 0)
                {
                    room.client = newClient;
                    room.SetRoomStatus(1);
                    count++;
                    break;
                }
            }
        }

        public void AddServices(string[] arr, int room)
        {
            for(int i = 0; i < services.Length; i++)
            {
                for(int j = 0; j < arr.Length; j++)
                {
                    if(arr[j] == services[i].serviceName)
                    {
                        int chek = rooms[room - 1].GetChek();
                        rooms[room-1].SetChek(chek + services[i].servicePrice);
                    }
                }
            }
        }

    }
}
