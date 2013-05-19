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
    public class repositories
    {
        public string type { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string owner { get; set; }
        public string homepage { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public int watchers { get; set; }
        public int followers { get; set; }
        public int forks { get; set; }
        public int size { get; set; }
        public int open_issues { get; set; }
        public double score { get; set; }
        public bool has_downloads { get; set; }
        public bool has_issues { get; set; }
        public bool has_wiki { get; set; }
        public bool fork { get; set; }
        public bool @private { get; set; }
        public string url { get; set; }
        public string created { get; set; }
        public string created_at { get; set; }
        public string pushed_at { get; set; }
        public string pushed { get; set; }
    }

    public class RootObject1
    {
        public List<repositories> repositories { get; set; }
    }

    public partial class searchRepos : PhoneApplicationPage
    {
        public searchRepos()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
                webClient.Headers["User-Agent"] = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.15) Gecko/20110303 Firefox/3.6.15";
                webClient.DownloadStringAsync(new Uri("https://api.github.com/legacy/repos/search/:" + textBox2.Text));



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

                var rootObject1 = JsonConvert.DeserializeObject<RootObject1>(e.Result);
                // MessageBox.Show(rootObject.users[0].name);

                if (rootObject1 != null)
                {
                    foreach (var x in rootObject1.repositories)
                    {
                     
                           TextBlock name = new TextBlock();
                            TextBlock owner = new TextBlock();
                            TextBlock description = new TextBlock();
                            TextBlock forks = new TextBlock();
                            TextBlock followers = new TextBlock();
                            TextBlock open_issues = new TextBlock();
                            TextBlock separator = new TextBlock();

                            name.Text = "Name: " + x.name;
                            stackPanel2.Children.Add(name);

                            owner.Text = "Owner: " + x.owner;
                            stackPanel2.Children.Add(owner);

                            description.Text = "Description: " + x.description;
                            stackPanel2.Children.Add(description);

                            forks.Text = "Forks: " + (x.forks).ToString();
                            stackPanel2.Children.Add(forks);
                         
                           followers.Text = "Followers: " + (x.followers).ToString();
                            stackPanel2.Children.Add(followers);
                          
                           open_issues.Text = "Open Issues: " + (x.open_issues).ToString();
                            stackPanel2.Children.Add(open_issues);

                            separator.Text = "\n";
                            stackPanel2.Children.Add(separator); 

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





    }
}