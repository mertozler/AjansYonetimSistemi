﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfDemandAnswersRepository: GenericRepository<DemandAnswer>,IDemandAnswersDal
    {
        
    }
}