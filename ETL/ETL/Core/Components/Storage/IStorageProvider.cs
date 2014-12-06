using ETL.Core.Components.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core.Components.StorageProvider {
    public interface IStorageProvider {
        
        IList<T> Get<T>() where T :class ;

        void Put<T>(IList<T> items);
    }
}
