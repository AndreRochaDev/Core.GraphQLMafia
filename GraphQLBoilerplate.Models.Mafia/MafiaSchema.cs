using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;
using GraphQL.Types;

namespace GraphQLBoilerplate.Models.Mafia
{
    public class MafiaSchema : Schema   
    {
        public MafiaSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MafiaQuery>();
            Mutation = resolver.Resolve<MafiaMutation>();
        }
    }
}
