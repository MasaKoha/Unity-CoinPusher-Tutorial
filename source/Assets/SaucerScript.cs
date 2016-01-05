using UnityEngine;
using System.Collections;

public class SaucerScript : MonoBehaviour {

	// scoreTextをインスペクタ上に表示させる
	public GameObject scoreText;
	ScoreScript scoreS;
	AudioSource getSE;

	void Start() {
		scoreS = scoreText.GetComponent<ScoreScript>();
		// Saucerに付けたAudioSourceコンポーネントをとってくる
		getSE = this.GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision colObject) {
		// Saucerと衝突したオブジェクトの「タグ」が"Coin"だったときに衝突したオブジェクトを消す(Destroy)
		if (colObject.gameObject.tag == "Coin") {
			Destroy(colObject.gameObject);
			scoreS.addScore(2);
			// PlayOneShotでAudioClipに入れた音を一度だけ鳴らす
			getSE.PlayOneShot(getSE.clip);
		}
	}
}