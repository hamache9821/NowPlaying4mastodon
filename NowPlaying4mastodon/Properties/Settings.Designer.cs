﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NowPlaying4mastodon.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://accounts.spotify.com/authorize")]
        public string Spotify_Endpoint_auth {
            get {
                return ((string)(this["Spotify_Endpoint_auth"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://accounts.spotify.com/api/token")]
        public string Spotify_Endpoint_token {
            get {
                return ((string)(this["Spotify_Endpoint_token"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://localhost/callback")]
        public string Spotify_Redirect_url {
            get {
                return ((string)(this["Spotify_Redirect_url"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("user-read-playback-state,user-modify-playback-state")]
        public string Spotify_oAuth_scope {
            get {
                return ((string)(this["Spotify_oAuth_scope"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("48c33e4f31cf48fcb45e475a97afce03")]
        public string Spotify_ClientSecret {
            get {
                return ((string)(this["Spotify_ClientSecret"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("399579fb41743ce1b1d6c1affbf3eff970a5a53be0481fc38f6186b0773cc5f6")]
        public string Mastodon_ClientKey {
            get {
                return ((string)(this["Mastodon_ClientKey"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("11470ba3fb6c2027e19abc5f647463761d5b821a08512e6470ac2025c851f94b")]
        public string Mastodon_ClientSecret {
            get {
                return ((string)(this["Mastodon_ClientSecret"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Mastodon_Access_token {
            get {
                return ((string)(this["Mastodon_Access_token"]));
            }
            set {
                this["Mastodon_Access_token"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Spotify_Access_token {
            get {
                return ((string)(this["Spotify_Access_token"]));
            }
            set {
                this["Spotify_Access_token"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Spotify_Refresh_token {
            get {
                return ((string)(this["Spotify_Refresh_token"]));
            }
            set {
                this["Spotify_Refresh_token"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Mastodon_Userinfo {
            get {
                return ((string)(this["Mastodon_Userinfo"]));
            }
            set {
                this["Mastodon_Userinfo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("public")]
        public string Mastodon_Toot_Visiblity {
            get {
                return ((string)(this["Mastodon_Toot_Visiblity"]));
            }
            set {
                this["Mastodon_Toot_Visiblity"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool Mastodon_Toot_SetNSFW {
            get {
                return ((bool)(this["Mastodon_Toot_SetNSFW"]));
            }
            set {
                this["Mastodon_Toot_SetNSFW"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool Mastodon_Toot_PostArtwork {
            get {
                return ((bool)(this["Mastodon_Toot_PostArtwork"]));
            }
            set {
                this["Mastodon_Toot_PostArtwork"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("{trackName} / {trackArtist}  {Links}   {Preview}  #Nowplaying")]
        public string Mastodon_Toot_Format {
            get {
                return ((string)(this["Mastodon_Toot_Format"]));
            }
            set {
                this["Mastodon_Toot_Format"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool Mastodon_Toot_TrackChangedAutoPost {
            get {
                return ((bool)(this["Mastodon_Toot_TrackChangedAutoPost"]));
            }
            set {
                this["Mastodon_Toot_TrackChangedAutoPost"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ShowTitlebarInfo {
            get {
                return ((bool)(this["ShowTitlebarInfo"]));
            }
            set {
                this["ShowTitlebarInfo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ES")]
        public string Spotify_Markets {
            get {
                return ((string)(this["Spotify_Markets"]));
            }
            set {
                this["Spotify_Markets"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("34675e91bb8f408faf548bee2a863b6c")]
        public string Spotify_ClientId {
            get {
                return ((string)(this["Spotify_ClientId"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("なうぷれ for Mastodon")]
        public string AppName {
            get {
                return ((string)(this["AppName"]));
            }
        }
    }
}
