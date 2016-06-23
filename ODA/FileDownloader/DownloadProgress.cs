using UnityEngine;
using UnityEngine.UI;

namespace ODA.FileDownloader
{
    public class DownloadProgress : MonoBehaviour
    {
        private static DownloadProgress _instance;
        private Image ProgressBar
        {
            get
            {
                return _instance.gameObject.GetComponent<Image>();
            }
        }

        void Awake()
        {
            _instance = this;
            UpdateProgress(0f);
        }

        public void UpdateProgress(float progress)
        {
            _instance.ProgressBar.transform.localScale = new Vector3(progress, 1, 1);
        }
    }
}
