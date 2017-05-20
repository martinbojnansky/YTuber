//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Windows.UI.Xaml.Controls;

//namespace YTuber.Services.Download
//{
//    public class YoutubeDownload : StorageFileDownloader
//    {
//        public WebView YoutubeWebView { get; set; }
//        public WebView DownloaderWebView { get; set; }

//        public YoutubeDownload()
//        { }

//        public void SetWebViews(WebView youtubeWebView, WebView downloaderWebView)
//        {
//            YoutubeWebView = youtubeWebView;
//            DownloaderWebView = downloaderWebView;
//        }

//        public async Task<string> InvokeScriptAsync(string javascript, WebView webView)
//        {
//            try
//            {
//                return await webView.InvokeScriptAsync("eval", new string[] { javascript });
//            }
//            catch (Exception ex)
//            {
//                return ex.Message;
//            }
//        }

//        public async Task DownloadMp3Async()
//        {
//            try
//            {
//                await StartConvertingVideoAsync();
//                var isSuccessful = await WaitForConversionAsync();

//                if (isSuccessful)
//                {
//                    var downloadUrl = await GetDownloadUrlAsync();
//                    var fileName = await GetFileNameAsync();

//                    await DownloadFileAsync(downloadUrl, fileName);
//                }
//            }
//            catch
//            {
//                await Dialogs.ShowError("MP3 download failed.");
//            }
//        }

//        #region Youtube-Mp3.org

//        private async Task StartConvertingVideoAsync()
//        {
//            // Get url of youtube video
//            string videoUrl = await InvokeScriptAsync("document.location.href;", YoutubeWebView);
//            // Set url to convert video
//            await InvokeScriptAsync("document.getElementById('youtube-url').value = '" + videoUrl + "';", DownloaderWebView);
//            // Start converting video
//            await DownloaderWebView.InvokeScriptAsync("btnSubmitClick", null);
//        }

//        private async Task<bool> WaitForConversionAsync()
//        {
//            bool isLoaded = false;

//            while (!isLoaded)
//            {
//                await Task.Delay(TimeSpan.FromMilliseconds(100));

//                var progress_info_class = await InvokeScriptAsync("document.getElementById('progress_info').className;", DownloaderWebView);

//                if (progress_info_class.Equals("success") || progress_info_class.Equals("error"))
//                {
//                    isLoaded = true;

//                    if (progress_info_class.Equals("error"))
//                    {
//                        await HandleConversionErrorAsync();
//                        return false;
//                    }
//                }
//            }

//            return true;
//        }

//        private async Task<string> GetDownloadUrlAsync()
//        {
//            return await InvokeScriptAsync(@"
//                        var link; 
//                        var dl_link = document.getElementById('dl_link');                      
//                        var links = dl_link.getElementsByTagName('a'); 

//                        for (var i = 0; i < links.length; i++) 
//                        { 
//                            if(links[i].style.display != 'none') 
//                            { 
//                                link = links[i].href; 
//                            };
//                        }" , DownloaderWebView);
//        }

//        private async Task<string> GetFileNameAsync()
//        {
//            string fileName = await InvokeScriptAsync("document.getElementById('title').innerText;", DownloaderWebView);
//            fileName = fileName.Replace("Title: ", "") + ".mp3";
//            fileName = RemoveInvalidFileNameCharacters(fileName);

//            return fileName;
//        }

//        private async Task HandleConversionErrorAsync()
//        {
//            var error = await InvokeScriptAsync("document.getElementById('error_text').innerHTML;", DownloaderWebView);

//            if (error.Contains("20") || error.Contains("copyright"))
//            {
//                await Dialogs.ShowError("Video could not be converted due to the maximal lenght of 20 minutes or the special copyright.");
//            }
//            else if (error.Contains("Invalid URL"))
//            {
//                await Dialogs.ShowError("No music video was found on the requested page.");
//            }
//            else
//            {
//                await Dialogs.ShowError("MP3 could not be converted for unknown reason.");
//            }

//            return;
//        }

//        private string RemoveInvalidFileNameCharacters(string fileName)
//        {
//            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

//            foreach (char c in invalid)
//            {
//                fileName = fileName.Replace(c.ToString(), string.Empty);
//            }

//            return fileName;
//        }

//        #endregion
//    }
//}
