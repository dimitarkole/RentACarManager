using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Common
{
    public enum RentStatus : int
    {
        Null = 0,
        Waiting = 1,
        Canceled = 2,
        Active = 3,
        Used = 4,
        Overdue = 5,
    }
}
