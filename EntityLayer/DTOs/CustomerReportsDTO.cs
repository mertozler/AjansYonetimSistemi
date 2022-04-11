using System;
using System.Collections.Generic;

namespace EntityLayer.DTOs
{
    public class CustomerReportsDTO
    {
        public List<ReportListClass> ReportList { get; set; }
    }
    
    public class ReportListClass
    {
        public string CustomerName { get; set; }
        public int DemandID { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public string ProductContent { get; set; }
        public int ProductID { get; set; }
        public DateTime ProductDate { get; set; }
        public string ReportName { get; set; }
        public string ReportPath { get; set; }
        public bool DemandStatus { get; set; }
    }
}