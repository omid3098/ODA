using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace ODA.FileDownloader
{
    /// <summary>
    /// Download a file and save it in Application.dataPath
    /// </summary>
    public class FileDownloader
    {
        public static float progress;
        public static bool downloading;

        public static IEnumerator GetFile(string url, bool localFile = false, bool saveFile = true)
        {
            if (localFile) url = "file://" + url;
            var fileName = GetFileName(url);
            Debug.Log("Download Startd: " + fileName);
            progress = 0;
            downloading = true;
            var myW = new WWW(url);
            while (!myW.isDone)
            {
                progress = myW.progress;
                ProgressBar.Instance.UpdateProgress(progress);
                yield return null;
            }
            progress = 0f;
            ProgressBar.Instance.UpdateProgress(progress);
            if (saveFile)
            {
                var data = myW.bytes;
                var docPath = DownloaderSetting.downloadPath + "/" + fileName;
                File.WriteAllBytes(docPath, data);
            }
            Debug.Log("Download Complete : " + DownloaderSetting.downloadPath + " : " +((long)myW.size).ToPrettySize());
            myW.Dispose();
            downloading = false;
        }

        private static string GetFileName(string hrefLink)
        {
            return Path.GetFileName(Uri.UnescapeDataString(hrefLink).Replace("/", "\\"));
        }
    }
}
