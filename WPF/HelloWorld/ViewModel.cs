using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class ViewModel : BindableBase
    {
        public ViewModel() {
            ChangeMessageCommand = new DelegateCommand<string>(
                (par) => GreetingMessage = par);
        }

        private string _greetingMessage = "Hello World!";
        public string GreetingMessage { 
            get=>_greetingMessage;
            set => SetProperty(ref _greetingMessage, value);                
        }

        public string NewMessage1 { get; } = "ばいばいワールド";
        public string NewMessage2 { get; } = "こんにちワールド";
        public DelegateCommand<string> ChangeMessageCommand { get; }      
    }
}
