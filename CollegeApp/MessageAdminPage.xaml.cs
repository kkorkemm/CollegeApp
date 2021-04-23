using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для MessageAdminPage.xaml
    /// </summary>
    public partial class MessageAdminPage : Page
    {
        public MessageAdminPage()
        {
            InitializeComponent();
        }

        private void BtnAddAttach_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Multiselect = true
            };

            if (fileDialog.ShowDialog() == true)
            {
                foreach(string file in fileDialog.FileNames)
                {
                    TextAttach.Text += "," + file;
                }
            }
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            string name = CollegeDBEntities.currentUser.FullName;
            string f = TextMail.Text;
            string t = "zhardemova2012@mail.ru";
            string pass = TextPass.Password;

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(TextMail.Text))
                errors.AppendLine("Укажите почту");
            if (string.IsNullOrWhiteSpace(TextPass.Password))
                errors.AppendLine("Введите пароль от почты");
            if (string.IsNullOrWhiteSpace(TextTitle.Text))
                errors.AppendLine("Укажите тему письма");
            if (string.IsNullOrWhiteSpace(TextMessage.Text))
                errors.AppendLine("Введите текст письма");
            
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                MailAddress from = new MailAddress(f, name);
                MailAddress to = new MailAddress(t);

                MailMessage mail = new MailMessage(from, to)
                {
                    Subject = TextTitle.Text,
                    Body = TextMessage.Text
                };

                if (!string.IsNullOrWhiteSpace(TextAttach.Text))
                {
                    string[] file = TextAttach.Text.Split(',');
                    try
                    {
                        for (int i = 1; i < file.Length; i++)
                        {
                            mail.Attachments.Add(new Attachment(file[i]));
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                try
                {
                    string[] services = f.Split('@');
                    string service = services[1];

                    SmtpClient smtpClient = new SmtpClient("smtp." + service, 587)
                    {
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(f, pass)
                    };

                    smtpClient.Send(mail);

                    MessageBox.Show("Письмо отправлено!");
                    TextTitle.Text = "";
                    TextMessage.Text = "";
                    TextAttach.Text = "";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
