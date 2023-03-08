using FileworxObjects.Connection;

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
