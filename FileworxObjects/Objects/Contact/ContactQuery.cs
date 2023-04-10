using Nest;
using System.Collections.Generic;
using System.Linq;

namespace FileworxObjects.Objects.Contact
{
    public partial class Contact : BusinessObject
    {
        public List<Contact> GetContacts(ElasticClient elasticClient)
        {
            var response = elasticClient.Search<Contact>(i => i.Index("contacts"));
            return response.Documents.ToList();
        }

        public List<Contact> GetSendContacts(ElasticClient elasticClient)
        {
            var res = elasticClient.Search<Contact>(new SearchRequest<Contact>
            {
                Query = new TermQuery { Field = Infer.Field<Contact>(p => p.IsWriteFile), Value = "true" } ||
                        new TermQuery { Field = Infer.Field<Contact> (p => p.IsWriteFtp),Value= "true" }
            });
            return res.Documents.ToList();
        }

        public List<Contact> GetReceiveContacts(ElasticClient elasticClient)
        {

            var res = elasticClient.Search<Contact>(new SearchRequest<Contact>
            {
                Query = new TermQuery { Field = Infer.Field<Contact>(p => p.IsReadFile), Value = "true" }||
                        new TermQuery { Field = Infer.Field<Contact>(p => p.IsReadFtp), Value = "true" }

            });
            return res.Documents.ToList();
        }
    }
}
