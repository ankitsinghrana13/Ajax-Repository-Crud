﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ajax_Repository_Crud.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Published_On { get; set; }
        public int Authar_Id { get; set; }

    }
}
