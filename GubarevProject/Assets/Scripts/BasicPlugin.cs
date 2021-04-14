using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicPlugin : MonoBehaviour
{
    const string ToastClassName = "android.widget.Toast";

    public void OnMyButtonClick(InputField playerinputName)
	{	        
		var toastJavaClass = new AndroidJavaClass(ToastClassName);
		const int duration = 1; // LENGTH_LONG in Android API
		string text = playerinputName.text; // C# string is automatically converted to java.lang.String
		var context = GetUnityActivity();
		var javaToastObject = toastJavaClass.CallStatic<AndroidJavaObject>("makeText", context, text, duration);

        Debug.Log("Hypocrisy");
		javaToastObject.Call("show");	
		toastJavaClass.Dispose();
	}

	AndroidJavaObject GetUnityActivity()
	{
		using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
		{
			return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		}
	}
}
