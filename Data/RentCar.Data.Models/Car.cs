using Microsoft.AspNetCore.Identity;
using RentCar.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Data.Models
{
    public class Car : IAuditInfo, IDeletableEntity
    {
        public Car()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.Id = Guid.NewGuid().ToString();
            this.RentCars = new HashSet<RentCar>();
        }

        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime Made { get; set; }

        public int CountPassagers { get; set; }

        public string Desctiption { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<RentCar> RentCars { get; set; }
    }
}
