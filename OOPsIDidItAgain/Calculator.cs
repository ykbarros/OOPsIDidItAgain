using System;
using Android.Widget;

namespace OOPsIDidItAgain
{
	public class Calculator
	{
		internal Calculator() {
			CalcView = "";
			Operand1 = "";
			Operator = "";
			Operand2 = "";
			Result = "";
			Singleton = false;
		}
		internal string CalcView { get; set; } // Current Calculator View
		internal string Operand1 { get; set; }
		internal string Operator { get; set; }
		internal string Operand2 { get; set; }
		internal string Result { get; set; }
		internal bool Singleton { get; set; } // Two Operand Operation or no?
		internal string PrevOperator { get; set; }
		internal string PrevOperand2 { get; set; }

		internal void Reset() {
			// Erase everything
			CalcView = "";
			Operand1 = "";
			Operator = "";
			Operand2 = "";
			Singleton = false;
		}
		internal void TwoOperands(){
			double op1 = 0.0;
			double op2 = 0.0;
			double doubResult = 0.0;

			try {
				op1 = Convert.ToDouble(Operand1);
				op2 = Convert.ToDouble(Operand2);
			}
			catch(FormatException){
				CalcView = "ERROR";
			}
			// add, subtract, divide, multiply
			switch (Operator) {
			case "+":
				doubResult = op1 + op2;
				break;
			case "-":
				doubResult = op1 - op2;
				break;
			case "÷":
				if (op2 == 0) {
					CalcView = "ERROR"; // divide by Zero
				} 
				else {
					doubResult = op1 / op2;
				}
				break;
			case "x":
				doubResult = op1 * op2;
				break;
			}
			this.Result = doubResult.ToString();
		}

		internal void SingleOperation(string action, TextView resultView) {
			double op1 = 0.0; 
			// can't operate on nothing and error or 0 can neither be pos or neg
			if (CalcView.Length == 0 || (CalcView == "0" && action == "+/-") ||
			    CalcView == "ERROR")
				CalcView = "ERROR";
			else {
				try {
					op1 = Convert.ToDouble(resultView.Text);
				}
				catch(FormatException){
					CalcView = "ERROR";
				}
				switch (action) {
				case "+/-":
					Result = (op1 * (-1)).ToString();
					break;
				case "%":
					Result = (op1 * (.01)).ToString();
					break;
				case "sin":
					Result = Math.Sin(op1).ToString();
					break;
				case "cos":
					Result = Math.Cos(op1).ToString();
					break;
				case "tan":
					Result = Math.Tan(op1).ToString();
					break;
				}
			}
		}
	}
}

