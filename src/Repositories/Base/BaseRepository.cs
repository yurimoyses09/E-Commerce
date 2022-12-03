﻿using E_Commerce_CasaDoCodigo.Context;
using E_Commerce_CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_CasaDoCodigo.Repositories.Base
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext _applicationContext;
        protected readonly DbSet<T> _DbSetprodutos;


        public BaseRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _DbSetprodutos = _applicationContext.Set<T>();
        }
    }
}
