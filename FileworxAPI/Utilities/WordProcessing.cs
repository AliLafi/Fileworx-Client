using FileworxObjects.Objects;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;


namespace FileworxAPI.Utilities
{
    public class WordProcessing
    {
        public static readonly string SharedFolder = "D:\\SharedPhotos";

        public static Stream SaveNews(News news)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NRAiBiAaIQQuGjN/V0d+XU9Hc1RHQmJOYVF2R2BJelRycl9CaUwgOX1dQl9gSXpSfkVgXHZcd3VRRmI=");
            WordDocument document = new WordDocument();
            IWSection section = document.AddSection();
            IWParagraph firstParagraph = section.AddParagraph();
            firstParagraph.AppendText(news.Name);
            firstParagraph.ApplyStyle(BuiltinStyle.Heading1);

            IWParagraph secondParagraph = section.AddParagraph();
            secondParagraph.AppendText(news.Body);
            secondParagraph.ApplyStyle(BuiltinStyle.BodyText);

            return SaveDocument(document);
            
        }

        public static Stream SavePhoto(Photo photo)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NRAiBiAaIQQuGjN/V0d+XU9Hc1RHQmJOYVF2R2BJelRycl9CaUwgOX1dQl9gSXpSfkVgXHZcd3VRRmI=");
            WordDocument document = new WordDocument();
            IWSection section = document.AddSection();
            IWParagraph firstParagraph = section.AddParagraph();
            firstParagraph.AppendText(photo.Name);
            firstParagraph.ApplyStyle(BuiltinStyle.Heading1);

            IWParagraph secondParagraph = section.AddParagraph();
            secondParagraph.AppendText(photo.Body);
            secondParagraph.ApplyStyle(BuiltinStyle.BodyText);
            
            try
            {
                IWParagraph photoParagraph = section.AddParagraph();
                FileStream imageStream = new FileStream(Path.Join(SharedFolder, photo.ImagePath), FileMode.Open, FileAccess.ReadWrite);
                photoParagraph.AppendPicture(imageStream);
            }
            catch
            {

            }

            return SaveDocument( document);    
        }

        public static Stream ExportNewsList(List<News> news)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NRAiBiAaIQQuGjN/V0d+XU9Hc1RHQmJOYVF2R2BJelRycl9CaUwgOX1dQl9gSXpSfkVgXHZcd3VRRmI=");
            WordDocument document = new WordDocument();
            IWSection section = document.AddSection();

            IWTable table = section.AddTable();
            table.ResetCells(news.Count + 1, 4);


            table.Rows[0].Cells[0].AddParagraph().AppendText("ID");
            table.Rows[0].Cells[1].AddParagraph().AppendText("Title");
            table.Rows[0].Cells[2].AddParagraph().AppendText("Category");
            table.Rows[0].Cells[3].AddParagraph().AppendText("Description");

            for (int i = 1; i <= news.Count; i++)
            {
                table.Rows[i].Cells[0].AddParagraph().AppendText(news.ElementAt(i-1).ID.ToString());
                table.Rows[i].Cells[1].AddParagraph().AppendText(news.ElementAt(i-1).Name);
                table.Rows[i].Cells[2].AddParagraph().AppendText(news.ElementAt(i-1).Category);
                table.Rows[i].Cells[3].AddParagraph().AppendText(news.ElementAt(i - 1).Description);
            }
           return SaveDocument( document);
        }

        public static Stream ExportPhotoList(List<Photo> photos)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NRAiBiAaIQQuGjN/V0d+XU9Hc1RHQmJOYVF2R2BJelRycl9CaUwgOX1dQl9gSXpSfkVgXHZcd3VRRmI=");
            WordDocument document = new WordDocument();
            IWSection section = document.AddSection();

            IWTable table = section.AddTable();
            table.ResetCells(photos.Count + 1, 4);


            table.Rows[0].Cells[0].AddParagraph().AppendText("ID");
            table.Rows[0].Cells[1].AddParagraph().AppendText("Title");
            table.Rows[0].Cells[2].AddParagraph().AppendText("Image Path");
            table.Rows[0].Cells[3].AddParagraph().AppendText("Description");

            for (int i = 1; i <= photos.Count; i++)
            {
                table.Rows[i].Cells[0].AddParagraph().AppendText(photos.ElementAt(i - 1).ID.ToString());
                table.Rows[i].Cells[1].AddParagraph().AppendText(photos.ElementAt(i - 1).Name);
                table.Rows[i].Cells[2].AddParagraph().AppendText(photos.ElementAt(i - 1).ImagePath);
                table.Rows[i].Cells[3].AddParagraph().AppendText(photos.ElementAt(i - 1).Description);
            }
            return SaveDocument(document);
        }

        private static Stream SaveDocument( WordDocument document)
        {

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Docx);
            stream.Position = 0;
            document.Close();

            return stream;
        }
    }
}
