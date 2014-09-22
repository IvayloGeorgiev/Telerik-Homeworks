using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MongoDbServer;
using MongoDbServer.Models;
using System.Windows.Threading;

namespace MongoDbChat.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string PostTemplate = "{0} on {1}\n\n\t{2}";

        private string username;
        private DateTime sessionStart;
        private DateTime lastUpdate;
        private MongoChatConnector chatConnector;

        public MainWindow()
        {
            InitializeComponent();
            this.sessionStart = DateTime.Now;
            this.lastUpdate = DateTime.Now;
            chatConnector = new MongoChatConnector("mongodb://testing:testing@ds063789.mongolab.com:63789/mongo-db-chat-test");
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private void GetAllMessagesSinceStartOfSession()
        {
            ListBoxMessages.Items.Clear();
            lastUpdate = DateTime.Now;
            var messages = chatConnector.GetAllMessagesSince(sessionStart);
            DisplayMessages(messages);
        }

        private void GetAllMessages()
        {
            ListBoxMessages.Items.Clear();
            lastUpdate = DateTime.Now;
            var messages = chatConnector.GetAllMessages();
            DisplayMessages(messages);
        }
        private void GetAllMessagesSinceLastUpdate()
        {
            var messages = chatConnector.GetAllMessagesSince(this.lastUpdate);
            lastUpdate = DateTime.Now;
            DisplayMessages(messages);
        }

        private void ClearAllMessages()
        {
            ListBoxMessages.Items.Clear();
            lastUpdate = DateTime.Now;
        }

        private void DisplayMessages(IEnumerable<Message> messages)
        {
            foreach (var message in messages)
            {
                var post = CreatePostBox(message);
                ListBoxMessages.Items.Add(post);
                ListBoxMessages.ScrollIntoView(post);
            }                        
        }

        private TextBox CreatePostBox(Message message)
        {
            var result = new TextBox();
            result.Text = string.Format(PostTemplate, message.User.Username, message.PostDate.ToString(), message.Text);
            //result.HorizontalAlignment = HorizontalAlignment.Stretch;
            result.IsReadOnly = true;
            result.TextWrapping = TextWrapping.Wrap;
            return result;
        }

        private void OnTimerTick(Object source, EventArgs e)
        {
            GetAllMessagesSinceLastUpdate();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.username = null;
            LoginName.Visibility = Visibility.Visible;
            Login.Visibility = Visibility.Visible;
            Logout.Visibility = Visibility.Collapsed;
            PostButton.IsEnabled = false;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.username = LoginName.Text;
            LoginName.Visibility = Visibility.Collapsed;
            Login.Visibility = Visibility.Collapsed;
            Logout.Visibility = Visibility.Visible;
            PostButton.IsEnabled = true;
        }

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            var postText = PostContent.Text;
            PostContent.Text = string.Empty;
            chatConnector.PostMessage(postText, this.username, DateTime.Now);
        }

        private void PostsSinceEver_Checked(object sender, RoutedEventArgs e)
        {
            this.GetAllMessages();
        }

        private void PostsSinceSession_Checked(object sender, RoutedEventArgs e)
        {
            this.GetAllMessagesSinceStartOfSession();
        }

        private void PostsSinceNow_Checked(object sender, RoutedEventArgs e)
        {
            this.ClearAllMessages();
        }      
    }
}
