using ETL.Core.Components.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core.Components.Package {
    public interface ILoad {
        void Load(IList<IPackageOutputItem> elements);
    }
}
