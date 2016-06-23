using UnityEngine;

namespace ODA.FileDownloader.Test
{
    public class TestDownload : MonoBehaviour
    {

        public string url = "";

        void Awake()
        {
            StartCoroutine(FileDownloader.GetFile(url));
        }
    }
}
