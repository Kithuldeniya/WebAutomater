using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace UserAction
{
    public class UserActions
    {
        public UserActions()
        {
            var IS = new InputSimulator();
            UserMouse = new UserMouse(IS);
            UserKeyboard = new UserKeyboard(IS);
        }
        public UserMouse UserMouse { get; set; }
        public UserKeyboard UserKeyboard { get; set; }
    }
}
