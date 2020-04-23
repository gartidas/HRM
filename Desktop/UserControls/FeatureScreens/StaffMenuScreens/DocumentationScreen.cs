using Desktop.Forms;
using Desktop.Models;
using Desktop.UserControls.FileHandling;
using Desktop.Utils;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens
{
    public partial class DocumentationScreen : UserControl
    {
        private string _subjectId;
        private IFileHandler _fileHandler;
        private string _filter;
        private List<Document> _documents;

        public DocumentationScreen(string subjectId, IFileHandler fileHandler)
        {
            InitializeComponent();
            _subjectId = subjectId;
            _fileHandler = fileHandler;
            if (_fileHandler is FormerEmployeesFileHandler)
            {
                uploadButton.Visible = false;
                deleteButton.Visible = false;
                sizeLabel.Visible = false;
            }
            _filter = @"All Files|*.txt;*.docx;*.doc;*.pdf*.xls;*.xlsx;*.pptx;*.ppt|Text File (.txt)|*.txt|Word File (.docx ,.doc)|*.docx;*.doc|PDF (.pdf)|*.pdf|Spreadsheet (.xls ,.xlsx)|  *.xls ;*.xlsx|Presentation (.pptx ,.ppt)|*.pptx;*.ppt";
        }

        private async void uploadButton_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = _filter; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time

            try
            {
                if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
                {
                    string path = dialog.FileName; // get name of file
                    byte[] content = null;
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        content = new byte[fs.Length];
                        fs.Read(content, 0, (int)fs.Length);
                        var name = Path.GetFileName(path);

                        var response = await _fileHandler.UploadFileAsync(_subjectId, content, name);
                        if (response.Success)
                        {
                            errorLabel.Visible = false;
                            LoadData();
                            return;
                        }

                        errorLabel.Text = "";

                        foreach (var error in response.Errors)
                        {
                            errorLabel.Text += error;
                        }

                        errorLabel.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Visible = true;
            }
        }

        private void downloadButton_Click(object sender, System.EventArgs e)
        {
            if (documentationListView.SelectedIndices.Count > 0)
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = "C:\\Users";
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    foreach (var document in _documents)
                    {
                        if (document.ID == documentationListView.SelectedItems[0].SubItems[1].Text)
                        {
                            File.WriteAllBytes(dialog.FileName + "//" + document.Name, document.Content);
                            return;
                        }
                    }
                }
            }
        }

        private async void deleteButton_Click(object sender, System.EventArgs e)
        {
            if (documentationListView.SelectedIndices.Count > 0)
            {
                ConfirmForm confirmForm = new ConfirmForm(MainFormStateSingleton.Instance.MainForm, false);

                if (confirmForm.ShowDialog() != DialogResult.OK)
                    return;

                var response = await _fileHandler.RemoveFileAsync(documentationListView.SelectedItems[0].SubItems[1].Text);

                if (response.Success)
                {
                    errorLabel.Visible = false;
                    LoadData();
                    return;
                }

                errorLabel.Text = "";
                errorLabel.Text += response.ErrorMessage;
                errorLabel.Visible = true;
            }
        }

        private void LoadListView(List<Document> documents)
        {
            documentationListView.Clear();

            documentationListView.Columns.Add(new ColumnHeader { Name = "Empty", TextAlign = HorizontalAlignment.Center, Text = "" });
            documentationListView.Columns.Add(new ColumnHeader { Name = "ID", TextAlign = HorizontalAlignment.Center, Text = "ID" });
            documentationListView.Columns.Add(new ColumnHeader { Name = "Name", TextAlign = HorizontalAlignment.Center, Text = "Name" });

            documentationListView.View = View.Details;

            if (_documents != null)
            {
                foreach (var document in documents)
                {
                    var item = new ListViewItem
                    {

                    };

                    item.SubItems.Clear();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, document.ID));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, document.Name));

                    documentationListView.Items.Add(item);
                }
            }

            documentationListView.Columns[0].Width = 0;
            documentationListView.Columns[1].Width = 0;

            documentationListView.Columns[2].Width = -2;
        }

        private async void DocumentationScreen_Load(object sender, System.EventArgs e)
        {
            var email = await _fileHandler.LoadSubjectEmailAsync(_subjectId);
            emailLabel.Text = email;
            emailLabel.Visible = true;

            LoadData();
        }

        private async void LoadData()
        {
            _documents = await _fileHandler.LoadFilesAsync(_subjectId);
            LoadListView(_documents);
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            ScreenLoading.LoadScreen(MainFormStateSingleton.Instance.LastLoadedScreen);
        }
    }
}
