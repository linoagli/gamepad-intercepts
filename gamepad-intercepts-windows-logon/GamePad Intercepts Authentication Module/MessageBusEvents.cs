using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePad_Intercepts_Authentication_Module
{
    class MessageBusEvents
    {
        public const string CONTROLLER_INPUT_MODE_MOUSE_AND_KEYBOARD = "controller_inputMode_mouseAndKeyboard";
        public const string CONTROLLER_INPUT_MODE_ON_SCREEN_KEYBOARD = "controller_inputMode_onScreenKeyboard";
        public const string CONTROLLER_INPUT_MODE_PIN_PAD = "controller_inputMode_pinPad";

        public const string CONTROLLER_SEARCHING = "controller_searching";
        public const string CONTROLLER_CONNECTED = "controller_connected";
        public const string CONTROLLER_SEND_KEY = "controller_sendKey";

        public const string CONTROLLER_ACTION_BACKSPACE = "controller_actionBackSpace";
        public const string CONTROLLER_ACTION_FINISH = "controller_actionFinish";
        public const string CONTROLLER_ACTION_QUIT = "controller_actionQuit";

        public const string CONTROLLER_INPUT_LEFT = "controller_inputLeft";
        public const string CONTROLLER_INPUT_UP = "controller_inputUp";
        public const string CONTROLLER_INPUT_RIGHT = "controller_inputRight";
        public const string CONTROLLER_INPUT_DOWN = "controller_inputDown";
        public const string CONTROLLER_INPUT_CROSS = "controller_inputCross";
        public const string CONTROLLER_INPUT_SQUARE = "controller_inputSquare";
        public const string CONTROLLER_INPUT_TRIANGLE = "controller_inputTriangle";
        public const string CONTROLLER_INPUT_CIRCLE = "controller_inputCircle";
        public const string CONTROLLER_INPUT_R1 = "controller_inputR1";
        public const string CONTROLLER_INPUT_R2 = "controller_inputR2";
        public const string CONTROLLER_INPUT_L1 = "controller_inputL1";
        public const string CONTROLLER_INPUT_L2 = "controller_inputL2";
        public const string CONTROLLER_INPUT_START = "controller_inputStart";

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
