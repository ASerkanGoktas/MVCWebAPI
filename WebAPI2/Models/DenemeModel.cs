﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI2.Models
{
    public class DenemeModel : IEntity
    {


        public DenemeModel(int ID, string Name, string Detail) {
            this.ID = ID;
            this.Name = Name;
            this.Detail = Detail;
        }

        public DenemeModel() { }
        public int ID { private get;  set; }
        public string Name { get; set; }
        public string Detail { get; set; }

        public int getID()
        {
            return ID;
        }
    }
}