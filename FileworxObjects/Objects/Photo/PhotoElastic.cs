using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
using Nest;

namespace FileworxObjects.Objects
{
    public partial class Photo : File
    {
        public void UpdateDocument(ElasticClient elasticClient)
        {
            var response = elasticClient.Index<PhotoDTO>(PhotoMapper.PhotoToDto(this), i => i
                  .Index("files")
                  .Id(this.ID)
                  .Refresh(Elasticsearch.Net.Refresh.True));
        }

        public void DeleteDocument(ElasticClient elasticClient)
        {
            var response = elasticClient.Delete<PhotoDTO>(ID, d => d
           .Index("files")
           .Refresh(Elasticsearch.Net.Refresh.True));
        }
    }
}
