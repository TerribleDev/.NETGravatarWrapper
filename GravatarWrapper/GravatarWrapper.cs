using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using RestSharp;
using System.Drawing;
using System.IO;

namespace GravatarWrapper
{
    public static class GravatarWrapper
    {
        private static string HashEmailForGravatar(string email)
        {
            email = email.ToLower();
            //MD
            var md5Hasher = MD5.Create();

           var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(email));
 
            var sBuilder = new StringBuilder();

            foreach (var x in data)
            {
                sBuilder.Append(x.ToString("x2"));
            }

            return sBuilder.ToString();  // Return the hexadecimal string. 
        }

        public static Bitmap Request(string email, int size)
        {
            var client = new RestClient("http://www.gravatar.com/avatar/" + HashEmailForGravatar(email));
            var req = new RestRequest(Method.GET);
            req.AddParameter("d", "%22%22" );
            req.AddParameter("s", size);
            var res = client.Execute(req);
            if (res != null)
            {
                var imagebytes = res.RawBytes;
                var ms = new MemoryStream(imagebytes);
                return new Bitmap(ms);
                //img.Save(@"c:\bmp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return null;
        }
    }
}
