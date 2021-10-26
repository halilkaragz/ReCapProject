﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();   
            //BrandTest();
        }

        static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            colorManager.Add(new Color() { Name = "Beyaz" });

            var uColor = colorManager.Get(2);
            uColor.Name = "Kırmızı";
            colorManager.Update(uColor);


            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + " 'Id nolu renk :  " + color.Name);
            }
        }

        static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            carManager.Add(new Car() { BrandId = 4, ColorId = 1, DailyPrice = 250, ModelYear = 2021, Description = "mercedes" });
            var car = carManager.Get(2);
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

            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine(item.Name);
            }

        }
    }
}
