using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Newtonsoft.Json;


namespace Git_It
{
    public class users
    {
        public string id { get; set; }
        public string gravatar_id { get; set; }
        public string username { get; set; }
        public string login { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string language { get; set; }
        public string fullname { get; set; }
        public string type { get; set; }
        public int public_repo_count { get; set; }
        public int repos { get; set; }
        public int followers { get; set; }
        public int followers_count { get; set; }
        public double score { get; set; }
        public string created_at { get; set; }
        public string created { get; set; }
    }

    public class RootObject2
    {
        public List<users> users { get; set; }
    }

    public static class GlobalVariables
    {
        public static string targetUser = "";
    }

    public partial class Page1 : PhoneApplicationPage
    {
       
        public Page1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
                webClient.Headers["User-Agent"] = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.15) Gecko/20110303 Firefox/3.6.15";
                webClient.DownloadStringAsync(new Uri("https://api.github.com/legacy/user/search/:"+textBox1.Text));
                MessageBox.Show("Fetching data, hang on...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! Show \n" + ex.Message);
            }
            }

        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
             
                var rootObject = JsonConvert.DeserializeObject<RootObject2>(e.Result);
               // MessageBox.Show(rootObject.users[0].name);
           
               if (rootObject != null)
                {
                    foreach (var x in rootObject.users)
                   {
                       // MessageBox.Show(x.name);
                       TextBlock login = new TextBlock();
                       TextBlock username = new TextBlock();
                       TextBlock repos = new TextBlock();
                       TextBlock score = new TextBlock();
                       TextBlock fullname = new TextBlock();
                       TextBlock separator = new TextBlock();

                       login.Text = "Login: " + x.login;
                       stackPanel1.Children.Add(login);

                        username.Text = "Username: "+x.name;
                        stackPanel1.Children.Add(username);

                        fullname.Text = "Fullname: "+x.fullname;
                        stackPanel1.Children.Add(fullname);

                        score.Text ="Score: "+ (x.score).ToString();
                        stackPanel1.Children.Add(score);

                        repos.Text = "Repos: "+(x.public_repo_count).ToString();
                        stackPanel1.Children.Add(repos);

                       separator.Text = "\n";
                       stackPanel1.Children.Add(separator);

                       

                       login.Tap += showInfo;

                      

                   }
                }
                else
               {
                    MessageBox.Show("Couldn't find anything :( ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Done!\n" + ex.Message);
            }
        }
        
        void showInfo(object sender, EventArgs e)
        {
            TextBlock x = sender as TextBlock;

            GlobalVariables.targetUser = (x.Text);
            GlobalVariables.targetUser = (GlobalVariables.targetUser).Remove(0, 7);
            this. NavigationService.Navigate(new Uri("/userInfo.xaml", UriKind.Relative));
            
        }
    }

  
}