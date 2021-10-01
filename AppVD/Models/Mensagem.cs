using System;
using System.Collections.Generic;
using System.Text;

namespace AppVD.Models
{
  public  class Mensagem
    {
        public Mensagem()
        {

        }
        public int Codigo { get; set; }
        public string Msg { get; set; }

        public Mensagem(int codigo, string msg)
        {
            Codigo = codigo;
            Msg = msg;
        }
    }
}
