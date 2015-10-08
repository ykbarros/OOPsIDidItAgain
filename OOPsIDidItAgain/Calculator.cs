using System;
using Android.Widget;

namespace OOPsIDidItAgain
{
	public class Calculator
	{
		public Calculator() {
			// public constructor
			CalcView = "";
			Operand1 = "";
			Operator = "";
			Operand2 = "";
			Result = "";
			Singleton = false;
		}
		public string CalcView { get; set; } // Current Calculator View
		public string Operand1 { get; set; }
		public string Operator { get; set; }
		public string Operand2 { get; set; }
		public string Result { get; set; }
		public bool Singleton { get; set; } // Two Operand Operation or no?
		public string PrevOperator { get; set; }
		public string PrevOperand2 { get; set; }

		public void Reset() {
			// Erase everything
			CalcView = "";
			Operand1 = "";
			Operator = "";
			Operand2 = "";
			Singleton = false;
		}
		public void TwoOperands(){
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

		public void SingleOperation(string action, TextView resultView) {
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

