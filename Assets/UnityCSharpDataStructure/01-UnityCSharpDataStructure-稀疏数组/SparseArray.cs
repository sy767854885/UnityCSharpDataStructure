using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparseArray : MonoBehaviour
{
    public GameObject CheckerBoardCube;
    public GameObject Sphere_1;
    public GameObject Sphere_2;

    private int[,] chessArr_1 = new int[15, 15];
    void Start()
    {
        //创建棋盘
        CreateCheckerBoard();
        //创建稀疏数组
       int[,] sparseArr = ChangeSparseArr(chessArr_1);
        //通过稀疏数组还原棋盘
        RestoreCheckerBoard(sparseArr);

    }
    /// <summary>
    /// 创建棋盘
    /// </summary>
    private void CreateCheckerBoard()
    {
        //1是橙色棋子，2是绿色棋子
        chessArr_1[1, 2] = 1;
        chessArr_1[2, 3] = 2;
        string str = "";
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                str += chessArr_1[i, j] + " ";
            }
            str += "\n";
        }
        Debug.Log("初始棋盘:\n"+ str);
    }
    /// <summary>
    /// 把棋盘中的数据转化为稀疏数组
    /// </summary>
    private int[,] ChangeSparseArr(int[,] chessArr)
    {
        //rows = chessArr_1.GetLength(0); // 获取行数
        //columns = chessArr_1.GetLength(1); // 获取列数

        //1.先获得这个棋盘中的非0个数
        int sum = 0;
        //遍历行和列
        for (int i = 0; i < chessArr.GetLength(0); i++)
        {
            for (int j = 0; j < chessArr.GetLength(1); j++)
            {
                if (chessArr_1[i, j] != 0)
                {
                    //记录非0个数
                    sum++;
                }
            }
        }
        Debug.Log("sum个数是: " + sum);

        //2、创建稀疏数组 sum+1是行，也就是说有多少个数据,
        //3是列，第一列是这个数在第几行(Row)，第二列是这个数在第几列(col)，第三列是这个数的值value
        int[,] sparseArr = new int[sum + 1, 3];
        //给这个稀疏数组赋予一下初始值
        sparseArr[0, 0] = chessArr.GetLength(0);
        sparseArr[0, 1] = chessArr.GetLength(1);
        sparseArr[0, 2] = sum;
        //遍历棋盘的数组，将非0的值(第几行第几列，以及值)存入稀疏数组中，
        int count = 0;
        for (int i = 0; i < chessArr.GetLength(0); i++)
        {
            for (int j = 0; j < chessArr.GetLength(1); j++)
            {
                if (chessArr_1[i, j] != 0)
                {
                    count++;
                    sparseArr[count, 0] = i;//行
                    sparseArr[count, 1] = j;//列
                    sparseArr[count, 2] = chessArr_1[i, j];//值
                }
            }
        }
        string temp = "";
        //输出一下这个稀疏数组
        for (int i = 0; i < sparseArr.GetLength(0); i++)
        {
            for (int j = 0; j < sparseArr.GetLength(1); j++)
            {
                temp += sparseArr[i, j] + "\t";
            }
            temp += "\n";
        }
        Debug.Log("稀疏数组:\n"+ temp);
        return sparseArr;
       
    }
    /// <summary>
    /// 通过稀疏数组还原棋盘
    /// </summary>
    private void RestoreCheckerBoard(int[,] sparseArr)
    {
        //3.将稀疏数组转换为二维数组
        string temp = "";
        //取出第一行的数据，得到棋盘是多大的，这里是15*15的大小
        int[,] chessArr2 = new int[sparseArr[0, 0], sparseArr[0, 1]];
        for (int i = 1; i < sparseArr.GetLength(0); i++)
        {
            chessArr2[sparseArr[i, 0], sparseArr[i, 1]] = sparseArr[i, 2];
        }
        //输出这个稀疏数组转化的二维数组
        for (int i = 0; i < chessArr2.GetLength(0); i++)
        {
            for (int j = 0; j < chessArr2.GetLength(1); j++)
            {
                temp += chessArr2[i, j] + " ";
            }
            temp += "\n";
        }
        Debug.Log("通过稀疏数组还原后的棋盘: \n" +temp);
    }

}
