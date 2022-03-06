using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();   
            //BrandTest();
            //CarDetailsTest();
            //RentalTest();
            //UserTest();

        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EFUserDal());
            User user = new User()
            {
                FirstName = "Halil",
                LastName = "Karagöz",
                Email = "halilkaragoz_blsm@hotmail.com",               
            };

            userManager.Add(user);
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EFRentalDal());
            Rental rental = new Rental() { CarId = 1, CustomerId = 1, RentDate = new DateTime(2021, 10, 31), ReturnDate = new DateTime(2021,10,31) };
            rentalManager.Add(rental);
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + " - " + car.BrandName +
                    " - " + car.ColorName + " - " + car.DailyPrice);
            }
        }

        static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            colorManager.Add(new Color() { Name = "Beyaz" });

            var uColor = colorManager.Get(2).Data;
            uColor.Name = "Kırmızı";
            colorManager.Update(uColor);


            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id + " 'Id nolu renk :  " + color.Name);
            }
        }

        static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            carManager.Add(new Car() { BrandId = 4, ColorId = 1, DailyPrice = 250, ModelYear = 2021, Description = "mercedes" });
            var car = carManager.Get(2).Data;
            car.Description = "bmv";
            carManager.Update(car);
        }

        static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            Brand brand = new Brand() { Name = "BMW" };
            brandManager.Add(brand);

            //Brand brand = brandManager.Get(1);

            //Console.WriteLine(brand.Name);

            //brand.Name = "BMW";
            //brandManager.Update(brand);

            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.Name);
            }

        }
    }
}
