using CincoVertice.UI.Forms;
using CincoVertice.WinAPI;
using CincoVertice.WinAPI.Enums;
using CincoVertice.WinAPI.Hotkey;

namespace CincoVertice
{
    public partial class MainForm : Form
    {
        private readonly MouseMoveSimulator _mouse = new MouseMoveSimulator();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var hotkey = new Hotkey();

            hotkey.RegisterHotKey(new HotKeyData(
                FSModifiers.MOD_CONTROL | FSModifiers.MOD_ALT,
                KeyCode.D0,
                HK_KeyPressed));

            _mouse.Interval = 5000;

            mdiTab.OpenMDI<SnippingForm>(false);
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

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CincoVertice");
        }
    }
}
