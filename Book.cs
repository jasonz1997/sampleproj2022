using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTechManagementApp.GUI
{
    public class Book
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        public float UnitPrice { get; set; }
        public int YearPublished { get; set; }
        public int QOH { get; set; }
        public int CategoryId { get; set; }
        public string PublisherName { get; set; }
    }
}
