using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace syntaxmd
{
    public partial class Form1 : Form
    {
        private readonly string zipUrl = "https://gist.github.com/SkitDev/675ec5b3bc53d9ec0275ac87ee5ac559/archive/a3c9fb426a5389be3caac6ca3d6f9d0cddbb1403.zip";
        private readonly string installDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "syntaxmd");
        private readonly string indexPath;

        public Form1()
        {
            InitializeComponent();
            this.Text = "syntax.md";

            indexPath = Path.Combine(installDir, "index.html");

            EnsureFilesDownloaded();
            InitializeWebView();
        }

        private void EnsureFilesDownloaded()
        {
            try
            {
                if (File.Exists(indexPath)) return;

                string tempZipPath = Path.Combine(Path.GetTempPath(), "syntaxmd_temp.zip");

                using (var client = new WebClient())
                {
                    client.DownloadFile(zipUrl, tempZipPath);
                }

                if (Directory.Exists(installDir))
                    Directory.Delete(installDir, true);

                ZipFile.ExtractToDirectory(tempZipPath, installDir);
                File.Delete(tempZipPath);

                // fix subfolder nesting
                var dirs = Directory.GetDirectories(installDir);
                if (dirs.Length == 1)
                {
                    var sub = dirs[0];
                    foreach (var file in Directory.GetFiles(sub))
                        File.Move(file, Path.Combine(installDir, Path.GetFileName(file)));
                    foreach (var dir in Directory.GetDirectories(sub))
                        Directory.Move(dir, Path.Combine(installDir, Path.GetFileName(dir)));
                    Directory.Delete(sub, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to download or extract markdown app:\n{ex.Message}", "syntax.md error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private void InitializeWebView()
        {
            var webView = new WebView2
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(webView);

            // sanity check
            if (!File.Exists(indexPath))
            {
                MessageBox.Show("index.html not found at:\n" + indexPath, "syntax.md error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // convert path to file:// URI safely
            string uriPath = new Uri(new FileInfo(indexPath).FullName).AbsoluteUri;
            webView.Source = new Uri(uriPath);
        }
    }
}
