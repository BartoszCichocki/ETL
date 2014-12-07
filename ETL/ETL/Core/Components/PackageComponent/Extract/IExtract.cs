﻿using ETL.Core.Components.SourceComponent;
using ETL.Core.Components.Storage;
using ETL.Core.Components.StorageProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core.Components.Package {
    public interface IExtract {
        IList<IPackageInputItem> Extract(ISourceProvider provider);
    }
}
