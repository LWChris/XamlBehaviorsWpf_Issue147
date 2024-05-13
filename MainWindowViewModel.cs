using Prism.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace XamlBehaviorsTest
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            MakeReadOnlyCommand = new DelegateCommand<DependencyObject>(MakeReadOnly);
        }

        public ICommand MakeReadOnlyCommand { get; }

        private void MakeReadOnly(DependencyObject parent)
        {
            SetTextBoxesReadOnly(parent, true);
        }

        private static void SetTextBoxesReadOnly(DependencyObject parent, bool isReadOnly)
        {
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is TextBox textBox)
                {
                    textBox.IsReadOnly = isReadOnly;
                } else
                {
                    SetTextBoxesReadOnly(child, isReadOnly);
                }
            }
        }
    }
}
