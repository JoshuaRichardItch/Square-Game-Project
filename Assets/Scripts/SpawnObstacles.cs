using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float defaultX = 17f;
    //default height of spawned obstacle
    public float defaultY = 59/*-1.6084527f*/;
    public float defaultZDynamic = 5.5f;
    public float repeatRate = 2.0f;
    private int[,] patternChessboard = 
    {
        //chessboard horizontal
        {1, 3, 5, 7, 9, 2, 4, 6, 8, 10, 1, 3, 5, 7, 9, 2, 4, 6, 8, 10},
        //chessboard vertical
        {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3} 
    };
    private int[,] patternCruelChessboard =
    {
        //chessboard horizontal
        {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 2, 4, 6, 8, 10, 1, 3, 5, 7, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
        //chessboard vertical
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
    };
    private int[,] patternJumpOver =
    {
        //jump over horizontal
        {1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
        //jump over vertical
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    };
    private int[,] patternStayUnder =
    {
        //horizontal
        {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
        //vertical
        {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}
    };
    private int[,] patternWall =
    {
        //horizontal
        {7, 8, 9, 10, 7, 8, 9, 10, 7, 8, 9, 10, 7, 8, 9, 10},
        //vertical
        {0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3}
    };
    private int[,] patternWall2 =
    {
        //horizontal
        {2, 1, 9, 10, 2, 1, 9, 10, 2, 1, 9, 10, 2, 1, 9, 10},
        //vertical
        {0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3}
    };
    private int[,] patternSmile =
    {
        //horizontal
        {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 4, 7},
        //vertical
        {1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 3}
    };
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPattern", 2f, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnPattern()
    {
        if (repeatRate > 0.5f)
        {
            repeatRate -= 0.1f;
        }
            transform.position = new Vector3(defaultX, 0, 0);
            int[,] currentPattern = { };
            int patternSelector = UnityEngine.Random.Range(0, 7);
        if (patternSelector == 0)
        {
            currentPattern = patternJumpOver;
        }
        else if (patternSelector == 1)
        {
            currentPattern = patternChessboard;
        }
        else if (patternSelector == 2)
        {
            currentPattern = patternStayUnder;
        }
        else if (patternSelector == 3)
        {
            currentPattern = patternCruelChessboard;
        }
        else if (patternSelector == 4)
        {
            currentPattern = patternWall;
        }
        else if (patternSelector == 5)
        {
            currentPattern = patternWall2;
        }
        else if (patternSelector == 6)
        {
            currentPattern = patternSmile;
        }
        for (int i = 0; i < currentPattern.Length; i++)
            {
                int hPos = currentPattern[0, i];
                int vPos = currentPattern[1, i];
                Instantiate(obstacle, new Vector3(defaultX, defaultY + vPos, defaultZDynamic - hPos), obstacle.transform.rotation);
        }
    }
}
