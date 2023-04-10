using FileworxObjects.Connection;
using System.Collections.Generic;

namespace FileworxObjects.Objects.Contact
{
    public partial class Contact
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

        public Contact Read()
        {
            DBRead();
            return this;
        }

        public List<Contact> Run()
        {
            return GetContacts(ElasticConnection.GetESClient("contacts"));
        }

        public List<Contact> SendContacts()
        {
            return GetSendContacts(ElasticConnection.GetESClient("contacts"));
        }

        public List<Contact> ReceiveContacts()
        {
            return GetReceiveContacts(ElasticConnection.GetESClient("contacts"));
        }
        
    }
}
