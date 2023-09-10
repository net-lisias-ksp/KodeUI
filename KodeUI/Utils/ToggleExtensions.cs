using System.Reflection;
 
namespace KodeUI
{
	// Based on https://forum.unity.com/threads/change-the-value-of-a-toggle-without-triggering-onvaluechanged.275056/#post-2307765
	public static class ToggleExtensions
	{
		static MethodInfo toggleSetMethod;

		static ToggleExtensions()
		{
			MethodInfo[] methods = typeof(UnityEngine.UI.Toggle).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
			for (var i = 0;i < methods.Length;i++)
			{
				if (methods[i].Name == "Set" && methods[i].GetParameters().Length == 2)
				{
					toggleSetMethod = methods[i];
					break;
				}
			}
		}
		public static void Set(this UnityEngine.UI.Toggle instance, bool value, bool sendCallback)
		{
			toggleSetMethod.Invoke(instance, new object[] { value, sendCallback });
		}
		public static void SetIsOnWithoutNotify(this UnityEngine.UI.Toggle instance, bool value)
		{
			toggleSetMethod.Invoke(instance, new object[] { value, false });
		}
	}
}
