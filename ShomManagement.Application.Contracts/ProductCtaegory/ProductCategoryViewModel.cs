﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShomManagement.Application.Contracts.ProductCtaegory
{
    public class ProductCategoryViewModel
    {
        //in panel modiriate
        public long id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int ProductsCount { get; set; }
    }
}