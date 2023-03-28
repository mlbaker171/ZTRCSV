using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using ZTWebShared.DataModels;


namespace CSVPlot
{
    public class BremboDiskDBTransaction
    {
    
        [BsonId]
        public ObjectId id { get; set; }

        public string Tool { get; set; }
        public string WorkOrderID { get; set; } = "UNDEFINED";
        public DateTime DateTimeStamp { get; set; }
        public string ReportPath { get; set; }
        public string Operator { get; set; }
        public string PartID { get; set; }

        public double Temperature_C1_CASE { get; set; }
        public double Temperature_C1_CMOS { get; set; }
        public double Temperature_C1_PROC { get; set; }

        public double Temperature_C2_CASE { get; set; }
        public double Temperature_C2_CMOS { get; set; }
        public double Temperature_C2_PROC { get; set; }

        public double Temperature_C3_CASE { get; set; }
        public double Temperature_C3_CMOS { get; set; }
        public double Temperature_C3_PROC { get; set; }

        public double Temperature_C4_CASE { get; set; }
        public double Temperature_C4_CMOS { get; set; }
        public double Temperature_C4_PROC { get; set; }

        public double Temperature_C5_CASE { get; set; }
        public double Temperature_C5_CMOS { get; set; }
        public double Temperature_C5_PROC { get; set; }

        public double Temperature_C6_CASE { get; set; }
        public double Temperature_C6_CMOS { get; set; }
        public double Temperature_C6_PROC { get; set; }

        public List<ZTWebShared.DataModels.CorysGeometricCharacteristic> CharacteristicList = new List<CorysGeometricCharacteristic>();

        #region CONSTRUCTOR

        public BremboDiskDBTransaction() { }
        public BremboDiskDBTransaction(CSVBremboDisk bDisk)
        {
            //BASIC HEADER
            DateTimeStamp = bDisk.DateTimeStamp;
            Tool = bDisk.ToolID;
            WorkOrderID = bDisk.WorkOrderID;
            Operator = bDisk.Operator;
            PartID = bDisk.PartID;
            ReportPath = bDisk.ReportPath;

            //SENSOR TEMP
            Temperature_C1_CASE = bDisk.Temperature_C1_CASE;
            Temperature_C1_CMOS = bDisk.Temperature_C1_CMOS;
            Temperature_C1_PROC = bDisk.Temperature_C1_PROC;
            Temperature_C2_CASE = bDisk.Temperature_C2_CASE;
            Temperature_C2_CMOS = bDisk.Temperature_C2_CMOS;
            Temperature_C2_PROC = bDisk.Temperature_C2_PROC;
            Temperature_C3_CASE = bDisk.Temperature_C3_CASE;
            Temperature_C3_CMOS = bDisk.Temperature_C3_CMOS;
            Temperature_C3_PROC = bDisk.Temperature_C3_PROC;
            Temperature_C4_CASE = bDisk.Temperature_C4_CASE;
            Temperature_C4_CMOS = bDisk.Temperature_C4_CMOS;
            Temperature_C4_PROC = bDisk.Temperature_C4_PROC;
            Temperature_C5_CASE = bDisk.Temperature_C5_CASE;
            Temperature_C5_CMOS = bDisk.Temperature_C5_CMOS;
            Temperature_C5_PROC = bDisk.Temperature_C5_PROC;
            Temperature_C6_CASE = bDisk.Temperature_C6_CASE;
            Temperature_C6_CMOS = bDisk.Temperature_C6_CMOS;
            Temperature_C6_PROC = bDisk.Temperature_C6_PROC;

            //GD&T CHARACTERISTICS
            CharacteristicList.Add(new CorysGeometricCharacteristic("F Diam.",      "1_0",  "Diam",     "0",  "", "",  0.025,  0.025,   70.120,     bDisk.FDiam));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M2_D_C_D",     "2_0",  "Unknown",  "1",  "", "",  0.25,   0.25,    7.5000,     bDisk.M2_D_C_D));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M3_A_C_D",     "3_0",  "Unknown",  "2",  "", "",  0.25,   0.25,    35.6500,    bDisk.M3_A_C_D));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M4_B_C_D",     "4_0",  "Unknown",  "3",  "", "",  0.25,   0.25,    60.6500,    bDisk.M4_B_C_D));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M5_A_D_D",     "5_0",  "Unknown",  "4",  "", "",  0.25,   0.25,    43.1500,    bDisk.M5_A_D_D));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M6_A_B_D",     "6_0",  "Unknown",  "5",  "", "",  0.25,   0.25,    25.0000,    bDisk.M6_A_B_D));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M11_D",        "11_0", "Unknown",  "6",  "", "",  0.04,   0.04,    0.0000,     bDisk.M11_D));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M14_C",        "14_0", "Unknown",  "7",  "", "",  0.025,  0.025,   0.0000,     bDisk.M14_C));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M15_D",        "15_0", "Unknown",  "8",  "", "",  0.025,  0.025,   0.0000,     bDisk.M15_D));
            CharacteristicList.Add(new CorysGeometricCharacteristic("CIR_M16_Diam", "16_0", "Diam",     "9",  "", "",  0.30,   0.30,    171.000,    bDisk.CIR_M16_Diam));
            CharacteristicList.Add(new CorysGeometricCharacteristic("CIR_M17_Diam", "17_0", "Diam",     "10", "", "",  0.30,   0.30,    159.000,    bDisk.CIR_M17_Diam));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M18_D",        "18_0", "Unknown",  "11", "", "",  0.30,   0.30,    6.0000,     bDisk.M18_D));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M29_A",        "29_0", "Unknown",  "12", "", "",  0.0125, 0.0125,  0.0000,     bDisk.M29_A));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M32_B",        "32_0", "Unknown",  "13", "", "", 0.0125, 0.0125, 0.0000,       bDisk.M32_B));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M39_A",        "39_0", "Unknown",  "14", "", "", 0.0125, 0.0125, 0.0000,       bDisk.M39_A));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M42_B",        "42_0", "Unknown",  "15", "", "", 0.0125, 0.0125, 0.0000,       bDisk.M42_B));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M43_A",        "43_0", "Unknown",  "16", "", "", 0.025, 0.025, 0.0000,         bDisk.M43_A));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M44_B",        "44_0", "Unknown",  "17", "", "", 0.025, 0.025, 0.0000,         bDisk.M44_B));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M47_DTV_V5",   "47_5", "Unknown",  "18", "", "", 0.005, 0.005, 0.0000,         bDisk.M47_DTV_V5));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M48_DTV_Radial_V2","48_2","Unknown","19","", "", 0.020, 0.020, 0.0000,         bDisk.M48_DTV_Radial_V2));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M52_1",        "51_1", "Unknown", "20", "", "", 0.050, 0.050, 0.0000,          bDisk.M52_1));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M52_2",        "52_2", "Unknown", "21", "", "", 0.050, 0.050, 0.0000,          bDisk.M52_2));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M52_3",        "52_3", "Unknown", "22", "", "", 0.050, 0.050, 0.0000,          bDisk.M52_3));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M52_4",        "52_4", "Unknown", "23", "", "", 0.050, 0.050, 0.0000,          bDisk.M52_4));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M52_5",        "52_5", "Unknown", "24", "", "", 0.050, 0.050, 0.0000,          bDisk.M52_5));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M53_1",        "53_1", "Unknown", "25", "", "", 0.050, 0.050, 0.0000,          bDisk.M53_1));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M53_2",        "53_2", "Unknown", "26", "", "", 0.050, 0.050, 0.0000,          bDisk.M53_2));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M53_3",        "53_3", "Unknown", "27", "", "", 0.050, 0.050, 0.0000,          bDisk.M53_3));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M53_4",        "53_4", "Unknown", "28", "", "", 0.050, 0.050, 0.0000,          bDisk.M53_4));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M53_5",        "53_5", "Unknown", "29", "", "", 0.050, 0.050, 0.0000,          bDisk.M53_5));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M54_1",        "54_1", "Unknown", "30", "", "", 0.25, 0.25, 16.5000,           bDisk.M54_1));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M54_2",        "54_2", "Unknown", "31", "", "", 0.25, 0.25, 16.5000,           bDisk.M54_2));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M54_3",        "54_3", "Unknown", "32", "", "", 0.25, 0.25, 16.5000,           bDisk.M54_3));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M54_4",        "54_4", "Unknown", "33", "", "", 0.25, 0.25, 16.5000,           bDisk.M54_4));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M54_5",        "54_5", "Unknown", "34", "", "", 0.25, 0.25, 16.5000,           bDisk.M54_5));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M55_1",        "55_1", "Unknown", "35", "", "", 0.25, 0.25, 6.50000,           bDisk.M55_1));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M55_2",        "55_2", "Unknown", "36", "", "", 0.25, 0.25, 6.50000,           bDisk.M55_2));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M55_3",        "55_3", "Unknown", "37", "", "", 0.25, 0.25, 6.50000,           bDisk.M55_3));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M55_4",        "55_4", "Unknown", "38", "", "", 0.25, 0.25, 6.50000,           bDisk.M55_4));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M55_5",        "55_5", "Unknown", "39", "", "", 0.25, 0.25, 6.50000,           bDisk.M55_5));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M56",          "56_0", "Unknown", "40", "", "", 0.20, 0.20, 320.000,           bDisk.M56));
            CharacteristicList.Add(new CorysGeometricCharacteristic("M57",          "57_0", "Unknown", "41", "", "", 0.5, 0.5, 8.0000,              bDisk.M57));
            CharacteristicList.Add(new CorysGeometricCharacteristic("Alignement_TX","999_1","Unknown", "42", "", "", 0.5, 0.5, 1.0000,              bDisk.Alignement_TX));
            CharacteristicList.Add(new CorysGeometricCharacteristic("Alignement_TY","999_2","Unknown", "43", "", "", 0.5, 0.5, 1.0000,              bDisk.Alignement_TY));
            CharacteristicList.Add(new CorysGeometricCharacteristic("Alignement_TZ","999_3","Unknown", "44", "", "", 0.5, 0.5, 1.0000,              bDisk.Alignement_TZ));
            CharacteristicList.Add(new CorysGeometricCharacteristic("Alignement_RX","999_4","Unknown", "45", "", "", 0.5, 0.5, 1.0000,              bDisk.Alignement_RX));
            CharacteristicList.Add(new CorysGeometricCharacteristic("Alignement_RY","999_5","Unknown", "46", "", "", 0.5, 0.5, 1.0000,              bDisk.Alignement_RY));
            CharacteristicList.Add(new CorysGeometricCharacteristic("Alignement_RZ","999_6", "Unknown", "47", "", "", 0.5, 0.5, 1.0000,             bDisk.Alignement_RZ));
        }
        
        #endregion
    }//CLASS
}//NAMESPAE
