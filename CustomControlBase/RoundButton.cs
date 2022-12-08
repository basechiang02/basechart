using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControlBase
{
    public partial class RoundButton : Button
    {
        private System.Drawing.Color hoverColor = System.Drawing.SystemColors.ButtonHighlight;
        private System.Drawing.Color DisableColor = System.Drawing.SystemColors.ControlDark;
        private System.Drawing.Color DisableTextColor = System.Drawing.SystemColors.ControlLight;

        private System.Drawing.Color orginBackColor;
       
        private bool isHover =false;
        private bool isEnable = true;
        public System.Drawing.Color HoverColor
        {
            get;
            set;
        } = SystemColors.Highlight;

        public RoundButton()
        {
            InitializeComponent();
        }
    
        
        protected override void OnPaint(PaintEventArgs pe)
        {
           
            GraphicsPath grPath = new GraphicsPath();
            System.Drawing.Rectangle roundButtonRectangle = this.ClientRectangle;
            System.Drawing.Rectangle textRectangle = this.ClientRectangle;
            Pen edgePen = null;
            SolidBrush customSolidBrush = null;
            roundButtonRectangle.Inflate(-4, -4);

            StringFormat stringFormat = new StringFormat();
            if (this.TextAlign == ContentAlignment.MiddleCenter)
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
            }

            base.OnPaint(pe);
           

            if (isHover)
            {
                edgePen = new Pen(HoverColor, 1);
                //edge color
                pe.Graphics.DrawEllipse(edgePen, roundButtonRectangle);
            }

            if (!this.Enabled)
            {
                //override region
                customSolidBrush = new SolidBrush(DisableColor);
                SolidBrush customSolidBrushText = new SolidBrush(this.DisableTextColor);
                pe.Graphics.FillEllipse(customSolidBrush, roundButtonRectangle);           
                pe.Graphics.DrawString(this.Text,this.Font, customSolidBrushText
                                       , textRectangle, stringFormat);
                customSolidBrushText.Dispose();
            }

            edgePen?.Dispose();
            customSolidBrush?.Dispose();
            roundButtonRectangle.Inflate(1, 1);
            grPath.AddEllipse(roundButtonRectangle);
            this.Region = new System.Drawing.Region(grPath);

        }
        protected override void OnBackColorChanged(EventArgs e)
        {
            
            base.OnBackColorChanged(e);
            if (!isHover && isEnable)
            {
                if(BackColor != DisableColor)
                    orginBackColor = BackColor;
            }
                    
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            isHover = true;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHover = false;
            base.OnMouseLeave(e);
        }

    }
}
