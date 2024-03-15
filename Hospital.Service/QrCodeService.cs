using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using static QRCoder.PayloadGenerator;



namespace Hospital.Service;

public class QrCodeService
{

    public static string GenerateQRCode(string text)
    {
            using MemoryStream ms = new();
            QRCodeGenerator qrCodeGenerate = new();
            QRCodeData qrCodeData = qrCodeGenerate.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new(qrCodeData);
            using Bitmap qrBitMap = qrCode.GetGraphic(20);
            qrBitMap.Save(ms, ImageFormat.Png);
            string base64 = Convert.ToBase64String(ms.ToArray());
            
            return string.Format("data:image/png;base64,{0}", base64);
    }


    /// <summary>
    /// Создание QrCode из id и сохранение в базу в формате пути string
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //public static string GenerateQRCode(string uniqname)
    //{
    //    // Получаем текущий путь к проекту
    //    string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\.."));
    //    // Создаем путь к папке images в корне проекта
    //    string imagesDirectory = Path.Combine(projectDirectory, "images");
    //    // Проверяем, существует ли папка images, и если нет, создаем ее
    //    if (!Directory.Exists(imagesDirectory))
    //    {
    //        Directory.CreateDirectory(imagesDirectory);
    //    }
    //    // Формируем полный путь к файлу QR-кода
    //    string imageFileName = Path.Combine(imagesDirectory, $"{uniqname}.png");

    //    QrCodeEncodingOptions options = new()
    //    {
    //        DisableECI = true,
    //        CharacterSet = "UTF-8",
    //        Width = 500,
    //        Height = 500
    //    };

    //    BarcodeWriter writer = new()
    //    {
    //        Format = BarcodeFormat.QR_CODE,
    //        Options = options
    //    };

    //    Bitmap qrCodeBitmap = writer.Write(uniqname);

    //    qrCodeBitmap.Save(imageFileName);

    //    return imageFileName;

    //}


    /// <summary>
    /// Создание QrCode из id и сохранение в базу в формате byte[]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //public static byte[] GenerateQRCodeAsByte(string id)
    //{

    //    QrCodeEncodingOptions options = new()
    //    {
    //        DisableECI = true,
    //        CharacterSet = "UTF-8",
    //        Width = 500,
    //        Height = 500
    //    };
    //    BarcodeWriter writer = new BarcodeWriter()
    //    {
    //        Format = BarcodeFormat.QR_CODE,
    //        Options = options
    //    };
    //    Bitmap qrCodeBitmap = writer.Write(id);

    //    using (MemoryStream ms = new MemoryStream())
    //    {
    //        qrCodeBitmap.Save(ms, ImageFormat.Png);
    //        return ms.ToArray();
    //    }

    //}

    /// <summary>
    /// Генерация qrcode в формате base64
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //public static string GenerateQRCodeBase64(string id)
    //{

    //    QrCodeEncodingOptions options = new()
    //    {
    //        DisableECI = true,
    //        CharacterSet = "UTF-8",
    //        Width = 500,
    //        Height = 500
    //    };

    //    BarcodeWriter writer = new BarcodeWriter()
    //    {
    //        Format = BarcodeFormat.QR_CODE,
    //        Options = options
    //    };

    //    Bitmap qrCodeBitmap = writer.Write(id);

    //    using (MemoryStream ms = new MemoryStream())
    //    {
    //        qrCodeBitmap.Save(ms, ImageFormat.Png);
    //        string base64 = Convert.ToBase64String(ms.ToArray());
    //        return string.Format("data:image/png;base64,{0}", base64);
    //    }

    //}

}
