using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Linq;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Car car = new Car();
            car.BrandId = 3;
            car.ColorID = 2;
            car.DailyPrice = 850;
            car.Description = "Egea";
            car.ModelYear = 2010;
            
            EfCarDal carDal = new EfCarDal();
            carDal.Add(car);*/

            //brandGetAll();

            //CarDetails();

            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName+"/"+car.ColorName+"/"+car.DailyPrice);

                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Rental rental = new Rental() { RentalId = 7,
                CarId = 3,
                CustomerId = 2,
                
                ReturnDate = DateTime.Now
            };

           

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var results = rentalManager.Update(rental);

            if (results.Success)
            {
                Console.WriteLine(results.Message);
            }
            else
            {
                Console.WriteLine(results.Message);
            }

            

           
            




            //if (results.Success)
            //{
            //    Console.WriteLine(results.Message);
            //}
            //else
            //{
            //    Console.WriteLine(results.Message);
            //}

            

            

            
            












            //colorGetAll();



        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " / " + car.Description);
                }
            }
            
        }

        private static void colorGetAll()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorId + " / " + color.ColorName);
                }
            }
            
        }

        private static void brandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            
        }
    }
}
