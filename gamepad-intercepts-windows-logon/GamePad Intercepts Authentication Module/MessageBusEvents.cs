using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePad_Intercepts_Authentication_Module
{
    class MessageBusEvents
    {
        public const string ENABLE_MOUSE_KEYBOARD_EMULATION = "enableMouseKeyboardEmulation";
        public const string DISABLE_MOUSE_KEYBOARD_EMULATION = "disableMouseKeyboardEmulation";

        public const string CONTROLLER_SEARCHING = "controller_searching";
        public const string CONTROLLER_CONNECTED = "controller_connected";
        public const string CONTROLLER_SEND_KEY = "controller_sendKey";
        public const string CONTROLLER_ACTION_BACKSPACE = "controller_actionBackSpace";
        public const string CONTROLLER_ACTION_FINISH = "controller_actionFinish";
        public const string CONTROLLER_ACTION_QUIT = "controller_actionQuit";

        public static string Join(params string[] messageParts)
        {
            return string.Join("|", messageParts);
        }

        public static string[] Split(string message)
        {
            return message.Split('|');
        }

        public static bool HasParts(string message)
        {
            return message.Contains("|");
        }
    }
}
