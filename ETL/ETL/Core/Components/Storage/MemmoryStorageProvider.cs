using ETL.Core.Components.StorageProvider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core.Components.Storage {
    public class MemmoryStorageProvider : IStorageProvider {

        //private IEnumerable storage;

        public void Put<T>(IList<T> items) {
            throw new NotImplementedException();
        }

        public IList<T> Get<T>() where T : class {
            throw new NotImplementedException();
        }
    }
}
