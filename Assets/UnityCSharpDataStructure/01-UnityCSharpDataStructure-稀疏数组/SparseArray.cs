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
        //��������
        CreateCheckerBoard();
        //����ϡ������
       int[,] sparseArr = ChangeSparseArr(chessArr_1);
        //ͨ��ϡ�����黹ԭ����
        RestoreCheckerBoard(sparseArr);

    }
    /// <summary>
    /// ��������
    /// </summary>
    private void CreateCheckerBoard()
    {
        //1�ǳ�ɫ���ӣ�2����ɫ����
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
        Debug.Log("��ʼ����:\n"+ str);
    }
    /// <summary>
    /// �������е�����ת��Ϊϡ������
    /// </summary>
    private int[,] ChangeSparseArr(int[,] chessArr)
    {
        //rows = chessArr_1.GetLength(0); // ��ȡ����
        //columns = chessArr_1.GetLength(1); // ��ȡ����

        //1.�Ȼ����������еķ�0����
        int sum = 0;
        //�����к���
        for (int i = 0; i < chessArr.GetLength(0); i++)
        {
            for (int j = 0; j < chessArr.GetLength(1); j++)
            {
                if (chessArr_1[i, j] != 0)
                {
                    //��¼��0����
                    sum++;
                }
            }
        }
        Debug.Log("sum������: " + sum);

        //2������ϡ������ sum+1���У�Ҳ����˵�ж��ٸ�����,
        //3���У���һ����������ڵڼ���(Row)���ڶ�����������ڵڼ���(col)�����������������ֵvalue
        int[,] sparseArr = new int[sum + 1, 3];
        //�����ϡ�����鸳��һ�³�ʼֵ
        sparseArr[0, 0] = chessArr.GetLength(0);
        sparseArr[0, 1] = chessArr.GetLength(1);
        sparseArr[0, 2] = sum;
        //�������̵����飬����0��ֵ(�ڼ��еڼ��У��Լ�ֵ)����ϡ�������У�
        int count = 0;
        for (int i = 0; i < chessArr.GetLength(0); i++)
        {
            for (int j = 0; j < chessArr.GetLength(1); j++)
            {
                if (chessArr_1[i, j] != 0)
                {
                    count++;
                    sparseArr[count, 0] = i;//��
                    sparseArr[count, 1] = j;//��
                    sparseArr[count, 2] = chessArr_1[i, j];//ֵ
                }
            }
        }
        string temp = "";
        //���һ�����ϡ������
        for (int i = 0; i < sparseArr.GetLength(0); i++)
        {
            for (int j = 0; j < sparseArr.GetLength(1); j++)
            {
                temp += sparseArr[i, j] + "\t";
            }
            temp += "\n";
        }
        Debug.Log("ϡ������:\n"+ temp);
        return sparseArr;
       
    }
    /// <summary>
    /// ͨ��ϡ�����黹ԭ����
    /// </summary>
    private void RestoreCheckerBoard(int[,] sparseArr)
    {
        //3.��ϡ������ת��Ϊ��ά����
        string temp = "";
        //ȡ����һ�е����ݣ��õ������Ƕ��ģ�������15*15�Ĵ�С
        int[,] chessArr2 = new int[sparseArr[0, 0], sparseArr[0, 1]];
        for (int i = 1; i < sparseArr.GetLength(0); i++)
        {
            chessArr2[sparseArr[i, 0], sparseArr[i, 1]] = sparseArr[i, 2];
        }
        //������ϡ������ת���Ķ�ά����
        for (int i = 0; i < chessArr2.GetLength(0); i++)
        {
            for (int j = 0; j < chessArr2.GetLength(1); j++)
            {
                temp += chessArr2[i, j] + " ";
            }
            temp += "\n";
        }
        Debug.Log("ͨ��ϡ�����黹ԭ�������: \n" +temp);
    }

}
