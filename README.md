# EvilPenguinNet
Twitterの過去ツイート消すアプリです。
## Getting Started
本ソフトウェアはMITライセンスとしていますが、APIキーはビルドして利用する人が発行するものとします。
以下のサイトでAPIキーを発行してください。
* [Twitter開発者用サイト](https://developer.twitter.com/)

ビルドした後、App.configの以下のパラメータをTwitterで発行したキーに変更します。
### 設定例
```
  <add key="ConsumerKey" value="aqwsedfrtghyjuol"/>
  <add key="ConsumerSecret" value="gfhauwio236w7892vnal839pry98awpjm08awp"/>
  <add key="AccessToken" value="3789pqv8ldsj7t9aej78t9a839w8r"/>
  <add key="AccessSecret" value="wcril2678yav7ru3wak72816c8oaa86r"/>
```

## 使用方法
起動すると、このような画面になります。
![起動した状態](https://user-images.githubusercontent.com/39305262/53227410-7883c380-36c1-11e9-89a2-5e1eb73fcaec.PNG "起動した状態")
  右側に必要な情報を入力します。
### 入力項目：テキストボックス
テキストボックスについて上から順に以下の情報を入力します。
- アカウント名  
Twitterのアカウント名を入力します。例：ginpaydo
- ツイートID  
ここに入力したツイートIDから古いツイートを取得します。  空欄だと最新のツイートを取得します。  初めて使う場合は空欄にしてください。
- 取得ツイート数  
取得したいツイート件数を入力します。
指定できる値は200までです。
- 最小文字数  
この長さ以上の文字数のツイートのみを取得します。空欄だと全取得します。
### 入力項目：チェックボックス
- RetweetOnly  
この項目にチェックを入れると、リツイートのみ取得します。
### ボタン
- GetTopTweet  
ツイートを取得します。
- Save  
入力項目を記憶し、次回起動時に読み込まれます。
- Del  
選択したツイートを削除します。
### ツイートの選択
検索して表示したツイートはクリックで選択できます。
以下の方法で複数選択できます。
- Shiftを押しながらクリック  
範囲で選択できます。
- Ctrlを押しながらクリック  
現在の選択に追加して選択できます。複数選択するときに使用します。
## テストの実行
テストコードはありません。
## コントリビューション
プルリクエストについては特に考えていません。
## バージョン管理
バージョン管理については特に考えていません。
## 著者
* **Ginpaydo** - *原著者* - [Ginpaydo](https://github.com/ginpaydo)
このプロジェクトへの[貢献者](https://github.com/ginpaydo/project/contributors)のリストもご覧ください。
## ライセンス
このプロジェクトは MIT ライセンスの元にライセンスされています。 詳細は[LICENSE.md](LICENSE.md)をご覧ください。
## 謝辞
* Twitterさん、素敵なAPIをありがとうございました。
