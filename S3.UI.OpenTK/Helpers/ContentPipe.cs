using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using S3.Framework.Entities;
using S3.UI.OpenTK.Models;
using SystemPixelFormat = System.Drawing.Imaging.PixelFormat;
using OpenTkPixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;


namespace S3.UI.OpenTK.Helpers
{
    public class ContentPipe
    {
        public static TextureMaterial2D LoadTexture(Material material)
        {
            var filePath = material.FilePath;

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found at " + filePath + ".");
            }

            var materialName = material.Name;

            var bmp = new Bitmap(filePath);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly, SystemPixelFormat.Format32bppArgb);

            var textureId = GL.GenTexture();

            GL.BindTexture(TextureTarget.Texture2D, textureId);

            GL.TexImage2D(
                TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                bmp.Width,
                bmp.Height,
                0,
                OpenTkPixelFormat.Bgra,
                PixelType.UnsignedByte,
                data.Scan0);

            bmp.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            return new TextureMaterial2D(textureId, materialName, bmp.Width, bmp.Height);
        }


    }
}
