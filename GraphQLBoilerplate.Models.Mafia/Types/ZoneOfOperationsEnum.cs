using GraphQL.Types;

namespace GraphQLBoilerplate.Models.Mafia.Types
{
    public class ZoneOfOperationsEnum : EnumerationGraphType
    {
        public ZoneOfOperationsEnum()
        {
            Name = "ZoneOfOperation";
            Description = "One of the state zones";
            AddValue("WestSide", "West side of the state", 1);
            AddValue("SouthSide", "South side of the state", 2);
        }
    }
}
