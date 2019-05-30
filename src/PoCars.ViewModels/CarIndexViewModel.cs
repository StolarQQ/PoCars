using System.Collections.Generic;
using PoCars.Domain;

namespace PoCars.ViewModels
{
    public class CarIndexViewModel
    {
        public string Title { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public Car Car { get; set; }
    }
}