using System;
using System.Windows.Forms;

namespace NowPlaying4mastodon
{
	public partial class dlgPostSettings : Form
	{
		/// <summary>
		/// 
		/// </summary>
		public dlgPostSettings()
		{
			InitializeComponent();

			Load += DlgPostSettings_Load;
			FormClosing += DlgPostSettings_FormClosing;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DlgPostSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			//設定反映

			Properties.Settings.Default.Mastodon_Toot_PostArtwork = chkPostArtwork.Checked;
			Properties.Settings.Default.Mastodon_Toot_SetNSFW = chkExplictNSFW.Checked;
			Properties.Settings.Default.Mastodon_Toot_Visiblity = cmbTootVisibility.Text;
			Properties.Settings.Default.Mastodon_Toot_TrackChangedAutoPost = chkAutoPost.Checked;
			Properties.Settings.Default.Mastodon_Toot_Format = txtPostFormat.Text;
			Properties.Settings.Default.ShowTitlebarInfo = chkShowTitlebarTrackInfo.Checked;

			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DlgPostSettings_Load(object sender, EventArgs e)
		{
			//設定戻す
			cmbTootVisibility.SelectedIndex = 0;

			chkPostArtwork.Checked = Properties.Settings.Default.Mastodon_Toot_PostArtwork;
			chkExplictNSFW.Checked = Properties.Settings.Default.Mastodon_Toot_SetNSFW;
			chkAutoPost.Checked = Properties.Settings.Default.Mastodon_Toot_TrackChangedAutoPost;
			chkShowTitlebarTrackInfo.Checked = Properties.Settings.Default.ShowTitlebarInfo;
			cmbTootVisibility.Text = Properties.Settings.Default.Mastodon_Toot_Visiblity;
			txtPostFormat.Text = Properties.Settings.Default.Mastodon_Toot_Format;
		}
	}
}
