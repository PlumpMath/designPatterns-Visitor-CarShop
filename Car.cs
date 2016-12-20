using System.Collections.Generic;
using System.Linq;

namespace CarShop
{
    class Car
    {
        private readonly string make;
        private readonly string model;
        private readonly Engine engine;
        private readonly IEnumerable<Seat> seats;

        public Car(string make, string model, Engine engine, IEnumerable<Seat> seats)
        {
            this.make = make;
            this.model = model;
            this.engine = engine;
            this.seats = seats;
        }

        public CarRegistration Register()
        {
            CarRegistrationVisitor visitor = new CarRegistrationVisitor();
            visitor.VisitCar(this.make, this.model);

            this.engine.Accept(visitor);

            foreach (Seat seat in this.seats)
            {
                seat.Accept(visitor);
            }

            return visitor.Register();
        }

        public void Accept(ICarVisitor visitor)
        {
            visitor.VisitCar(this.make, this.model);

            this.engine.Accept(visitor);

            foreach (Seat seat in this.seats)
            {
                seat.Accept(visitor);
            }
        }
    }
}