using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace UserAction
{
    public class UserKeyboard : KeyboardSimulator, IKeyboardSimulator
    {
        public UserKeyboard(IInputSimulator inputSimulator) : base(inputSimulator)
        { 
        }
    }
}
