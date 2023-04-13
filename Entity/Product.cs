﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductListingPage.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Hover_Image { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }

        public string Size { get; set; }
        public string Color { get; set; }

        public string FeatureValue { get; set; }
        public string Brand { get; set; }

    }
}