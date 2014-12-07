using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.Core.Components.SourceComponent;
using ETL.Core.Components.Storage;
using ETL.Core.Components.StorageProvider;

namespace ETL.Core.Components.Package {
    public abstract class Package : IPackage {

        public abstract ISourceProvider GetSourceProvider();

        public abstract IStorageProvider GetStorageProvider();

        public abstract IList<IPackageInputItem> Extract(ISourceProvider provider);

        public abstract IPackageOutputItem Transform(IPackageInputItem element);

        public abstract void Load(IStorageProvider provider, IList<IPackageOutputItem> elements);
    }
}
