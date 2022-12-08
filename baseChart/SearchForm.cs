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
    enum SearchFormSelectItem
    {
        StartDate,
        EndDate
    }
    public partial class SearchForm : Form
    {
        private DataCreateForm parentForm;
        private ExpandAnimateBase ExpandAnimate;
        private SearchFormSelectItem SelectedSearchItem;

        public SearchForm(DataCreateForm parent)
        {
            parentForm = parent;
            InitializeComponent();
          
        }

        private void tbSearchStartDate_Enter(object sender, EventArgs e)
        {
            // this.btnOK.Visible = true;
            SelectedSearchItem = SearchFormSelectItem.StartDate;
            this.monthCalendarSearch.Visible = true;
        }

        private void tbSearchEndDate_Enter(object sender, EventArgs e)
        {
            SelectedSearchItem = SearchFormSelectItem.EndDate;
            //  this.btnOK.Visible = true;
            this.monthCalendarSearch.Visible = true;
        }

        private void monthCalendarSearch_DateSelected(object sender, DateRangeEventArgs e)
        {
            


            if (SelectedSearchItem == SearchFormSelectItem.StartDate)
            {
                tbSearchStartDate.Text = monthCalendarSearch.SelectionStart.ToString("yyyy/MM/dd");
            }
            else if (SelectedSearchItem == SearchFormSelectItem.EndDate)
            {
                tbSearchEndDate.Text = monthCalendarSearch.SelectionStart.ToString("yyyy/MM/dd");
            }

            if (!compareStartDateAndEndDate())
            {

                if (SelectedSearchItem == SearchFormSelectItem.StartDate)
                    tbSearchStartDate.Text = "";

                else if (SelectedSearchItem == SearchFormSelectItem.EndDate)
                    tbSearchEndDate.Text = "";
                
                MessageBox.Show("起始日期無法大於結束日期", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.monthCalendarSearch.Visible = false;
            
        }
                

        private bool compareStartDateAndEndDate()
        {
            if(tbSearchStartDate.Text.Trim()!="" && tbSearchEndDate.Text.Trim() != "")
            {
                DateTime start, end;
                DateTime.TryParseExact(tbSearchStartDate.Text, "yyyy/MM/dd",
                    null,System.Globalization.DateTimeStyles.None,out start);
                DateTime.TryParseExact(tbSearchEndDate.Text, "yyyy/MM/dd",
                    null, System.Globalization.DateTimeStyles.None, out end);

                if((end-start).Ticks < 0 )
                    return false;
                   // MessageBox.Show("起始日期無法大於結束日期", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

            }

            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            StoreDataSearch data = new StoreDataSearch();
            if (tbSearchStartDate.Text.Trim() != "")
            {
                if (parentForm.ValidationDate(tbSearchStartDate.Text.Trim()))
                {
                    data.StartDate = tbSearchStartDate.Text.Trim();
                }
                else
                {
                    MessageBox.Show("起始日期錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }


            if (tbSearchEndDate.Text.Trim() != "")
            {
                if (parentForm.ValidationDate(tbSearchEndDate.Text.Trim()))
                {
                    data.EndDate = tbSearchEndDate.Text.Trim();
                }
                else
                {
                    MessageBox.Show("結束日期日期錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            if (!compareStartDateAndEndDate())
            {
                MessageBox.Show("起始日期無法大於結束日期", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            parentForm.SaveStoreDataSearch(data);

            this.Close();
        }
    }
 
}
