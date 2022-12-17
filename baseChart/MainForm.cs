using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace baseChart
{
    public partial class MainForm : Form
    {
        DataCreateForm dataForm;
        string DefaultDataFile = "data.xml";
        private List<StoreData> StoreDataList;
        protected string XmlStoreName = "default";
        private XmlDocument doc;

        public List<StoreData> StoreDataItems { get => StoreDataList; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripbtnCreate_Click(object sender, EventArgs e)
        {
            if (dataForm == null || dataForm.IsDisposed)
            {
                dataForm = new DataCreateForm(this);
                dataForm.ShowDialog();
                dataForm = null;
            }

        }

        protected void LoadData()
        {
            if(doc is null)
                doc = new XmlDocument();
            try
            {
                doc.Load(DefaultDataFile);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                #if DEBUG
                LoadDefaultData(doc, true);
                #else
                LoadDefaultData(doc, false);
                #endif
                doc.Save(DefaultDataFile);
            }
           //  StoreDataHelper.ImportDefaultStoreData(doc, "default");
          
            StoreDataList = StoreDataHelper.GetStoreDataListFromXmlDocument(doc, XmlStoreName);
        }




        protected void LoadDefaultData(XmlDocument doc, bool importDammyData = false)
        {
          
            doc=StoreDataHelper.CreateDefaultStoreData(doc);
            //doc = StoreDataHelper.AddNewStoreName(doc, "test");
            if(importDammyData)
                StoreDataHelper.ImportDefaultStoreData(doc, "default");
            //StoreDataHelper.ImportDefaultStoreData(doc, "test");

            doc.Save(DefaultDataFile);
         
        }
        public void AddNewStoreData(StoreData sd)
        {
            StoreDataHelper.AddStoreDataNode(doc,XmlStoreName,sd);
            /*if(sd.Id == 0)
                sd.Id = StoreDataHelper.GetMaxStoreDataId(doc);
            XmlElement element = StoreDataHelper.StoreDataConvertToXmlElement(sd, doc);
            XmlNode StoreNode = StoreDataHelper.GetStoreXmlNode(doc, XmlStoreName);
            StoreNode.AppendChild(element);*/
            doc.Save(DefaultDataFile);
            StoreDataList.Add(sd);
        }

        public void AddNewStoreDataWithoutSave(StoreData sd)
        {
            StoreDataHelper.AddStoreDataNode(doc, XmlStoreName, sd);
        }

        public void UpdateStoreData(List<StoreData> updateData)
        {
            if(updateData != null)
            {
                int count= StoreDataHelper.UpdateStoreDataNodes(doc, XmlStoreName, updateData);

                doc.Save(DefaultDataFile);
                LoadData();
                
            }
           
        }
        public void DeleteStoreData(List<StoreData> updateData)
        {
            if (updateData != null)
            {
                int count = StoreDataHelper.DeleteStoreDataNodes(doc, XmlStoreName, updateData,false);
                doc.Save(DefaultDataFile);
                LoadData();

            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
            ShowChart(ChartStoreDataViewType.Last10Days);
        }

        private void ShowChartLast10Days()
        {
           
            if (StoreDataList?.Count > 0)
            {
                DateTime baseDate = new DateTime(StoreDataList.Max(item => DateTime.ParseExact(item.Date, "yyyy/MM/dd", null).Ticks));
                DateTime diffDate;
                List<StoreData> list;
                double days = 10.0;
                double sum = 0.0;
                double avg = 0.0;
               
                list = StoreDataList.FindAll((st) => {
                    try
                    {
                        diffDate = DateTime.ParseExact(st.Date, "yyyy/MM/dd", null);
                        if (Math.Abs((diffDate - baseDate).TotalDays) < days)
                            return true;
                    }
                    catch (Exception) { }

                    return false;

                });
             
                foreach (StoreData item in list.OrderBy(item => item.Date))
                {
                    sum += item.CustomerCount;
                    chartStoreData.Series[0].Points.AddXY(item.Date, item.CustomerCount);
                }
                avg = sum / list.Count;
                lblStoreDataInfo.Text = string.Format("客人統計\r\n\r\n總數:{0}\r\n平均人數:{1}", sum, avg);
            }
        }
        protected void ShowChartRecent10Data()
        {
            if (StoreDataList?.Count > 0)
            {
                List<StoreData> list = StoreDataList;
                int maxcount = 10;
                int firstIndex=0;
                double sum = 0.0;
                double avg = 0.0;
                if (list.Count > maxcount)
                    firstIndex = list.Count - maxcount;
          
                for (int i = firstIndex; i < list.Count; i++)
                {
                    sum += list[i].CustomerCount;
                    chartStoreData.Series[0].Points.AddXY(list[i].Date, list[i].CustomerCount);
                }
                if (firstIndex <= 0)
                    avg = sum / list.Count;
                else
                    avg = sum / maxcount;

                lblStoreDataInfo.Text = string.Format("客人統計\r\n\r\n總數:{0}\r\n平均人數:{1}",sum,avg);

            }
        }
        protected void ShowChart(ChartStoreDataViewType chartStoreDataViewType)
        {
            lblStoreDataInfo.Text = "";
            chartStoreData.Series[0].Points.Clear();
            if (chartStoreDataViewType == ChartStoreDataViewType.Last10Days)
                ShowChartLast10Days();
            else if (chartStoreDataViewType == ChartStoreDataViewType.Recent10Data)
                ShowChartRecent10Data();
        }
        private void toolStripButtonTest_Click(object sender, EventArgs e)
        {
            new TestForm().ShowDialog(this);
        }

        private void btnLast10Days_Click(object sender, EventArgs e)
        {
            ShowChart(ChartStoreDataViewType.Last10Days);
        }

        private void btnRecent10Data_Click(object sender, EventArgs e)
        {
            ShowChart(ChartStoreDataViewType.Recent10Data);
        }
    }
    public enum ChartStoreDataViewType{
        Last10Days,
        Recent10Data
    }
}
