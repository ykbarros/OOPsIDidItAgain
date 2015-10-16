using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace OOPsIDidItAgain
{
	[Activity (Label = "Calculadora", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		Button zero, one, two, three, four, five, six, seven, eight, nine;
		Button point, signChange, percent;
		Button divide, multiply, subtract, addition, equalsSign;
		Button sine, cosine, tangent, sqrt;
		Button pi, clear;
		TextView resultView;

		Calculator operation = new Calculator();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource
			zero = FindViewById<Button> (Resource.Id.zero);
			one = FindViewById<Button> (Resource.Id.one);
			two = FindViewById<Button> (Resource.Id.two);
			three = FindViewById<Button> (Resource.Id.three);
			four = FindViewById<Button> (Resource.Id.four);
			five = FindViewById<Button> (Resource.Id.five);
			six = FindViewById<Button> (Resource.Id.six);
			seven = FindViewById<Button> (Resource.Id.seven);
			eight = FindViewById<Button> (Resource.Id.eight);
			nine = FindViewById<Button> (Resource.Id.nine);
			point = FindViewById<Button> (Resource.Id.point);
			clear = FindViewById<Button> (Resource.Id.clear);
			signChange = FindViewById<Button> (Resource.Id.signChange);
			percent = FindViewById<Button> (Resource.Id.percent);
			divide = FindViewById<Button> (Resource.Id.divide);
			multiply = FindViewById<Button> (Resource.Id.multiply);
			subtract = FindViewById<Button> (Resource.Id.subtract);
			addition = FindViewById<Button> (Resource.Id.addition);
			sine = FindViewById<Button> (Resource.Id.sine);
			cosine = FindViewById<Button> (Resource.Id.cosine);
			tangent = FindViewById<Button> (Resource.Id.tangent);
			sqrt = FindViewById<Button> (Resource.Id.root);
			pi = FindViewById<Button> (Resource.Id.pi);
			equalsSign = FindViewById<Button> (Resource.Id.equalsSign);
			resultView = FindViewById<TextView> (Resource.Id.resultView);

			// numEventHandler
			zero.Click += (sender, e) => {
				numEventHandler(sender, resultView);
			} ;
			one.Click += (sender, e) => {
				numEventHandler(sender, resultView);
			} ;
			two.Click += (sender, e) => {
				numEventHandler(sender, resultView);
			} ;
			three.Click += (sender, e) => {
				numEventHandler(sender, resultView);
			} ;
			four.Click += (sender, e) => {
				numEventHandler(sender, resultView);
			} ;
			five.Click += (sender, e) => {
				numEventHandler(sender, resultView);
			} ;
			six.Click += (sender, e) => {
				numEventHandler(sender, resultView);
			} ;
			seven.Click += (sender, e) => {
				numEventHandler(sender, resultView);
			} ;
			eight.Click += (sender, e) => {
				numEventHandler(sender, resultView);
			} ;
			nine.Click += (sender, e) => {
				numEventHandler(sender, resultView);
			} ;

			// operatorEventHandler
			divide.Click += (sender, e) => {
				operatorEventHandler(sender, resultView);
			} ;
			multiply.Click += (sender, e) => {
				operatorEventHandler(sender, resultView);
			} ;
			subtract.Click += (sender, e) => {
				operatorEventHandler(sender, resultView);
			} ;
			addition.Click += (sender, e) => {
				operatorEventHandler(sender, resultView);
			} ;

			/* 
			 * Calculation with one operand (+/-, %, ., pi, trig function):
			 * 
			 *   signChange.Click
			 *   percent.Click
			 *   sine.Click
			 *   cosine.Click
			 *   tangent.Click
			 * 
			 * Goes to Operation(sender, resultView) method with Singleton flag on.
			 * 
			 */ 
			signChange.Click += (sender, e) => {
				operation.Singleton = true;
				Operation(sender, resultView);
			} ;
			percent.Click += (sender, e) => {
				operation.Singleton = true;
				Operation(sender, resultView);
			} ;
			sine.Click += (sender, e) => {
				operation.Singleton = true;
				Operation(sender, resultView);
			} ;
			cosine.Click += (sender, e) => {
				operation.Singleton = true;
				Operation(sender, resultView);
			} ;
			tangent.Click += (sender, e) => {
				operation.Singleton = true;
				Operation(sender, resultView);
			} ;

			/* 
			 * Handler for:
			 * 
			 *   equalsSign.Click
			 *   clear.Click
			 *   point.Click
			 *   pi.Click
			 *   sqrt.Click
			 * 
			 * These do not go to an event handler; specialized cases.
			 * 
			 */ 

			// Calculation with two operands (x +-/* y = )
			equalsSign.Click += (sender, e) => {
				// pressed number and then equals sign; identity x = x.
				if (operation.Operand1 == "" && resultView.Text.Length > 0) {
					resultView.Text = operation.CalcView;
				}
				else {
					// previous operation result on screen then pressed = --> continue to apply same operation
					if (resultView.Text.Length > 0 && operation.Operand1 == ""){
						operation.Operand1 = resultView.Text;
						operation.Operator = operation.PrevOperator;
						operation.Operand2 = operation.PrevOperand2;
					}
					// operand 1, operation, operand2, then = presed OR prev op result, operation, operand2
					else {
							operation.Operand2 = resultView.Text;
					}
						Operation(sender, resultView);
				}
			} ;

			// wipe everything when C pressed
			clear.Click += (sender, e) => {
				operation.Reset();
				operation.PrevOperand2 = "";
				operation.PrevOperator = "";
				resultView.Text = operation.CalcView;
			} ;

			// only one point allowed per input
			point.Click += (sender, e) => {
				// if there is already a point there, don't add another
				if (operation.CalcView.Contains("."))
					operation.CalcView += "";
				else {
					operation.CalcView += ".";
				}
				resultView.Text = operation.CalcView;
			} ;

			// pi number is rendered on screen except when Error msg shows up
			pi.Click += (sender, e) => {
				if (resultView.Text == "ERROR") 
					resultView.Text = "ERROR";
				operation.CalcView = Math.PI.ToString();
				resultView.Text = operation.CalcView;
			} ;

			sqrt.Click += (sender, e) => {
				bool negflag = false;
				// can't find sq root of nothing, error or complex numbers (with i)
				if (resultView.Text.Length == 0 || resultView.Text == "ERROR" || resultView.Text.Contains("i")) 
					resultView.Text = "ERROR";
				else {
					if (resultView.Text == operation.Result) //previous calculation left behind and sq root pressed
						operation.CalcView = operation.Result;
					Double doubnum = Convert.ToDouble(operation.CalcView);
					if (doubnum < 0) { // set negative flag on and change neg to positive numbers
						negflag = true;
						doubnum *= -1;
					}
					operation.Result = (Math.Sqrt(doubnum)).ToString();
					if (negflag) operation.Result += "i"; //if negative on concatenate imaginary i					resultView.Text = "";
					operation.CalcView = operation.Result;
					resultView.Text = operation.CalcView;
				}
			} ;
		}

		/* 
		 * Methods:
		 * 
		 *  void Operation(object sender, TextView resultView) = Calculates the single or 2 operands.
		 *  void numEventHandler(object sender, TextView resultView) = Action for when a number is pressed.
		 *  void operatorEventHandler(object sender, TextView resultView) = Action for when an operator is pressed.
		 * 
		 */ 
		void Operation(object sender, TextView resultView) {
			if (operation.Singleton) { // calculation with one operand (+/-, %, trig function)
				Button btn = (Button)sender;
				String btnAction = btn.Text;
				operation.SingleOperation(btnAction, resultView);
			}
			else { // x (+-/*) y =
				operation.TwoOperands();
			}
			if (!(operation.CalcView == "ERROR")) { 
				/* if calculation was successful:
				 *    result saved into CalcView to be rendered on screen
				 *    operator and operand2 saved into Prev for 2nd if in EqualsSign pressed;
				 * 		i.e., result is x and equals sign pressed again (repeat last operation with x).
				 */ 
				operation.CalcView = operation.Result;
				operation.PrevOperator = operation.Operator;
				operation.PrevOperand2 = operation.Operand2;
			}
			resultView.Text = operation.CalcView; // render view
			if (!operation.Singleton) { // if the calculator just did a 2 operand calculation...
				// don't reset Singleton ops, it may be used as an operand; need to keep info intact.
				operation.Reset (); 
				operation.CalcView = resultView.Text; // match calcView with what's on the screen
			}
			operation.Singleton = false; // reset single op flag
		}
		void numEventHandler(object sender, TextView resultView) {
			Button btn = (Button)sender;
			// if there is a num from prev. calculation, the first operand or an error, erase
			if (operation.CalcView.Equals (operation.Result) ||
			    operation.CalcView.Equals (operation.Operand1) ||
			    resultView.Text.Equals ("ERROR"))
				operation.CalcView = "";
			operation.CalcView += btn.Text; // add onto existing number (e.g., 5 was pressed, then 2 --> 52)
			resultView.Text = operation.CalcView; // render view
		}
		void operatorEventHandler(object sender, TextView resultView) {
			Button btn = (Button)sender;
			operation.Operand1 = resultView.Text; // whatever is on screen now is the first operand
			operation.Operator = btn.Text;
		}
	}
}


