using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core.Components.Storage {
    public interface IStorage {
        void Save<T>(IList<T> elements) where T : class;
    }
}
