using LojaVirtual.Domain.Entities.Base;
using LojaVirtual.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Entities
{
    public class Banner : EntityBase
    {
        public Banner(string title, string image, string url, int pos, int x, int y, EBannerLocal local)
        {
            Title = title;
            Image = image;
            Url = url;
            Pos = pos;
            X = x;
            Y = y;
            UserCreate = null;
            Local = local;
        }

        public string Title { get; private set; }
        public string Image { get; private set; }
        public string Url { get; private set; }
        public int Pos { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public User UserCreate { get; private set; }
        public EBannerLocal Local { get; private set; }
    }
}
