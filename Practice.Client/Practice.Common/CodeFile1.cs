using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Common
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public class Trunk : IEntity
    {

        public int Id
        {
            get;
            set;
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public int CarCount { get; set; }

        public List<Car> Cars { get; set; }
    }


    public class Car : IEntity
    {
        public int Id
        {
            get;
            set;
        }

        public int TrunkId { get; set; }

        public int TypeId { get; set; }

        public int DetailedId { get; set; }

        public float Cost { get; set; }

        public String  Mark { get; set; }

        public String Color { get; set; }
        
    }

    public class CarType
    {
        public int Id { get; set; }

        public String Type { get; set; }
    }

    public class DetailedInfo
    {
        public int Id { get; set; }

        public int Motor { get; set; }

        public string GearType { get; set; }
    }
}
