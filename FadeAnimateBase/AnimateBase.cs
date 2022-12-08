using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace AnimateBase
{
    public class AnimateBase
    {
        protected Control m_AnimatedControl;
        protected Timer m_Timer;
        //public delegate void PostAnimateEventHandler(object sender, AnimateBaseEventArg e);

        public event EventHandler<AnimateBaseEventArg> PostAnimateEvent;
        private bool IsEnd;
        public bool IsRunning{ get => isRunning(); }
        public Control AnimatedControl
        {
            get => m_AnimatedControl;
        }

      /*  public bool IsRun
        {
            get => m_Timer.Enabled;
        }*/

        public AnimateBase(Control l_AnimatedControl)
        {
            init(l_AnimatedControl);

        }

        private void init(Control l_AnimatedControl)
        {
            m_AnimatedControl = l_AnimatedControl;
            m_Timer = new Timer();
            m_Timer.Tick += M_Timer_Tick;
            m_Timer.Interval = 80;
        }

        private void M_Timer_Tick(object sender, EventArgs e)
        {
            RunProcess();
            if (IsEndProcess())
                EndSetting();
            if (IsEnd)
            {
               // Debug.WriteLine("before call PostAnimateEvent");
                PostAnimateEvent?.Invoke(this, new AnimateBaseEventArg(this.m_AnimatedControl));
                EndProcess();
            }
            
        }
        protected virtual void EndProcess()
        {

        }
        protected virtual void EndSetting()
        {
            IsEnd = true;
            m_Timer.Stop();
        }

        protected virtual void RunProcess()
        {
            
        }

        protected virtual bool IsEndProcess()
        {
            return true;
        }

        public virtual void RunAnimatie() {
            IsEnd = false;
            if (isRunning())
                return;
            CalculateArgment();
            m_Timer.Start();
        }

        protected virtual void CalculateArgment()
        {
            
        }

        public void StopAnimatie()
        {
            IsEnd = true;
            m_Timer.Stop();
        }
        private bool isRunning() => m_Timer?.Enabled ?? false;


    }

    public class AnimateBaseEventArg
    {
        public Control m_AnimatedControl;
        public AnimateBaseEventArg(Control l_AnimatedControl) => m_AnimatedControl = l_AnimatedControl;


    }


}
