using UnityEngine;
using System.Collections;
using System.IO;

public class UnityGyazo: MonoBehaviour
{
		public enum GyazoStatus
		{
				Init,
				Uploading,
				Success,
				Error
		}

		// Default filename
		public string localFilePath = "icon.png";

		// Default gyazo-server's URL to upload.
		// You can customize this URL if you want to upload to your own gyazo-server.
		public string uploadURL = "http://gyazo.com/upload.cgi";

		// Response from gyazo
		private string _response = "";
		public string Response { get { return _response; } }

		// Log message
		private string _log = "";
		public string Log { get { return _log; } }

		// Gyazo status
		public GyazoStatus Status { get; set; }

		void Start ()
		{
				if (!Directory.Exists (Application.persistentDataPath)) {
						Directory.CreateDirectory (Application.persistentDataPath);
				}

				Status = GyazoStatus.Init;
		}

		private IEnumerator UploadFileCoroutine (string absoluteFilePath, string uploadURL)
		{
				Status = GyazoStatus.Uploading;
				WWW localFile = new WWW ("file:///" + absoluteFilePath);
				yield return localFile;
				if (localFile.error == null) {
						_log = "Loaded file successfully.";
						Debug.Log (_log);
				} else {
						// if can't open image file then stop coroutine.
						_log = "Open file error: " + localFile.error;
						Status = GyazoStatus.Error;
						Debug.Log (_log);
						yield break;
				}

				WWWForm postForm = new WWWForm ();
				postForm.AddBinaryData ("imagedata", localFile.bytes);

				WWW upload = new WWW (uploadURL, postForm);
				yield return upload;

				if (upload.error == null) {
						// SUCCESS to upload then upload.text contains URL of the image uploaded.
						_response = upload.text;
						_log = "Upload done:" + upload.text;
						Status = GyazoStatus.Success;
						Debug.Log (_log);
				} else {
						_response = upload.error;
						_log = "Error during upload: " + upload.error;
						Status = GyazoStatus.Error;
						Debug.Log (_log);
				}
		}

		public void UploadFileAsync (string absoluteFilePath, string uploadURL = "http://gyazo.com/upload.cgi")
		{
				StartCoroutine (UploadFileCoroutine (absoluteFilePath, uploadURL));
		}
}
