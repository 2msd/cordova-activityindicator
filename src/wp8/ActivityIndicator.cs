//
//  ActivityIndicator.cs
//  Version 1.0
//  Created by Marco Spinola Durante on 14.04.2014.
//

using Microsoft.Phone.Shell;
using System.Windows;

namespace WPCordovaClassLib.Cordova.Commands
{
    public class ActivityIndicator : BaseCommand
    {

        public ActivityIndicator()
        {
            SystemTray.ProgressIndicator = new ProgressIndicator();
            SystemTray.ProgressIndicator.Text = "";
        }

        public void show(string options)
        {
            string[] args = JSON.JsonHelper.Deserialize<string[]>(options);
            string text = args[0];
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                SystemTray.ProgressIndicator.Text = text;
                SystemTray.ProgressIndicator.IsIndeterminate = true;
                SystemTray.ProgressIndicator.IsVisible = true;
            });
        }
        public void hide(string options)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                SystemTray.ProgressIndicator.IsIndeterminate = false;
                SystemTray.ProgressIndicator.IsVisible = false;
            });
        }
    }
}
