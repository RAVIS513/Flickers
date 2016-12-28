using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/*******************************************
 *
 * @file	StartScript.cs
 * @brief	タイトル画面処理
 * @author	goto
 * @date	2016/12/14
 *
 *******************************************/
public class StartScript : MonoBehaviour {

    // 変数定義
    private Image panel;
    private float step;

    /*******************************************
	 *
	 * @brief	初期化
	 *
	 *
	 *
	 *******************************************/
    void Awake()
    {

        step = 0.01f;

    }

    /*******************************************
	 *
	 * @brief	初回フレーム前処理
	 *
	 *
	 *
	 *******************************************/
    void Start ()
    {

        panel = GameObject.Find("Panel").GetComponentInChildren<Image>();

	}

    /*******************************************
     *
     * @brief	フレーム毎処理
     *
     * @detail	ボタン点滅
     *
     *******************************************/
    // Update is called once per frame
    void Update ()
    {

        // 現在のカラー値を取得
        float r = panel.color.r;
        float g = panel.color.g;
        float b = panel.color.b;
        float a = panel.color.a;

        // アルファー値増減
        if (a < 0.5 || a > 1)
        {

            step = step * -1;

        }

        // アルファー値更新
        panel.color = new Color(r, g, b, a + step);
	
	}

    /*******************************************
     *
     * @brief	フレーム毎処理
     *
     * @detail	ボタン点滅
     *
     *******************************************/
    public void OnClick()
    {

        // ゲームスタート
        SceneManager.LoadScene("Main");

    }

}
