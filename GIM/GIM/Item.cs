using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIM {
    class Item {
        public int ID { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string alias { get; set; }
        public string description { get; set; }
        public double quantity { get; set; }
        public string unitOfMeasure { get; set; }
        public double price { get; set; }
        public double extension { get; set; }
        public string status { get; set; }
        //some date comes here
        public bool active { get; set; }

    }
}
