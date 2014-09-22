// By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type EntitySet<T>.


namespace NorthwindConsole
{
    using System;
    using System.Data.Linq;
    using System.Linq;

    public partial class Employee
    {
        public EntitySet<Territory> TerritoriesAsEntitySet
        {
            get
            {
                var entityTeritories = new EntitySet<Territory>();
                entityTeritories.AddRange(this.Territories);
                return entityTeritories;
            }
        }
    }
}
