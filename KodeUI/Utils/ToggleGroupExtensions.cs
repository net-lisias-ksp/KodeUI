using System.Reflection;
 
namespace KodeUI
{
	public static class ToggleGroupExtensions
	{
		static MethodInfo toggleSetMethod;

		static ToggleGroupExtensions()
		{
			MethodInfo[] methods = typeof(UnityEngine.UI.ToggleGroup).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
			for (var i = 0;i < methods.Length;i++)
			{
				if (methods[i].Name == "Set" && methods[i].GetParameters().Length == 2)
				{
					toggleSetMethod = methods[i];
					break;
				}
			}
		}
		public static void Set(this UnityEngine.UI.ToggleGroup instance, bool value, bool sendCallback)
		{
			toggleSetMethod.Invoke(instance, new object[] { value, sendCallback });
		}
		public static void SetAllTogglesOff(this UnityEngine.UI.ToggleGroup instance, bool value)
		{
			foreach (UnityEngine.UI.Toggle i in instance.ActiveToggles())
				i.Set(false, value);
		}
	}
}
