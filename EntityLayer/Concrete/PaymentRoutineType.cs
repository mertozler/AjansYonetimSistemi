﻿using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class PaymentRoutineType
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}