using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebAPI3.Models
{
    public class DenemeModel : IEntity
    {


        public DenemeModel(int ID, string Name, string Detail, int NumberStock) {
            this.ID = ID;
            this.Name = Name;
            this.Detail = Detail;
            this.NumberStock = NumberStock;
        }

        public DenemeModel() { }
        public int ID { get;  set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int NumberStock { get; set; }

        public int getID()
        {
            return ID;
        }

 
    }
}