###とりあえず覚えておく3操作

1.  Inspectorをからダブルクリックすると、対象のオブジェクトを注目する
2.  Alt押しながらシーンをドラッグすると平行移動する
3.  マウスホイールをスクロールすると拡大縮小

###スプライトの操作

1.  スプライトを選択してドラッグするとスプライトが動く
2.  スプライトの右上を選択してドラッグすると、スプライトが回る
3.  スプライト端の青い玉をドラッグすると、サイズが変わる
4.  vを押しながら動かすと、他のスプライトにフィットする

※スプライトを動かす場合、SpriteRendererを開く

###

###Script A

```
using UnityEngine;

public class CrashBlock : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D col)
	{
		Destroy(gameObject);
	}
} 
```

###Script B

```
using UnityEngine;

public class CrashBlock : MonoBehaviour
{
	public float m_Strength = 1, m_hp = 1;

	void OnCollisionEnter2D(Collision2D col)
	{
		float damage = col.relativeVelocity.magnitude - m_Strength;
		if (damage > 0){
			m_hp -= damage;
		}

		if (m_hp < 0){
			Destroy(gameObject);
		}
	}
}
```

###Script C

```
using UnityEngine;

public class CrashBlock : MonoBehaviour
{
	public float m_Strength, m_hp;
	public GameObject m_Effect;

	void OnCollisionEnter2D(Collision2D col)
	{
		float damage = col.relativeVelocity.magnitude - m_Strength;
		if (damage > 0){
			m_hp -= damage;
		}

		if (m_hp < 0){
			Destroy(gameObject);
			Object effect = GameObject.Instantiate(
					m_Effect, 
					transform.position, 
					Quaternion.identity);
			DestroyObject(effect, 1.5f);
		}
	}
}
```

###Script D

```
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<Animator>().SetTrigger("Hit");
    }
}
```

#【extra】

##もっと作りこもう

###音楽の追加
1.  音楽を追加。[煉獄庭園](http://www.rengoku-teien.com/)や[魔王魂](http://maoudamashii.jokersounds.com/)、[AssetStore](https://www.assetstore.unity3d.com/#/category/78)からダウンロードしインポートします。
2.   インポートした音楽ファイルを選択し、**3d sound**のチェックを外す
3.  空のGameObjectを作成し、名前をMusicに変更、先ほどインポートしたオーディオファイルをドラッグ＆ドロップ。

###爆発する効果音の追加

1.  先ほどと同じ手順で爆発音をインポート（3d soundのチェックは外す）
2.  Effect>breakやEffect>Bombにドラッグ＆ドロップで登録

###発射音の追加

1.   効果音をインポート（3d soundのチェックは外す）
2.   Slingshot>Slingshot.csを開き、 **void Update()**の上に①のコードを追加。  
  また、64〜68行目を②のように修正。
3.  Scene上のSlingshotにaudioを設定する項目が追加されるので、変更する

①

```
public AudioClip shotAudio;
``` 

②

```
if (diff.magnitude > minPower)
{
	catchObject.rigidbody2D.isKinematic = false;
	catchObject.rigidbody2D.AddForce(diff * power);
	
	AudioSource.PlayClipAtPoint(shotAudio, Vector3.zero); // <- add
}
```

###Playerを2発以上発射出来るようにする

以下の操作で弾発射後一定時間で弾が補充される。

1.  Playerをプレハブ化
2.   シーンのSlingshotのSpawnPlayerのPlayerPrefabにアタッチ

なお、SlingShotのSlinhshotコンポーネントのMaxPowerとMinPowerは、引ける最大値と弾が発射出来る最小値

###オブジェクトに重さを設定する

質量の高い方が吹っ飛ばない。

1.  対象のオブジェクトを選択する。
2.  Rigidbody2Dのmassの値を2〜3と増やす。

*※ゆで理論は適応されないので、重くても落下速度は変わらない*

###凹凸のある地形を設定する

1.  Images>stage>ground_roughのスプライトをシーンに配置する。
2.  配置したスプライトにPolygonCollider2Dをアタッチする。

###スプライトの色を濃くする、透明にする

1.  SpriteRenderのColorを弄る

###揺れる物を作る

振り子の事で、胸や髪ではありません。

1.  接続元となる空のGameObjectを作成し、rigidbody2dをアタッチする。
2.  rigidbody2dのIsKinematicにチェックを入れる。（衝撃・重力では動かなくなる）
3.  揺れるSpriteを作成し、rigidbody2dとdistanceJoin2dをアタッチする。
4.  distanceJoinのConnected Rigidybodyに1で作成した接続元のオブジェクトを設定。  
distanceに適当な距離を設定する。

###テクスチャをパックする

同じタグかつ同じフォーマットのテクスチャを1枚のテクスチャにパックする。

1.  各スプライトのpacking tagに適当な名前  
（例えばPlayer関連はPlayer、backgroundはbackground)と設定
2.  メニュー>WIndow>SpritePackerを選択
3.    SpritePacker左上のPackを選択

現状developer previewなので、Textureをtexturepacker等でまとめてしまう方が有効。
http://terasur.blog.fc2.com/blog-entry-621.html