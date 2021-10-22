﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand entity)
        {
            _brandDal.Add(entity);
        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
        }

        public Brand Get(int id)
        {
            return _brandDal.Get(c => c.Id == id);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }     

        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
        }
    }
}
