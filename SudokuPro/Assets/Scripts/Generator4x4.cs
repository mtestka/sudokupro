using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Generator4x4 : MonoBehaviour
{

    const int N = 16;
    private static bool done = true;
    public Font fontForAll;
    //bool execute = false;
    public static int[,] tab = new int[N, N];
    //public static int[] tba = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    //int o = 0;
    public GameObject field;
    public Transform board;
    private List<GameObject> fields;
    public GameObject result;
    private InputField ifield;
    //public GameObject loader;
    //CONSIDER MAKING AN LIST OF MADE BOARDS AT START TO FAST LATER GAME
    //List<int[,]> arrayList = new List<int[,]>();

    // Use this for initialization
    void Start()
    {
        fields = new List<GameObject>();
        ifield = GameObject.FindObjectOfType<InputField>();
        for(int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                GameObject newObject;
                //(int)(i / Mathf.Sqrt(N))
                newObject = Instantiate(field, new Vector2((j / 3f) - 2.4f, i / 3f - 1.5f), Quaternion.identity, board) as GameObject;
                newObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0.4f, 0.4f);
                newObject.GetComponentInChildren<Text>().GetComponent<RectTransform>().sizeDelta= new Vector2(0.4f, 0.4f);
                fields.Add(newObject);
            }
        }
        //fields = new Button[81];
        for (int i = 0; i < N*N; i++)
        {
            fields[i].GetComponentInChildren<Text>().text = 0 + "";
        }
        //Gen_board();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (execute)
        {
            loader.transform.DORotate(new Vector3(0, 0, o++), 0.04f);
        }*/
    }

    public void Gen_board()
    {
        System.DateTime aa = System.DateTime.Now;
        //Debug.Log("Almost Found 1");
        Uzup_tab(tab, true);
        //Debug.Log("Almost Found 2");
        Skok_petla(tab, 0, 0);
        check:
        Uzup_tab(tab, false);
        Skok_petla(tab, 3, 3);
        if (!done)
        {
            goto check;
        }
        Skok_petla(tab, 6, 6);
        if (!done)
        {
            goto check;
        }
        Skok_petla(tab, 0, 6);
        if (!done)
        {
            goto check;
        }
        Skok_petla(tab, 6, 0);
        if (!done)
        {
            goto check;
        }
        Skok_petla(tab, 0, 3);
        if (!done)
        {
            goto check;
        }
        Skok_petla(tab, 3, 0);
        if (!done)
        {
            goto check;
        }
        Skok_petla(tab, 3, 6);
        if (!done)
        {
            goto check;
        }
        Skok_petla(tab, 6, 3);
        if (!done)
        {
            goto check;
        }
        Wykresl_do_rozw(tab, int.Parse(ifield.text));
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (tab[i, j] == 0)
                {
                    fields[j + i * 9].GetComponentInChildren<Text>().text = "";
                    fields[j + i * 9].GetComponentInChildren<Text>().color = Color.white;
                }
                else
                {
                    fields[j + i * 9].GetComponentInChildren<Text>().text = tab[i, j] + "";
                    fields[j + i * 9].GetComponentInChildren<Text>().color = Color.white;
                }
            }
        }
        System.DateTime ab = System.DateTime.Now;
        System.TimeSpan duration = ab.Subtract(aa);
        Debug.Log("Duration in milliseconds: " + duration.Milliseconds);
        /*execute = false;
        loader.GetComponent<Image>().enabled = false;*/
    }

    /*public void GetEnabled()
    {
        o = 0;
        loader.GetComponent<Image>().enabled = true;
        execute = true;
    }*/

    private void Uzup_tab(int[,] tab, bool pier)
    {
        if (pier)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    tab[i, j] = 0;
                }
            }
        }
        else
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 3; j < N; j++)
                {
                    tab[i, j] = 0;
                }
            }
            for (int i = 3; i < N; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tab[i, j] = 0;
                }
            }
        }
        /*tab[0][0] = 8;tab[0][1] = 0;tab[0][2] = 0;tab[0][3] = 0;tab[0][4] = 0;tab[0][5] = 0;tab[0][6] = 0;tab[0][7] = 0;tab[0][8] = 0;
        tab[1][0] = 0;tab[1][1] = 0;tab[1][2] = 3;tab[1][3] = 6;tab[1][4] = 0;tab[1][5] = 0;tab[1][6] = 0;tab[1][7] = 0;tab[1][8] = 0;
        tab[2][0] = 0;tab[2][1] = 7;tab[2][2] = 0;tab[2][3] = 0;tab[2][4] = 9;tab[2][5] = 0;tab[2][6] = 2;tab[2][7] = 0;tab[2][8] = 0;
        tab[3][0] = 0;tab[3][1] = 5;tab[3][2] = 0;tab[3][3] = 0;tab[3][4] = 0;tab[3][5] = 7;tab[3][6] = 0;tab[3][7] = 0;tab[3][8] = 0;
        tab[4][0] = 0;tab[4][1] = 0;tab[4][2] = 0;tab[4][3] = 0;tab[4][4] = 4;tab[4][5] = 5;tab[4][6] = 7;tab[4][7] = 0;tab[4][8] = 0;
        tab[5][0] = 0;tab[5][1] = 0;tab[5][2] = 0;tab[5][3] = 1;tab[5][4] = 0;tab[5][5] = 0;tab[5][6] = 0;tab[5][7] = 3;tab[5][8] = 0;
        tab[6][0] = 0;tab[6][1] = 0;tab[6][2] = 1;tab[6][3] = 0;tab[6][4] = 0;tab[6][5] = 0;tab[6][6] = 0;tab[6][7] = 6;tab[6][8] = 8;
        tab[7][0] = 0;tab[7][1] = 0;tab[7][2] = 8;tab[7][3] = 5;tab[7][4] = 0;tab[7][5] = 0;tab[7][6] = 0;tab[7][7] = 1;tab[7][8] = 0;
        tab[8][0] = 0;tab[8][1] = 9;tab[8][2] = 0;tab[8][3] = 0;tab[8][4] = 0;tab[8][5] = 0;tab[8][6] = 4;tab[8][7] = 0;tab[8][8] = 0;*/
    }

    int[] Zeruj_kr(int[,] tab, int i, int j)
    {
        int[] acc = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int pw = i / 3, pk = j / 3;
        for (int p = 3 * pw; p < 3 * pw + 3; p++)
        {
            for (int r = 3 * pk; r < 3 * pk + 3; r++)
            {
                if (tab[p, r] != 0)
                {
                    acc[tab[p, r] - 1] = 0;
                }
            }
        }
        for (int b = 0; b < N; b++)
        {
            if (tab[i, b] != 0)
            {
                acc[tab[i, b] - 1] = 0;
            }
        }
        for (int b = 0; b < N; b++)
        {
            if (tab[b, j] != 0)
            {
                acc[tab[b, j] - 1] = 0;
            }
        }
        return acc;
    }

    /*private bool Zeruj_kr_l8r(int[,] tab, int i, int j, int num)
    {
        //int[] acc = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int pw = i / 3, pk = j / 3;
        for (int p = 3 * pw; p < 3 * pw + 3; p++)
        {
            for (int r = 3 * pk; r < 3 * pk + 3; r++)
            {
                if (tab[p, r] == num)
                {
                    return false;
                }
            }
        }
        for (int b = 0; b < N; b++)
        {
            if (tab[i, b] == num)
            {
                return false;
            }
        }
        for (int b = 0; b < N; b++)
        {
            if (tab[b, j] == num)
            {
                return false;
            }
        }
        return true;
    }*/

    private void Skok_petla(int[,] tab, int id, int jd)
    {
        for (int i = id; i < id + 3; i++)
        {
            for (int j = jd; j < jd + 3; j++)
            {
                done = false;
                if (tab[i, j] == 0)
                {
                    for (int g = 0; g < N; g++)
                    {
                        if (Zeruj_kr(tab, i, j)[g] != 0)
                        {
                            done = true;
                        }
                    }
                    if (!done)
                    {
                        return;
                    }
                    //int b = 0;
                    int cc = Random.Range(0, 9);
                    while (Zeruj_kr(tab, i, j)[cc] == 0)
                    {
                        cc = Random.Range(0, 9);
                    }
                    //zeruj_kr(tab, i,j)[idx] = 0;
                    tab[i, j] = Zeruj_kr(tab, i, j)[cc];
                }
            }
        }
    }

    /*private void Skok_petla_l8r(int[,] tab, int id, int jd)
    {
        for (int i = id; i < id + 3; i++)
        {
            for (int j = jd; j < jd + 3; j++)
            {
                done = false;
                if (tab[i, j] == 0)
                {
                    for (int g = 1; g < 10; g++)
                    {
                        if (Zeruj_kr_l8r(tab, i,j, g))
                        {
                            done = true;
                            tab[i, j] = g;
                        }
                    }
                    if (!done)
                    {
                        return;
                    }
                }
            }
        }
    }*/

    private void Wykresl_do_rozw(int[,] tab, int liczba)
    {
        int i = 0;
        while (i < liczba)
        {
            int a = Random.Range(0, 9);
            int b = Random.Range(0, 9);
            if (tab[a, b] != 0)
            {
                tab[a, b] = 0;
                i++;
            }
        }
    }

    private bool Check()
    {
        for (int i = 0; i < N; i++)
        {
            int countA = 0;
            for (int j = 0; j < N; j++)
            {
                if (fields[j + i * 9].GetComponentInChildren<Text>().text == "")
                {
                    return false;
                }
                countA += int.Parse(fields[j + i * 9].GetComponentInChildren<Text>().text);
            }
            if (countA != 45)
            {
                return false;
            }
        }
        return true;
    }

    public void ShowResults()
    {
        if (Check())
        {
            result.SetActive(true);
        }
        else
        {
            Debug.Log("You didnt make it right");
        }
    }

    public void TryAgain()
    {
        result.SetActive(false);
        Gen_board();
        foreach (FieldSc fs in GameObject.FindObjectsOfType<FieldSc>())
        {
            fs.selected = false;
        }
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

}
