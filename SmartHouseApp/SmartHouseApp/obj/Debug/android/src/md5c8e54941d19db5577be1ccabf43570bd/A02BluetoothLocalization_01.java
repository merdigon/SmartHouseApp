package md5c8e54941d19db5577be1ccabf43570bd;


public class A02BluetoothLocalization_01
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("SmartHouseApp.Activities.A02BluetoothLocalization.A02BluetoothLocalization_01, SmartHouseApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", A02BluetoothLocalization_01.class, __md_methods);
	}


	public A02BluetoothLocalization_01 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == A02BluetoothLocalization_01.class)
			mono.android.TypeManager.Activate ("SmartHouseApp.Activities.A02BluetoothLocalization.A02BluetoothLocalization_01, SmartHouseApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
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
