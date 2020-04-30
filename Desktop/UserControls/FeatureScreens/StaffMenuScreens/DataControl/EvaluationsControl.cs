using Desktop.Models;
using Desktop.Utils;
using System;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataControl
{
    public partial class EvaluationsControl : UserControl
    {
        private string _id;
        private ToolTip _toolTip = new ToolTip();
        private string _hR_WorkerId;

        public EvaluationsControl(string id)
        {
            InitializeComponent();
            _id = id;
            _toolTip.IsBalloon = true;

            foreach (var weightType in Enum.GetValues(typeof(EvaluationWeight)))
            {
                weightComboBox.Items.Add(weightType);
            }
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            if (descriptionTextBox.Text == "")
            {
                _toolTip.Show("Description is empty", descriptionTextBox);
                return;
            }

            if (weightComboBox.SelectedItem == default)
            {
                _toolTip.Show("There is nothing selected", weightComboBox);
                return;
            }

            var response = await ApiHelper.Instance.AddEvaluationAsync(_id, _hR_WorkerId, (EvaluationWeight)Enum.Parse(typeof(EvaluationWeight), weightComboBox.SelectedItem.ToString()), positiveRadioButton.Checked ? true : false, descriptionTextBox.Text);

            if (response.Success)
            {
                ScreenLoading.LoadScreen(27);
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

        private async void EvaluationsControl_Load(object sender, EventArgs e)
        {
            _hR_WorkerId = (await ApiHelper.Instance.GetMeAsync()).ID;
        }
    }
}
