using System.Text.Json;

namespace NaWebConfigs2
{
    public partial class NaWebConfigs : Form
    {
        string url;
        string spinnerColorText = "#000000";
        string systemUIColorText = "#000000";
        bool showTopAppBar = true;
        string topAppBarTitleText = "";
        string topAppColorText  = "#000000";
        string topAppBarTitleColorText = "#000000";
        bool refreshIcon = true;
        string refreshIconColorText = "#000000";
        bool showInterstitialAds = true;
        string admobInterstitialIDText = "ca-app-pub-3940256099942544/1033173712";
        bool showBannerAds = true;
        string admobBannerIDText = "ca-app-pub-3940256099942544/6300978111";
        public NaWebConfigs()
        {
            InitializeComponent();
        }

        private void spinnerColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                spinnerColor.BackColor = colorDialog.Color;
                spinnerColorText = String.Format("#{0:X2}{1:X2}{2:X2}", colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
        }
        private void systemUIColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                systemUIColor.BackColor = colorDialog.Color;
                systemUIColorText = String.Format("#{0:X2}{1:X2}{2:X2}", colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
        }

        private void topAppColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                topAppBarColor.BackColor = colorDialog.Color;
                topAppColorText = String.Format("#{0:X2}{1:X2}{2:X2}", colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
        }


        private void topAppBarTitleColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                topAppBarTitleColor.BackColor = colorDialog.Color;
                topAppBarTitleColorText = String.Format("#{0:X2}{1:X2}{2:X2}", colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
        }

        private void refreshIconColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                refreshIconColor.BackColor = colorDialog.Color;
                refreshIconColorText = String.Format("#{0:X2}{1:X2}{2:X2}", colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            url = urlText.Text;
            topAppBarTitleText = topAppBarTitle.Text;
            admobInterstitialIDText = admobInterstitialID.Text;
            admobBannerIDText = admobBannerID.Text;

            if (showTopAppBarYes.Checked) {
                showTopAppBar = true;
            }
            else {
                showTopAppBar = false;
            }

            if (refreshIconYes.Checked) {
                refreshIcon = true;
            }
            else {
                refreshIcon = false;
            }

            if (showInterstitialYes.Checked) {
                showInterstitialAds = true;
            }
            else {
                showInterstitialAds = false;
            }

            if (showBannerYes.Checked) {
                showBannerAds = true;
            }
            else {
                showBannerAds = false;
            }

            Data data = new()
            {
                url = url,
                spinnerColorText = spinnerColorText,
                systemUIColorText = systemUIColorText,
                showTopAppBar = showTopAppBar,
                topAppBarTitleText = topAppBarTitleText,
                topAppColorText = topAppColorText,
                topAppBarTitleColorText = topAppBarTitleColorText,
                refreshIcon = refreshIcon,
                refreshIconColorText = refreshIconColorText,
                showInterstitialAds = showInterstitialAds,
                admobInterstitialIDText = admobInterstitialIDText,
                showBannerAds = showBannerAds,
                admobBannerIDText = admobBannerIDText
            };
            SaveFileDialog fileDialog = new SaveFileDialog { 
            FileName = "configs",
            DefaultExt = ".json"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK) {

                using Stream s = File.Open(fileDialog.FileName, FileMode.Create);
                using StreamWriter sw = new StreamWriter(s);
                sw.Write(JsonSerializer.Serialize(data));
            }
        }
    }
}