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
    public partial class TestForm : Form
    {

        private ExpandAnimateBase b;
        private ExpandAnimateBase a;
        private ExpandAnimateBase c;
        private FadeAnimateBase d;
        
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        public TestForm()
        {
           
            InitializeComponent();
            a = new ExpandAnimateBase(panelLeft, ExpandAnimateBaseEffect.Callaspe, ExpandAnimateBaseEffectDirection.LeftRight);
            b = new ExpandAnimateBase(panelLeft, ExpandAnimateBaseEffect.ExpandToggle, ExpandAnimateBaseEffectDirection.LeftRight);
            c = new ExpandAnimateBase(panelLeft, ExpandAnimateBaseEffect.Expand, ExpandAnimateBaseEffectDirection.LeftRight);
            d = new FadeAnimateBase(panelLeft, FadeAnimateBaseEffect.FadeToggle);

            animateBaseManager1.Add(a);
            animateBaseManager1.Add(b);
            animateBaseManager1.Add(c);
            animateBaseManager1.Add(d);
        }
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await animateBaseManager1.Run(b);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await animateBaseManager1.Run(a);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await animateBaseManager1.Run(c);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await animateBaseManager1.Run(d);
        }
    }
}
