using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EntityLayer.Concrete;

namespace EntityLayer.DTOs
{
    public class CustomerPaymentTrackingDTO
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerServices { get; set; }
        public string CustomerPaymentRoutineName { get; set; }
        public int CustomerPaymentRoutineID { get; set; }
        public List<Services> serviceList { get; set; }
        [Required(ErrorMessage ="Tarih seçimi boş geçilemez.")]
        public DateTime SelectedDate { get; set; }
        [Required(ErrorMessage ="Hizmet seçimi boş geçilemez.")]
        public int SelectedServiceID { get; set; }
        public double PaymentPrice { get; set; }
        public List<PaymentHistoryClass> PaymentHistoryList { get; set; }
        public double PaymentPriceSum { get; set; }
    }

    public class PaymentHistoryClass
    {
        public double PaymentPrice { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}