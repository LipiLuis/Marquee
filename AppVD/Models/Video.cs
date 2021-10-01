using System;
using System.Collections.Generic;
using System.Text;

namespace AppVD.Models
{
    public class Video
    {
        public Video()
        {

        }
        public int Codigo { get; set; }
        public string url { get; set; }

        public Video(int codigo, string url)
        {
            Codigo = codigo;
            this.url = url;
        }
    }
}
