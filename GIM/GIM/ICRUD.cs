using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIM {
    interface ICRUD {
        void add(Object T);
        Object find(int id);
        Object[] findAll();
        Object delete(int id);
        Object update(int id, object T);
    }
}
