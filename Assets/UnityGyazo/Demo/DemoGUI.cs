using UnityEngine;
using System.Collections;
using System.IO;

public class DemoGUI: MonoBehaviour
{
		public UnityGyazo gyazo;

		void OnGUI ()
		{
				// Labels
				GUILayout.BeginArea (new Rect (0, 0, Screen.width / 4, Screen.height / 3));
				GUILayout.Label ("Image File Path: ");
				GUILayout.Label ("Upload URL: ");
				GUILayout.EndArea ();

				GUILayout.BeginArea (new Rect (Screen.width / 4, 0, Screen.width / 4 * 3, Screen.height / 3));
				gyazo.localFilePath = GUILayout.TextField (gyazo.localFilePath);
				gyazo.uploadURL = GUILayout.TextField (gyazo.uploadURL);

				if (GUILayout.Button ("Upload local file")) {
						gyazo.UploadFileAsync (gyazo.localFilePath, gyazo.uploadURL);
				}
				GUILayout.EndArea ();

				if (GUI.Button (new Rect (0, Screen.height / 3, Screen.width, Screen.height / 3), "Upload screenshot directly")) {
						var fileName = "screenshot.png";
						Application.CaptureScreenshot (fileName);
						gyazo.UploadFileAsync (Path.Combine (Application.persistentDataPath, fileName), gyazo.uploadURL);
				}

				GUI.Label (new Rect (0, Screen.height - 100, Screen.width / 3, 50), "Log: ");
				GUI.TextField (new Rect (Screen.width / 3, Screen.height - 100, Screen.width / 3 * 2, 50), gyazo.Status.ToString () + ": " + gyazo.Log);

				GUI.Label (new Rect (0, Screen.height - 50, Screen.width / 3, 50), "Response from Gyazo: ");
				GUI.TextField (new Rect (Screen.width / 3, Screen.height - 50, Screen.width / 3 * 2, 50), gyazo.Response);

		}
}
