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
        }

        public void VisitEngine(EngineStructure structure, EngineStatus status)
        {
            this.power = structure.Power;
            this.cylinderVolume = structure.CylinderVolume;
        }

        public void VisitSeat(string name, int capacity)
        {
            this.seats.Enqueue(new SeatStructure(name, capacity));
        }
    }
}