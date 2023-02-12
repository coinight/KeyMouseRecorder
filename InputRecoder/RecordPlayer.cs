using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static InputRecoder.inputHepler;

namespace InputRecoder
{
    internal class RecordPlayer
    {
        public static void Decode(string data)
        {
            if (data == null) { return; }
            var code = data.Split('&');
            switch(code[0])
            {
                case "kdown":
                    inputHepler.VirtualKeyEvent((byte)int.Parse(code[1]), inputHepler.KeyPressState.Pressed);
                    break;
                case "wait":
                    Thread.Sleep(int.Parse(code[1]));
                    break;
                case "kup":
                    inputHepler.VirtualKeyEvent((byte)int.Parse(code[1]), inputHepler.KeyPressState.Release);
                    break;
                case "ms":
                    var pos0 = code[1].Split(',');
                    int x0 = int.Parse(pos0[0]);
                    int y0 = int.Parse(pos0[1]);
                    inputHepler.SetCursorPos(x0, y0);
                    break;
                case "msdown":
                    var pos = code[1].Split(',');
                    int x = int.Parse(pos[0]);
                    int y = int.Parse(pos[1]);
                    inputHepler.SetCursorPos(x, y);
                    switch (code[3])
                    {
                        case "Left":

                            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
                            break;
                        case "Right":
                            mouse_event(MouseEventFlag.RightDown, 0, 0, 0, UIntPtr.Zero);
                            break;
                        case "Middle":
                            mouse_event(MouseEventFlag.MiddleDown, 0, 0, 0, UIntPtr.Zero);
                            break;
                        default:
                            break;
                    }
                    break;
                case "msup":
                    var pos2 = code[1].Split(',');
                    int x2 = int.Parse(pos2[0]);
                    int y2 = int.Parse(pos2[1]);
                    inputHepler.SetCursorPos(x2, y2);

                    switch (code[3])
                    {
                        case "Left":

                            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
                            break;
                        case "Right":
                            mouse_event(MouseEventFlag.RightUp, 0, 0, 0, UIntPtr.Zero);
                            break;
                        case "Middle":
                            mouse_event(MouseEventFlag.MiddleUp, 0, 0, 0, UIntPtr.Zero);
                            break;
                        default:
                            break;
                    }
                    break;
                case "mswheel":
                    var temp = int.Parse(code[1]);
                    Debug.Print(""+temp);
                    uint temp2 = temp > 0 ?(uint)temp : ~(uint)-temp + 1;
                    mouse_event(MouseEventFlag.Wheel, 0, 0,temp2 , UIntPtr.Zero);
                    break;

            }
        }
    }
}
