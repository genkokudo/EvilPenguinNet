# EvilPenguinNet
Twitterの過去ツイート消すアプリ

【必要なライブラリ】
Nugetから以下をインストールします。
・CoreTweet
・Newtonsoft.Json

【必要な設定】
App.configの以下のパラメータを、Twitterで発行したキーに変更します。

      <add key="ConsumerKey" value="aqwsedfrtghyjuol"/>
      <add key="ConsumerSecret" value="gfhauwio236w7892vnal839pry98awpjm08awp"/>
      <add key="AccessToken" value="3789pqv8ldsj7t9aej78t9a839w8r"/>
      <add key="AccessSecret" value="wcril2678yav7ru3wak72816c8oaa86r"/>

【App.configの内容】
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
    </startup>
    <appSettings>
      <!-- トークン -->
      <add key="ConsumerKey" value="設定すること"/>
      <add key="ConsumerSecret" value="設定すること"/>
      <add key="AccessToken" value="設定すること"/>
      <add key="AccessSecret" value="設定すること"/>
    </appSettings>
</configuration>
