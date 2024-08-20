namespace System.Text.Json.External;

public static partial class JsonExternal
{
	public static JsonElement GetPropertyEx(this JsonElement rootElement, string propertyPath, char splitChar = '.')
	{
		string[] pathNodes = propertyPath.Split(splitChar); 
		return GetPropertyEx(rootElement, pathNodes);
	}

	public static JsonElement GetPropertyEx(this JsonElement rootElement, string[] pathNodes)
	{
		JsonElement element = rootElement;
		int arraycount = pathNodes.Length - 1;
		int count = -1;
		while (count < arraycount)
		{
			count++;
			element = element.GetProperty(pathNodes[count]);
		}
		return element;
	}

	public static bool TryGetPropertyEx(this JsonElement rootElement, string propertyPath, out JsonElement element, char splitChar = '.')
	{
		string[] pathNodes = propertyPath.Split(splitChar);
		bool result = TryGetPropertyEx(rootElement, pathNodes, out element);
		return result;
	}

    public static bool TryGetPropertyEx(this JsonElement rootElement, string[] pathNodes, out JsonElement element)
    {
		element = rootElement;
		int arraycount = pathNodes.Length - 1;
		int count = -1;
		while (count < arraycount)
		{
			count++;
			if (!element.TryGetProperty(pathNodes[count], out element)) return false;
		}
		return true;
    }
}
