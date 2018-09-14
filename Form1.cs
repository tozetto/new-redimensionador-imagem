using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace NewRedimensionadorImagem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRedimensionar_Click(object sender, EventArgs e)
        {
            //Teste commit push
            if ((!(ckbSubstituirArquivos.Checked)) && (txtPastaDestino.Text == "")) {
                MessageBox.Show("Se não for substituir informe a pasta destino");
            }
            Image img;
            string pasta = txtPastaOrigem.Text;
            //string pastaNova = @"D:\Projetos\NewRedimensionadorImagem\Convertido";
            string pastaNova = txtPastaDestino.Text;
            if (!(ckbSubstituirArquivos.Checked) && (!(Directory.Exists(pastaNova))))
                Directory.CreateDirectory(pastaNova);
            if (Directory.Exists(pasta))
            {
                string[] fileEntries;                
                if (ckbIncluirSubPasta.Checked)
                    fileEntries = Directory.GetFiles(pasta, "*.*", System.IO.SearchOption.AllDirectories);
                else
                    fileEntries = Directory.GetFiles(pasta);
                foreach (string fileName in fileEntries)
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    string tempFile = Path.GetTempFileName();
                    File.Copy(fileName, tempFile, true);
                    img = Image.FromFile(tempFile);
                    if (ckbSubstituirArquivos.Checked)
                        SalvarImagemRedimensionada(img, fileName);
                    else
                        SalvarImagemRedimensionada(img, pastaNova + @"\" + Path.GetFileName(fileName));
                    img.Dispose();
                    File.Delete(tempFile);
                }
            }
            MessageBox.Show("Feito!");
        }

        public static void SalvarImagemRedimensionada(Image img, string path)
        {            
            Image imgAux;
            int percentSize = 0;
            if ((img.Size.Width > 600) || (img.Size.Height > 600))
            {
                if (img.Size.Width > img.Size.Height) //paisagem            
                    percentSize = Convert.ToInt32((600 * 100) / img.Size.Width);
                else
                    percentSize = Convert.ToInt32((600 * 100) / img.Size.Height);
                imgAux = ScaleByPercent(img, percentSize); //tamanho em %
                imgAux.Save(path);
            }
            else
            {
                img.Save(path);
                imgAux = img;
            }
            FileInfo fileInfo = new FileInfo(path);
            long fileLen = fileInfo.Length;
            int percent = 100;
            if (fileLen >= 500000)
                percent = 70;
            if ((fileLen < 500000) && (fileLen >= 300000))
                percent = 75;
            if ((fileLen < 300000) && (fileLen >= 100000))
                percent = 80;
            if (fileLen < 100000)
                percent = 85;
            SaveJpeg(path, imgAux, percent);
            imgAux.Dispose();
        }

        public static void SaveJpeg(string path, Image img, int quality)
        {
            // Encoder parameter for image quality 
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            // JPEG image codec 
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;            
            img.Save(path, jpegCodec, encoderParams);
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }

        static Image ScaleByPercent(Image imgPhoto, int Percent)
        {
            float nPercent = ((float)Percent / 100);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight,
                                     PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                                    imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            var attributes = new ImageAttributes();
            attributes.SetWrapMode(WrapMode.TileFlipXY);

            var destination = new Rectangle(0, 0, destWidth, destHeight);
            grPhoto.DrawImage(imgPhoto, destination, 0, 0, sourceWidth, sourceHeight, GraphicsUnit.Pixel, attributes);

            grPhoto.Dispose();
            return bmPhoto;
        }

        private void ckbSubstituirArquivos_CheckedChanged(object sender, EventArgs e)
        {
            txtPastaDestino.Enabled = !(ckbSubstituirArquivos.Checked);
        }


        /*NOVAS FUNCOES*/

        private void SaveTemporary(Bitmap bmp, MemoryStream ms, int quality, string sourcePath)
        {
            EncoderParameter qualityParam = new EncoderParameter
                (System.Drawing.Imaging.Encoder.Quality, quality);
            var codec = GetImageCodecInfo(sourcePath);            
            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            bmp.Save(ms, codec, encoderParams);
        }

        private void SaveTemporary(Bitmap bmp, MemoryStream ms, int quality)
        {
            EncoderParameter qualityParam = new EncoderParameter
                (System.Drawing.Imaging.Encoder.Quality, quality);            
            ImageCodecInfo codec = GetEncoderInfo("image/jpeg");
            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            bmp.Save(ms, codec, encoderParams);
        }


        public Bitmap ScaleImage(Bitmap image, double scale)
        {
            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);

            Bitmap result = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
            result.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                g.DrawImage(image, 0, 0, result.Width, result.Height);
            }
            return result;
        }

        public void ScaleImage(string sourcePath, string destinationPath, int allowedFileSizeInByte, short quality)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(sourcePath, FileMode.Open))
                {
                    Bitmap bmp = (Bitmap)Image.FromStream(fs);
                    SaveTemporary(bmp, ms, quality, sourcePath);

                    while (ms.Length > allowedFileSizeInByte)
                    {
                        double scale = Math.Sqrt((double)allowedFileSizeInByte / (double)ms.Length);
                        ms.SetLength(0);
                        bmp = ScaleImage(bmp, scale);
                        SaveTemporary(bmp, ms, quality, sourcePath);
                    }
                    if (bmp != null)
                        bmp.Dispose();
                    if (sourcePath == destinationPath)
                    {
                        fs.Dispose();
                        File.Delete(sourcePath);
                    }
                    SaveImageToFile(ms, destinationPath);
                }
            }
        }

        public void ScaleImage(Image image, string destinationPath, int allowedFileSizeInByte, short quality)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                
                    Bitmap bmp = new Bitmap(image);
                    SaveTemporary(bmp, ms, quality);

                    while (ms.Length > allowedFileSizeInByte)
                    {
                        double scale = Math.Sqrt((double)allowedFileSizeInByte / (double)ms.Length);
                        ms.SetLength(0);
                        bmp = ScaleImage(bmp, scale);
                        SaveTemporary(bmp, ms, quality);
                    }

                    if (bmp != null)
                        bmp.Dispose();                    

                    SaveImageToFile(ms, destinationPath);
                
            }
        }


        private void SaveImageToFile(MemoryStream ms, string destinationPath)
        {
            byte[] data = ms.ToArray();

            using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
            {
                fs.Write(data, 0, data.Length);
            }
        }


        private ImageCodecInfo GetImageCodecInfo(string sourcePath)
        {
            FileInfo fi = new FileInfo(sourcePath);

            switch (fi.Extension)
            {
                case ".bmp": return ImageCodecInfo.GetImageEncoders()[0];
                case ".jpg":
                case ".jpeg": return ImageCodecInfo.GetImageEncoders()[1];
                case ".gif": return ImageCodecInfo.GetImageEncoders()[2];
                case ".tiff": return ImageCodecInfo.GetImageEncoders()[3];
                case ".png": return ImageCodecInfo.GetImageEncoders()[4];
                default: return null;
            }
        }
        
    }
}
