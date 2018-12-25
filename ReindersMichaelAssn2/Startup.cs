using Android.App;
using Android.Widget;
using Android.OS;
using System;
// Needed for Intent.
using Android.Content;
using Android.Runtime;

namespace ReindersMichaelAssn2
{
    [Activity(Label = "ReindersMichaelAssn2", MainLauncher = true)]
    public class Startup : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Startup);

            Button btnGoAssumptions = (Button)FindViewById(Resource.Id.btnAssumptions);
            btnGoAssumptions.Click += btnGoAssumptions_Click;

            Button btnExit = (Button)FindViewById(Resource.Id.btnExit);
            btnExit.Click += btnExit_Click;

            Button btnTextEmail = (Button)FindViewById(Resource.Id.btnTextEmail);
            btnTextEmail.Click += btnTextEmail_Click;
        }

        private void btnTextEmail_Click(object sender, EventArgs e)
        {
            //Creates the Alert nad Sets the Title and Message.
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("");
            alert.SetMessage("");

            //Setup Buttons. 
            alert.SetPositiveButton("Text", (senderAlert, args) =>
            {
                var smsUri = Android.Net.Uri.Parse("smsto:77555512345");

                var smsIntent = new Intent(Intent.ActionSendto, smsUri);
                smsIntent.PutExtra("sms_body", "Hello from ReindersMichaelAssn2!");
                StartActivity(smsIntent);
                              
            });
            alert.SetNeutralButton("Cancel", (senderAlert, args) =>
            {
                //nothing
            });
            alert.SetNegativeButton("Email", (senderAlert, args) =>
            {
                var email = new Intent(Intent.ActionSend);
                email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] { "ReindersMichaelAssn2@gmail.com", "ReindersMichaelAssn2@outlook.com" });

                email.PutExtra(Android.Content.Intent.ExtraSubject, "Hello Email");
                email.PutExtra(Android.Content.Intent.ExtraText, "Hello from ReindersMichaelAssn2!");

                email.SetType("Message/rfc822");

                StartActivity(email);                               
            });
            //Display the alert
            alert.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
            this.FinishAffinity();
        }

        private void btnGoAssumptions_Click(object sender, EventArgs e)
        {
            Intent activityIntent = new Intent(this, typeof(ReindersMichaelAssn2.Assumptions));
            //Open Assumptions Activity
            StartActivity(activityIntent);
        }


        protected override void OnDestroy()
        {
            base.OnDestroy();
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}

