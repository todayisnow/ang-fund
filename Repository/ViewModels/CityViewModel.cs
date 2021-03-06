﻿/*
The next code was generated by Repository Pattern Generator.
Be free to modify this file.

This extension was developed and designed by Francisco López Sánchez.
*/

using Repository.Models;
using System;

namespace Repository.ViewModels
{
    public class CityViewModel : IViewModel<City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public City ToModel()
        {
            return new City()
            {
                Id = Id,
                Name = Name,
                CountryId = CountryId
            };
        }

        public void FromModel(City model)
        {
            Id = model.Id;
            Name = model.Name;
            CountryId = model.CountryId;
        }

        public void UpdateModel(City model)
        {
            model.Id = Id;
            model.Name = Name;
            model.CountryId = CountryId;
        }

        public object[] GetKeys()
        {
            return new object[] { Id,CountryId };
        }
    }
}