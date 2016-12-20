using System;

namespace CarShop
{
    class CarRegistrationVisitor : ICarVisitor
    {
        private string make;
        private string model;

        private EngineStructure engineStructure;
        private EngineStatus engineStatus;

        private int seatsCount;

        public void VisitCar(string make, string model)
        {
            this.make = make;
            this.model = model;
        }

        public void VisitEngine(EngineStructure structure, EngineStatus status)
        {
            this.engineStructure = structure;
            this.engineStatus = status;
        }

        public void VisitSeat(string name, int capacity)
        {
            this.seatsCount += capacity;
        }

        public CarRegistration Register()
        {
            return new CarRegistration(this.make.ToUpper(), this.model, this.engineStructure.CylinderVolume, this.seatsCount);
        }
    }
}