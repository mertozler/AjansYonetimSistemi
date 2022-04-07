using System.Collections.Generic;

namespace EntityLayer.DTOs
{
    public class CustomerDesignDTO
    {
        private List<Design> DesignList { get; set; }
    }

    public class Design
    {
        public string ImagePath { get; set; }
    }
}