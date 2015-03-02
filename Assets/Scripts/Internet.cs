using UnityEngine;
using System.Net;
using System.Collections;

public class Internet : MonoBehaviour {

	public static bool IsAvailable()
	{
		string resource = "http://www.google.com.tw";
		HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
		try
		{
			using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
			{
				bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
				if (isSuccess)
				{
					// do something
				}
			}
		}
		catch
		{
			return false;
		}
		return true;
	}
}
