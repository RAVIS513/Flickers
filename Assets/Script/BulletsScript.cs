using UnityEngine;
using System.Collections;

/*******************************************
 *
 * @file	BulletsScript.cs
 * @brief	初回弾生成
 * @author	goto
 * @date	2016/12/14
 *
 *******************************************/
public class BulletsScript : MonoBehaviour {

    // 変数定義
    public Transform bullet;

    // 定数定義
    private const float bulletInitPosX = 0;
    private const float bulletInitPosY = -4.0f;

    /*******************************************
	 *
	 * @brief	初回フレーム前処理
	 *
	 *
	 *
	 *******************************************/
    void Start () {

        Instantiate(bullet, new Vector2(bulletInitPosX, bulletInitPosY), Quaternion.identity);

	}

}
