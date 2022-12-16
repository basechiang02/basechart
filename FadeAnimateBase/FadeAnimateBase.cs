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
    public enum FadeAnimateBaseEffect
    {
        FadeIn,
        FadeOut,
        FadeToggle
    }
    public class FadeAnimateBaseRunningUpdatePropertyException : Exception
    {
        public FadeAnimateBaseRunningUpdatePropertyException(string msg)
        {

        }
    }

    public class FadeAnimateBase : AnimateBase
    {

        private FadeAnimateBaseEffect _CurrentEffectType;
        protected int ControlAlpha;
        protected int CurrrentControlAlpha;
        protected Color ControlColor;
        private int Increment;
        protected FadeAnimateBaseEffect CurrentEffectType { get => _CurrentEffectType; set=> _CurrentEffectType = value; }
        public const int CONTROL_ALPHA_MAX = 255;
        public const int CONTROL_ALPHA_MIN = 0;
        
       
        public bool FadeAnimateToggle {
                        get => m_FadeAnimateToggle;
                        set {
                            if (!this.IsRunning)
                            {
                                m_FadeAnimateToggle = value;
                            }
                            else
                                throw new FadeAnimateBaseRunningUpdatePropertyException("Timer is running");  
                        }
                    }
        /// <summary>
        /// true:fade in.
        /// false: fade out.
        /// </summary>
       
        protected bool m_FadeAnimateToggle=true;
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


        public FadeAnimateBase(Control animatedobject,FadeAnimateBaseEffect effectType) :base(animatedobject)
        {
            Init(animatedobject, effectType);
        }
       
        protected override void RunProcess()
        {
            if (_CurrentEffectType == FadeAnimateBaseEffect.FadeIn)
            {
                FadeIn_Tick_Process();
            }
            else if (_CurrentEffectType == FadeAnimateBaseEffect.FadeOut)
            {
                FadeOut_Tick_Process();
            }
            else if (_CurrentEffectType == FadeAnimateBaseEffect.FadeToggle)
            {
                if (m_FadeAnimateToggle)
                    FadeIn_Tick_Process();
                else
                    FadeOut_Tick_Process();
            }

            m_AnimatedControl.BackColor = Color.FromArgb(CurrrentControlAlpha, m_AnimatedControl.BackColor);
            if (!m_AnimatedControl.Visible)
            {
                m_AnimatedControl.Show();
            }
        }

        protected override bool IsEndProcess()
        {
            if(CurrrentControlAlpha == ControlColor.A || CurrrentControlAlpha == CONTROL_ALPHA_MIN)
                return true;
            else
                return false;
        }

        protected void Init(Control animatedobject, FadeAnimateBaseEffect effectType)
        {
            ControlAlpha = animatedobject.BackColor.A;
           
            _CurrentEffectType = effectType;
            ControlColor = animatedobject.BackColor;

            m_FadeAnimateToggle = !this.m_AnimatedControl.Visible;
            Increment = 15;
        }

        protected override void EndSetting()
        {
            base.EndSetting();
            CurrrentControlAlpha = ControlAlpha;
            m_AnimatedControl.BackColor = ControlColor;
            if (AutoControlVisible)
            {
                // m_FadeAnimateToggle 
                //true:fade in ,false: fade out
                if (m_FadeAnimateToggle)
                {
                    //collaspe end
                    m_AnimatedControl.Show();
                }
                else
                {
                    m_AnimatedControl.Hide();
                }
            }
        }
        protected void FadeIn_Init()
        {
            CurrrentControlAlpha = CONTROL_ALPHA_MIN;
        }
        protected void FadeIn_Tick_Process()
        {
            CurrrentControlAlpha += Increment;
            if (CurrrentControlAlpha > ControlAlpha)
            {
                CurrrentControlAlpha = ControlAlpha;
            }
        }
        protected void FadeOut_Init()
        {
            CurrrentControlAlpha = ControlAlpha;
        }
        protected void FadeOut_Tick_Process()
        {
            CurrrentControlAlpha -= Increment;
            if (CurrrentControlAlpha < CONTROL_ALPHA_MIN)
            {
                CurrrentControlAlpha = CONTROL_ALPHA_MIN;
            }
        }

        public override void RunAnimatie()
        {

            base.RunAnimatie();
        }

        protected override void EndProcess()
        {
            base.EndProcess();
            if (_CurrentEffectType == FadeAnimateBaseEffect.FadeToggle)
            {
                m_FadeAnimateToggle = !m_FadeAnimateToggle;
            }
        }

        protected override void CalculateArgment()
        {
            base.CalculateArgment();
            Increment = 30;
            if (CurrentEffectType == FadeAnimateBaseEffect.FadeIn)
            {
                m_FadeAnimateToggle = true;
                CurrrentControlAlpha = CONTROL_ALPHA_MIN;
            }
            else if (CurrentEffectType == FadeAnimateBaseEffect.FadeOut)
            {
                m_FadeAnimateToggle = false;
                CurrrentControlAlpha = ControlAlpha;
            }
            else if (CurrentEffectType == FadeAnimateBaseEffect.FadeToggle)
            {
                if (m_FadeAnimateToggle) // fade in 
                    CurrrentControlAlpha = CONTROL_ALPHA_MIN;
                else
                    CurrrentControlAlpha = ControlAlpha;
            }
        }

    }
}
