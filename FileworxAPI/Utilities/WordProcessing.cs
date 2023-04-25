using FileworxObjects.Objects;

using Telerik.Windows.Documents.Flow.Model;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Documents.Core.Fonts;
using Telerik.Windows.Documents.Flow.Model.Shapes;
using Telerik.Windows.Documents.Fixed.Model.Resources;
using Telerik.Windows.Documents.Flow.Model.Styles;

namespace FileworxAPI.Utilities
{
    public class WordProcessing
    {
        public static readonly string SharedFolder = "D:\\SharedPhotos";

        public static Stream SaveNews(News news)
        {
            RadFlowDocument document = new RadFlowDocument();
            Section section = new Section(document);
            document.Sections.Add(section);

            Paragraph firstParagraph = new Paragraph(document);
            section.Blocks.Add(firstParagraph);

            Run name = new Run(document);
            name.Text = news.Name;
            name.FontSize = 50;
            firstParagraph.Inlines.Add(name);

            Paragraph secondParagraph = new Paragraph(document);
            section.Blocks.Add(secondParagraph);

            Run body = new Run(document);
            body.Text = news.Body;
            body.FontSize = 30;
            secondParagraph.Inlines.Add(body);

            return SaveDocument(document);

        }

        public static Stream SavePhoto(Photo photo)
        {
            RadFlowDocument document = new RadFlowDocument();
            Section section = new Section(document);
            document.Sections.Add(section);

            Paragraph firstParagraph = new Paragraph(document);
            section.Blocks.Add(firstParagraph);

            Run name = new Run(document);
            name.Text = photo.Name;
            name.FontSize = 50;
            firstParagraph.Inlines.Add(name);

            Paragraph secondParagraph = new Paragraph(document);
            section.Blocks.Add(secondParagraph);

            Run body = new Run(document);
            body.Text = photo.Body;
            body.FontSize = 30;
            secondParagraph.Inlines.Add(body);

            Paragraph imageParagraph = new Paragraph(document);
            section.Blocks.Add(imageParagraph);
            try
            {
                ImageInline imageInline = new ImageInline(document);

                byte[] data = File.ReadAllBytes(photo.ImagePath);
                string extension = Path.GetExtension(photo.ImagePath);
                imageInline.Image.ImageSource = new Telerik.Windows.Documents.Media.ImageSource(data, extension);
                imageInline.Image.SetWidth(true, 400);
                imageInline.Image.SetHeight(false, 400);

                imageParagraph.Inlines.Insert(0, imageInline);
            }
            catch
            {

            }

            return SaveDocument(document);
        }

        public static Stream ExportNewsList(List<News> news)
        {
            RadFlowDocument document = new RadFlowDocument();
            Section section = new Section(document);
            document.Sections.Add(section);


            Table table = new Table(document);
            section.Blocks.Add(table);
            document.StyleRepository.AddBuiltInStyle(BuiltInStyleNames.TableGridStyleId);
            table.StyleId = BuiltInStyleNames.TableGridStyleId;

            TableRow row = table.Rows.AddTableRow();
            TableCell IdCell = row.Cells.AddTableCell();
            IdCell.Blocks.AddParagraph().Inlines.AddRun("ID");
            TableCell Namecell = row.Cells.AddTableCell();
            Namecell.Blocks.AddParagraph().Inlines.AddRun("Name");
            TableCell categoryCell = row.Cells.AddTableCell();
            categoryCell.Blocks.AddParagraph().Inlines.AddRun("Category");
            TableCell descriptionCell = row.Cells.AddTableCell();
            descriptionCell.Blocks.AddParagraph().Inlines.AddRun("Description");
            for (int i = 0; i < news.Count; i++)
            {
                row = table.Rows.AddTableRow();


                IdCell = row.Cells.AddTableCell();
                IdCell.Blocks.AddParagraph().Inlines.AddRun(news[i].ID.ToString());

                Namecell = row.Cells.AddTableCell();
                Namecell.Blocks.AddParagraph().Inlines.AddRun(news[i].Name);

                categoryCell = row.Cells.AddTableCell();
                categoryCell.Blocks.AddParagraph().Inlines.AddRun(news[i].Category);

                descriptionCell = row.Cells.AddTableCell();
                descriptionCell.Blocks.AddParagraph().Inlines.AddRun(news[i].Description);

            }
            return SaveDocument(document);
        }
        public static Stream ExportPhotoList(List<Photo> photos)
        {
            RadFlowDocument document = new RadFlowDocument();
            Section section = new Section(document);
            document.Sections.Add(section);


            Table table = new Table(document);
            section.Blocks.Add(table);
            document.StyleRepository.AddBuiltInStyle(BuiltInStyleNames.TableGridStyleId);
            table.StyleId = BuiltInStyleNames.TableGridStyleId;

            TableRow row = table.Rows.AddTableRow();
            TableCell IdCell = row.Cells.AddTableCell();
            IdCell.Blocks.AddParagraph().Inlines.AddRun("ID");
            TableCell Namecell = row.Cells.AddTableCell();
            Namecell.Blocks.AddParagraph().Inlines.AddRun("Name");
            TableCell categoryCell = row.Cells.AddTableCell();
            categoryCell.Blocks.AddParagraph().Inlines.AddRun("Image Path");
            TableCell descriptionCell = row.Cells.AddTableCell();
            descriptionCell.Blocks.AddParagraph().Inlines.AddRun("Description");
            for (int i = 0; i < photos.Count; i++)
            {
                row = table.Rows.AddTableRow();


                IdCell = row.Cells.AddTableCell();
                IdCell.Blocks.AddParagraph().Inlines.AddRun(photos[i].ID.ToString());

                Namecell = row.Cells.AddTableCell();
                Namecell.Blocks.AddParagraph().Inlines.AddRun(photos[i].Name);

                categoryCell = row.Cells.AddTableCell();
                categoryCell.Blocks.AddParagraph().Inlines.AddRun(photos[i].ImagePath);

                descriptionCell = row.Cells.AddTableCell();
                descriptionCell.Blocks.AddParagraph().Inlines.AddRun(photos[i].Description);

            }
            return SaveDocument(document);
        }

        private static Stream SaveDocument(RadFlowDocument document)
        {

            MemoryStream stream = new MemoryStream();
            DocxFormatProvider provider = new DocxFormatProvider();
            provider.Export(document, stream);
            stream.Position = 0;

            return stream;
        }
    }
}
