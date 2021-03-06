﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Media;
using Plugin.CurrentActivity;
using IconEntry.FormsPlugin.Abstractions;
using Xamarin.Forms;
using IconEntry.FormsPlugin.Android;
using Firebase.Auth;



namespace StarterProject.Droid
{
    [Activity(Label = "sharezeug", Icon = "@drawable/logo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            
            await CrossMedia.Current.Initialize();
            CrossCurrentActivity.Current.Init(this, savedInstanceState);


            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            IconEntry.FormsPlugin.Android.IconEntryRenderer.Init();

            Xamarin.FormsMaps.Init(this, savedInstanceState);


            Firebase.FirebaseApp.InitializeApp(this); //keine ahnung ob das rein oder raus muss //Android.App.Application.Context

            LoadApplication(new App());

            //FirestoreService.Init(this); //??ß
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}