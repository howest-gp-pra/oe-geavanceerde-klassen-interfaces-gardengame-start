﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden.Lib.Interfaces
{
    public interface IGardenItem
    {
        string ShowCompactInfo();
        string ShowFullInfo();
    }
}
