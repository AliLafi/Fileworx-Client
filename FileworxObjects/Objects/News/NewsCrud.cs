using FileworxObjects.Connection;

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
            DBDelete();
            DeleteDocument(ElasticConnection.GetESClient());

        }

        public News Read()
        {
            DBRead();
            return this;
        }
    }
}