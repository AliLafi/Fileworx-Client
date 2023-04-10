using FileworxObjects.Mappers;
using Nest;

namespace FileworxObjects.Objects.Contact
{
    public partial class Contact : BusinessObject
    {
        public void UpdateDocument(ElasticClient elasticClient)
        {
            var response = elasticClient.Index(ContactMapper.ContactToDto(this), i => i
                  .Index("contacts")
                  .Id(ID)
                  .Refresh(Elasticsearch.Net.Refresh.True)
                  );
        }

        public void DeleteDocument(ElasticClient elasticClient)
        {
            var response = elasticClient.Delete<Contact>(ID, d => d
           .Index("contacts")
           .Refresh(Elasticsearch.Net.Refresh.True));
        }
    }
}
