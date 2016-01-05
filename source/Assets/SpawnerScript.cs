using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

	float moveSpeed = 2.0f;
	Rigidbody rb;

	/*
     * public で変数宣言をすると、インスペクタ上に項目が表示される。
     * ここではcoin という変数がインスペクタ上で表示される。
     */
	public GameObject coin;
	/*
     * シーンに置いたLeftWall 、RightWall をこのスクリプトで使用する。
     * また、それぞれのx 座標の変数も準備しておく。
     */
	public GameObject leftWall;
	public GameObject rightWall;
	float leftWallPositionX;
	float rightWallPositionX;

	void Start () {
		// スクリプトを付けたゲームオブジェクトのRigidbodyコンポーネントを取得する
		rb = this.GetComponent<Rigidbody>();
		// leftWall とrightWall のx 座標を取得
		leftWallPositionX = leftWall.transform.position.x;
		rightWallPositionX = rightWall.transform.position.x;
	}

	void Update () {
		/*
         * Mathf.Clamp である変数の最小値と最大値を設定することができる。
         * 第一引数は設定したい変数、第二引数は最小値、第三引数は最大値である。
         * Spawner の移動できるx 座標範囲をleftWallPosition のx 座標から、rightWallPostion のx 座標の範囲にしている。
         */
		Vector3 currentPosition = this.transform.position;
		currentPosition.x = Mathf.Clamp(currentPosition.x,leftWallPositionX,rightWallPositionX);
		this.transform.position = currentPosition;

		/*
         * Inputクラスは入力システムに関する関数が含まれている。
         * GetAxisでPCの矢印キーの入力を受け付けることができる。
         * "Horizontal"だと、左右の矢印キーの入力を受け付け、"Vertical"だと
         * 上下の矢印キーの入力を受け付けるようになる。
         * http://docs.unity3d.com/ja/current/ScriptReference/Input.GetAxis.html
         */
		float x = Input.GetAxis ("Horizontal");

		// キー入力された際の移動する向きを決める。
		// 今回はx軸方向に移動させたい
		Vector3 direction = new Vector3 (x, 0, 0);

		// velocity(速度)に代入することによって、このオブジェクトの移動速度が決定される
		rb.velocity = direction * moveSpeed;

		/* 
         * スペースキーが押されたときにcoinを生成する。
         * 第一引数は生成するオブジェクト、第二引数は生成する場所、第三引数は生成する角度
         */
		if (Input.GetKeyDown("space")) {
			Instantiate(coin,this.transform.position,this.transform.rotation);
		}
	}
}