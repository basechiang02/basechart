using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimateBase
{
    public partial class AnimateBaseManager : Component
    {
        protected List<AnimateBase> ManagedItem;
        public bool IgnoreWaiting
        {
            set;
            get;
        } = false;
        public AnimateBaseManager()
        {
            InitializeComponent();
            ManagedItem = new List<AnimateBase>();
        }

        public AnimateBaseManager(IContainer container)
        {
            container.Add(this);
            
            InitializeComponent();
            ManagedItem = new List<AnimateBase>();
        }

        public void Add(AnimateBase animateBase)
        {
            if (animateBase != null)
            {
                int index = 0;
                index = this.ManagedItem.FindIndex((item) => item == animateBase);
                if (index < 0)
                    this.ManagedItem.Add(animateBase);
            }
        }

        public void Remove(AnimateBase animateBase)
        {
            if (animateBase != null)
            {
                this.ManagedItem.Remove(animateBase);
            }
        }


        public async Task Run(AnimateBase animateBase)
        {
            if (animateBase != null)
            {
                bool waiting = false;
                List<AnimateBase> FoundItems;
                // find front ones
                FoundItems = this.ManagedItem.FindAll((item) => {
                    if (item.AnimatedControl == animateBase.AnimatedControl
                        && item.IsRunning
                    )
                            return true;
                    return false;
                                });
                if (this.IgnoreWaiting && FoundItems?.Count > 0)
                    return;
                // wait front ones end
                do
                {
                    waiting = false;
                    foreach (AnimateBase item in FoundItems)
                    {
                        if (item.IsRunning)
                            waiting = true;
                    }
                    if(waiting)
                        await Task.Delay(50);
                } while (waiting);

                animateBase.RunAnimatie();

            }
        }

    }
}
