using RentCar.Common;
using RentCar.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Data.Models
{
    public class RentCar : IAuditInfo, IDeletableEntity
    {
        public RentCar()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string CarId { get; set; }

        public Car Car { get; set; }

        public RentStatus RentStattus { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public double Price { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
