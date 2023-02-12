using System;
using System.Runtime.InteropServices;

namespace InputRecoder
{
    internal class inputHepler
    {

        public enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000,
            HWHEEL = 0x10000
        }
        [DllImport("user32.dll")]
        public static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);
        /// <param name="bVk" >按键的虚拟键值</param>
        /// <param name= "bScan" >扫描码，一般不用设置，用0代替就行</param>
        /// <param name= "dwFlags" >选项标志：0：表示按下，2：表示松开</param>
        /// <param name= "dwExtraInfo">一般设置为0</param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public enum KeyPressState : int
        {
            Pressed = 0,Release = 2
        }
        public static void VirtualKeyEvent(byte keyCode,KeyPressState state)
        {
            keybd_event(keyCode, 0, (int)state, 0);
        }
        public static void KeyInput(byte keyCode)
        {
            inputHepler.VirtualKeyEvent(keyCode, inputHepler.KeyPressState.Pressed);
            inputHepler.VirtualKeyEvent(keyCode, inputHepler.KeyPressState.Release);
        }
        public static void LeftClickAt(int x, int y)
        {

            SetCursorPos(x, y);
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }
        public static void RightClickAt(int x, int y)
        {

            SetCursorPos(x, y);
            mouse_event(MouseEventFlag.RightDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.RightUp, 0, 0, 0, UIntPtr.Zero);
        }

        public static void MiddleClickAt(int x, int y)
        {

            SetCursorPos(x, y);
            mouse_event(MouseEventFlag.MiddleDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.MiddleUp, 0, 0, 0, UIntPtr.Zero);
        }
        public static void WheelAt(int x, int y, uint delta)
        {

            LeftClickAt(x, y);
            mouse_event(MouseEventFlag.Wheel, 0, 0, delta, UIntPtr.Zero);
        }
    }
}
