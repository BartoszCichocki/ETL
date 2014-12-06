using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.Core.Components.Storage;
using ETL.Core.Components.StorageProvider;

namespace ETL.Core.Components.Package {
    public abstract class Package : IPackage {
        public abstract IList<IPackageInputItem> Extract(IStorageProvider provider);

        public abstract IStorageProvider GetInputStorageProvider();

        public abstract IStorageProvider GetOutputStorageProvider();

        public abstract void Load(IList<IPackageOutputItem> elements);

        public abstract IPackageOutputItem Transform(IPackageInputItem element);
    }
}
