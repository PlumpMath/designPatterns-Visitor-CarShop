using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEnumerable<Car> cars = new CarRepository().GetAll();

            CarsView view = new CarsView(cars);
            view.Render();

            Console.WriteLine(new string('-', 20));

            Car car = new Car("Renault", "Megane", new Engine(66, 1598), Seat.FourSeatConfiguration);

            CarRegistration registration = car.Register();

            Console.WriteLine(registration);


            Console.Write("Press ENTER to exit... ");
            Console.ReadLine();
        }
    }
}
