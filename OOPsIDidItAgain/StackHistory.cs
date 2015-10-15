using System;
using System.Collections.Generic;

namespace OOPsIDidItAgain
{
	public class StackHistory<T>
	{
		private Node first; // top of the stack

		public bool isEmpty { get { return first == null; } }

		public void push(string element) {
			Node old = first;
			first = new Node();
			first.userInput = element;
			first.next = old;
		}

		public string pop() {
			if (isEmpty)
				throw new Exception ("Stack Underflow: No elements in the stack");
			string element = first.userInput;
			first = first.next; // the element after the top gets to be top now
			return element.ToString();
		}

		public string peek() {
			if (isEmpty)
				throw new Exception ("Stack Underflow: No elements in the stack");
			return first.userInput.ToString ();
		}
			
	}
	public class Node {
		public string userInput { get; set; }
		public Node next { get; set; }
	}
}

