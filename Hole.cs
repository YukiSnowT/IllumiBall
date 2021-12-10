using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //どのボールを吸い寄せるかタグで指定
    public string targetTag;
    bool isHolding;

    //ボールが入っているかを返す・ホール状態の公開
    public bool IsHolding()
    {
        return isHolding;
    }

    //衝突トリガーイベント処理
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == targetTag)
        {
            isHolding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == targetTag)
        {
            isHolding = false;
        }
    }

    void OnTriggerStay(Collider other) {
        {
            //コライダに触れているオブジェクトのRigidbodyコンポーネントを取得
            Rigidbody r = other.gameObject.GetComponent<Rigidbody>(); //Rigidbodyコンポーネントの取得

            //ボールがある方向を計算
            Vector3 direction = other.gameObject.transform.position - transform.position;
            direction.Normalize();

            //タグに応じてボールに力を加える
            if(other.gameObject.tag == targetTag)
            {
                //中心地点でボールを止めるため速度を減速させる
                r.velocity *= 0.9f;
                r.AddForce(direction * -20.0f, ForceMode.Acceleration); //力の加算
            }
            else
            {
                r.AddForce(direction * 80.0f, ForceMode.Acceleration); //力の加算
            }

        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
