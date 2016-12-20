using System;

namespace CarShop
{
    class Engine
    {
        private float power;
        private float cylinderVolume;

        private const float WorkingTemperatureC = 90.0F;
        private float temperatureC = 20.0F;

        public Engine(float power, float cylinderVolume)
        {
            this.power = power;
            this.cylinderVolume = cylinderVolume;
        }

        public void Accept(ICarPartVisitor visitor)
        {
            visitor.VisitEngine(this.power, this.cylinderVolume, this.temperatureC);
        }

        public void Run(TimeSpan time)
        {
            TimeSpan heatingTime = GetHeatingTime();

            if (time > heatingTime)
            {
                this.temperatureC = WorkingTemperatureC;
            }
            else
            {
                double temperatureDelta = WorkingTemperatureC - this.temperatureC;
                double timeRatio = time.TotalMinutes / heatingTime.TotalMinutes;
                this.temperatureC += (float)(temperatureDelta * timeRatio);
            }
        }

        private TimeSpan GetHeatingTime()
        {
            return new TimeSpan(0, 3, 0);
        }
    }
}