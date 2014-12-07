using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.Core.Components.Package;

namespace ETL.Core.Components.SourceComponent.SourceProviders {
    public class MemorySourceProvider : ISourceProvider {

        protected InMemorySource source = new InMemorySource();

        public virtual IDisposable EstablishConnection() {
            return source.Set();
        }

        public virtual IList<IPackageInputItem> Get() {
            return source.Get();
        }
    }

    public class InMemorySource : IDisposable {

        private IList<IPackageInputItem> source;

        public InMemorySource Set() {
            source = new List<IPackageInputItem>();
            return this;
        }

        public IList<IPackageInputItem> Get() {
            return this.source;
        }

        public void Dispose() {
            source = null;
        }
    }
}
