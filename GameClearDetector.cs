using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearDetector : MonoBehaviour
{
    [SerializeField]
    Hole holeRed;
    [SerializeField]
    Hole holeBlue;
    [SerializeField]
    Hole holeGreen;
    
    void OnGUI()
    {
        //文字サイズ
        GUI.matrix = Matrix4x4.Scale(Vector3.one * 5);

        //すべてのボールが入ったらラベルを表示
        if(holeRed.IsHolding() && holeBlue.IsHolding() && holeGreen.IsHolding())
        {
            GUI.Label(new Rect(50,50,100,30),"Game Clear!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
