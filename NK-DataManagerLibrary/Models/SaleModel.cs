﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NK_DataManagerLibrary.Models
{
    public class SaleModel
    {
        public LinkedList<SaleDetailModel> SaleDetails { get; set; }
    }
}