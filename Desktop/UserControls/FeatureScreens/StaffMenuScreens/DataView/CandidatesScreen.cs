using Desktop.Forms;
using Desktop.Models;
using Desktop.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataView
{
    public partial class CandidatesScreen : UserControl
    {
        private int _currentPageNumber = 1;
        private int _numberOfPages;
        private IEnumerable<Candidate> _candidates;

        public CandidatesScreen()
        {
            InitializeComponent();
        }

        private async Task LoadCandidatesAsync()
        {
            GenericGetAllResponse<Candidate> response = null;

            if (emailFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllCandidates(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, emailFilter: filterTextBox.Text);
            else if (specialtyFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllCandidates(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, specialtyFilter: filterTextBox.Text);
            else if (surnameFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllCandidates(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, surnameFilter: filterTextBox.Text);

            _numberOfPages = response.Pages;
            _currentPageNumber = response.PageNumber;
            pagingLabel.Text = $"{response.PageNumber}/{response.Pages}";
            _candidates = response.Content;
            LoadListView(_candidates);
        }

        private async void filterTextBox_TextChanged(object sender, System.EventArgs e)
        {
            _currentPageNumber = 1;
            await LoadCandidatesAsync();
        }

        private async void pagingNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            _currentPageNumber = 1;
            await LoadCandidatesAsync();
        }

        private async void previousPageButton_Click(object sender, System.EventArgs e)
        {
            if (_currentPageNumber <= 1) return;

            _currentPageNumber--;
            await LoadCandidatesAsync();
        }

        private async void nextPageButton_Click(object sender, System.EventArgs e)
        {
            if (_currentPageNumber >= _numberOfPages) return;

            _currentPageNumber++;
            await LoadCandidatesAsync();
        }

        private async void CandidatesScreen_Load(object sender, System.EventArgs e)
        {
            await LoadCandidatesAsync();
        }

        private void LoadListView(IEnumerable<Candidate> candidates)
        {
            candidatesListView.Clear();

            candidatesListView.Columns.Add(new ColumnHeader { Name = "Empty", TextAlign = HorizontalAlignment.Center, Text = "" });
            candidatesListView.Columns.Add(new ColumnHeader { Name = "Title", TextAlign = HorizontalAlignment.Center, Text = "Title" });
            candidatesListView.Columns.Add(new ColumnHeader { Name = "Name", TextAlign = HorizontalAlignment.Center, Text = "Name" });
            candidatesListView.Columns.Add(new ColumnHeader { Name = "Education", TextAlign = HorizontalAlignment.Center, Text = "Education" });
            candidatesListView.Columns.Add(new ColumnHeader { Name = "Specialty", TextAlign = HorizontalAlignment.Center, Text = "Specialty" });
            candidatesListView.Columns.Add(new ColumnHeader { Name = "Address", TextAlign = HorizontalAlignment.Center, Text = "Address" });
            candidatesListView.Columns.Add(new ColumnHeader { Name = "RequestedSalary", TextAlign = HorizontalAlignment.Center, Text = "Requested salary" });
            candidatesListView.Columns.Add(new ColumnHeader { Name = "Evaluation", TextAlign = HorizontalAlignment.Center, Text = "Evaluation" });
            candidatesListView.Columns.Add(new ColumnHeader { Name = "Status", TextAlign = HorizontalAlignment.Center, Text = "Status" });
            candidatesListView.Columns.Add(new ColumnHeader { Name = "Info", TextAlign = HorizontalAlignment.Center, Text = "Info" });
            candidatesListView.Columns.Add(new ColumnHeader { Name = "Email", TextAlign = HorizontalAlignment.Center, Text = "Email" });

            candidatesListView.View = View.Details;

            if (candidates != null)
            {
                foreach (var candidate in candidates)
                {
                    var item = new ListViewItem
                    {
                        ToolTipText = $@"Email: {candidate.Email}
Phone: {candidate.PhoneNumber}"
                    };

                    item.SubItems.Clear();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, candidate.Title));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, $"{candidate.Name} {candidate.Surname}"));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, candidate.Education));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, candidate.Specialty));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, candidate.Address));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, candidate.RequestedSalary.ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, candidate.Evaluation.ToString()));

                    var str = (string.Concat(candidate.Status.ToString().ToString().Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, str[0] + str.Substring(1).ToLower()));

                    if (!string.IsNullOrEmpty(candidate.AdditionalInfo))
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, candidate.AdditionalInfo));

                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, candidate.Email));
                    candidatesListView.Items.Add(item);
                }
            }

            candidatesListView.Columns[1].Width = -1;

            if (candidatesListView.Columns[1].Width < 100)
                candidatesListView.Columns[1].Width = 100;

            candidatesListView.Columns[2].Width = -1;

            if (candidatesListView.Columns[2].Width < 100)
                candidatesListView.Columns[2].Width = 100;

            candidatesListView.Columns[3].Width = -1;

            if (candidatesListView.Columns[3].Width < 200)
                candidatesListView.Columns[3].Width = 200;

            candidatesListView.Columns[4].Width = -1;

            if (candidatesListView.Columns[4].Width < 200)
                candidatesListView.Columns[4].Width = 200;

            candidatesListView.Columns[5].Width = -1;

            if (candidatesListView.Columns[5].Width < 100)
                candidatesListView.Columns[5].Width = 200;

            candidatesListView.Columns[6].Width = -1;

            if (candidatesListView.Columns[6].Width < 300)
                candidatesListView.Columns[6].Width = 300;

            candidatesListView.Columns[7].Width = -1;

            if (candidatesListView.Columns[7].Width < 100)
                candidatesListView.Columns[7].Width = 200;

            candidatesListView.Columns[8].Width = -1;

            if (candidatesListView.Columns[8].Width < 100)
                candidatesListView.Columns[8].Width = 200;

            candidatesListView.Columns[9].Width = -1;

            if (candidatesListView.Columns[9].Width < 100)
                candidatesListView.Columns[9].Width = 200;

            candidatesListView.Columns[10].Width = 0;
        }

        private void addButton_Click(object sender, System.EventArgs e)
        {
            MainFormStateSingleton.Instance.ScreenContentId = default;
            LoadScreen(15);
        }

        private void hireButton_Click(object sender, System.EventArgs e)
        {

        }

        private void editButton_Click(object sender, System.EventArgs e)
        {
            if (candidatesListView.SelectedIndices.Count > 0)
            {
                foreach (var candidate in _candidates)
                {
                    if (candidate.Email == candidatesListView.SelectedItems[0].SubItems[candidatesListView.SelectedItems[0].SubItems.Count - 1].Text)
                    {
                        MainFormStateSingleton.Instance.ScreenContentId = candidate.Id;
                        LoadScreen(15);
                        return;
                    }
                }
            }
        }

        private async void deleteButton_Click(object sender, System.EventArgs e)
        {
            if (candidatesListView.SelectedIndices.Count > 0)
            {
                foreach (var candidate in _candidates)
                {
                    if (candidate.Email == candidatesListView.SelectedItems[0].SubItems[candidatesListView.SelectedItems[0].SubItems.Count - 1].Text)
                    {
                        var response = await ApiHelper.Instance.RemoveCandidateAsync(candidate.Id);

                        if (response.Success)
                        {
                            errorLabel.Visible = false;
                            _currentPageNumber = 1;
                            await LoadCandidatesAsync();
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

        private void LoadScreen(int screenNumber)
        {
            if (!MainFormStateSingleton.Instance.ScreenMoving && !MainFormStateSingleton.Instance.MenuMoving)
            {
                if (MainFormStateSingleton.Instance.ScreenHidden)
                    MainFormStateSingleton.Instance.ScreenOpened = screenNumber;

                if (MainFormStateSingleton.Instance.ScreenOpened == screenNumber)
                    MainFormStateSingleton.Instance.ScreenTimer.Start();
                else
                {
                    MainFormStateSingleton.Instance.ScreenOpened = screenNumber;
                    MainFormStateSingleton.Instance.ScreensChanging = true;
                    MainFormStateSingleton.Instance.ScreenTimer.Start();
                }
            }
        }
    }
}
