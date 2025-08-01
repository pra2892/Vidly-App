using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieWithGenre
    {
        public Movie movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; } 
    }
}