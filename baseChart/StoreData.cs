using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace baseChart
{
    public class StoreData
    {
        public int Id;
        public string Date { get; set; }
        public int CustomerCount { get; set; }

        public StoreData(int Id, string Date, int CustomerCount)
        {
            this.Id = Id;
            this.Date = Date;
            this.CustomerCount = CustomerCount;
        }
        public static StoreData ConvertStringToStoreData(string s_Id, string s_Date, string s_CustomerCount)
        {
            int Id = 0;
            string Date = s_Date.Trim();
            int CustomerCount = 0;

            if (!int.TryParse(s_Id.Trim(), out Id))
                throw new StoreDataConvertException("Id Can't Converted");
            if (!int.TryParse(s_CustomerCount.Trim(), out CustomerCount))
                throw new StoreDataConvertException("CustomerCount Can't Converted");

            return new StoreData(Id, Date, CustomerCount);
        }
    }

    public class StoreDataException : Exception
    {
        public string ErrorMessage { get; set; }
        public StoreDataException(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
        }
    }
    public class StoreDataConvertException : StoreDataException
    {
        public StoreDataConvertException(string ErrorMessage) : base(ErrorMessage)
        {

        }
    }

    public class StoreDataUpdateXmlException : StoreDataException
    {
        public StoreDataUpdateXmlException(string ErrorMessage) : base(ErrorMessage)
        {

        }
    }
    public class StoreDataHelper
    {

        public static XmlElement StoreDataConvertToXmlElement(StoreData data, XmlDocument doc)
        {
            XmlElement node;
            XmlElement nodetmp;
            node = doc.CreateElement("Item");

            nodetmp = doc.CreateElement("Id");
            nodetmp.InnerText = data.Id.ToString();
            node.AppendChild(nodetmp);

            nodetmp = doc.CreateElement("Date");
            nodetmp.InnerText = data.Date;
            node.AppendChild(nodetmp);

            nodetmp = doc.CreateElement("CustomerCount");
            nodetmp.InnerText = data.CustomerCount.ToString();
            node.AppendChild(nodetmp);

            return node;
        }
        //
        public static XmlNode GetStoreXmlNode(XmlDocument doc, string attr = "default")
        {
            string express = string.Format(@"/root/Store[@Storename='{0}']", attr);
            XmlNodeList list = doc.SelectNodes(express);
            return list?[0];

        }

        public static List<StoreData> GetStoreDataListFromXmlDocument(XmlDocument doc, string attr = "default")
        {
            XmlNode StoreNode = GetStoreXmlNode(doc, attr);

            XmlNodeList list = StoreNode?.SelectNodes("Item");
            List<StoreData> StoreDataList;
            if (list is null || list?.Count <= 0)
                return null;
            StoreDataList = new List<StoreData>();

            for (int i = 0; i < list.Count; i++)
            {
                int id = 0;
                string date = "";
                int customerAccount = 0;
                int.TryParse(list[i].SelectNodes("Id")[0]?.InnerText, out id);
                date = list[i].SelectNodes("Date")[0]?.InnerText;
                int.TryParse(list[i].SelectNodes("CustomerCount")[0]?.InnerText, out customerAccount);
                StoreData sd = new StoreData(id, date, customerAccount);
                StoreDataList.Add(sd);
            }

            return StoreDataList;
        }
        public static XmlDocument CreateDefaultStoreData(XmlDocument doc)
        {

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            XmlElement element = doc.CreateElement(string.Empty, "root", string.Empty);

            doc.AppendChild(element);
            element = doc.CreateElement(string.Empty, "Store", string.Empty);
            root = doc.DocumentElement;
            element.SetAttribute("Storename", "default");
            root.AppendChild(element);

            return doc;
        }
        public static XmlDocument AddNewStoreName(XmlDocument doc, string storeName)
        {
            XmlElement root = doc.DocumentElement;
            XmlElement element = doc.CreateElement(string.Empty, "Store", string.Empty);
            element.SetAttribute("Storename", storeName);
            root.AppendChild(element);
            return doc;
        }
        public static void ImportDefaultStoreData(XmlDocument doc, string storename)
        {
            XmlNode StoreNode = GetStoreXmlNode(doc, storename);
            int i = 0;
            XmlNodeList list = doc?.SelectNodes("//Store/Item");

            if (list != null)
            {
                i = GetMaxStoreDataId(doc);
            }

            List<StoreData> StoreDataList = new List<StoreData> {
                                new StoreData(i++,"2020/04/21",10),
                                new StoreData(i++,"2020/04/20",20),
                                new StoreData(i++,"2020/04/19",30),
                            };

            foreach (StoreData sd in StoreDataList)
            {
                XmlElement element = StoreDataConvertToXmlElement(sd, doc);
                StoreNode?.AppendChild(element);
            }

        }
        public static int GetMaxStoreDataId(XmlDocument doc)
        {
            int i = -1;
            XmlNodeList list = doc?.SelectNodes("//Store/Item");
            if (list != null)
            {
                foreach (XmlNode node in list)
                {
                    int id = 0;
                    Console.WriteLine(node["Id"].InnerText);
                    int.TryParse(node["Id"]?.InnerText, out id);
                    if (id >= i)
                        i = id;
                }
            }

            return ++i;
        }

        //add
        public static int AddStoreDataNode(XmlDocument doc, string StoreAttr, StoreData storeData)
        {
            int count = 0;

            if (storeData.Id == 0)
                storeData.Id = GetMaxStoreDataId(doc);
            XmlElement element = StoreDataConvertToXmlElement(storeData, doc);
            XmlNode StoreNode = GetStoreXmlNode(doc, StoreAttr);
            StoreNode.AppendChild(element);
            count += 1;
            return count;
        }

        public static int AddStoreDataNodes(XmlDocument doc, string StoreAttr, List<StoreData> storeData)
        {
            int count = 0;

            foreach (StoreData storeDataItem in storeData)
            {
                count += AddStoreDataNode(doc, StoreAttr, storeDataItem);
            }
            return count;
        }

        public static int UpdateStoreDataNode(XmlDocument doc, string StoreAttr, StoreData storeData)
        {
            int count = 0;

            XmlElement element = StoreDataConvertToXmlElement(storeData, doc);
            XmlNode StoreNode = StoreDataHelper.GetStoreXmlNode(doc, StoreAttr);
            string QueryStr = string.Format("Item[Id={0}]", storeData.Id);
            XmlNodeList list = StoreNode.SelectNodes(QueryStr);
            XmlNodeList listChild;
            if (list.Count > 0)
            {
                listChild = list[0].SelectNodes("Date");
                if (listChild.Count > 0)
                    listChild[0].InnerText = storeData.Date;
                else
                    throw new StoreDataUpdateXmlException("更新XML錯誤，無法找到節點Date");

                listChild = list[0].SelectNodes("CustomerCount");
                if (listChild.Count > 0)
                    listChild[0].InnerText = storeData.CustomerCount.ToString();
                else
                    throw new StoreDataUpdateXmlException("更新XML錯誤，無法找到節點CustomerCount");
                count++;
            }
            else
                count += AddStoreDataNode(doc, StoreAttr, storeData);

            return count;
        }
        public static int UpdateStoreDataNodes(XmlDocument doc, string StoreAttr, List<StoreData> storeData)
        {
            int count = 0;

            foreach (StoreData storeDataItem in storeData)
            {
                count += UpdateStoreDataNode(doc, StoreAttr, storeDataItem);
            }
            return count;
        }

        public static int DeleteStoreDataNode(XmlDocument doc, string StoreAttr, StoreData storeData, bool byId = true)
        {
            int count = 0;
            XmlElement element = StoreDataConvertToXmlElement(storeData, doc);
            XmlNode StoreNode = StoreDataHelper.GetStoreXmlNode(doc, StoreAttr);
            string QueryStr;

            if (byId)
                QueryStr = string.Format("Item[Id={0}]", storeData.Id);
            else
                QueryStr = string.Format(@"Item[Id={0} and Date='{1}' and CustomerCount={2}]", storeData.Id, storeData.Date, storeData.CustomerCount);

            XmlNodeList list = StoreNode.SelectNodes(QueryStr);
            XmlNode node;
            if (list.Count > 0)
            {
                node = StoreNode.RemoveChild(list[0]);
                if (node != null)
                    count++;
            }
            return count;
        }
        public static int DeleteStoreDataNodes(XmlDocument doc, string StoreAttr, List<StoreData> storeData, bool byId = true)
        {
            int count = 0;

            foreach (StoreData storeDataItem in storeData)
            {
                count += DeleteStoreDataNode(doc, StoreAttr, storeDataItem, byId);
            }
            return count;
        }
    }

    public class StoreDataSearch
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

}
