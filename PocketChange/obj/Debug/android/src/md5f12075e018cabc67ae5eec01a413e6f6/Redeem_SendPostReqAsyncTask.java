package md5f12075e018cabc67ae5eec01a413e6f6;


public class Redeem_SendPostReqAsyncTask
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("PocketChange.Fragments.Redeem+SendPostReqAsyncTask, PocketChange, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Redeem_SendPostReqAsyncTask.class, __md_methods);
	}


	public Redeem_SendPostReqAsyncTask () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Redeem_SendPostReqAsyncTask.class)
			mono.android.TypeManager.Activate ("PocketChange.Fragments.Redeem+SendPostReqAsyncTask, PocketChange, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
