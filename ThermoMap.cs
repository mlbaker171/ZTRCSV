using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace CSVPlot
{
    public class ThermoMap:ClassMap<ThermoData>
    {
        public ThermoMap() 
        {
            Map(m => m.TIMESTAMP).Name("TIMESTAMP");
            Map(m => m.UE_CMD_SP).Name("UE_CMD_SP");
            Map(m => m.UE_TEMP_SP).Name("UE_TEMP_SP");
            Map(m => m.UE_TEMP_ACT).Name("UE_TEMP_ACT");
            Map(m => m.UE_POWER_PERCENT).Name("UE_POWER_PERCENT");
        }

    }//CLASS
}//NAMESPACE
