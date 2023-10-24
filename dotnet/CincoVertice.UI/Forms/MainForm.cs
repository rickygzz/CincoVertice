using CincoVertice.WinAPI;
using CincoVertice.WinAPI.Hotkey;
using CincoVertice.WinAPI.Libs;

namespace VerticeLib
{
    public partial class MainForm : Form
    {
        private MouseMoveSimulator _mouse;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var hotkey = new Hotkey();

            hotkey.RegisterHotKey(new HotKeyData(
                User32.FSModifiers.MOD_CONTROL | User32.FSModifiers.MOD_ALT,
                User32.KeyCode.D0,
                HK_KeyPressed));

            _mouse = new MouseMoveSimulator();
            _mouse.Interval = 5000;
        }

        private void HK_KeyPressed(object sender, HotkeyPressedEventArgs e)
        {
            MessageBox.Show("hey");
        }

        private void MouseMove_Checked(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                _mouse.Start();
                return;
            }

            _mouse.Stop();
        }
    }
}
