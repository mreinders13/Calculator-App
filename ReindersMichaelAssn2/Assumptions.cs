using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ReindersMichaelAssn2
{
    [Activity(Label = "Assumptions")]
    public class Assumptions : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Assumptions" layout resource
            SetContentView(Resource.Layout.Assumptions);
           

            // Declare button and set button click event handler
            Button btnGoToFunctions = (Button)FindViewById(Resource.Id.btnGoToFunctions);
            btnGoToFunctions.Click += btnGoToFunctions_Click;

            
            
        }
        private void btnGoToFunctions_Click(object sender, EventArgs e)
        {
            // Declare all TextView's responsible for displaying input error/validation 
            TextView tvAmountError = (TextView)FindViewById(Resource.Id.tvAmountError);
            TextView tvInterestRateError = (TextView)FindViewById(Resource.Id.tvInterestRateError);
            TextView tvTermError = (TextView)FindViewById(Resource.Id.tvTermError);

            // Declare the EditText fields 
            EditText txtAmount = (EditText)FindViewById(Resource.Id.txtAmount);
            EditText txtInterestRate = (EditText)FindViewById(Resource.Id.txtInterestRate);
            EditText txtTerm = (EditText)FindViewById(Resource.Id.txtTerm);

            // Declare my validation integer variables to use for validation
            int valid1 = 0;
            int valid2 = 0;
            int valid3 = 0;
            int allValid = 0;

            // Declare variable to pass to the fucntions activity
            int passAmount = 0;
            double passRate = 0;
            int passTerm = 0;
            // Validate the Amount Input
            if (txtAmount.Text != "") {
                int amount;
                var value = txtAmount.Text;
                bool parsed = Int32.TryParse(value, out amount);
                if (parsed)
                {
                    if (amount < 1000 || amount > 1000000)
                    {
                        tvAmountError.Text = "Please enter a whole number between 1,000 and 1,000,000!";
                        valid1 = 0;
                        txtAmount.Text = "";
                    }
                    else
                    {
                        tvAmountError.Text = "Input is Valid";
                        valid1 = 1;
                        // Store variable to be used on the functions page 
                        passAmount = System.Convert.ToInt32(txtAmount.Text);
                    }
                }
                else
                {
                    tvAmountError.Text = "Please enter a whole number between 1,000 and 1,000,000!";
                    valid1 = 0;
                    txtAmount.Text = "";
                }
                
            }
            else
            {
                tvAmountError.Text = "Please enter a whole number between 1,000 and 1,000,000!";
                valid1 = 0;
                txtAmount.Text = "";
            }
            // Validate the InterstRate Input
            if (txtInterestRate.Text != "")
            {
                var interestRate = System.Convert.ToDouble(txtInterestRate.Text);
                if (interestRate < .01 || interestRate > .2)
                {
                    tvInterestRateError.Text = "Please enter a decimal number between 0.01 and 0.20!";
                    valid2 = 0;
                    txtInterestRate.Text = "";
                }
                else
                {
                    tvInterestRateError.Text = "Input is Valid";
                    valid2 = 1;
                    // Store the variable to be used on the funtions page
                    passRate = System.Convert.ToDouble(txtInterestRate.Text);
                }
            }
            else
            {
                txtInterestRate.Text = "Please enter a decimal number between 0.01 and 0.20!";
                valid2 = 0;
                txtInterestRate.Text = "";
            }
            // Validate the Term Input
            if (txtTerm.Text != "")
            {
                var term = System.Convert.ToInt16(txtTerm.Text);
                if (term < 1 || term > 30)
                {
                    tvTermError.Text = "Please enter a whole number between 1 and 30!";
                    valid3 = 0;
                    txtTerm.Text = "";
                }
                else
                {
                    tvTermError.Text = "Input is Valid";
                    valid3 = 1;
                    // Store the variable to be used on the functions page 
                    passTerm = System.Convert.ToInt16(txtTerm.Text);
                }
            }
            else
            {
                tvTermError.Text = "Please enter a whole number between 1 and 30!";
                valid3 = 0;
                txtTerm.Text = "";
            }
            // Go to the functions activity if all is valid
            allValid = valid1 + valid2 + valid3;
            if (allValid != 3)
            {
                Context context = ApplicationContext;
                string text = "Inputs are invalid!";
                Toast toast = Toast.MakeText(context, text,
                    Android.Widget.ToastLength.Long);
                toast.Show();
            }
            else
            {
                Intent activityIntent = new Intent(this, typeof(ReindersMichaelAssn2.Functions));
                activityIntent.PutExtra("Amount", passAmount);
                activityIntent.PutExtra("Rate", passRate);
                activityIntent.PutExtra("Term", passTerm);
                StartActivityForResult(activityIntent, 100);
                              

            }

        }
    }
}