using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class PaymentRoutineTypesManager:IPaymentRoutineTypesService
    {
        private IPaymentRoutineTypesDal _paymentRoutineTypesDal;

        public PaymentRoutineTypesManager(IPaymentRoutineTypesDal paymentRoutineTypesDal)
        {
            _paymentRoutineTypesDal = paymentRoutineTypesDal;
        }

        public void Add(PaymentRoutineType t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(PaymentRoutineType t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(PaymentRoutineType t)
        {
            throw new System.NotImplementedException();
        }

        public List<PaymentRoutineType> GetList()
        {
            return _paymentRoutineTypesDal.GetListAll();
        }

        public PaymentRoutineType GetById(int id)
        {
            return _paymentRoutineTypesDal.GetById(id);
        }
    }
}