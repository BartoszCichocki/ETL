using ETL.Core.Components.Package;
using ETL.Core.Components.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core.Components.StorageProvider {
    public interface IStorageProvider {
        IDisposable BeginTransaction();
        void CommitTransaction();
        void Save(IList<IPackageOutputItem> items);
    }
}
