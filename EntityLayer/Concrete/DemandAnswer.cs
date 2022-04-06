using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DemandAnswer
    {
        [Key] 
        public int ID { get; set; }

        public int DemandID { get; set; }
        public Demand Demand { get; set; }
        public string SenderID { get; set; }
        public ApplicationUser Sender { get; set; }
        public string ReceiverID { get; set; }
        public ApplicationUser Receiver { get; set; }
        public string Message { get; set; }
        public DateTime CreateTime { get; set; }
        public byte DemandAnswerType { get; set; } // If DemandAnswerType = 0 then it is a employee message, if DemandAnswerType = 1 then it is a 
        public bool Status { get; set; }
        public string? AnswerFilePath { get; set; }
        public string? FileName { get; set; }
    }
}