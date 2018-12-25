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
    [Activity(Label = "Functions")]
    public class Functions : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "functions" layout resource
            SetContentView(Resource.Layout.Functions);

            // Declate the TextView's to be used to display the answers 
            TextView tvPV = (TextView)FindViewById(Resource.Id.tvPV);
            TextView tvFV = (TextView)FindViewById(Resource.Id.tvFV);
            TextView tvPMT = (TextView)FindViewById(Resource.Id.tvPMT);

            // Declare the TextViews to display errors in data not passed
            TextView tvAmountNotFound = (TextView)FindViewById(Resource.Id.tvAmountNotFound);
            TextView tvRateNotFound = (TextView)FindViewById(Resource.Id.tvRateNotFound);
            TextView tvTermNotFound = (TextView)FindViewById(Resource.Id.tvTermNotFound);

            // Get the extras for the Amount, Interest Rate and Term variables from the Assumptions Activity 
            int GetAmount = Intent.GetIntExtra("Amount", -1);
            double GetRate = Intent.GetDoubleExtra("Rate", -1);
            int GetTerm = Intent.GetIntExtra("Term", -1);

            // Declare the Amount, Interest Rate and Term variables for the Functions Activity
            int Amount = 0;
            double Rate = 0;
            int Term = 0;

            // Get the Amount Extra. If the value does not exist the default is -1. 
            if (GetAmount == -1)
            {
                tvAmountNotFound.Text = "An error ocurred: No value was found for the Amount variable!";
                
            }
            else
            {
                tvAmountNotFound.Text = "Amount = " + GetAmount.ToString("$#,###,###.##");
                Amount = GetAmount;
            }

            //Get the Rate Extra. If the value does not exist the default is -1. 
            if (GetRate == -1)
            {
                tvRateNotFound.Text = "An error ocurred: No value was found for the Interest Rate variable!";
            }
            else
            {
                double showRate = GetRate * 100;
                tvRateNotFound.Text = "Interest Rate = " + showRate.ToString() + "%";
                Rate = GetRate/12;
            }

            // Get the Term Extra. If the value does not exist the default is -1. 
            if (GetTerm == -1)
            {
                tvTermNotFound.Text = "An error ocurred: No value was found for the Term variable!";
            }
            else
            {
                tvTermNotFound.Text = "Term = " + GetTerm.ToString() + " Years";
                Term = GetTerm * 12;
            }
            // Calculate and Display FV = Amount * ((rate + 1) ^ n) 
            double FV(double FVRate, int FVTerm, double loanAmount)
            {
                double temp = System.Math.Pow(FVRate + 1, FVTerm);
                return (loanAmount * temp);
            }
            double FutureValue = FV(Rate, Term, Amount);
            tvFV.Text = "FV: " + FV(Rate, Term, Amount).ToString("$#,###,###,###.##");

            // Calculate and Display PV = Amount/((rate + 1) ^ n)
            double PV(double FValue, double PVRate, int PVPeriods)
            {
                double temp = System.Math.Pow(1 + PVRate, PVPeriods);
                return FutureValue * (1 / temp);
            }
            double presentValue = PV(FutureValue, Rate, Term);
            tvPV.Text = "PV: " + PV(FutureValue, Rate, Term).ToString("$#,###,###,###.##");


            // Calculate and Display PMT = (-Amount * ((rate + 1) ^ n)) / ((((rate + 1) ^ n) - 1) * rate)
            double Pmt(double PMTRate, int PMTTerm, double PMTAmount)
            {
                double temp1 = System.Math.Pow((PMTRate + 1), -PMTTerm);
                // double temp2 = System.Math.Pow((PMTRate * (1 + PMTRate)), PMTTerm);
                
                return ((PMTRate * presentValue) / (1-temp1));
            }
            
            tvPMT.Text = "PMT: " + Pmt(Rate, Term, Amount).ToString("$#,###,###,##.##");
        }
    }
}