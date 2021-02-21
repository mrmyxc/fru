using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace fru.Views
{
    public class BoardAreaView : UserControl
    {
        public BoardAreaView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
