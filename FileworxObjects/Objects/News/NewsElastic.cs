using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
using Nest;

namespace FileworxObjects.Objects
{
    public partial class News
    {

        public void UpdateDocument(ElasticClient elasticClient)
        {
            var response = elasticClient.Index(NewsMapper.NewsToDto(this), i => i
                  .Index("files")
                  .Id(ID)
                  .Refresh(Elasticsearch.Net.Refresh.True));
        }

        public void DeleteDocument(ElasticClient elasticClient)
        {
            var response = elasticClient.Delete<NewsDTO>(ID, d => d
           .Index("files")
           .Refresh(Elasticsearch.Net.Refresh.True));

        }
    }
}
