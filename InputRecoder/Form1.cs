using Gma.System.MouseKeyHook;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static InputRecoder.inputHepler;

namespace InputRecoder
{
    public partial class InputRecoder : Form
    {
        private bool isRecoding = false;
        //private KeyEventHandler recodeKey = null;
        //private KeyboardHook keyboardHook = new KeyboardHook();
        private IKeyboardMouseEvents hook;
        private TextLine textLine;
        private StreamWriter file;
        private Stopwatch timerWatcch;
        private bool isRunningScript = false;
        private int lastX,lastY;
        /// <summary>
        /// 上一个录制的脚本文件
        /// </summary>
        private string lastCreateFile;
        public InputRecoder()
        {
            InitializeComponent();
            //textLine = new TextLine(14, listBox1);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            textLine = new TextLine(13, label1);
            buttonTriggerRocoder.Text = "开始录制";
            textLine.Clear();
            label2.Text = "" + (textLine.index);
            textLine.Show();

            hook = Hook.GlobalEvents();
            hook.KeyDown += HookCheckShotcut;
        }

        public bool IsRecoding
        {
            get => isRecoding; set
            {
                isRecoding = value;
                buttonTriggerRocoder.Text = value ? "停止录制" : "开始录制";
            }
        }

        #region 监听区域
        private void HookCommon()
        {
            if (timerWatcch.IsRunning)
            {
                textLine.AddLine("间隔时间:" + timerWatcch.ElapsedMilliseconds + "ms");
                file.WriteLine("wait&" + timerWatcch.ElapsedMilliseconds);
                timerWatcch.Restart();
            }
            else
            {
                timerWatcch.Start();
            }
        }
        private void HookOnKeyDown(object sender, KeyEventArgs e)
        {
            if(isInCheckShotcut(e.KeyValue))
            {
                return;
            }
            HookCommon();
            textLine.AddLine("按下按键" + ((int)e.KeyValue)+(char)e.KeyCode);
            file.WriteLine("kdown&" + e.KeyValue);
            textLine.Show();
        }
        private void HookOnKeyUp(object sender, KeyEventArgs e)
        {

            if (isInCheckShotcut(e.KeyValue))
            {
                return;
            }
            HookCommon();
            textLine.AddLine("松开按按键" + ((int)e.KeyValue));
            file.WriteLine("kup&" + e.KeyValue);
            textLine.Show();
        }
        private void HookOnMouseDown(object sender, MouseEventExtArgs e)
        {
            HookCommon();
            textLine.AddLine("点击鼠标&" + e.X +","+e.Y+"按键&"+e.Button);
            file.WriteLine("msdown&" + e.X + "," + e.Y+"&btn&"+e.Button);
            lastX = e.X;
            lastY = e.Y;
            textLine.Show();
        }
        private void HookOnMouseUp(object sender, MouseEventExtArgs e)
        {
            HookCommon();
            if(e.X != lastX || e.Y != lastY) { 
                textLine.AddLine("移动到" + e.X + "," + e.Y);
                file.WriteLine("ms&" + e.X + "," + e.Y);
                file.WriteLine("wait&1");
            }
            textLine.AddLine("松开鼠标&" + e.X + "," + e.Y + "&按键&" + e.Button);
            file.WriteLine("msup&" + e.X + "," + e.Y + "&btn&" + e.Button);

            textLine.Show();
        }
        private void HookOnMouseWheel(object sender, MouseEventArgs e)
        {
            HookCommon();
            textLine.AddLine("鼠标滚轮&" + e.Delta);
            file.WriteLine("mswheel&" + e.Delta);
            textLine.Show();
        }
        private void HookCheckShotcut(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 121)
            {
                test(null,null);
            }
            //f11
            if(e.KeyValue == 122)
            {
                if (!isRunningScript)
                {
                    RunRecoder();
                }
                return;
            }
            //f12
            else if (e.KeyValue == 123)
            {
                buttonTrigger();
                return;
            }

        }
        private bool isInCheckShotcut(int value)
        {
            return value == 123 || value == 122;

        }
        #endregion
        private void buttonTrigger()
        {
            IsRecoding = !IsRecoding;
            if (IsRecoding)
            {
                hook.KeyDown += HookOnKeyDown;
                hook.KeyUp += HookOnKeyUp;
                hook.MouseDownExt += HookOnMouseDown;
                hook.MouseUpExt += HookOnMouseUp;
                hook.MouseWheel += HookOnMouseWheel;

                timerWatcch = new Stopwatch();
                file =  new StreamWriter(FileUtils.CreateNoRepeatFile("./save.auto"));
            }
            else
            {
                hook.KeyDown -= HookOnKeyDown;
                hook.KeyUp -= HookOnKeyUp;
                hook.MouseDownExt -= HookOnMouseDown;
                hook.MouseUpExt -= HookOnMouseUp;
                hook.MouseWheel -= HookOnMouseWheel;
                timerWatcch = null;
                file.Close();
            }
        }

        
        
        private void buttonTriggerRocoder_Click(object sender, EventArgs e)
        {
            buttonTrigger();
        }
        private void textMouseWheelEvent(object sender, MouseEventArgs e)
        {
            textLine.SetShowIndexDelta(-e.Delta/120);
            label2.Text = "" + (textLine.index);
            textLine.Show();
        }

        private void clearLog_Click(object sender, EventArgs e)
        {
            textLine.Clear();
            label2.Text = "" + (textLine.index);
            textLine.Show();
        }
        
        private void test(object sender, EventArgs e)
        {
            mouse_event(MouseEventFlag.Wheel, 0, 0, ~(uint)120 + 1, UIntPtr.Zero);
        }
        private void RunRecoder()
        {
            if (LastChooseText.Text == "" || isRunningScript) return;
            isRunningScript = true;
            var temp = new StreamReader(LastChooseText.Text);
            var temp2 = temp.ReadLine();
            while (temp2 != null)
            {
                Debug.Print(temp2);
                RecordPlayer.Decode(temp2);
                temp2 = temp.ReadLine();
            }
            temp.Close();
            isRunningScript= false;
            Debug.Print("完成");
        }
        private void ChooseFIle_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog= new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "选择脚本";
            dialog.Filter = "脚本存档(*.auto)|*.auto";
            dialog.InitialDirectory = System.Environment.CurrentDirectory;
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Debug.Print(dialog.FileName);
                LastChooseText.Text = dialog.FileName;
            }
        }

        private void LastChooseText_TextChanged(object sender, EventArgs e)
        {
            RunScript.Enabled = !(LastChooseText.Text == "");
        }

        private void RunScript_Click(object sender, EventArgs e)
        {
            RunRecoder();
        }
    }
}