using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Acpects.Autofac.Validation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Car car)
        {
            //ValidationTool.Validate(new CarValidator(), car);

            //Business codes

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            return null;
        }

        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Delete(Car car)
        {            
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>( _carDal.Get(c => c.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            //İş kodlarından geçiyorsa veri erişim katmanını çalıştır
            //if (DateTime.Now.Hour == 19)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult< List<CarDetailDTO> > GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO> > (_carDal.GetCarDetails());
        }

        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
