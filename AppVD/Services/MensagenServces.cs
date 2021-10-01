using AppVD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppVD.Services
{
    public class MensagenServces
    {
        public ObservableCollection<Mensagem> GetAllMsg()
        {
            return new ObservableCollection<Mensagem>
           {
               new Mensagem(1,"Por favor leia toda a descrição com atenção antes de realizar sua compra. Leia também as políticas da loja, pois ao clicar em comprar, você está concordando com elas."),
               new Mensagem(2,"Uma linda recordação para os noivos guardarem as mensagens dos convidados de um dia tão inesquecível."),
               new Mensagem(3,"Contracapa personalizada com uma frase (pode ser personalizado com frase de preferência do cliente ou nome dos noivos, aniversariantes, etc)"),
               new Mensagem(4,"Na capa pode conter o nome dos noivos ou aniversariante (consultar vendedor sobre essa mudança no layout)"),
               new Mensagem(5,"Capa exterior e lombada feita em papelão rígido 2.2mm de espessura revestido em tecido 100% algodão, contracapa forrada em papel colorido de alta gramatura;"),
               new Mensagem(6,"Miolo costurado com cordão encerado utilizando a técnica de encadernação artesanal;"),
               new Mensagem(7,"Tamanho final 22x22cm - quadrado(pode ser feito em outras medidas menores).  50 Folhas papel offset 180g sem pauta"),
               new Mensagem(8,"Cor do miolo: branco (para outras cores ou papel Kraft, consultar o vendedor antes de efetuar a compra);")
           };

        }
    }
}
