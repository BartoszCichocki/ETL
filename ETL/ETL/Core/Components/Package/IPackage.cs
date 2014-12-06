using ETL.Core.Components.StorageProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core.Components.Package {
    public interface IPackage : 
        IExtract,
        ITransform,
        ILoad
    {
        IStorageProvider GetInputStorageProvider();

        IStorageProvider GetOutputStorageProvider();
    }
}
