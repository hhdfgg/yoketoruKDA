# 音符取り  
## 操作方法
 - マウス移動で*パンプキン*が移動、ゴーストはW・A・S・Dで移動します。                   
　　　　　　　　　　　　　　　　（Wで上、Aで左、Sで下、Dで右）

## ゲーム説明
 - ２体のプレイヤー（パンプキンとゴースト）を動かして音符を取りましょう！  
   クリア方法は音符をすべて取ることです。  
   飛行機にあたってしまうとゲームオーバーです。  
   時間経過と共にスコアは減っていくので、音符を素早くすべて取りクリアを目指しましょう！  
   
## 使用素材
### アセットストア
 - プレイヤー  
    - ["Query-Chan" model](http://u3d.as/8Bh)のゴースト  
   - [Bretwalda Halloween](http://u3d.as/CfA)  
 - 音符  
   - [The Notes](http://u3d.as/7Lz)  
 - 敵  
   - [3D Voxel Cube Spaceships Sampler](http://u3d.as/w1e)  
 - 背景  
   - [Snow Mountain](http://u3d.as/a4i)  
   
### BGM・効果音  
 - [魔王魂](http://maoudamashii.jokersounds.com/)より
    - タイトル　　　　[Forever Truth](http://maoudamashii.jokersounds.com/archives/song_17_forever_truth.html)  
    - ゲーム中　　　　[空の記憶](http://maoudamashii.jokersounds.com/archives/song_18_karano_kioku.html)  
    - クリア　　　　　[ジングル04](http://maoudamashii.jokersounds.com/archives/se_maoudamashii_jingle04.html)  
    - ゲームオーバー　[ピアノ39](http://maoudamashii.jokersounds.com/archives/bgm_maoudamashii_piano39.html)  
 - [効果音ラボ](http://soundeffect-lab.info/)より
    - 時代劇演出１  
    - 回復魔法２  
## ライセンス
 - アセットストアの"Query-Chan" modelからゴーストを使用したのでライセンスロゴを掲載します。  
    - [クエリちゃん公式サイト](http://query-chan.com/)より  
![](http://query-chan.com/wp-content/uploads/2016/08/02_%E3%82%AF%E3%82%A8%E3%83%AA%E3%81%A1%E3%82%83%E3%82%93%E3%83%A9%E3%82%A4%E3%82%BB%E3%83%B3%E3%82%B9%E3%83%AD%E3%82%B4-e1472646888241-300x256.png)  
 
## 追加した点
 - タイトルにＥキーでの説明を追加  
    1. シーン(Description)を新しく追加して、CanvasをTitleからコピー。  
   2. CanvasにTextで説明を追加。  
   3. DescriptionにDescriptionManagerを設定し以下のプログラム追加
```c
		if (Input.GetKeyDown (KeyCode.E)) {
			SceneManager.LoadSceneAsync ("Title");
		}
```
  4. TitleManagerにもシーン切り替えのプログラム追加
```c
		if (Input.GetKeyDown (KeyCode.E)) {
			SceneManager.LoadSceneAsync ("Description");
		}
```
 - GameシーンにPlayer2を追加  
  1. Player2の操作をＷ・Ａ・Ｓ・Ｄで出来るようにした。
```c
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
  2. Player2が画面外に出ないようにした。(Playerだとマウスの位置を取得しているので、new Vector3に変えて値を制限した)  
```c
		transform.position =(new Vector3 (
			Mathf.Clamp(transform.position.x, MoveBounds.min.x, MoveBounds.max.x),
			Mathf.Clamp(transform.position.y, MoveBounds.min.y, MoveBounds.max.y),
			transform.position.z)
		);
```  
 - アイテムをもう一つ追加(同じ色で分かりにくいですが、音符の形が違います。)  
   1. BallをコピーしてBall2を作成(BallとBall2の子にそれぞれ違うPrefabを追加)  
   2. BallSpawnerもコピーし、Ball2Spawnerを作成。Prefabを変えた。 

 - 面白いことが出来た、GameシーンでPlayerを動かすと背景のアセット(3Dモデル)も動くようになった。
   なぜなら、PlayerのスクリプトにはPlayerオブジェクトをマウスの位置に置き換えるスクリプトが入っているから、
   Playerの子にすることにより、背景のアセット(3Dモデル)も一緒に動く！！！



