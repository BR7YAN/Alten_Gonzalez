﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Alten_Gonzalez.Models
{
    public partial class ProdottiCarrello
    {
        public int Id { get; set; }
        public int IdCarrello { get; set; }
        public int IdProdotto { get; set; }
        public int Quantità { get; set; }

        public virtual Carrelli IdCarrelloNavigation { get; set; }
        public virtual Prodotti IdProdottoNavigation { get; set; }
    }
}