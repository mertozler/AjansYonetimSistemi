using System;
using System.Collections.Generic;

namespace EntityLayer.DTOs
{
    public class CustomerRevisedDemandsDTO
    {
        public List<RevisedDemandListClass> RevisedDemandList { get; set; }
    }

    public class RevisedDemandListClass
    {
        public int DemandID { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public string ProductContent { get; set; }
        public int ProductID { get; set; }
        public DateTime ProductDate { get; set; }
        public string RevisedMessage { get; set; }
        public bool DemandStatus { get; set; }
    }
}