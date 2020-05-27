using Garden.Lib.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden.Lib.Interfaces
{
    public interface IHarvestable
    {
        int HarvestSize { get; }
        Harvest GetHarvest();
    }
}
