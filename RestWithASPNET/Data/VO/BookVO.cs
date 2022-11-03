using RestWithASPNET.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET.Model
{
    
    public class BookVO 
    {
        public long Id { get; set; }
        public string Author { get; set; }
        
        public DateTime LaunchDate { get; set; }
        
        public double Price { get; set; }
       
        public string Title { get; set; }
    }
}
