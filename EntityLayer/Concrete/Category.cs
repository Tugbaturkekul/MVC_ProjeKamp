﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
      
        public int CategoryID { get; set; }
        
     
        public string CategoryName { get; set; }

       
        public string CategoryDescription { get; set; }

        public bool CategoryStatus { get; set; }
        //silme yerine true/false şeklinde göstericez pasif hale getireceğiz

        public ICollection<Heading> Headings { get  ; set; }
    }
}
