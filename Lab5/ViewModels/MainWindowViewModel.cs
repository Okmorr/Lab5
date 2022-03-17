using ReactiveUI;
using System.Text.RegularExpressions;

namespace Lab5.ViewModels
{
	public class MainWindowViewModel : ViewModelBase{
		string input = "";
		string output = "";
		string regex = "";
		public string Regex{
			get => regex;
			set{
				if (value != null)
					regex = value;
			}
		}
		public string Input{
			get => input;
			set{
				output = "";
				if (Regex != "")
				{
					Regex rgx = new Regex(Regex);
					foreach (Match match in rgx.Matches(value))
						Output += match.Value + "\n";
					if (Output == "")
						Output = "Совпадений не найдены!";
				}
				this.RaiseAndSetIfChanged(ref input, value);
			}
		}

		public string Output{
			get => output;
			set{
				if (Regex == "")
					this.RaiseAndSetIfChanged(ref output, "Ошибка");
				else
					this.RaiseAndSetIfChanged(ref output, value);
			}
		}

	}

}