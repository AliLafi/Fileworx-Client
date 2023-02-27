using FileworxObjects.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects.Objects
{
    public partial class Photo
    {
        public void Update()
        {
            this.DBUpdate();
            this.UpdateDocument(ElasticConnection.GetESClient());
        }

        public void Delete()
        {
            this.DBDelete();
            this.DeleteDocument(ElasticConnection.GetESClient());

        }

        public Photo Read()
        {
            this.DBRead();
            return this;
        }

    }
}
