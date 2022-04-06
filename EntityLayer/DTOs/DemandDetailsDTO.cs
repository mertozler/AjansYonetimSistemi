using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EntityLayer.DTOs
{
    public class DemandDetailsDTO
    {
        public List<DemandDetailClass> DemandDetailList { get; set; }
        public List<DemandAnswersForEmployee> EmployeeDemandAnswers { get; set; }
        public string DemandAnswer { get; set; }
        public int DemandID { get; set; }
        public IFormFile DemandFile { get; set; }
    }

    public class DemandDetailClass
    {
        public string DemandTitle { get; set; }
        public string DemandContent { get; set; }
        public string DemandCreatorName{ get; set; }
        public string DemandReceiverName{ get; set; }
        public string DemandFilePath{ get; set; }
        public DateTime DemandCreateTime { get; set; }
        
    }
    
    public class DemandAnswersForEmployee
    {
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Message { get; set; }
        public byte AnswerType { get; set; }
        public DateTime DemandAnswerDate { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}