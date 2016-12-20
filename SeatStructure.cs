using System;

namespace CarShop
{
    class SeatStructure
    {
        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public SeatStructure(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }
    }
}