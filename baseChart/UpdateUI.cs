using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace baseChart
{
    //[Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class UpdateUI : UserControl
    {
        public Label LableId
        {
            get
            {
                return this.lblUpdateId;
            }
          
        }
        public Label LabelUpdateIdTilte { get => this.lblUpdateIdTilte; }
        public Label LabelUpdateDate { get => this.lblUpdateDate; }
        public Label LabelUpdateCustomerCount { get => this.lblUpdateCustomerCount; }
        public Label LabelUpdateDateStar { get => this.lblUpdateDateStar; }
        public Label LabelUpdateCustomerStar { get => this.lblUpdateCustomerStar; }

        public TextBox TextBoxUpdateDate { get => this.tbUpdateDate; }
        public TextBox TextBoxUpdateCustomerCount { get => this.tbUpdateCustomerCount; }

        public UpdateUI()
        {
            InitializeComponent();
        }
    }
}
