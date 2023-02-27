using Elasticsearch.Net;
using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var response = elasticClient.Delete<PhotoDTO>(this.ID, d => d
           .Index("files")
           .Refresh(Elasticsearch.Net.Refresh.True));

        }
    }
}
