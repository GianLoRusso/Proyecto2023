﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    internal interface IEntityAdapter<T> where T : class, new()
    {
        T Adapt(object[] values);
    }
}
