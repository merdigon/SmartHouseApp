package md523b81258409d755e8a1bd3bfe6d2f966;


public class A01SearchRouters_01
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
		mono.android.Runtime.register ("SmartHouseApp.Activities.A01SearchRouters.A01SearchRouters_01, SmartHouseApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", A01SearchRouters_01.class, __md_methods);
	}


	public A01SearchRouters_01 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == A01SearchRouters_01.class)
			mono.android.TypeManager.Activate ("SmartHouseApp.Activities.A01SearchRouters.A01SearchRouters_01, SmartHouseApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
