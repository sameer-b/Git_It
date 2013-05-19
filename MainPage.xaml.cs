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

namespace Git_It
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void searchUsers(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/searchUsers.xaml", UriKind.Relative));
        }

        private void searchRepos(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/searchRepos.xaml", UriKind.Relative));
        }

    
    }
}