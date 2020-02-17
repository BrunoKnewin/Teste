using Cidades.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Cidades.Infra.Mappings
{
    public class CidadeMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Cidade>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Nome).SetIsRequired(true);
                map.MapMember(x => x.Populacao).SetIsRequired(true);
                map.MapMember(x => x.Fronteiras).SetIsRequired(true);
            });
        }
    }
}
