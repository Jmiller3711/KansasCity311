using System;
using System.Windows;
using System.Windows.Documents;

namespace KansasCity311
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var form311 = GetFormInformation();
            if (UserInputValidator.Valid(form311))
            {
                var automation = new Automation();
                var status = automation.Run(form311);
                MessageBox.Show(status, "Automation Status");
            }
        }

        private Form311 GetFormInformation()
        {
            var contactInfo = new ContactInformation(firstName.Text, lastName.Text, email.Text, phoneNumber.Text, GetBoolValue(includeContactInfo.IsChecked));
            return new Form311(contactInfo, whatToReportComboBox.Text, GetAddress(), GetDescription());
        }

        private string GetDescription()
        {
            var richText = new TextRange(description.Document.ContentStart, description.Document.ContentEnd).Text;
            if (richText == "\r\n")
            {
                return "";
            }
            return richText;
        }

        private string GetAddress()
        {
            if (GetBoolValue(gillham4323.IsChecked))
            {
                return "4323 Gillham Road";
            }
            else if (GetBoolValue(gillham4339.IsChecked))
            {
                return "4339 Gillham Road";
            }
            else if (GetBoolValue(other.IsChecked))
            {
                return addressOther.Text;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private bool GetBoolValue(bool? value)
        {
            return value.HasValue ? value.Value : false;
        }

        private void prefillButton_Click(object sender, RoutedEventArgs e)
        {
            var prefillText = Complaints.GetComplaint(prefillDescriptionComboBox.Text);
            description.Document.Blocks.Clear();
            description.Document.Blocks.Add(new Paragraph(new Run(prefillText)));
        }
    }
}