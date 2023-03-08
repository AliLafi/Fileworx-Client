using FileworxObjects.Connection;

namespace FileworxObjects.Objects
{
    public partial class Photo
    {
        public void Update()
        {
            DBUpdate();
            UpdateDocument(ElasticConnection.GetESClient());
        }

        public void Delete()
        {
            DBDelete();
            DeleteDocument(ElasticConnection.GetESClient());
        }

        public Photo Read()
        {
            DBRead();
            return this;
        }
    }
}
