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
using System.Windows.Media.Imaging;



namespace Git_It
{
   public partial class userInfo : PhoneApplicationPage
    {
        
        public userInfo()
        {           
         
            InitializeComponent();
            getInfo();
           
            
        }

        public void getInfo()
        {
            try
            {
                
                WebClient webClient = new WebClient();
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
              //  webClient.Headers["User-Agent"] = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.15) Gecko/20110303 Firefox/3.6.15";
                webClient.DownloadStringAsync(new Uri("https://api.github.com/users/"+GlobalVariables.targetUser));
                MessageBox.Show("Fetching data, hang on...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not send request! \n" + ex.Message);
            }
        }

        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            
            try
            {

                var x = JsonConvert.DeserializeObject<userInfoJason>(e.Result);

             
                  if (x != null)
             {  
                        
                  string profilePictureUrl = x.avatar_url;
                  Uri imageUrl = new Uri(profilePictureUrl, UriKind.Absolute);
                  Image profilePicture = new Image();
                  profilePicture.Source = new BitmapImage(imageUrl);
                  profilePicture.Height = 100;
                  profilePicture.Width = 100;
                  profilePicture.HorizontalAlignment = HorizontalAlignment.Left;
                  stackPanel1.Children.Add(profilePicture);

                    
                        
                  TextBlock type = new TextBlock();
                  type.Text="Type: "+x.type;
                  stackPanel1.Children.Add(type);
                  TextBlock name = new TextBlock();
                  name.Text="Name: "+x.name;
                  stackPanel1.Children.Add(name);
                  TextBlock company = new TextBlock();
                  company.Text="Company: "+x.company;
                  stackPanel1.Children.Add(company);
                  TextBlock blog = new TextBlock();
                  blog.Text="Blog: "+x.blog;
                  stackPanel1.Children.Add(blog);
                  TextBlock location = new TextBlock();
                  location.Text="Location: "+x.location;
                  stackPanel1.Children.Add(location);
                  TextBlock email = new TextBlock();
                  email.Text="Email: "+x.email;
                  stackPanel1.Children.Add(email);
                  TextBlock bio = new TextBlock();
                  bio.Text="Bio: "+x.bio;
                  stackPanel1.Children.Add(bio);
                  TextBlock public_repos = new TextBlock();
                  public_repos.Text="Repos: "+x.public_repos;
                  stackPanel1.Children.Add(public_repos);
                  TextBlock followers = new TextBlock();
                  followers.Text="Followers: "+x.followers;
                  stackPanel1.Children.Add(followers);
                  TextBlock following = new TextBlock();
                  following.Text="Following: "+x.following;
                  stackPanel1.Children.Add(following);   
                     
                                      
                                  }
                                  else
                                  {
                                      MessageBox.Show("Couldn't find anything :( ");
                                  } 
                          
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Could not show correctly!\n" + ex.Message);
            }
        }

       
        
       
    

       
    }
   public class userInfoJason
   {
       public string login { get; set; }
       public int id { get; set; }
       public string avatar_url { get; set; }
       public string gravatar_id { get; set; }
       public string url { get; set; }
       public string html_url { get; set; }
       public string followers_url { get; set; }
       public string following_url { get; set; }
       public string gists_url { get; set; }
       public string starred_url { get; set; }
       public string subscriptions_url { get; set; }
       public string organizations_url { get; set; }
       public string repos_url { get; set; }
       public string events_url { get; set; }
       public string received_events_url { get; set; }
       public string type { get; set; }
       public string name { get; set; }
       public string company { get; set; }
       public string blog { get; set; }
       public string location { get; set; }
       public string email { get; set; }
       public bool hireable { get; set; }
       public object bio { get; set; }
       public int public_repos { get; set; }
       public int followers { get; set; }
       public int following { get; set; }
       public string created_at { get; set; }
       public string updated_at { get; set; }
       public int public_gists { get; set; }
   }

  // public class RootObject3
   //{
  //     public List<userInfoJason> userInfoJason { get; set; }
  // }
   
}