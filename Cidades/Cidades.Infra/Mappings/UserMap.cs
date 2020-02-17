using Cidades.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Cidades.Infra.Mappings
{
    public class UserMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<User>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Nome).SetIsRequired(true);
                map.MapMember(x => x.Senha).SetIsRequired(true);
                map.MapMember(x => x.Email).SetIsRequired(true);
                map.MapMember(x => x.DataNascimento).SetIsRequired(true);
            });
        }
    }
}
