using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Globalization;
using System.Security.Policy;
using System.Text;
using ZTWebShared.Mongo;
using ZTWebShared.DataModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using MongoDB.Driver;
using System.Xml.Linq;

namespace CSVPlot
{
    public partial class Form1 : Form
    {
        public Color GREEN = System.Drawing.Color.Lime;
        public Color GRAY = System.Drawing.Color.Gray;
        public Color RED = System.Drawing.Color.Red;
        public const string COLON = ":";
        public const string SLASH = "/";
        public const string PERIOD = ".";
        public const string TERMINATOR = "\r\n";
        public const string CR = "\r";
        public const string LF = "\n";
        public const string COMMA = ",";
        public const char COMMA_CHAR = ',';
        public const string SPACE = " ";
        public const char SPACE_CHAR = ' ';
        public const string TAB = "\t ";
        const int MAX_LIST_VAL = 20;

        //MONGODB STUFF
        const string MONGO_CONNECTION_STRING = "mongodb://10.2.1.18:27017";
        public const string OPERATIONS_DATABASE_NAME = "Operations";
        public const string WORKORDER_COLLECTION_NAME = "WorkOrder";
        public const string BREMBO_DATABASE_NAME = "ZTR04_Brembo";
        public const string BREMBO_DISK_COLLECTION_NAME = "PartData";
        public const string THERMO_COLLECTION_NAME = "ThermoData";
       
        MongoDatabaseClient MyMongoClient = null;
        DateTime WorkOrder_Start;
        List<CSVBremboDisk> BremboDiskList;
        List<ThermoData> ThermoDataList;
        List<BremboDiskDBTransaction> BremboDiskDBTransactionList = new List<BremboDiskDBTransaction>();

        #region CONSTRUCTOR
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region SUPPORT FUNCTIONS

        public string GenerateTimeStamp()
        {
            string timeStamp;
            DateTime Now = DateTime.Now;
            timeStamp = Now.Year.ToString() + SLASH + Now.Month.ToString("D2") + SLASH + Now.Day.ToString("D2") + SPACE + SPACE;
            timeStamp += "[" + Now.Hour.ToString("D2") + COLON + Now.Minute.ToString("D2") + COLON + Now.Second.ToString("D2") + PERIOD;
            timeStamp += Now.Millisecond.ToString("D3") + "]" + SPACE + COLON + SPACE;
            return timeStamp;
        }

        public List<ThermoData> MakeFakeThermoData()
        {
            List<ThermoData> retList = new List<ThermoData>();

            retList.Add(new ThermoData(DateTime.Now, 20, 21, 19, -99));
            retList.Add(new ThermoData(DateTime.Now, 20, 21, 18, -50));
            retList.Add(new ThermoData(DateTime.Now, 20, 21, 19, 23));
            retList.Add(new ThermoData(DateTime.Now, 20, 21, 17, 45));
            retList.Add(new ThermoData(DateTime.Now, 20, 21, 19, 85));

            return retList;
        }

        private WorkOrderData BuildWorkOrder()
        {
            string szNotes = String.Empty;
            WorkOrderData myWorkOrder = new WorkOrderData();
            myWorkOrder.DateTimeIssued = DateTime.Now;
            myWorkOrder.DateTimeStarted = WorkOrder_Start;
            myWorkOrder.ToolID = cbox_ToolID.SelectedText;
            myWorkOrder.DateTimeDone = DateTime.Now;
            myWorkOrder.ID = txbx_WorkOrderID.Text;
            myWorkOrder.WOTypeString = "PERFORMANCE";
            myWorkOrder.Project = "BREMBO_1";
            myWorkOrder.SetState(WorkOrderData.STATE.COMPLETE);
            myWorkOrder.Notes = txbx_WorkOrderNotes.Text + "....Created by ZTR CSV Insertion App.";
            myWorkOrder.InspectionEntityList.Clear();

            return myWorkOrder;
        }

        #endregion

        #region MONGODB FUNCTIONS

        public void ConvertBremboCSVToTransactionsAndDelete()
        {
            BremboDiskDBTransactionList.Clear();
            AddToStatusDisplay("Converting Brembo CSV Entities to Mongo Data Transactions");
            foreach (CSVBremboDisk bremborecord in BremboDiskList)
            {
                BremboDiskDBTransactionList.Add(new BremboDiskDBTransaction(bremborecord));
            }

            AddToStatusDisplay("Converted [ " + BremboDiskDBTransactionList.Count.ToString() + " ] Brembo CSV Entities");
            BremboDiskList.Clear();
        }

        public bool ConnectToMongo(string databaseName)
        {
            MyMongoClient = new MongoDatabaseClient(MONGO_CONNECTION_STRING, databaseName);
            if (true == MyMongoClient.IsConnected())
            {
                AddToStatusDisplay("MONGO CLIENT CONNECTED: " + MyMongoClient.IPAddressString + " TRUE");
            }
            else
            {
                AddToStatusDisplay("MONGO CLIENT CONNECTED: " + MyMongoClient.IPAddressString + " FALSE");
            }
            return MyMongoClient.IsConnected();
        }

        public void SendToWorkOrderDatabase()
        {
            IMongoCollection<WorkOrderData> myCollection = null;

            bool isconnected = ConnectToMongo(OPERATIONS_DATABASE_NAME);
            if ((null != MyMongoClient) && (true == MyMongoClient.IsConnected()))
            {
                myCollection = MyMongoClient.GetDataBase.GetCollection<WorkOrderData>(WORKORDER_COLLECTION_NAME);  //Get the collection
                AddToStatusDisplay("Accessing Collection: " + myCollection.CollectionNamespace.ToString());
                WorkOrderData tempWO = BuildWorkOrder();
                myCollection.InsertOne(tempWO);

                AddToStatusDisplay("Inserted Into WorkOrder Collection: " + tempWO.ID + " [" + tempWO.Project + "]  DATABASE:" + MyMongoClient.GetDatabaseName + " COLLECTION:" + myCollection.CollectionNamespace);

            }
            else
            {
                AddToStatusDisplay("Not Connected to: " + OPERATIONS_DATABASE_NAME + "." + WORKORDER_COLLECTION_NAME);
            }
        }

        public void SendToMongoThermoData()
        {
            IMongoCollection<ThermoData> myCollection = null;

            foreach (ThermoData idata in ThermoDataList)
            {
                bool isconnected = ConnectToMongo(THERMO_COLLECTION_NAME);

                if ((null != MyMongoClient) && (true == MyMongoClient.IsConnected()))
                {
                    myCollection = MyMongoClient.GetDataBase.GetCollection<ThermoData>(THERMO_COLLECTION_NAME);  //Get the collection
                    AddToStatusDisplay("Accessing Collection: " + myCollection.CollectionNamespace.ToString());
                }

                myCollection.InsertOne(idata);
                AddToStatusDisplay("Inserted Into Collection: " + idata.ToString() + "]  DATABASE:" + MyMongoClient.GetDatabaseName + " COLLECTION:" + myCollection.CollectionNamespace);

            }
        }

        public void SendToMongoPartData()
        {
            bool isconnected = ConnectToMongo(BREMBO_DATABASE_NAME);
            IMongoCollection<BremboDiskDBTransaction> myCollection = null;
            int idx = 1;
            foreach (BremboDiskDBTransaction idata in BremboDiskDBTransactionList)
            {
                if ((null == myCollection) && (true == MyMongoClient.IsConnected()))
                {
                    myCollection = MyMongoClient.GetDataBase.GetCollection<BremboDiskDBTransaction>(BREMBO_DISK_COLLECTION_NAME);  //Get the collection
                    AddToStatusDisplay("In DATABASE: " + MyMongoClient.GetDatabaseName);
                    AddToStatusDisplay("Accessing COLLECTION: " + myCollection.CollectionNamespace.ToString());
                }

                myCollection.InsertOne(idata);

                idx++;
            }
           
            AddToStatusDisplay("Inserted [ " + idx.ToString() + " ] Entries ");
           
        }

        #endregion


        #region THREAD SAFE UI UPDATES

        public void AddToStatusDisplay(string szData)
        {
            //Log this data - dont care about the thread used for this next call
            // ServerLog.LogDataToTargets(szData);

            //Check to see of this is being called from a different thread
            if (this.InvokeRequired)
            {   //This is being called from a different thread so use beginInvoke
                //and the associated delelgate to have the main (UI) thread call it.
                this.BeginInvoke(new AddToStatusDisplayDelegate(AddToStatusDisplay), new object[] { szData });
                return;
            }
            else
            {
                //Only allow a certain number of entries to be displayed
                if (lbox_Status.Items.Count > MAX_LIST_VAL)
                {
                    lbox_Status.Items.RemoveAt(MAX_LIST_VAL);
                }
                this.lbox_Status.Items.Insert(0, GenerateTimeStamp() + szData);
            }
        }
        private delegate void AddToStatusDisplayDelegate(string szData);
        /////////////////////////////////////////////////////////////////

        public void ClearWorkOrderUI()
        {
            //Check to see of this is being called from a different thread
            if (this.InvokeRequired)
            {   //This is being called from a different thread so use beginInvoke
                //and the associated delelgate to have the main (UI) thread call it.
                this.BeginInvoke(new ClearWorkOrderUIDelegate(ClearWorkOrderUI), new object[] { });
                return;
            }
            else
            {
                txbx_WorkOrderNotes.Clear();
            }
        }
        private delegate void ClearWorkOrderUIDelegate();
        /////////////////////////////////////////////////////////////////

        public void InitializeToolIDUI(List<string> toolChoices)
        {
            //Check to see of this is being called from a different thread
            if (this.InvokeRequired)
            {   //This is being called from a different thread so use beginInvoke
                //and the associated delelgate to have the main (UI) thread call it.
                this.BeginInvoke(new InitializeToolIDUIDelegate(InitializeToolIDUI), new object[] { toolChoices });
                return;
            }
            else
            {
              foreach(string s in toolChoices) 
                {
                    cbox_ToolID.Items.Add(s);
                }
            }
        }
        private delegate void InitializeToolIDUIDelegate(List<string> toolChoices);
        /////////////////////////////////////////////////////////////////


        #endregion

        #region SPECIFIC CSVHELPER BASED FUNCTIONALITY
        //https://stackoverflow.com/questions/59046788/skip-rows-from-csv-file
        //https://duongnt.com/read-csv-helper/
        //https://joshclose.github.io/CsvHelper/examples/reading/reading-by-hand/

        private void LoadThermoDataFromCSVFile(string filepathname)
        {
            var localconfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,   // Our file uses UTF-8 encoding.
                Delimiter = ","             // The delimiter is a comma.
            };

            var recordList = new List<ThermoData>();

            using (var reader = new StreamReader(filepathname))
            using (var csv = new CsvReader(reader, localconfiguration))
            {

                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    var record = new ThermoData
                    {
                        //NEED TO ADD THEM ALL IN HERE
                        TIMESTAMP = csv.GetField<DateTime>("TIMESTAMP"),
                        UE_TEMP_ACT = csv.GetField<double>("UE_TEMP_ACT"),
                        UE_CMD_SP = csv.GetField<double>("UE_CMD_SP"),
                        UE_POWER_PERCENT = csv.GetField<double>("UE_POWER_PERCENT"),
                        UE_TEMP_SP = csv.GetField<double>("UE_TEMP_SP")
                    };
                    recordList.Add(record);
                }
                ThermoDataList = recordList;

                AddToStatusDisplay("Loaded " + recordList.Count.ToString() + " ThermoData Entries from file");
            }
        }

        private void LoadBremboDiskDataFromCSVFile(string filepathname)
        {
            var localconfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,   // Our file uses UTF-8 encoding.
                Delimiter = ";",             // The delimiter is a comma.
                IgnoreBlankLines = false
            };

            var recordList = new List<CSVBremboDisk>();

            using (var reader = new StreamReader(filepathname))
            using (var csv = new CsvReader(reader, localconfiguration))
            {
                
                csv.Read();
                csv.ReadHeader();

                //THEN SKIP THE NEXT FEW LINES
                for(int idx = 0; idx < 6; idx++) 
                {
                    csv.Read();
                }

                while (csv.Read())
                {
                    try
                    {
                        var record = new CSVBremboDisk
                        {
                            //NEED TO ADD THEM ALL IN HERE
                            Date = csv.GetField<string>("Date"),
                            Name = csv.GetField<string>("Name"),
                            PartID = csv.GetField<string>("PartID"),
                            ReportPath = csv.GetField<string>("reportPath"),
                            Operator = csv.GetField<string>("Operator"),

                            FDiam = csv.GetField<double>("F Diam."),
                            M2_D_C_D = csv.GetField<double>("M2-D/C D"),
                            M3_A_C_D = csv.GetField<double>("M3-A/C D"),
                            M4_B_C_D = csv.GetField<double>("M4-B/C D"),
                            M5_A_D_D = csv.GetField<double>("M4-B/C D"),
                            M6_A_B_D = csv.GetField<double>("M6-A/B D"),

                            M11_D = csv.GetField<double>("M11-D Val."),
                            M14_C = csv.GetField<double>("M14-C Val."),
                            M15_D = csv.GetField<double>("M15-D Val."),
                            CIR_M16_Diam = csv.GetField<double>("CIR_M16 Diam."),
                            CIR_M17_Diam = csv.GetField<double>("CIR_M17 Diam."),
                            M18_D = csv.GetField<double>("M18 D"),
                            M29_A = csv.GetField<double>("M29-A Val."),

                            M32_B = csv.GetField<double>("M32-B Val."),
                            M39_A = csv.GetField<double>("M39-A Val."),
                            M42_B = csv.GetField<double>("M42-B Val."),
                            M43_A = csv.GetField<double>("M43-A Val."),
                            M44_B = csv.GetField<double>("M44-B Val."),
                            M47_DTV_V5 = csv.GetField<double>("M47-DTV-v5 Val."),
                            M48_DTV_Radial_V2 = csv.GetField<double>("M48-DTV-Radial-v2 Val."),

                            M52_1 = csv.GetField<double>("M52.1 Val."),
                            M52_2 = csv.GetField<double>("M52.2 Val."),
                            M52_3 = csv.GetField<double>("M52.3 Val."),
                            M52_4 = csv.GetField<double>("M52.4 Val."),
                            M52_5 = csv.GetField<double>("M52.5 Val."),

                            M53_1 = csv.GetField<double>("M53.1 Val."),
                            M53_2 = csv.GetField<double>("M53.2 Val."),
                            M53_3 = csv.GetField<double>("M53.3 Val."),
                            M53_4 = csv.GetField<double>("M53.4 Val."),
                            M53_5 = csv.GetField<double>("M53.5 Val."),

                            M54_1 = csv.GetField<double>("M54.1 Diam."),
                            M54_2 = csv.GetField<double>("M54.2 Diam."),
                            M54_3 = csv.GetField<double>("M54.3 Diam."),
                            M54_4 = csv.GetField<double>("M54.4 Diam."),
                            M54_5 = csv.GetField<double>("M54.5 Diam."),

                            M55_1 = csv.GetField<double>("M55.1 Diam."),
                            M55_2 = csv.GetField<double>("M55.2 Diam."),
                            M55_3 = csv.GetField<double>("M55.3 Diam."),
                            M55_4 = csv.GetField<double>("M55.4 Diam."),
                            M55_5 = csv.GetField<double>("M55.5 Diam."),
                            M56 = csv.GetField<double>("M56 Diam."),
                            M57 = csv.GetField<double>("M57 Val."),

                            Alignement_TX = csv.GetField<double>("Alignement Tx"),
                            Alignement_TY = csv.GetField<double>("Alignement Ty"),
                            Alignement_TZ = csv.GetField<double>("Alignement Tz"),
                            Alignement_RX = csv.GetField<double>("Alignement Rx"),
                            Alignement_RY = csv.GetField<double>("Alignement Ry"),
                            Alignement_RZ = csv.GetField<double>("Alignement Rz"),

                            Temperature_C1_CASE = csv.GetField<double>("temperature_c1_CASE"),
                            Temperature_C1_CMOS = csv.GetField<double>("temperature_c1_CMOS"),
                            Temperature_C1_PROC = csv.GetField<double>("temperature_c1_PROC"),
                            Temperature_C2_CASE = csv.GetField<double>("temperature_c2_CASE"),
                            Temperature_C2_CMOS = csv.GetField<double>("temperature_c2_CMOS"),
                            Temperature_C2_PROC = csv.GetField<double>("temperature_c2_PROC"),
                            Temperature_C3_CASE = csv.GetField<double>("temperature_c3_CASE"),
                            Temperature_C3_CMOS = csv.GetField<double>("temperature_c3_CMOS"),
                            Temperature_C3_PROC = csv.GetField<double>("temperature_c3_PROC"),
                            Temperature_C4_CASE = csv.GetField<double>("temperature_c4_CASE"),
                            Temperature_C4_CMOS = csv.GetField<double>("temperature_c4_CMOS"),
                            Temperature_C4_PROC = csv.GetField<double>("temperature_c4_PROC"),
                            Temperature_C5_CASE = csv.GetField<double>("temperature_c5_CASE"),
                            Temperature_C5_CMOS = csv.GetField<double>("temperature_c5_CMOS"),
                            Temperature_C5_PROC = csv.GetField<double>("temperature_c5_PROC"),
                            Temperature_C6_CASE = csv.GetField<double>("temperature_c6_CASE"),
                            Temperature_C6_CMOS = csv.GetField<double>("temperature_c6_CMOS"),
                            Temperature_C6_PROC = csv.GetField<double>("temperature_c6_PROC"),
                    };
                        record.ConvertTheCrazyFrenchTimeString();
                        record.PartID = record.Name;                        //BAKER
                        record.WorkOrderID = txbx_WorkOrderID.Text;
                        record.ToolID = cbox_ToolID.Text;
                        recordList.Add(record);
                    }
                   catch(Exception ex) 
                    {
                        AddToStatusDisplay("Missing Data Issues Found in File...Continuing without this entry");
                    }

                   
                }

                BremboDiskList = recordList;
                AddToStatusDisplay("Loaded " + recordList.Count.ToString() + " Brembo Entries from file");
            }
        }

        #endregion

        #region FORM AND BUTTON HANDLERS

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> toollist = new List<string>();
            toollist.Add("ZTR4_Brembo");
            toollist.Add("ZTR4_Ford");
            toollist.Add("BAKER_TEST_TOOL");

            InitializeToolIDUI(toollist);

            AddToStatusDisplay("Application Started");
        }

        private void bn_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btn_LoadCSVData_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "CSV FILE (*.csv, *.csv) | *.csv; *.csv";
            openFileDialog.Title = "Load CSV File";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadBremboDiskDataFromCSVFile(openFileDialog.FileName);
            }

        }

        private void btn_LoadTemp_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "CSV FILE (*.csv, *.csv) | *.csv; *.csv";
            openFileDialog.Title = "Load CSV File";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                 LoadThermoDataFromCSVFile(openFileDialog.FileName);
            }
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            List<ThermoData> myTrash = MakeFakeThermoData();
            using (var stream = File.OpenWrite("c:\\Temp\\HOOHAHNEW.csv"))
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(myTrash);
            }

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            int idx = 1;
            DateTime dtime = e.Start;
            WorkOrder_Start = e.Start;
            AddToStatusDisplay("Chose Start Date of: " + WorkOrder_Start.ToString());
        }

        private void btn_SendAllToMongo_Click(object sender, EventArgs e)
        {
            //if(ThermoDataList.Count > 0)
            //{
            //    SendToMongoThermoData();
            //}

            if (BremboDiskList.Count > 0)
            {
                ConvertBremboCSVToTransactionsAndDelete();
                SendToMongoPartData();
            }
        }

        private void btn_SendWorkOrder_Click(object sender, EventArgs e)
        {
            SendToWorkOrderDatabase();
        }

        #endregion


    }//CLASS
}//NAMESPACE