﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core.Components.Package {
    public interface ITransform {
        Td Transform<Ts, Td>(Ts element);
    }
}