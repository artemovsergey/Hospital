using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using static QRCoder.PayloadGenerator;


namespace Hospital.Service;

public class QrCodeService
{

    /// <summary>
    /// Генерация QrCode из изображения в строку base64
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string GenerateQRCode(string text)
    {
            using MemoryStream ms = new();
            QRCodeGenerator qrCodeGenerate = new();
            QRCodeData qrCodeData = qrCodeGenerate.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new(qrCodeData);
            using Bitmap qrBitMap = qrCode.GetGraphic(5);
            qrBitMap.Save(ms, ImageFormat.Png);
            string base64 = Convert.ToBase64String(ms.ToArray());
            
            return string.Format("data:image/png;base64,{0}", base64);
    }
}
