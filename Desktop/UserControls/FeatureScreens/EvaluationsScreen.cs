﻿using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens
{
    public partial class EvaluationsScreen : UserControl
    {
        ToolTip _toolTip = new ToolTip();

        public EvaluationsScreen()
        {
            InitializeComponent();
        }

        private async Task LoadDataAsync()
        {
            evaluationsListView.Clear();

            var column = new ColumnHeader { Name = "Description", TextAlign = HorizontalAlignment.Center, Width = evaluationsListView.Width, Text = "Description" };
            evaluationsListView.Columns.Add(column);
            evaluationsListView.View = View.Details;

            var response = await ApiHelper.Instance.GetEmployeeEvaluationsAsync();
            Color color = Color.White;
            if (response != null)
            {
                foreach (var evaluation in response)
                {
                    if (!evaluation.Type)
                    {
                        switch (evaluation.Weight)
                        {
                            case Responses.ModelResponses.Models.EvaluationWeight.High:
                                color = Color.Red;
                                break;
                            case Responses.ModelResponses.Models.EvaluationWeight.Medium:
                                color = Color.Firebrick;
                                break;
                            case Responses.ModelResponses.Models.EvaluationWeight.Low:
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
                            case Responses.ModelResponses.Models.EvaluationWeight.High:
                                color = Color.Lime;
                                break;
                            case Responses.ModelResponses.Models.EvaluationWeight.Medium:
                                color = Color.Green;
                                break;
                            case Responses.ModelResponses.Models.EvaluationWeight.Low:
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

        private async void EvaluationsScreen_LoadAsync(object sender, System.EventArgs e)
        {
            await LoadDataAsync();
        }
    }
}
