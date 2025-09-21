using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ZK.Domain.Utilities
{
    public class ImageHelper
    {
        public static byte[] ConvertToByteArray(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            byte[] imageData = [];

            using (var memoryStream = new System.IO.MemoryStream())
            {
                imageFile.CopyTo(memoryStream);

                imageData = memoryStream.ToArray();
            }

            return imageData;
        }
    }
}
