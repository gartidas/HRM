using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class ConfirmForm : Form
    {
        private ToolTip _toolTip = new ToolTip();
        private Form _subjectForm;

        public string Input { get; set; }

        public ConfirmForm(Form subjectForm, bool showTextBox)
        {
            InitializeComponent();

            if (showTextBox)
            {
                textBoxLabel.Visible = true;
                textBox.Visible = true;
            }
            _toolTip.IsBalloon = true;
            _subjectForm = subjectForm;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        #region DragForm
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam); //Drag form by top panel
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();
        #endregion

        #region CreateRoundCorner
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        #endregion

        private void ConfirmForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (textBox.Visible == true)
            {
                if (textBox.Text == "")
                {
                    _toolTip.Show("Text box is empty.", textBox);
                    return;
                }

                Input = textBox.Text;
            }

            this.DialogResult = DialogResult.OK;
            _subjectForm.Enabled = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _subjectForm.Enabled = true;
            this.Close();
        }

        private void ConfirmForm_Load(object sender, EventArgs e)
        {
            MainFormStateSingleton.Instance.MainForm.Enabled = false;
        }
    }
}
