using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AppCRM.Login.Entities
{
    public class LoginQR
    {
        //1. Socket:
        public void SendInforQrCode(string QrId, string Email, string UserPassword)
        {
            try
            {
                //WIO.EmitAsync("QRLogin", QrId, Email, UserPassword);
            }
            catch (Exception ex)
            {

            }
        }

        //2. Hàm:
        // Hàm random để làm id qr
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        // Hàm chuyển bitmap sang image source
        private ImageSource BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        // Đối tượng infoQR
        public class infoQR
        {
            public infoQR(string qRType, string idQR, string idComputer, string nameComputer, double? latitude, double? longitude, string time)
            {
                QRType = qRType;
                this.idQR = idQR;
                IdComputer = idComputer;
                NameComputer = nameComputer;
                this.latitude = latitude;
                this.longitude = longitude;
                Time = time;
            }

            public string QRType { get; set; }
            public string idQR { get; set; }
            public string IdComputer { get; set; }
            public string NameComputer { get; set; }
            public double? latitude { get; set; }
            public double? longitude { get; set; }
            public string Time { get; set; }

        }

        // Hàm mã hóa Base64
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }


        // Hàm tạo QR code đăng nhập
        private void CreateQRCode(double? lat, double? lng)
        {

            //try
            //{
            //    string logo = Environment.GetEnvironmentVariable("APPDATA") + @"\Chat365\chat365_logo.png";
            //    IdQR = RandomString(8);
            //    string x = Base64Encode(IdQR);
            //    string IdDevice = $"{RandomString(8)}-{RandomString(4)}-{RandomString(4)}-{RandomString(4)}-{RandomString(12)}";
            //    string info = JsonConvert.SerializeObject(new infoQR("QRLoginPc", (x + "++"), IdDevice, $"{Environment.MachineName}-Windows", lat, lng, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
            //    QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            //    QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(info, QRCodeGenerator.ECCLevel.Q);
            //    QRCode qRCode = new QRCode(qRCodeData);
            //    Bitmap qRCodeImage = qRCode.GetGraphic(20);
            //    //QRCodeWriter.CreateQrCode("Welcome to HungHa", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium);
            //    //var MyQRWithLogo = QRCodeWriter.CreateQrCodeWithLogo(info, logo, 500);

            //    this.Dispatcher.Invoke(() =>
            //    {
            //        //QrCodeImage.ImageSource = BitmapToImageSource(MyQRWithLogo.ToBitmap());
            //        QrCodeImage.ImageSource = BitmapToImageSource(qRCodeImage);
            //    });
            //}
            //catch (Exception ex)
            //{

            //}
        }
    }
}