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
                /*
                dataForm = new DataCreateForm(this);
                this.AddOwnedForm(dataForm);

                dataForm.Show();*/
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
                LoadDefaultData(doc);
                doc.Save(DefaultDataFile);
            }
           //  StoreDataHelper.ImportDefaultStoreData(doc, "default");
          
            StoreDataList = StoreDataHelper.GetStoreDataListFromXmlDocument(doc, XmlStoreName);
           // StoreDataList.Sort((t1, t2) =>  t2.Id.CompareTo(t1.Id)  );

            /*foreach (var tmp in StoreDataList)
            {
                Console.WriteLine("Id:"+ tmp.Id);
            }*/
            //Console.WriteLine(doc.DocumentElement.Name);
        }




        protected void LoadDefaultData(XmlDocument doc)
        {
          
            doc=StoreDataHelper.CreateDefaultStoreData(doc);
            //doc = StoreDataHelper.AddNewStoreName(doc, "test");

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
           // ChartDataOperator();
        }

        protected void ChartDataOperator()
        {
            if(StoreDataList?.Count >0)
            {
                DateTime baseDate = new DateTime(2022, 4, 25);
                DateTime diffDate;
                List<StoreData> list;
                double days = 10; 

                list = StoreDataList.FindAll((st) => {
                    try { 
                    diffDate = DateTime.ParseExact(st.Date, "yyyy/MM/dd",null);
                    if((diffDate - baseDate).TotalDays < days)
                        return true;
                    }
                    catch (Exception) { }
                     
                    return false;
                    
                });
                
                foreach (StoreData item in list)
                {
                    //chartStoreData.Series[0].Points.AddXY(item.Date,item.CustomerCount);
                  
                    //chartStoreData.Series[0].ChartArea = "test";
                }

            }



        }

        private void toolStripButtonTest_Click(object sender, EventArgs e)
        {
            new TestForm().ShowDialog(this);
        }
    }

    

}
