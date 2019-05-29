using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace PoCars.Domain
{
    public class Car
    {
        public int Id { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public BodyStyle BodyStyle { get; set; }
        public Fuel Fuel { get; set; }
        public float EnginePower { get; set; }
        public string Color { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal Price { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public Car()
        {
            UpdateAt = DateTime.UtcNow;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
