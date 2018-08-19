# なうぷれ for ますとどん

spotifyの再生中の曲をmastodonにトゥートするやつ。  
  
用意するもの  

・SpotifyのClient ID/Client Secret  
https://developer.spotify.com/dashboard/applications   

app.config
```
<setting name="Spotify_ClientId" serializeAs="String">
	<value />
</setting>
<setting name="Spotify_ClientSecret" serializeAs="String">
	<value />
</setting>

```   
   

・mastodonのクライアントキー/クライアントシークレット

app.config
``` 
<setting name="Mastodon_ClientKey" serializeAs="String">
	<value />
</setting>
<setting name="Mastodon_ClientSecret" serializeAs="String">
	<value />
</setting>

```

---

MIT License / 🐛 入りなので無保証
