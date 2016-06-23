using Scripts._Libs.Downloader;
using UnityEngine;

namespace ODA.FileDownloader
{
    [UnitySingleton(UnitySingletonAttribute.Type.LoadedFromResources, false, "ProgressBar/DownloadCanvas")]
    public class ProgressBar : UnitySingleton<ProgressBar>
    {
        [SerializeField]private DownloadProgress _progressBar;

        public void UpdateProgress(float progress)
        {
            if (_progressBar != null) _progressBar.UpdateProgress(progress);
            else { Debug.Log("Progressbar is not set in inspector");}
        }
    }
}
