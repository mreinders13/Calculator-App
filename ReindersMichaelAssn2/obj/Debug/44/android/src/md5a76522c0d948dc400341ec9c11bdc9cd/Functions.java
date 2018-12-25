package md5a76522c0d948dc400341ec9c11bdc9cd;


public class Functions
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ReindersMichaelAssn2.Functions, ReindersMichaelAssn2", Functions.class, __md_methods);
	}


	public Functions ()
	{
		super ();
		if (getClass () == Functions.class)
			mono.android.TypeManager.Activate ("ReindersMichaelAssn2.Functions, ReindersMichaelAssn2", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
