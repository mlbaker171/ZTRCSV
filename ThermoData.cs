using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;

namespace CSVPlot
{
    public class ThermoData
    {
        //NOT PART OF THE ORIGINAL DATAFILE
        [BsonId]
        public ObjectId id { get; set; }

        [Name("TIMESTAMP")]
        public DateTime TIMESTAMP { get; set; } 

        [Name("UE_CMD_SP")]
        public double UE_CMD_SP { get; set; } = 0;

        [Name("UE_TEMP_SP")]
        public double UE_TEMP_SP { get; set; } = 0;

        [Name("UE_TEMP_ACT")]
        public double UE_TEMP_ACT { get; set; } = 0;

        [Name("UE_POWER_PERCENT")]
        public double UE_POWER_PERCENT { get; set; } = 0;

        public ThermoData() { }

        public ThermoData(DateTime tIMESTAMP, double uE_CMD_SP, double uE_TEMP_SP, double uE_TEMP_ACT, double uE_POWER_PERCENT)
        {
            TIMESTAMP = tIMESTAMP;
            UE_CMD_SP = uE_CMD_SP;
            UE_TEMP_SP = uE_TEMP_SP;
            UE_TEMP_ACT = uE_TEMP_ACT;
            UE_POWER_PERCENT = uE_POWER_PERCENT;
        }   
    }
}
