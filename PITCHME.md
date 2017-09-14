# 音符取り  

講義中に作った "yoketoru" に  
要素を追加して作りました。

---

### 操作方法
マウス移動でパンプキンが移動、  
ゴーストはW・A・S・Dで移動します。  
（Wで上、Aで左、Sで下、Dで右）

---

### ゲーム説明
- ２体のプレイヤー（パンプキンとゴースト）を動かして音符を取りましょう！
- クリア方法は音符をすべて取ることです。
- 飛行機にあたってしまうとゲームオーバーです。
- 時間経過と共にスコアは減っていくので、音符を素早くすべて取りクリアを目指しましょう！

---

### 使用素材
#### アセットストア
 - プレイヤー  
    - ["Query-Chan" model](http://u3d.as/8Bh)のゴースト  
    - [Bretwalda Halloween](http://u3d.as/CfA)  
 - 音符  
   - [The Notes](http://u3d.as/7Lz)  
 - 敵  
   - [3D Voxel Cube Spaceships Sampler](http://u3d.as/w1e)  
 - 背景  
   - [Snow Mountain](http://u3d.as/a4i)  

---

#### BGM・効果音  
 - [魔王魂](http://maoudamashii.jokersounds.com/)より
    - タイトル　　　　[Forever Truth](http://maoudamashii.jokersounds.com/archives/song_17_forever_truth.html)  
    - ゲーム中　　　　[空の記憶](http://maoudamashii.jokersounds.com/archives/song_18_karano_kioku.html)  
    - クリア　　　　　[ジングル04](http://maoudamashii.jokersounds.com/archives/se_maoudamashii_jingle04.html)  
    - ゲームオーバー　[ピアノ39](http://maoudamashii.jokersounds.com/archives/bgm_maoudamashii_piano39.html)  
    - 説明画面　　　　[時の彼方へ](http://maoudamashii.jokersounds.com/archives/song_12_tokino_kanatahe.html)  
 - [効果音ラボ](http://soundeffect-lab.info/)より
    - 時代劇演出１  
    - 回復魔法２
---

#### フォント
- [google noto](https://www.google.com/get/noto/#sans-jpan)のサイトより
    - Noto Sans CJK JP

---

### ライセンス
 - アセットストアの"Query-Chan" modelからゴーストを使用したのでライセンスロゴを掲載します。  
    - [クエリちゃん公式サイト](http://query-chan.com/)より  
![ALT属性](http://query-chan.com/wp-content/uploads/2016/08/02_%E3%82%AF%E3%82%A8%E3%83%AA%E3%81%A1%E3%82%83%E3%82%93%E3%83%A9%E3%82%A4%E3%82%BB%E3%83%B3%E3%82%B9%E3%83%AD%E3%82%B4-e1472646888241-300x256.png)

---

### 追加した点

1. タイトルにＥキーでの説明を追加  
   - シーン(Description)を新しく追加して、CanvasをTitleからコピー。
   - CanvasにTextで説明を追加。
   - DescriptionにDescriptionManagerを設定し以下のプログラム追加

```cs
   if (Input.GetKeyDown (KeyCode.E)) {
     SceneManager.LoadSceneAsync ("Title");
   }

```

---

2. Player2を追加
   - PlayerをコピーしてPlayer2を作成。
   - Player2をＷ・Ａ・Ｓ・Ｄで移動するようにした。
   - Player2が画面外に出ないようにした。(Playerだとマウスの位置を取得しているので、new Vector3だけに変えて値を制限した)

---

```cs
if (Input.GetKey(KeyCode.W)){
  transform.position += new Vector3 (0f, MAX_SPEED * Time.deltaTime, 0f);
}

if (Input.GetKey(KeyCode.A)){
  transform.position += new Vector3 (-(MAX_SPEED * Time.deltaTime), 0f, 0f);
}

if (Input.GetKey(KeyCode.S)){
  transform.position += new Vector3 (0f, -(MAX_SPEED * Time.deltaTime), 0f);
}

if (Input.GetKey(KeyCode.D)){
  transform.position += new Vector3 (MAX_SPEED * Time.deltaTime, 0f, 0f);
}
```

---

```cs
transform.position =(new Vector3 (
	Mathf.Clamp(transform.position.x, MoveBounds.min.x, MoveBounds.max.x),
	Mathf.Clamp(transform.position.y, MoveBounds.min.y, MoveBounds.max.y),
	transform.position.z)
);
```

---

3. アイテムをもう一つ追加 (同じ色で分かりにくいですが、音符の形が違います。)
   - BallをコピーしてBall2を作成(BallとBall2の子にそれぞれ違うPrefabを追加)
   - BallSpawnerもコピーし、Ball2Spawnerを作成。Prefabを変えた。

 ---

4. 難易度の設定
   - タイトル画面で１・２・３キーを押すことで選択できるようにした。(1で簡単、2で普通、3で難しい)  
   そしてCanvasにText追加
   - Game1、Game2のシーンを新しく追加し、Gameから中身をコピーし、Spawnerで敵とボールの数と速さを調節。

---

```cs
// 1が押されたら、Game1シーンに切り替え
if (Input.GetKeyDown (KeyCode.Alpha1)||Input.GetKeyDown (KeyCode.Keypad1)) {
   SceneManager.LoadSceneAsync ("Game1");
}

// 2が押されたら、Gameシーンに切り替え
if (Input.GetKeyDown (KeyCode.Alpha2)||Input.GetKeyDown (KeyCode.Keypad2)) {
   SceneManager.LoadSceneAsync ("Game");
}

// 3が押されたら、Game2シーンに切り替え
if (Input.GetKeyDown (KeyCode.Alpha3)||Input.GetKeyDown (KeyCode.Keypad3)) {
   SceneManager.LoadSceneAsync ("Game2");
}
```

---

### 悩んだ所とやりたかったこと  
###### 悩んだ所  
   - Player2が画面から出ないようすること  
Playerはマウスの位置を取得していて、プログラムをそのまま使うことはできなかったので、色々なサイトを調べてがそのサイト古かったりしてエラーでたりしたので、かなり考えて試行錯誤してやっと出来た。  

 ---

###### やりたかったこと  
   - アイテムを追加したときに、取得した時のScoreを変えること。しかし、MoveBallをコピーしてMoveBall2を作成してみたが、Ballcountのプログラムがどこでどう動いているか理解できずに、片方だけ全部取ったらClearと出てしまい諦めました。  
   - タイトル画面でTextの"キーを押してスタート！"を点滅させたかった。  

---

#### 確認できているバグ  
 - タイトルでキーを同時に押すと、押された順にシーンがすぐに切り替わってしまうこと。(解決方法が分からなかった)  
  
