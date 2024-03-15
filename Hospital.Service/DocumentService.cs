using Xceed.Words.NET;


namespace Hospital.Application.Services;

public class DocumentService
{
    /// <summary>
    /// Генерация документа - договор на оказание услуг
    /// </summary>
    /// <param name="p">Пациент</param>
    public static void GenerateContract(Patient p)
    {

    }

    /// <summary>
    /// Генерация документа с помощью SyncFusion - согласие на обработку персональных данных
    /// </summary>
    /// <param name="p">Пациент</param>
    //public static void ReplaceTextSync(string filePath, string bookmarkName, string newText)
    //{
    //    // Открытие документа Word
    //    using (FileStream inputStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    //    {
    //        using (WordDocument document = new WordDocument(inputStream, FormatType.Docx))
    //        {
    //            // Замена текста в закладке
    //            if (document.Bookmarks.FindByName(bookmarkName) != null)
    //            {
    //                BookmarksNavigator bookmarksNavigator = new BookmarksNavigator(document);
    //                bookmarksNavigator.MoveToBookmark(bookmarkName);
    //                TextBodyPart textBodyPart = bookmarksNavigator.GetBookmarkContent();

    //                foreach (TextBodyItem item in textBodyPart.BodyItems)
    //                {
    //                    if (item is WParagraph paragraph)
    //                    {
    //                        paragraph.Replace(new System.Text.RegularExpressions.Regex(bookmarkName), newText);
    //                    }
    //                }

    //                bookmarksNavigator.ReplaceBookmarkContent(textBodyPart);
    //            }

    //            // Сохранение изменений в документ
    //            using (FileStream outputFileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
    //            {
    //                document.Save(outputFileStream, FormatType.Docx);
    //            }
    //        }
    //    }
    //}


    /// <summary>
    /// Генерация документа c помощью Xceed - согласие на обработку персональных данных
    /// </summary>
    /// <param name="p">Пациент</param>
    public static void ReplaceWithDocX()
    {
        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "template1.docx");
       
        using (var doc = DocX.Load(templatePath))
        { 

            foreach (var p in doc.Paragraphs)
            {
                p.ReplaceText("text1", "text2");

                Console.WriteLine(p.Text);
            }

            doc.Save();
        }
    }
}
