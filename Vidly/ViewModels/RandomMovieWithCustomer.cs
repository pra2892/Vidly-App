﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieWithCustomer
    {
        public Movie Movie { get; set; }
        public List<Customer> Customer { get; set; }
    }
}