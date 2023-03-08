using FileworxObjects.DTOs;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileworxObjects
{
    public class PhotoQuery
    {
        public List<PhotoDTO> Run(ElasticClient elasticClient, DateTime? lower, DateTime? upper, string query = "*")
        {
            var queries = new List<QueryContainer>();

            QueryStringQuery keywordQuery = new QueryStringQuery
            {
                Fields = Infer.Fields<PhotoDTO>(p => p.Body).And("description").And("name"),
                Query = "*" + query + "*",
                AnalyzeWildcard = true,
                DefaultOperator = Operator.Or
            };
            queries.Add(keywordQuery);

            QueryStringQuery classidQuery = new QueryStringQuery
            {
                Fields = Infer.Field<PhotoDTO>(p => p.ClassID),
                Query = "2"

            };
            queries.Add(classidQuery);

            DateRangeQuery dateQuery = new DateRangeQuery
            {
                Field = Infer.Field<PhotoDTO>(p => p.Created),
                GreaterThan= lower,
                LessThan = upper

            };
            queries.Add(dateQuery);

            var searchRequest = new SearchRequest<PhotoDTO>
            {
                From = 0,
                Size = 100,
                Query = new BoolQuery
                {
                    Must = queries

                }
            };

            var response = elasticClient.Search<PhotoDTO>(searchRequest);
            return response.Documents.ToList();
        }
    }
}
