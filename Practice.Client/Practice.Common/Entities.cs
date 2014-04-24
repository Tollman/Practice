using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Practice.Common
{
	public interface IEntity
	{
		int Id { get; set; }
	}

	[DataContract]
	public class Trunk : IEntity
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string Address { get; set; }

		[DataMember]
		public int CarCount { get; set; }

		[DataMember]
		public List<Car> Cars { get; set; }
	}

	[DataContract]
	public class Car : IEntity
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public int TrunkId { get; set; }

		[DataMember]
		public int TypeId { get; set; }

		[DataMember]
		public int DetailedId { get; set; }

		[DataMember]
		public float Cost { get; set; }
		[DataMember]
		public String Mark { get; set; }
		[DataMember]
		public String Color { get; set; }
		[DataMember]
		public CarType Type { get; set; }
		[DataMember]
		public DetailedInfo Info { get; set; }
		[DataMember]
		public Trunk Trunk { get; set; }
	}

	[DataContract]
	public class CarType : IEntity
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public String Type { get; set; }
	}

	[DataContract]
	public class DetailedInfo : IEntity
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public int Motor { get; set; }
		[DataMember]
		public string GearType { get; set; }
	}
}
