using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoCars.Domain;

namespace PoCars.ViewModels
{
    public class CarViewModel
    {
        public string Title { get; set; }
        public Car Car { get; set; }

        public List<SelectListItem> Brands { get; set; }
        public List<SelectListItem> FuelType { get; set; }
        public List<SelectListItem> BodyStyles { get; set; }

        public CarViewModel()
        {
            Brands = new List<SelectListItem>();
            BodyStyles = new List<SelectListItem>();
            FuelType = new List<SelectListItem>();

            foreach (var brand in Enum.GetValues(typeof(Brand)).Cast<Brand>())
                Brands.Add(new SelectListItem
                {
                    Value = ((int) brand).ToString(),
                    Text = brand.ToString()
                });

            foreach (var fuel in Enum.GetValues(typeof(Brand)).Cast<Fuel>())
                FuelType.Add(new SelectListItem
                {
                    Value = ((int) fuel).ToString(),
                    Text = fuel.ToString()
                });

            foreach (var bodyStyle in Enum.GetValues(typeof(BodyStyle)).Cast<BodyStyle>())
                BodyStyles.Add(new SelectListItem
                {
                    Value = ((int) bodyStyle).ToString(),
                    Text = bodyStyle.ToString()
                });
        }
    }
}