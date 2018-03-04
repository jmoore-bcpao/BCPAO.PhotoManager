using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace BCPAO.PhotoManager.Helpers
{
    public static class ImageHelper
    {
        public static string ConvertToBase64String(byte[] imageData)
        {
            return $"data:image/jpg;base64,{Convert.ToBase64String(imageData)}";
        }

        public static IHtmlContent Image(this IHtmlHelper html, byte[] imageData, string alt = null, int? width = null, int? height = null)
        {
            var tagBuilder = new TagBuilder("img");

            var src = string.Empty;

            if (imageData != null)
            {
                src = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(imageData));

                tagBuilder.MergeAttribute("src", src);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(src), src, "Must not be null or whitespace");
            }

            if (!string.IsNullOrWhiteSpace(alt))
            {
                tagBuilder.MergeAttribute("alt", alt);
            }

            if (!string.IsNullOrWhiteSpace(width.ToString()))
            {
                tagBuilder.MergeAttribute("width", width.ToString());
            }

            if (!string.IsNullOrWhiteSpace(height.ToString()))
            {
                tagBuilder.MergeAttribute("height", height.ToString());
            }

            tagBuilder.TagRenderMode = TagRenderMode.SelfClosing;

            return tagBuilder;
        }

        //public static IHtmlContent Image(this HtmlHelper helper, string src, string alt = null, string height = null)
        //{
        //    var tagBuilder = new TagBuilder("img");

        //    if (!string.IsNullOrWhiteSpace(src))
        //    {
        //        tagBuilder.MergeAttribute("src", src);
        //    }
        //    else
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(src), src, "Must not be null or whitespace");
        //    }

        //    if (!string.IsNullOrWhiteSpace(alt))
        //    {
        //        tagBuilder.MergeAttribute("alt", alt);
        //    }

        //    if (!string.IsNullOrWhiteSpace(height))
        //    {
        //        tagBuilder.MergeAttribute("height", height);
        //    }

        //    tagBuilder.TagRenderMode = TagRenderMode.SelfClosing;

        //    return tagBuilder;
        //}

        //        // To convert from base 64 string to Image
        //        public static Image Base64ToImage(string base64String)
        //        {
        //            // Convert base 64 string to byte[]
        //            byte[] imageBytes = Convert.FromBase64String(base64String);

        //            // Convert byte[] to Image
        //            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
        //            {
        //                var image = Image.FromStream(ms, true);
        //                return image;
        //            }
        //        }

        //        // To convert from Image to base 64 string
        //        public static string ImageToBase64(Image image, ImageFormat format)
        //        {
        //            using (MemoryStream ms = new MemoryStream())
        //            {
        //                // Convert Image to byte[]
        //                image.Save(ms, format);
        //                byte[] imageBytes = ms.ToArray();

        //                // Convert byte[] to base 64 string
        //                string base64String = Convert.ToBase64String(imageBytes);
        //                return base64String;
        //            }
        //        }

        //        /// <summary>
        //        /// Gets the name of the encoding.
        //        /// </summary>
        //        /// <param name="image">The image.</param>
        //        /// <returns></returns>
        //        /// <exception cref="System.ArgumentNullException">image</exception>
        //        /// <exception cref="System.NotSupportedException"></exception>
        //        public static string GetEncodingName(this Image image)
        //        {
        //            if (image == null)
        //                throw new ArgumentNullException("image");

        //            Guid formatGuid = image.RawFormat.Guid;

        //            if (formatGuid.Equals(ImageFormat.Bmp.Guid))
        //                return "Bmp";
        //            if (formatGuid.Equals(ImageFormat.Emf.Guid))
        //                return "Emf";
        //            if (formatGuid.Equals(ImageFormat.Exif.Guid))
        //                return "Exif";
        //            if (formatGuid.Equals(ImageFormat.Gif.Guid))
        //                return "Gif";
        //            if (formatGuid.Equals(ImageFormat.Icon.Guid))
        //                return "Icon";
        //            if (formatGuid.Equals(ImageFormat.Jpeg.Guid))
        //                return "Jpeg";
        //            if (formatGuid.Equals(ImageFormat.MemoryBmp.Guid))
        //                return "Bmp";
        //            if (formatGuid.Equals(ImageFormat.Png.Guid))
        //                return "Png";
        //            if (formatGuid.Equals(ImageFormat.Tiff.Guid))
        //                return "Tiff";
        //            if (formatGuid.Equals(ImageFormat.Wmf.Guid))
        //                return "Wmf";

        //            throw new NotSupportedException(
        //                string.Format(
        //                    "Image format [{0}] is not supported",
        //                    formatGuid));
        //        }

        //        /// <summary>
        //        /// Gets the image bytes.
        //        /// </summary>
        //        /// <param name="image">The image.</param>
        //        /// <returns></returns>
        //        /// <exception cref="System.ArgumentNullException">image</exception>
        //        public static byte[] GetImageBytes(this Image image)
        //        {
        //            if (image == null)
        //                throw new ArgumentNullException("image");

        //            return GetImageBytes(image, image.RawFormat);
        //        }

        //        /// <summary>
        //        /// Gets the image bytes.
        //        /// </summary>
        //        /// <param name="image">The image.</param>
        //        /// <param name="imageFormat">The image format.</param>
        //        /// <returns></returns>
        //        /// <remarks>This method is used in case the specified <c>image</c> does not have an encoding.</remarks>
        //        public static byte[] GetImageBytes(Image image, ImageFormat imageFormat)
        //        {
        //            using (MemoryStream stream = new MemoryStream())
        //            {
        //                image.Save(stream, imageFormat);
        //                return stream.ToArray();
        //            }
        //        }

        //        /// <summary>
        //        /// Gets the image from image bytes.
        //        /// </summary>
        //        /// <param name="imageData">The image bytes.</param>
        //        /// <returns></returns>
        //        /// <exception cref="System.ArgumentNullException">imageData</exception>
        //        public static Image GetImage(byte[] imageData)
        //        {
        //            if (imageData == null)
        //                throw new ArgumentNullException("imageData");

        //            using (MemoryStream stream = new MemoryStream(imageData))
        //            {
        //                return Image.FromStream(stream);
        //            }
        //        }

        //        /// <summary>
        //        /// Gets the image from the specified URL.
        //        /// </summary>
        //        /// <param name="imageUrl">The image URL.</param>
        //        /// <returns></returns>
        //        public static Image GetRemoteImage(string imageUrl)
        //        {
        //            byte[] imageBytes = null;
        //            using (WebClient webClient = new WebClient())
        //            {
        //                imageBytes = webClient.DownloadData(imageUrl);
        //            }
        //            return GetImage(imageBytes);
        //        }

        //        /// <summary>
        //        /// Gets the resized image with the specified width.
        //        /// </summary>
        //        /// <param name="originalImage">The original image.</param>
        //        /// <param name="resizedWidth">Width of the resized image.</param>
        //        /// <returns></returns>
        //        /// <exception cref="System.ArgumentNullException">originalImage</exception>
        //        /// <exception cref="System.ArgumentException"></exception>
        //        public static Bitmap GetResizedImage(Image originalImage, float resizedWidth)
        //        {
        //            if (originalImage == null)
        //                throw new ArgumentNullException("originalImage");

        //            if (resizedWidth > originalImage.Width)
        //                throw new ArgumentException(
        //                    string.Format(
        //                        "The specified resized width is longer than the width of specified image [{0}px].",
        //                        originalImage.Width));

        //            int originalWidth = originalImage.Width;
        //            int originalHeight = originalImage.Height;
        //            int resizedHeight = (int)(((float)originalHeight / originalWidth) * resizedWidth);
        //            return new Bitmap(originalImage, new Size((int)resizedWidth, resizedHeight));
        //        }

        //        /// <summary>
        //        /// Gets the resized image.
        //        /// </summary>
        //        /// <param name="imageData">The image data.</param>
        //        /// <param name="width">The width.</param>
        //        /// <param name="height">The height.</param>
        //        /// <returns></returns>
        //        /// <exception cref="System.InvalidOperationException">Either width or height must be specified.</exception>
        //        public static byte[] GetResizedImage(byte[] imageData, int? width, int? height)
        //        {
        //            if (!width.HasValue && !height.HasValue)
        //                throw new InvalidOperationException("Either width or height must be specified.");

        //            using (Image image = GetImage(imageData))
        //            {
        //                Size resizedSize = GetImageSize(image.Width, image.Height, width, height);
        //                Bitmap bitmap = new Bitmap(image, resizedSize);
        //                using (Graphics graphic = Graphics.FromImage(bitmap))
        //                {
        //                    graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //                    graphic.DrawImage(image, 0, 0, resizedSize.Width, resizedSize.Height);
        //                }
        //                return GetImageBytes(bitmap, image.RawFormat);
        //            }
        //        }

        //        #region helper methods
        //        /// <summary>
        //        /// Gets the size of the resized image. 
        //        /// Note that, in case of width or height is not given,
        //        /// this method returns a size according to the original aspect ratio.
        //        /// </summary>
        //        /// <param name="orignalWidth">Width of the orignal.</param>
        //        /// <param name="originalHeight">Height of the original.</param>
        //        /// <param name="width">The new width.</param>
        //        /// <param name="height">The new height.</param>
        //        /// <returns></returns>
        //        /// <exception cref="System.ApplicationException">Both width and height were not specified.</exception>
        //        private static Size GetImageSize(int orignalWidth, int originalHeight, int? width, int? height)
        //        {
        //            if (!width.HasValue && !height.HasValue)
        //                throw new ApplicationException("Both width and height were not specified.");

        //            if (width.HasValue && height.HasValue)
        //                return new Size(width.Value, height.Value);

        //            if (!height.HasValue)
        //            {
        //                double percentage = ((double)width.Value) / ((double)orignalWidth);
        //                int resizedHeight = (int)(((double)originalHeight) * percentage);
        //                return new Size(width.Value, resizedHeight);
        //            }
        //            else
        //            {
        //                double percentage = ((double)height.Value) / ((double)originalHeight);
        //                int resizedWidth = (int)(((double)orignalWidth) * percentage);
        //                return new Size(resizedWidth, height.Value);
        //            }
        //        }
        //        #endregion
    }
}