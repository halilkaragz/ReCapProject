using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars = new List<Car>
        {
            new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 100, Description = "Arazi aracı", ModelYear = 2019},
            new Car{Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 150, Description = "Binek otomobil", ModelYear = 2019},
            new Car{Id = 3, BrandId = 2, ColorId = 3, DailyPrice = 200, Description = "Spor araba", ModelYear = 2019},
            new Car{Id = 4, BrandId = 3, ColorId = 4, DailyPrice = 200, Description = "Makam aracı", ModelYear = 2019},
            new Car{Id = 5, BrandId = 3, ColorId = 5, DailyPrice = 100, Description = "Ticari araç", ModelYear = 2019},
        };
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //foreach (var item in _cars)
            //{
            //    if (item.Id == car.Id)
            //    {
            //        _cars.Remove(item);
            //    }
            //}

            Car _carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(_carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int Id)
        {
            //Car carToReturn = null;

            //foreach (var item in _cars)
            //{
            //    if (item.Id == Id)
            //    {
            //        carToReturn = item;
            //    }               
            //}
            //return carToReturn;

            return _cars.SingleOrDefault(c => c.Id == Id);
        }

        public void Update(Car car)
        {
            //foreach (var item in _cars)
            //{
            //    if (item.Id == car.Id)
            //    {
            //        item.BrandId = car.BrandId;
            //        item.ColorId = car.ColorId;
            //        item.DailyPrice = car.DailyPrice;
            //        item.Description = car.Description;
            //        item.ModelYear = car.ModelYear;
            //    }
            //}

            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
