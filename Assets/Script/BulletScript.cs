using UnityEngine;
using System.Collections;

/*******************************************
 *
 * @file	BulletScript.cs
 * @brief	弾処理
 * @author	goto
 * @date	2016/12/14
 *
 *******************************************/
public class BulletScript : MonoBehaviour {

    // 変数定義
    public Camera cameraObj;
    public Transform bullet;
    private Vector2 onMousePos, onMousePosBuff1, onMousePosBuff2;
    private float xdiff, ydiff;
    private bool fire;
    private int frameCount;
    private float fps;
    private float prevtime;

    // 定数定義
    private const float onFlickDiff = 0.5f;
    private const float bulletSpeed = 0.2f;
    private const float bulletInitPosX = 0;
    private const float bulletInitPosY = -4.0f;
    private const float negativeMargin = -0.1f;
    private const float positiveMargin = 1.1f;

    /*******************************************
     *
     * @brief	初期化
     *
     *
     *
     *******************************************/
    void Awake()
    {

        fire = false;
        frameCount = 0;
        fps = 0;
        prevtime = 0;

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

        // カメラオブジェクト設定
        if (cameraObj == null)
        {
            cameraObj = Camera.main;
        }
	
	}

    /*******************************************
     *
     * @brief	フレーム毎処理
     *
     * @detail	画面タッチ処理
     *
     *******************************************/
    void Update ()
    {

        if (fire)
        {

            return;

        }

        // FPS算出
        calculateFps();

        // 画面タッチ中処理
        if (Input.GetMouseButton(0))
        {

            // 弾位置調整
            adjustBulletPosition();


            // 1～2フレーム前のタッチ位置を取得
            onMousePos = onMousePosBuff1;
            if (fps < 30.0f)
            {

                onMousePosBuff1 = cameraObj.ScreenToWorldPoint(Input.mousePosition);
                onMousePosBuff2 = onMousePosBuff1;

            } else
            {

                onMousePosBuff1 = onMousePosBuff2;
                onMousePosBuff2 = cameraObj.ScreenToWorldPoint(Input.mousePosition);

            }

        }

        // 画面タッチを離した時処理
        if (Input.GetMouseButtonUp(0))
        {

            // フリック判定
            Vector2 upMousePos = cameraObj.ScreenToWorldPoint(Input.mousePosition);
            float diff = Vector2.Distance(upMousePos, onMousePos);
            if (diff > onFlickDiff)
            {

                // 弾発射
                xdiff = upMousePos.x - onMousePos.x;
                ydiff = upMousePos.y - onMousePos.y;
                fire = true;

                // 次の弾を生成
                Instantiate(bullet, new Vector2(bulletInitPosX, bulletInitPosY), Quaternion.identity);

            }

        }

    }

    /*******************************************
     *
     * @brief	固定フレーム毎処理
     *
     * @detail	オブジェクト移動
     *
     *******************************************/
    void FixedUpdate ()
    {

        if (fire)
        {

            // 画面外に移動した場合、自身のオブジェクトを削除
            if (isOutScreen())
            {

                Destroy(this.gameObject);

            }

            // 弾移動
            Vector2 pos = gameObject.transform.position;
            pos.x += xdiff * bulletSpeed;
            pos.y += ydiff * bulletSpeed;
            gameObject.transform.position = pos;

        }

    }

    /*******************************************
     *
     * @brief	弾位置調整
     *
     *
     *
     *******************************************/
    private void adjustBulletPosition()
    {

        Vector2 bulletPos = gameObject.transform.position;
        Vector2 touchPos = cameraObj.ScreenToWorldPoint(Input.mousePosition);

        float dis = Mathf.Abs(touchPos.x - bulletPos.x);
        if (dis > 0.1f)
        {

            bulletPos.x = touchPos.x;
            gameObject.transform.position = bulletPos;

        }

    }

    /*******************************************
     *
     * @brief	FPS算出
     *
     *
     *
     *******************************************/
    private void calculateFps()
    {

        ++frameCount;

        float time = Time.realtimeSinceStartup - prevtime;

        if (time >= 0.5f)
        {

            fps = frameCount / time;
            frameCount = 0;
            prevtime = Time.realtimeSinceStartup;

        }

    }

    /*******************************************
     *
     * @brief	画面外判定
     *
     *
     *
     *******************************************/
    private bool isOutScreen ()
    {

        Vector2 posInScreen = cameraObj.WorldToViewportPoint(gameObject.transform.position);
        if (posInScreen.x <= negativeMargin || posInScreen.x >= positiveMargin ||
            posInScreen.y <= negativeMargin || posInScreen.y >= positiveMargin)
        {

            // 画面外
            return true;

        }
        else
        {

            // 画面内
            return false;

        }

    }
}
