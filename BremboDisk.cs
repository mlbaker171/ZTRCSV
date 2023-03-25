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
    public class BremboDisk
    {
        //NOT PART OF THE ORIGINAL DATAFILE
        [BsonId]
        public ObjectId id { get; set; }

        [Name("Date")]
        public string Date { get; set; }

        //NOT PART OF THE ORIGINAL DATAFILE
        public string WorkOrderID { get; set; } = "UNDEFINED";

        //NOT PART OF THE ORIGINAL DATAFILE
        public DateTime DateTimeStamp{get;set;}

        [Name("reportPath")]
        public string ReportPath{ get; set; }

        [Name("Operator")]
        public string Operator { get; set; }

        [Name("Name")]
        public string Name { get; set; }

        [Name("PartID")]
        public string PartID { get; set; }

        [Name("F Diam.")]
        public double FDiam { get; set; }

        [Name("M2-D/C D")]
        public double M2_D_C_D { get; set; }

        [Name("M3-A/C D")]
        public double M3_A_C_D { get; set; }

        [Name("M4-B/C D")]
        public double M4_B_C_D { get; set; }

        [Name("M5-A/D D")]
        public double M5_A_D_D { get; set; }

        [Name("M6-A/B D")]
        public double M6_A_B_D
        { get; set; }

        [Name("M11-D Val.")]
        public double M11_D{ get; set; }

        [Name("M14-C Val.")]
        public double M14_C { get; set; }

        [Name("M15-D Val.")]
        public double M15_D { get; set; }

        [Name("CIR_M16 Diam.")]
        public double CIR_M16_Diam { get; set; }

        [Name("CIR_M17 Diam.")]
        public double CIR_M17_Diam { get; set; }

        [Name("M18 D")]
        public double M18_D { get; set; }

        [Name("M29-A Val.")]
        public double M29_A { get; set; }

        [Name("M32-B Val.")]
        public double M32_A{ get; set; }

        [Name("M39-A Val.")]
        public double M39_A { get; set; }

        [Name("M42-B Val.")]
        public double M42_B { get; set; }

        [Name("M43-A Val.")]
        public double M43_A { get; set; }

        [Name("M44-B Val.")]
        public double M44_B { get; set; }

        [Name("M47-DTV-v5 Val.")]
        public double M47_DTV_V5 { get; set; }

        [Name("M48-DTV-Radial-v2 Val.")]
        public double M48_DTV_Radial_V2{ get; set; }

        [Name("M52.1 Val.")]
        public double M52_1 { get; set; }

        [Name("M52.2 Val.")]
        public double M52_2 { get; set; }

        [Name("M52.3 Val.")]
        public double M52_3 { get; set; }

        [Name("M52.4 Val.")]
        public double M52_4 { get; set; }

        [Name("M52.5 Val.")]
        public double M52_5 { get; set; }

        [Name("M53.1 Val.")]
        public double M53_1 { get; set; }

        [Name("M53.2 Val.")]
        public double M53_2 { get; set; }

        [Name("M53.3 Val.")]
        public double M53_3 { get; set; }

        [Name("M53.4 Val.")]
        public double M53_4 { get; set; }

        [Name("M53.5 Val.")]
        public double M53_5 { get; set; }

        [Name("M54.1 Diam.")]
        public double M54_1 { get; set; }

        [Name("M54.2 Diam.")]
        public double M54_2 { get; set; }

        [Name("M54.3 Diam.")]
        public double M54_3 { get; set; }

        [Name("M54.4 Diam.")]
        public double M54_4 { get; set; }

        [Name("M54.5 Diam.")]
        public double M54_5 { get; set; }

        [Name("M55.1 Diam.")]
        public double M55_1 { get; set; }

        [Name("M55.2 Diam.")]
        public double M55_2 { get; set; }

        [Name("M55.3 Diam.")]
        public double M55_3 { get; set; }

        [Name("M55.4 Diam.")]
        public double M55_4 { get; set; }

        [Name("M55.5 Diam.")]
        public double M55_5{ get; set; }

        [Name("M56 Diam.")]
        public double M56{ get; set; }

        [Name("M57 Val.")]
        public double M57{ get; set; }

        [Name("Alignement Tx")]
        public double Alignement_TX { get; set; }

        [Name("Alignement Ty")]
        public double Alignement_TY { get; set; }

        [Name("Alignement Tz")]
        public double Alignement_TZ { get; set; }

        [Name("Alignement Rx")]
        public double Alignement_RX { get; set; }

        [Name("Alignement Ry")]
        public double Alignement_RY { get; set; }

        [Name("Alignement Rz")]
        public double Alignement_RZ { get; set; }

        [Name("temperature_c1_CASE")]
        public double Temperature_C1_CASE { get; set; }

        [Name("temperature_c1_CMOS")]
        public double Temperature_C1_CMOS { get; set; }

        [Name("temperature_c1_PROC")]
        public double Temperature_C1_PROC { get; set; }

        [Name("temperature_c2_CASE")]
        public double Temperature_C2_CASE { get; set; }

        [Name("temperature_c2_CMOS")]
        public double Temperature_C2_CMOS { get; set; }

        [Name("temperature_c2_PROC")]
        public double Temperature_C2_PROC { get; set; }

        [Name("temperature_c3_CASE")]
        public double Temperature_C3_CASE { get; set; }

        [Name("temperature_c3_CMOS")]
        public double Temperature_C3_CMOS { get; set; }

        [Name("temperature_c3_PROC")]
        public double Temperature_C3_PROC { get; set; }

        [Name("temperature_c4_CASE")]
        public double Temperature_C4_CASE { get; set; }

        [Name("temperature_c4_CMOS")]
        public double Temperature_C4_CMOS { get; set; }

        [Name("temperature_c4_PROC")]
        public double Temperature_C4_PROC{ get; set; }

        [Name("temperature_c5_CASE")]
        public double Temperature_C5_CASE { get; set; }

        [Name("temperature_c5_CMOS")]
        public double Temperature_C5_CMOS { get; set; }

        [Name("temperature_c5_PROC")]
        public double Temperature_C5_PROC{ get; set; }

        [Name("temperature_c6_CASE")]
        public double Temperature_C6_CASE { get; set; }

        [Name("temperature_c6_CMOS")]
        public double Temperature_C6_CMOS { get; set; }

        [Name("temperature_c6_PROC")]
        public double Temperature_C6_PROC { get; set; }

        public BremboDisk() { }

        
        public void ConvertTheCrazyFrenchTimeString()
        {
            DateTime retDateTime = new DateTime();  //WISH THIS COULD BE NULL

            //DATE STRING HAS TO HAVE THE FOLLOWING STRUCTURE
            //2023-03-21_11H21M57S817MS  - SPLIT THE HELL OUT OF IT STRING
            string[] mySplits = Date.Split('-','H','M','S');
            //SHOULD CONVERT TO THE FOLLOWING SPLITS[] {"2023", "03", "21", "11", "21", "57", "817"}
           
            if(mySplits.Length > 6 ) 
            {
                int nYear  =  int.Parse(mySplits[0]);
                int nMonth = int.Parse(mySplits[1]);
                int nDay   =   int.Parse(mySplits[2]);
                int nHour =  int.Parse(mySplits[3]);
                int nMin =   int.Parse(mySplits[4]);
                int nSec =   int.Parse(mySplits[5]);
                int nMsec =  int.Parse(mySplits[6]);

                retDateTime = new DateTime(nYear, nMonth, nDay, nHour, nMin, nSec, nMsec);
            }
            DateTimeStamp = retDateTime;
        }
    }//CLASS
}//NAMESPACE
