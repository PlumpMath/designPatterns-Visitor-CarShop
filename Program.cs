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



            foreach (Car car in cars)
            {
                CarRegistration registration = car.Register();
                // CarRegistration registration = car.Accept(() => new CarRegistrationBuilder(car));
                Console.WriteLine(registration);
            }



            Console.WriteLine(new string('-', 20));



            Car car2 = new CarRepository().GetAll().Last();

            car2.Accept(() => new SaveCarVisitor());




            Console.Write("Press ENTER to exit... ");
            Console.ReadLine();
        }
    }
}
