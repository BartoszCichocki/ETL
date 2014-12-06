using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core.Components.Storage {
    public class MemmoryStorage : IStorage {

        private IEnumerable storage;

        public void Save<T>(IList<T> elements) where T : class {
            storage = elements.AsEnumerable();
        }
    }
}
