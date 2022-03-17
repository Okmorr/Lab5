using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Lab5.Views
{
    public partial class NoMainWindow : Window{
        public NoMainWindow(string OldRegex) : this(){
            this.FindControl<TextBox>("RegexInput").Text = OldRegex;
        }

        public NoMainWindow(){
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            this.FindControl<Button>("RegexC").Click += delegate{
                var regexStr = this.FindControl<TextBox>("RegexInput").Text;
                if (regexStr != null)
                    Close(regexStr);
                else
                    Close("");
            };

            this.FindControl<Button>("RegexOutput").Click += delegate{
                Close("");
            };
        }


        private void InitializeComponent(){
            AvaloniaXamlLoader.Load(this);
        }
    }
}