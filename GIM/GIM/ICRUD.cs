using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIM {
    interface ICRUD {
        int getID(string name);
        void add(Object T);
        Object find(int id);
        Object[] findAll();
        DataTable loadData();
        Object delete(int id);
        Object update(int id, object T);
    }
}
