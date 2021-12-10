using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    //重力加速度
    const float Gravity = 9.81f;

    //重力の適用具合
    public float gravityScale = 1.0f;

    void Update()
    {
        //重力ベクトルの初期化
        Vector3 vector = new Vector3();

        if(Application.isMobilePlatform) //もしモバイルなら
        {
            vector.x = Input.acceleration.x; //加速度取得
            vector.z = Input.acceleration.y; //Unity上と傾きの軸が異なる
            vector.y = Input.acceleration.z;
        }
        else
        {
            //キー入力でベクトルを設定
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");

            //高さ判定はキーのz
            if(Input.GetKey("z"))
            {
                vector.y = 1.0f;
            }else{
                vector.y = -1.0f;
            }
        }

            //シーンの重力を変化させる
            Physics.gravity = Gravity * vector.normalized * gravityScale;
    }
}
