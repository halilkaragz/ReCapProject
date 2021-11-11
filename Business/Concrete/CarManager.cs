﻿using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                //Console.WriteLine("Araba açıklaması iki karakterden fazla olmalıdır!");
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else if (car.DailyPrice <= 0)
            {
                //Console.WriteLine("Arabanın günlük kiralama fiyatı sıfırdan büyük olmalıdır!");
                return new ErrorResult(Messages.InvalidCarDailyPrice);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);                
            }
        }

        public IResult Delete(Car car)
        {            
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>( _carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetAll()
        {
            //İş kodlarından geçiyorsa veri erişim katmanını çalıştır
            //if (DateTime.Now.Hour == 19)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult< List<CarDetailDTO> > GetCarDetails()
        {
            return new ErrorDataResult<List<CarDetailDTO> > (_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
