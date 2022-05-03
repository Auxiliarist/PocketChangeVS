package md5f7515de53d2d97f4bcd5a6ad73819c16;


public class OfferRecyclerViewAdapterViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("PocketChange.Adapters.OfferRecyclerViewAdapterViewHolder, PocketChange, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", OfferRecyclerViewAdapterViewHolder.class, __md_methods);
	}


	public OfferRecyclerViewAdapterViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == OfferRecyclerViewAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("PocketChange.Adapters.OfferRecyclerViewAdapterViewHolder, PocketChange, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

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
