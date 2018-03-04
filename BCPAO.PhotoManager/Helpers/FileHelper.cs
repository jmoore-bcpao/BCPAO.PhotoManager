using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace BCPAO.PhotoManager.Helpers
{
	public static class FileHelper
	{
		public static byte[] ConvertToBytes(IFormFile file)
		{
			var stream = file.OpenReadStream();
			using (var ms = new MemoryStream())
			{
				stream.CopyTo(ms);
				return ms.ToArray();
			}
		}

		public static string GetContentType(string path)
		{
			var types = GetMimeTypes();
			var ext = Path.GetExtension(path).ToLowerInvariant();
			return types[ext];
		}

		private static Dictionary<string, string> GetMimeTypes()
		{
			return new Dictionary<string, string>
			{
				{".txt", "text/plain"},
				{".pdf", "application/pdf"},
				{".doc", "application/vnd.ms-word"},
				{".docx", "application/vnd.ms-word"},
				{".xls", "application/vnd.ms-excel"},
				{".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
				{".png", "image/png"},
				{".jpg", "image/jpeg"},
				{".jpeg", "image/jpeg"},
				{".gif", "image/gif"},
				{".csv", "text/csv"}
			};
		}
	}
}
