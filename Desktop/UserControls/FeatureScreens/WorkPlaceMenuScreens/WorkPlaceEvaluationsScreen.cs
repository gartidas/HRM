using Desktop.Models;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.WorkPlaceMenuScreens
{
    public partial class WorkPlaceEvaluationsScreen : UserControl
    {
        private List<Employee> _employees = new List<Employee>();
        private string _id;

        public WorkPlaceEvaluationsScreen()
        {
            InitializeComponent();
        }

        private async Task LoadEmployeesComboBoxAsync()
        {
            var response = await ApiHelper.Instance.GetAllEmployeesAsync(workPlaceIdFilter: _id);

            for (int i = 1; i <= response.Pages; i++)
            {
                _employees.AddRange((await ApiHelper.Instance.GetAllEmployeesAsync(i, workPlaceIdFilter: _id)).Content.Where(x => x.Data.EmailAddress != CurrentUser.User.Email));
            }

            foreach (var employee in _employees)
            {
                employeeComboBox.Items.Add(employee.Data.EmailAddress);
            }
        }

        private async void WorkPlaceEvaluationsScreen_Load(object sender, System.EventArgs e)
        {
            _id = (await ApiHelper.Instance.GetEmployeeDataAsync()).WorkPlace.ID;

            if (_id != default)
            {
                await LoadListViewAsync("");
                await LoadEmployeesComboBoxAsync();
            }
        }

        private async void employeeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            foreach (var employee in _employees)
            {
                if (employee.Data.EmailAddress == employeeComboBox.SelectedItem.ToString())
                {
                    await LoadListViewAsync(employee.ID);
                }
            }
        }

        private async Task LoadListViewAsync(string id)
        {
            evaluationsListView.Clear();

            var column = new ColumnHeader { Name = "Description", TextAlign = HorizontalAlignment.Center, Width = evaluationsListView.Width, Text = "Description" };
            evaluationsListView.Columns.Add(column);
            evaluationsListView.View = View.Details;

            var response = await ApiHelper.Instance.GetAllEvaluationsOfEmployeeAsync(id);
            Color color = Color.White;
            if (response != null)
            {
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
                        ForeColor = color,
                        Text = evaluation.Description,
                        ToolTipText = $@"Name: {evaluation.HR_Worker.Name}
Email: {evaluation.HR_Worker.Email}"
                    };

                    evaluationsListView.Items.Add(item);
                }
            }
        }
    }
}
