using Desktop.Forms;
using Desktop.Models;
using Desktop.Utils;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Desktop.Utils.ContentLoading;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataView
{
    public partial class EvaluationsScreen : UserControl
    {
        private string _id;
        private List<Evaluation> _evaluations = new List<Evaluation>();

        public EvaluationsScreen(string id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void EvaluationsScreen_Load(object sender, System.EventArgs e)
        {
            if (_id == default)
                return;

            await LoadDataAsync();
            await LoadEmailLabelAsync();
        }

        private async Task LoadDataAsync()
        {
            evaluationsListView.Clear();

            evaluationsListView.Columns.Add(new ColumnHeader { Name = "Empty", TextAlign = HorizontalAlignment.Center, Text = "" });
            evaluationsListView.Columns.Add(new ColumnHeader { Name = "Description", TextAlign = HorizontalAlignment.Center, Text = "Description" });
            evaluationsListView.Columns.Add(new ColumnHeader { Name = "ID", TextAlign = HorizontalAlignment.Center, Text = "ID" });
            evaluationsListView.View = View.Details;

            var response = await ApiHelper.Instance.GetAllEvaluationsOfSelectedEmployeeAsync(_id);
            Color color = Color.White;

            if (response != null)
            {
                _evaluations = response.ToList();

                foreach (var evaluation in response)
                {
                    if (!evaluation.Type)
                    {
                        switch (evaluation.Weight)
                        {
                            case EvaluationWeight.High:
                                color = Color.Red;
                                break;
                            case EvaluationWeight.Medium:
                                color = Color.Firebrick;
                                break;
                            case EvaluationWeight.Low:
                                color = Color.IndianRed;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (evaluation.Weight)
                        {
                            case EvaluationWeight.High:
                                color = Color.Lime;
                                break;
                            case EvaluationWeight.Medium:
                                color = Color.Green;
                                break;
                            case EvaluationWeight.Low:
                                color = Color.SeaGreen;
                                break;
                            default:
                                break;
                        }
                    }

                    var item = new ListViewItem
                    {
                        ToolTipText = $@"Name: {evaluation.HR_Worker.Name}
Email: {evaluation.HR_Worker.Email}"
                    };

                    item.SubItems.Clear();
                    item.UseItemStyleForSubItems = false;

                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, evaluation.Description, color, evaluationsListView.BackColor, evaluationsListView.Font));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, evaluation.ID));

                    evaluationsListView.Items.Add(item);
                }
            }

            if (evaluationsListView.Columns[1].Width < (evaluationsListView.Width - evaluationsListView.Columns[0].Width))
                evaluationsListView.Columns[1].Width = evaluationsListView.Width - evaluationsListView.Columns[0].Width;
            evaluationsListView.Columns[2].Width = 0;
        }

        private async Task LoadEmailLabelAsync()
        {
            var result = await ApiHelper.Instance.GetSelectedEmployeeAsync(_id);

            if (result != null)
            {
                emailLabel.Text = result.Data.EmailAddress;
                emailLabel.Visible = true;
            }
        }

        private void addButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.EvaluationsControl);
        }

        private async void deleteButton_Click(object sender, System.EventArgs e)
        {
            if (evaluationsListView.SelectedIndices.Count > 0)
            {
                ConfirmForm confirmForm = new ConfirmForm(MainFormStateSingleton.Instance.MainForm, false);

                if (confirmForm.ShowDialog() != DialogResult.OK)
                    return;

                foreach (var evaluation in _evaluations)
                {
                    if (evaluation.ID == evaluationsListView.SelectedItems[0].SubItems[2].Text)
                    {
                        var response = await ApiHelper.Instance.RemoveEvaluationAsync(evaluation.ID);

                        if (response.Success)
                        {
                            errorLabel.Visible = false;
                            await LoadDataAsync();
                        }
                        else
                        {
                            errorLabel.Text = response.ErrorMessage;
                            errorLabel.Visible = true;
                        }

                        return;
                    }
                }
            }
        }

        private void doneButton_Click(object sender, System.EventArgs e)
        {
            ContentLoading.LoadScreen(MainFormStateSingleton.Instance.LastLoadedScreen);
        }
    }
}
