using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Test1.Droid;

namespace Test1.Droid
{
    [Activity(Theme = "@style/splashScreenTheme", ScreenOrientation = ScreenOrientation.Portrait, MainLauncher = true, NoHistory = true, WindowSoftInputMode = SoftInput.AdjustResize)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
                var newUiOptions = (int)SystemUiFlags.LayoutStable;
                newUiOptions |= (int)SystemUiFlags.LayoutFullscreen;
                newUiOptions |= (int)SystemUiFlags.HideNavigation;
                newUiOptions |= (int)SystemUiFlags.ImmersiveSticky;
                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;
            }

            base.OnCreate(bundle);
            Intent i = new Intent(this, typeof(MainActivity));
            this.StartActivity(i);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            //FirebasePushNotificationManager.ProcessIntent(this, intent);
        }
    }
}