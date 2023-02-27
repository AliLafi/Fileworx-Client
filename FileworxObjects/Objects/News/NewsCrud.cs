using Elasticsearch.Net;
using FileworxObjects.Connection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects.Objects
{
    public partial class News 
    {

        public  void  Update()
        {
            DBUpdate();
            UpdateDocument(ElasticConnection.GetESClient());
        }

        public  void Delete()
        {
            this.DBDelete();

            DeleteDocument(ElasticConnection.GetESClient());

        }

        public News Read()
        {
            this.DBRead();
            return this;
        }
        
    }
}
