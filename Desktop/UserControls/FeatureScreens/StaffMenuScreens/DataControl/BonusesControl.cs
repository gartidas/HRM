using System;
using System.Linq;
using System.Windows.Forms;
using static Desktop.Utils.ContentLoading;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataControl
{
    public partial class BonusesControl : UserControl
    {
        private string _subjectId;
        private string _hR_WorkerId;
        private ToolTip _toolTip = new ToolTip();

        public BonusesControl(string subjectId)
        {
            InitializeComponent();
            _subjectId = subjectId;
            _toolTip.IsBalloon = true;
        }

        private async void BonusesControl_Load(object sender, System.EventArgs e)
        {
            _hR_WorkerId = (await ApiHelper.Instance.GetMeAsync()).ID;
        }

        private async void submitButton_Click(object sender, System.EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is TextBox && (control as TextBox).Text == "")
                {
                    var name = ((TextBox)control).Name.Replace("TextBox", "");
                    name = (string.Concat(name.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '));
                    name = Char.ToUpper(name[0]) + name.Substring(1).ToLower();

                    _toolTip.Show($"{name} is empty", (TextBox)control);
                    return;
                }
            }

            if (!int.TryParse(valueTextBox.Text, out int result))
            {
                _toolTip.Show("Number in wrong format", valueTextBox);
                return;
            }

            var response = await ApiHelper.Instance.AddBonusAsync(_subjectId, _hR_WorkerId, DateTime.Now.Date, result, descriptionTextBox.Text);

            if (response.Success)
            {
                LoadScreen(ScreenName.BonusesScreen);
            }
            else
            {
                errorLabel.Text = "";
                foreach (var error in response.Errors)
                {
                    errorLabel.Text += error;
                }
                errorLabel.Visible = true;
            }
        }
    }
}
