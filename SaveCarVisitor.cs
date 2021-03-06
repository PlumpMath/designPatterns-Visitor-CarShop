using System;
using System.Collections.Generic;

namespace CarShop
{
    class SaveCarVisitor : ICarVisitor
    {
        private CarPersistence persistence = new CarPersistence();
        private int carId;
        private string make;
        private string model;
        private float power;
        private float cylinderVolume;
        private Queue<SeatStructure> seats = new Queue<SeatStructure>();

        public void VisitCar(string make, string model)
        {
            this.make = make;
            this.model = model;
            this.ProcessQueue();
        }

        public void VisitEngine(EngineStructure structure, EngineStatus status)
        {
            this.power = structure.Power;
            this.cylinderVolume = structure.CylinderVolume;
            this.ProcessQueue();
        }

        public void VisitSeat(string name, int capacity)
        {
            this.seats.Enqueue(new SeatStructure(name, capacity));
            this.ProcessQueue();
        }

        private void ProcessQueue()
        {
            this.SaveCar();
            this.SaveEngine();
            this.SaveSeats();
        }

        private void SaveCar()
        {
            if (this.carId == 0 && this.make != null)
            {
                this.carId = this.persistence.InsertCar(this.make, this.model);
            }
        }

        private void SaveEngine()
        {
            if (this.carId > 0 && this.power > 0)
            {
                this.persistence.InsertEngine(this.carId, this.power, this.cylinderVolume);
                this.power = 0;
            }
        }

        private void SaveSeats()
        {
            if (this.carId > 0)
            {
                while (this.seats.Count > 0)
                {
                    SeatStructure seat = this.seats.Dequeue();
                    this.persistence.InsertSeat(this.carId, seat.Name, seat.Capacity);
                }
            }
        }
    }
}