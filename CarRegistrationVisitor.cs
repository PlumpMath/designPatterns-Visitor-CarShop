using System;

namespace CarShop
{
    class CarRegistrationVisitor : ICarVisitor
    {
        private string make;
        private string model;
        private float power;
        private float cylinderVolume;
        private float temperatureC;
        private int seatsCount;

        public void VisitCar(string make, string model)
        {
            this.make = make;
            this.model = model;
        }

        public void VisitEngine(float power, float cylinderVolume, float temperatureC)
        {
            this.power = power;
            this.cylinderVolume = cylinderVolume;
            this.temperatureC = temperatureC;
        }

        public void VisitSeat(string name, int capacity)
        {
            this.seatsCount += capacity;
        }

        public CarRegistration Register()
        {
            return new CarRegistration(this.make.ToUpper(), this.model, this.cylinderVolume, this.seatsCount);
        }
    }
}