using Elasticsearch.Net;
using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FileworxObjects.Objects
{
    public partial class News
    {


        public void UpdateDocument(ElasticClient elasticClient)
        {
            var response = elasticClient.Index<NewsDTO>(NewsMapper.NewsToDto(this), i => i
                  .Index("files")
                  .Id(this.ID)
                  .Refresh(Elasticsearch.Net.Refresh.True));
        }

        public void DeleteDocument(ElasticClient elasticClient)
        {
            var response = elasticClient.Delete<NewsDTO>(this.ID, d => d
           .Index("files")
           .Refresh(Elasticsearch.Net.Refresh.True));

        }

  
    }
}
