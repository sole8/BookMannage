using System;
using System.Collections.Generic;
using System.Text;

namespace BookMannage.Model
{
    public class Book
    {
        public string Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public DateTime? InDay { get; set; }
        public DateTime? OutDay { get; set; }
        public string Kind { get; set; }
    }
}
