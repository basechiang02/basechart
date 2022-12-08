using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;

namespace AnimateBase
{
    public enum ExpandAnimateBaseEffect
    {
        Expand,
        Callaspe,
        ExpandToggle
    }

    public enum ExpandAnimateBaseEffectDirection
    {
        UpDown,
        LeftRight
    }

    public class ExpandAnimateBaseRunningUpdatePropertyException : Exception
    {
        public ExpandAnimateBaseRunningUpdatePropertyException(string msg)
        {

        }
    }

    public class ExpandAnimateBase : AnimateBase
    {
       // protected Control AnimatedSourceObject;
      //  protected int AnimatedSourceObject_Alpha;
      //  protected int AnimatedSourceObject_CurrrentAlpha;
      //  protected Timer timer;
        private ExpandAnimateBaseEffect _CurrentEffectType;
        protected int ControlHeightWidth;
        protected int CurrentControlHeightWidth;
        private int Increment;
        private int DefaultIncrement = 25;
        protected ExpandAnimateBaseEffect CurrentEffectType { get => _CurrentEffectType; set=> _CurrentEffectType = value; }
      //  public const int CONTROL_ALPHA_MAX = 255;
        public const int CONTROL_HEIGHT_MIN = 0;
        public const int CONTROL_WIDTH_MIN = 0;
        public bool ControlShow=false;
        private ExpandAnimateBaseEffectDirection _direction;
        public ExpandAnimateBaseEffectDirection Direction {
                                                    get => this._direction;
                                                    set {
                                                        if (!this.IsRunning)
                                                            this._direction = value;
                                                    }
                                        }
        private bool _autoControlVisibl = true;
        public bool AutoControlVisible
        {
            get => this._autoControlVisibl;
            set
            {
                if (!this.IsRunning)
                    this._autoControlVisibl = value;
            }
        }

        public bool ExpandAnimateToggle {
                        get => m_ExpandAnimateToggle;
                        set {
                            if (!this.IsRunning)
                            {
                                m_ExpandAnimateToggle = value;
                            }
                            else
                                throw new ExpandAnimateBaseRunningUpdatePropertyException("Timer is running");
                            
                        }

                    }
        /// <summary>
        /// true:Expand in.
        /// false: Expand out.
        /// </summary>
       
        protected bool m_ExpandAnimateToggle=true;

        public ExpandAnimateBase(Control animatedobject,ExpandAnimateBaseEffect effectType) :base(animatedobject)
        {
            
            this.Direction = ExpandAnimateBaseEffectDirection.UpDown;
            Init(animatedobject, effectType);

            //    timer_init(50);
            // AnimatedSourceObject.BackColor = Color.FromArgb(0, AnimatedSourceObject.BackColor);
        }
        public ExpandAnimateBase(Control animatedobject, ExpandAnimateBaseEffect effectType, ExpandAnimateBaseEffectDirection direction) : base(animatedobject)
        {
            this.Direction = direction;
            Init(animatedobject, effectType);

        }
        protected override void RunProcess()
        {

            if(_CurrentEffectType == ExpandAnimateBaseEffect.Expand)
            {
                Expand_Tick_Process();
            }
            else if(_CurrentEffectType == ExpandAnimateBaseEffect.Callaspe)
            {
                Callaspe_Tick_Process();
            }
            else if(_CurrentEffectType == ExpandAnimateBaseEffect.ExpandToggle)
            {
               
                if (m_ExpandAnimateToggle)
                    Expand_Tick_Process();
                else
                    Callaspe_Tick_Process();
            }
            // Debug.WriteLine("Current a:{0}", CurrrentControlAlpha);
            //  Console.WriteLine("current :" + CurrentControlHeightWidth);
            if (this.Direction == ExpandAnimateBaseEffectDirection.UpDown)
                m_AnimatedControl.Height = CurrentControlHeightWidth;
            else if (this.Direction == ExpandAnimateBaseEffectDirection.LeftRight)
                m_AnimatedControl.Width = CurrentControlHeightWidth;

            if (!m_AnimatedControl.Visible)
            {
                m_AnimatedControl.Show();
            }

            //  m_AnimatedControl.Invalidate();
        }

        protected override bool IsEndProcess()
        {
            int defaultMinValue = 0;
            if (this.Direction == ExpandAnimateBaseEffectDirection.UpDown)
                defaultMinValue = CONTROL_HEIGHT_MIN;
            if (this.Direction == ExpandAnimateBaseEffectDirection.UpDown)
                defaultMinValue = CONTROL_WIDTH_MIN;


            if (CurrentControlHeightWidth == ControlHeightWidth || CurrentControlHeightWidth <= defaultMinValue)
                return true;
            else
                return false;
        }

        protected void Init(Control animatedobject, ExpandAnimateBaseEffect effectType)
        {
         
            //CurrrentControlAlpha = ControlAlpha;
           
            _CurrentEffectType = effectType;
           // ControlColor = new Color();
            
            Increment = DefaultIncrement;

            m_ExpandAnimateToggle = this.m_AnimatedControl.Visible;
           // m_Timer.Interval = 500;
        }

        protected override void EndSetting()
        {
            base.EndSetting();
            CurrentControlHeightWidth = ControlHeightWidth;
            //m_AnimatedControl.BackColor = Color.FromArgb(CurrrentControlAlpha, m_AnimatedControl.BackColor);
            if(this.Direction == ExpandAnimateBaseEffectDirection.UpDown)
                m_AnimatedControl.Height = ControlHeightWidth;
            else if(this.Direction == ExpandAnimateBaseEffectDirection.LeftRight)
                m_AnimatedControl.Width = ControlHeightWidth;

            if(AutoControlVisible)
            {
                // m_ExpandAnimateToggle 
                //true:expend ,false: callaspe
                if (m_ExpandAnimateToggle)
                {
                    //collaspe end
                    m_AnimatedControl.Show();
                }
                else
                {
                    m_AnimatedControl.Hide();
                }
            }
            else
            {
                if (ControlShow)
                    m_AnimatedControl.Show();
                else
                    m_AnimatedControl.Hide();
            }
            
            //AnimatedControl.Invalidate();
        }
        protected void Expand_Init()
        {
            if(this.Direction == ExpandAnimateBaseEffectDirection.UpDown)
                CurrentControlHeightWidth = CONTROL_HEIGHT_MIN;
            else if (this.Direction == ExpandAnimateBaseEffectDirection.LeftRight)
                CurrentControlHeightWidth = CONTROL_WIDTH_MIN;
        }
        protected void Expand_Tick_Process()
        {
            CurrentControlHeightWidth += Increment;
            if (CurrentControlHeightWidth > ControlHeightWidth)
            {
                CurrentControlHeightWidth = ControlHeightWidth;
            }

        }
        protected void Callaspe_Init()
        {
            CurrentControlHeightWidth = ControlHeightWidth;
        }
        protected void Callaspe_Tick_Process()
        {
            CurrentControlHeightWidth -= Increment;
            if(this.Direction == ExpandAnimateBaseEffectDirection.UpDown)
            {
                if (CurrentControlHeightWidth < CONTROL_HEIGHT_MIN)
                {
                    CurrentControlHeightWidth = CONTROL_HEIGHT_MIN;
                }
            }
            else if (this.Direction == ExpandAnimateBaseEffectDirection.LeftRight)
            {
                if (CurrentControlHeightWidth < CONTROL_WIDTH_MIN)
                {
                    CurrentControlHeightWidth = CONTROL_WIDTH_MIN;
                }
            }

        }

        public override void RunAnimatie()
        {
            
            base.RunAnimatie();
        }

        protected override void EndProcess()
        {
            base.EndProcess();

            if (_CurrentEffectType == ExpandAnimateBaseEffect.ExpandToggle)
            {
                m_ExpandAnimateToggle = !m_ExpandAnimateToggle;
            }
        }

        protected override void CalculateArgment()
        {
            base.CalculateArgment();
            //m_Timer.Interval = 80;
            if(this.Direction == ExpandAnimateBaseEffectDirection.UpDown)
            {
                Increment = m_AnimatedControl.Height / 12;
                ControlHeightWidth = m_AnimatedControl.Height;
            } 
            else if (this.Direction == ExpandAnimateBaseEffectDirection.LeftRight)
            {
                Increment = m_AnimatedControl.Width / 12;
                ControlHeightWidth = m_AnimatedControl.Width;
            }
               
            //Console.WriteLine(Increment);
            if (Increment <= 0)
                Increment = DefaultIncrement;

            if (CurrentEffectType == ExpandAnimateBaseEffect.Expand)
            {
                m_ExpandAnimateToggle = true;
                if(this.Direction == ExpandAnimateBaseEffectDirection.UpDown)
                    CurrentControlHeightWidth = CONTROL_HEIGHT_MIN;
                if (this.Direction == ExpandAnimateBaseEffectDirection.LeftRight)
                    CurrentControlHeightWidth = CONTROL_WIDTH_MIN;
            }
            else if (CurrentEffectType == ExpandAnimateBaseEffect.Callaspe)
            {
                m_ExpandAnimateToggle = false;
                CurrentControlHeightWidth = ControlHeightWidth;
            }
            else if (CurrentEffectType == ExpandAnimateBaseEffect.ExpandToggle)
            {

                if (m_ExpandAnimateToggle) // Expand  
                {
                    if (this.Direction == ExpandAnimateBaseEffectDirection.UpDown)
                        CurrentControlHeightWidth = CONTROL_HEIGHT_MIN;
                    if (this.Direction == ExpandAnimateBaseEffectDirection.LeftRight)
                        CurrentControlHeightWidth = CONTROL_WIDTH_MIN;
                }
                else
                    CurrentControlHeightWidth = ControlHeightWidth;
            }
            if (this.Direction == ExpandAnimateBaseEffectDirection.UpDown)
                m_AnimatedControl.Height = CurrentControlHeightWidth;
            else if (this.Direction == ExpandAnimateBaseEffectDirection.UpDown)
                m_AnimatedControl.Width = CurrentControlHeightWidth;
            ControlShow = m_AnimatedControl.Visible;

          /*  if (!m_AnimatedControl.Visible)
            {
                m_AnimatedControl.Show();
            }*/
                
        }

    }
}
