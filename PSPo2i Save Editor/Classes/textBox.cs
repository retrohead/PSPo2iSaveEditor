using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace PSPo2i_Save_Editor
{ 
    public class TextBoxEnterKeyUpdateBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            if (AssociatedObject != null)
            {
                base.OnAttached();
                TextBox item = AssociatedObject;
                item.AddHandler(TextBox.PreviewKeyDownEvent, new KeyEventHandler(AssociatedObject_KeyDown));
            }
        }

        protected override void OnDetaching()
        {
            if (this.AssociatedObject != null)
            {
                TextBox item = AssociatedObject;
                item.RemoveHandler(TextBox.PreviewKeyDownEvent, new KeyEventHandler(AssociatedObject_KeyDown));
                base.OnDetaching();
            }
        }

        private void AssociatedObject_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (e.Key == Key.Enter)
                    ((TextBox)e.OriginalSource).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
    }
}
