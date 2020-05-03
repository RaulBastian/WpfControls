using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfCustomControls
{
    public class ShappedContentControl:ContentControl
    {
        private Border border = null;
        public Border Border {
            get {
                return border;
            }
            set {

                if(border != null)
                {
                    border.MouseEnter -= Border_MouseEnter;
                    border.MouseLeave -= Border_MouseLeave;
                }

                this.border = value;

                if(this.border != null)
                {
                    border.MouseEnter += Border_MouseEnter;
                    border.MouseLeave += Border_MouseLeave;
                }
            }
        }

        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            UpdateStates(false);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.Border = this.GetTemplateChild("Border") as Border;
        }

        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            UpdateStates(true);
        }

        private void UpdateStates(bool isMouseOver)
        {
            if(isMouseOver)
            {
                VisualStateManager.GoToState(this, "MouseOver", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "Normal", true);
            }
        }
    }
}
