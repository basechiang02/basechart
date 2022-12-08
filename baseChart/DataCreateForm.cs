using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnimateBase;
namespace baseChart
{
    public partial class DataCreateForm : Form
    {
        private MainForm parentForm;
        private bool showPickDate = false;
        public int PagedItemSize = 5;
        private UpdateUI[] UpdateUIItem;
        protected int currentPage = 0;
        private FadeAnimateBase testAnimateBase;
        protected List<StoreData> OriginStoreData;
        protected List<StoreData> UpdateStoreData;
        protected List<StoreData> DeleteStoreData;
        protected List<StoreData> SearchStoreData;
        protected StoreDataSearch SearchCondition;
        int panelRightDownHeightOrigin = 0;

        public bool IsSearch { get; set; } = false; 

        public DataCreateForm(MainForm parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            testAnimateBase = new FadeAnimateBase(btnClose, FadeAnimateBaseEffect.FadeToggle);
            testAnimateBase.PostAnimateEvent += TestAnimateBase_PostAnimateEvent;
            panelRightDownHeightOrigin = panelRightDown.Height;
            CreateUpdateUIList();
            UpdateStoreData = new List<StoreData>();
            DeleteStoreData = new List<StoreData>();
            SearchStoreData = new List<StoreData>();
            LoadStoreData();
        }

        private void DataCreateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
         //   parentForm.Enabled = true;
        }

        private void btnShowDate_Click(object sender, EventArgs e)
        {
            showPickDate = !showPickDate;
            if (showPickDate)
            {
                Point p = new Point(btnShowDate.Location.X + btnShowDate.Size.Width, btnShowDate.Location.Y);
                monthCalendar1.Location = p;
                this.monthCalendar1.Show();
            }
            else
                this.monthCalendar1.Hide();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            tbDate.Text = monthCalendar1.SelectionStart.ToString("yyyy/MM/dd");
            showPickDate = false;
            monthCalendar1.Hide();
        }
        private StoreData GetAddedStoreData()
        {
            int Id = 0;
            string Date;
            int CustomerCount=0;
            if (!ValidationDate(tbDate.Text))
                throw new DateIsNotOk("日期錯誤");
            if (!ValidationCustomerCount(tbCustomerCount.Text))
                throw new CustomerCountIsNotOk("來客數錯誤，請輸入數字");
            Date = tbDate.Text;
            int.TryParse(tbCustomerCount.Text,out CustomerCount);
            return new StoreData(Id, Date, CustomerCount);

        }
        //check date
        public bool ValidationDate(string text)
        {
            DateTime fromDateValue;
            if (DateTime.TryParseExact(text, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture,
                                        System.Globalization.DateTimeStyles.None, out fromDateValue))
                return true;
            else
                return false;
        }
        public bool ValidationCustomerCount(string text)
        {
            int num;
            if (int.TryParse(text, out num) && num >= 0)
                return true;
            else
                return false;
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            StoreData sd;
            try
            {
                sd = GetAddedStoreData();
            }
            catch(DateIsNotOk ex)
            {
               MessageBox.Show(ex.ErrorMessage, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
            catch(CustomerCountIsNotOk ex)
            {
                MessageBox.Show(ex.ErrorMessage, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            parentForm.AddNewStoreData(sd);
            LoadStoreData();
            MessageBox.Show("新增一筆資料","新增");
        }

        public void SaveStoreDataSearch(StoreDataSearch searchdata)
        {
            SearchCondition = searchdata;
            SearchStoreData.Clear();

            SearchStoreData = OriginStoreData.FindAll((st)=>{
                    DateTime startDate ;
                    DateTime endDate;
                    DateTime data;
 
                    DateTime.TryParseExact(searchdata?.StartDate?.Trim(), "yyyy/MM/dd",
                            null, System.Globalization.DateTimeStyles.None, out startDate);
                    DateTime.TryParseExact(searchdata?.EndDate?.Trim(), "yyyy/MM/dd",
                            null, System.Globalization.DateTimeStyles.None, out endDate);
                    DateTime.TryParseExact(st?.Date?.Trim(), "yyyy/MM/dd",
                            null, System.Globalization.DateTimeStyles.None, out data);

                if (data.Ticks == 0)
                    return false;
                if (endDate.Ticks > 0 && data.Ticks > endDate.Ticks)
                    return false;
                if (startDate.Ticks > 0 && data.Ticks < startDate.Ticks)
                    return false;
               
                return true;
            });

            IsSearch = true;
            UpdateUIListApply();

        }

        private void TestAnimateBase_PostAnimateEvent(object sender, AnimateBaseEventArg e)
        {
            if (testAnimateBase.FadeAnimateToggle)
                e.m_AnimatedControl.Show();
            else
                e.m_AnimatedControl.Hide();
        }

        private void rbCollaspe_Click(object sender, EventArgs e)
        {
            if (panelRightUp.Visible)
            {
                panelRightUp.Hide();
                rbCollaspe.Text = "⬇";
                panelRightDown.Height = this.Height-70-this.panelRightMiddle.Height;
            }
            else
            {
                panelRightUp.Show();
                rbCollaspe.Text = "⬆";
                panelRightDown.Height = panelRightDownHeightOrigin;
            }
        }


        private void CreateUpdateUIList()
        {
            UpdateUIItem = new UpdateUI[PagedItemSize];
            flowLayoutPanelRightDown.Controls.Remove(updateUI1);
            for (int i=0;i< UpdateUIItem.Length;i++)
            {
                UpdateUIItem[i] = new UpdateUI();
                UpdateUIItem[i].Location = new System.Drawing.Point(10, 10);

                UpdateUIItem[i].Size = new System.Drawing.Size(270, 166);
                UpdateUIItem[i].TabIndex = 0;
                flowLayoutPanelRightDown.Controls.Add(UpdateUIItem[i]);

                UpdateUIItem[i].TextBoxUpdateDate.KeyPress += UpdateUITextBoxUpdateDate_KeyPress;
                UpdateUIItem[i].TextBoxUpdateDate.Leave += UpdateUITextBoxUpdateDate_Leave;

                UpdateUIItem[i].TextBoxUpdateCustomerCount.KeyPress += UpdateUITextBoxUpdateCustomerCount_KeyPress;
                UpdateUIItem[i].TextBoxUpdateCustomerCount.Leave += UpdateUITextBoxUpdateCustomerCount_Leave;
            }


        }
        // update action
        private void UpdateUIUpdateActionUI(object UIContorl)
        {
            Control TargetItem;
            StoreData storeData;
            StoreData updateStoreData;
            StoreData originStoreData;

            if (UIContorl is Control)
                TargetItem = (Control)UIContorl;
            else
                return;

            if (OriginStoreData == null) return;


            for (int i=0;i<UpdateUIItem.Length;i++)
            {
                if (UpdateUIItem[i].Controls.Contains(TargetItem))
                {
                    storeData = StoreData.ConvertStringToStoreData(UpdateUIItem[i].LableId.Text,
                                                                   UpdateUIItem[i].TextBoxUpdateDate.Text,
                                                                   UpdateUIItem[i].TextBoxUpdateCustomerCount.Text
                                                                );
                    updateStoreData = UpdateStoreData.Find((sd) => sd.Id == storeData.Id);
                    originStoreData = OriginStoreData.Find((sd) => sd.Id == storeData.Id);
                    
                    //orgin data not found
                    if (originStoreData == null)
                        return;

                    if (!originStoreData.Date.Equals(storeData.Date))
                    {
                        UpdateUIItem[i].LabelUpdateDateStar.Show();
                    }
                    else
                    {
                        UpdateUIItem[i].LabelUpdateDateStar.Hide();
                    }
                    if (originStoreData.CustomerCount != storeData.CustomerCount)
                    {
                        UpdateUIItem[i].LabelUpdateCustomerStar.Show();
                    }
                    else
                    {
                        UpdateUIItem[i].LabelUpdateCustomerStar.Hide();
                    }

                    if (updateStoreData == null)
                    {
                        UpdateStoreData.Add(storeData);
                    }
                    else
                    {
                        if (updateStoreData.Date != storeData.Date)
                            updateStoreData.Date = storeData.Date;
                        if (updateStoreData.CustomerCount != storeData.CustomerCount)
                            updateStoreData.CustomerCount = storeData.CustomerCount;
                    }
                    return;
                }
            }
        }

        private bool UpdateUIUpdateValidationAndAction(Control controlItem)
        {
            foreach(UpdateUI item in UpdateUIItem)
            {
                if(item.Controls.Contains(controlItem))
                {
                    int id = 0;
                    if(!int.TryParse(item.LableId.Text.Trim(),out id))
                    {
                        throw new StoreDataException("無法預期的錯誤，ID不存在");
                    }


                    if (item.TextBoxUpdateDate == controlItem  )
                    {
                        if(this.ValidationDate(controlItem.Text))
                            return true;
                        else
                        {
                            StoreData orginStoreData = OriginStoreData?.Find(st => st.Id == id);

                            if (orginStoreData == null)
                                item.TextBoxUpdateDate.Text = "";
                            else
                                item.TextBoxUpdateDate.Text = orginStoreData.Date;
                            return false;
                        }
                    }
                    else if (item.TextBoxUpdateCustomerCount == controlItem )
                    {
                        if(this.ValidationCustomerCount(controlItem.Text))
                            return true;
                        else
                        {
                            StoreData orginStoreData = OriginStoreData?.Find(st => st.Id == id);
                            if (orginStoreData == null)
                                item.TextBoxUpdateCustomerCount.Text = "";
                            else
                                item.TextBoxUpdateCustomerCount.Text = orginStoreData.CustomerCount.ToString();
                            
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        private void UpdateUITextBoxUpdateCustomerCount_Leave(object sender, EventArgs e)
        {
            if(sender is Control)
                if(UpdateUIUpdateValidationAndAction((Control)sender))
                    UpdateUIUpdateActionUI(sender);
            //throw new NotImplementedException();
        }

        private void UpdateUITextBoxUpdateCustomerCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (sender is Control)
                    if (UpdateUIUpdateValidationAndAction((Control)sender))
                        UpdateUIUpdateActionUI(sender);
            }
            //throw new NotImplementedException();
        }

        private void UpdateUITextBoxUpdateDate_Leave(object sender, EventArgs e)
        {
            if (sender is Control)
                if (UpdateUIUpdateValidationAndAction((Control)sender))
                    UpdateUIUpdateActionUI(sender);
        }

        private void UpdateUITextBoxUpdateDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (sender is Control)
                    if (UpdateUIUpdateValidationAndAction((Control)sender))
                        UpdateUIUpdateActionUI(sender);
            }
        }
        //search form
        private void UpdateSearchUI()
        {
            if(IsSearch)
            {
                if(SearchCondition !=null)
                {
                    if (SearchCondition.StartDate == null)
                        lblSearchStartDate.Text = "";
                    else
                        lblSearchStartDate.Text = SearchCondition.StartDate;
                    if (SearchCondition.EndDate == null)
                        lblSearchEndDate.Text = "";
                    else
                        lblSearchEndDate.Text = SearchCondition.EndDate;
                }

                if (!panelSearchInfo.Visible)
                    panelSearchInfo.Show();
            }
            else
                panelSearchInfo.Hide();
        }
        //update list UI
        private void UpdateUIListApply()
        {
            int offset = currentPage * PagedItemSize;
            StoreData updateStoreData = null;
            List<StoreData> StoreDataShow;

            //search
            if (IsSearch)
                StoreDataShow = SearchStoreData;
            else
                StoreDataShow = OriginStoreData;
         
            for (int i = 0; i < UpdateUIItem.Length; i++)
            {
                if(StoreDataShow != null && StoreDataShow?.Count > i && i + offset < StoreDataShow.Count)
                {
                    if (UpdateStoreData.Count > 0)
                    {
                        updateStoreData = UpdateStoreData.Find((st) => st.Id == StoreDataShow[i + offset].Id);
                    }
                    if(updateStoreData != null)
                    {
                        UpdateUIItem[i].LableId.Text = updateStoreData.Id.ToString();
                        UpdateUIItem[i].TextBoxUpdateDate.Text = updateStoreData.Date;
                        UpdateUIItem[i].TextBoxUpdateCustomerCount.Text = updateStoreData.CustomerCount.ToString();
                        if (StoreDataShow[i + offset].Date != updateStoreData.Date)
                            UpdateUIItem[i].LabelUpdateDateStar.Show();
                        else
                            UpdateUIItem[i].LabelUpdateDateStar.Hide();
                        if (StoreDataShow[i + offset].CustomerCount != updateStoreData.CustomerCount)
                            UpdateUIItem[i].LabelUpdateCustomerStar.Show();
                        else
                            UpdateUIItem[i].LabelUpdateCustomerStar.Hide();
                    }
                    else
                    {
                        UpdateUIItem[i].LableId.Text = StoreDataShow[i + offset].Id.ToString();
                        UpdateUIItem[i].TextBoxUpdateDate.Text = StoreDataShow[i + offset].Date;
                        UpdateUIItem[i].TextBoxUpdateCustomerCount.Text = StoreDataShow[i + offset].CustomerCount.ToString();
                        UpdateUIItem[i].LabelUpdateDateStar.Hide();
                        UpdateUIItem[i].LabelUpdateCustomerStar.Hide();
                    }
                    if (!UpdateUIItem[i].TextBoxUpdateCustomerCount.Visible)
                        UpdateUIItem[i].Show();
                }
                else
                {
                    UpdateUIItem[i].Hide();
                }
                
            }
            if (IsSearch)
                UpdateSearchUI();
            //workround scroll not apply children controls visible
            this.panelRightDown.AutoScroll = false;
            this.panelRightDown.AutoScroll = true;

            PageButtonApply();
        }
        // apply button eable or disable
        private void PageButtonApply()
        {
            List<StoreData> storeDataShow;

            if (IsSearch)
                storeDataShow = SearchStoreData;
            else
                storeDataShow = OriginStoreData;
            
            if (currentPage <= 0)
            {
                rbPageDecrement.Enabled = false;
            }
            else if (currentPage >= GetMaxPageNumber(storeDataShow.Count))
            {
                rbPageIncrement.Enabled = false;
            }
            else
            {
                rbPageIncrement.Enabled = true;
                rbPageDecrement.Enabled = true;
            }
            if(storeDataShow is null || storeDataShow?.Count < PagedItemSize+1)
            {
                rbPageIncrement.Hide();
                rbPageDecrement.Hide();
                tbPageNumber.Hide();
            }
            else
            {
                rbPageIncrement.Show();
                rbPageDecrement.Show();
                tbPageNumber.Show();
            }
            tbPageNumber.Text = (currentPage + 1).ToString();
        }
        //button previous click
        private void rbPageDecrement_Click(object sender, EventArgs e)
        {
            currentPage--;
            tbPageNumber.Text = currentPage.ToString();
            if (currentPage <=0)
            {
                rbPageDecrement.Enabled = false;
                if (currentPage < 0)
                {
                    currentPage=0;
                    return;
                }
            }
            if (!rbPageIncrement.Enabled)
                rbPageIncrement.Enabled = true;
          
            UpdateUIListApply();
        }
        // button next click
        private void rbPageIncrement_Click(object sender, EventArgs e)
        {
            int PageMaxSize ;
            if (IsSearch)
                PageMaxSize = GetMaxPageNumber(SearchStoreData.Count);
            else
                PageMaxSize = GetMaxPageNumber(OriginStoreData.Count);

            currentPage++;
            tbPageNumber.Text = currentPage.ToString();
            if (currentPage >= PageMaxSize+1)
            {
                rbPageIncrement.Enabled = false;
                if (currentPage == PageMaxSize+1)
                {
                    currentPage = PageMaxSize;
                    return;
                }
            }
            if (!rbPageDecrement.Enabled)
                rbPageDecrement.Enabled = true;
            UpdateUIListApply();
        }
        private bool ValidationtbPageNumber()
        {
            int num = 0;
            if (int.TryParse(tbPageNumber.Text, out num))
            {
                int count=0;
                if (IsSearch)
                    count = (int)SearchStoreData?.Count;
                else
                    count = (int)OriginStoreData?.Count;

                if (num <= this.GetMaxPageNumber(count)+1 && num > 0)
                    return true;
            }
            return false;

        }
       // private int GetMaxPageNumber() =>  ((OriginStoreData?.Count - 1) ?? 0 )/ PagedItemSize ;

        private int GetMaxPageNumber(int count) => count > 0 ? (count - 1)  / PagedItemSize : 0;

        private void tbPageNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\r')
            {
                if(ValidationtbPageNumber())
                {
                    int num = 0;
                    int.TryParse(tbPageNumber.Text, out num);
                    currentPage = num-1;
                    e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                }
                UpdateUIListApply();
            }
            
        }
        private void tbPageNumber_Leave(object sender, EventArgs e)
        {
            if (ValidationtbPageNumber())
            {
                int num = 0;
                int.TryParse(tbPageNumber.Text, out num);
                currentPage = num - 1; 
            }
            UpdateUIListApply();
        }
        private void LoadStoreData()
        {
            OriginStoreData = parentForm.StoreDataItems;
            UpdateUIListApply();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(UpdateStoreData!=null && UpdateStoreData.Count>0)
            { 
                parentForm.UpdateStoreData(UpdateStoreData);
                UpdateStoreData.Clear();
                LoadStoreData();
            }
            else
                MessageBox.Show("尚未有需要更新的資料", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteStoreData.Add(OriginStoreData[OriginStoreData.Count-1]);
            parentForm.DeleteStoreData(DeleteStoreData);
            DeleteStoreData.Clear();
            LoadStoreData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            new SearchForm(this).ShowDialog();
        }

        private void pbCloseSearch_Click(object sender, EventArgs e)
        {
            IsSearch = false;
            SearchCondition = null;
            SearchStoreData.Clear();
            panelSearchInfo.Hide();
            
            UpdateUIListApply();
        }
    }

    public class DateIsNotOk : Exception {
        public string ErrorMessage{get; set;}

        public  DateIsNotOk(string msg) { ErrorMessage = msg;  }
    }
    public class CustomerCountIsNotOk : Exception {
        public string ErrorMessage { get; set; }
        public CustomerCountIsNotOk(string msg) { ErrorMessage = msg; }
    }

    

}
