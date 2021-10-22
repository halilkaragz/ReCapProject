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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color entity)
        {
            _colorDal.Add(entity);
        }

        public void Delete(Color entity)
        {
            _colorDal.Delete(entity);
        }

        public Color Get(int id)
        {
            return _colorDal.Get(c => c.Id == id);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }     

        public void Update(Color entity)
        {
            _colorDal.Update(entity);
        }    
    }
}
