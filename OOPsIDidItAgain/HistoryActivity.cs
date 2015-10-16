using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;

namespace OOPsIDidItAgain
{
	[Activity (Label = "History", Icon = "@drawable/icon")]          
	public class HistoryActivity : ListActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			/*base.OnCreate(bundle);
			Intent passed = getIntent ();
			StackHistory myCalcStack = (StackHistory)passed.getSerializableExtra ("calc_history");
			*/
		}
	}
}