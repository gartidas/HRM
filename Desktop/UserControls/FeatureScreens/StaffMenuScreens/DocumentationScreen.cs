using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens
{
    public partial class DocumentationScreen : UserControl
    {
        private string _subjectId;

        public DocumentationScreen(string subjectId)
        {
            InitializeComponent();
            _subjectId = subjectId;
        }

        //var filter = @"All Files|*.txt;*.docx;*.doc;*.pdf*.xls;*.xlsx;*.pptx;*.ppt|Text File (.txt)|*.txt|Word File (.docx ,.doc)|*.docx;*.doc|PDF (.pdf)|*.pdf|Spreadsheet (.xls ,.xlsx)|  *.xls ;*.xlsx|Presentation (.pptx ,.ppt)|*.pptx;*.ppt";

        //OpenFileDialog dialog = new OpenFileDialog();
        //dialog.Filter = filter; // file types, that will be allowed to upload
        //dialog.Multiselect = true; // allow/deny user to upload more than one file at a time
        //if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
        //{
        //    string path = dialog.FileName; // get name of file
        //    using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
        //    {
        //        var content = reader.ReadToEnd();
        //        var name = Path.GetFileName(path);
        //    }
        //}
    }
}
