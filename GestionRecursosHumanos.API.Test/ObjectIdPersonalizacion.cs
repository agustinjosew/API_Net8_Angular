using AutoFixture;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRecursosHumanos.API.Test
{
    public class ObjectIdPersonalizacion : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register<ObjectId>(() => ObjectId.GenerateNewId());
        }
    }
}
