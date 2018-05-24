using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour {

    public GameObject[] allCubes, topLR, midLR, bottomLR, leftUD, centerUD, rightUD, buttons;
    public GameObject top, midlr, bottom, left, midUD, right, wholeCube;
    private bool topB, midlrB, bottomB, leftB, midUDB, rightB;
    public float mouseStartX, mouseStartY;
    public float numSpeed;
    private bool first = true, endsolve = true;
    public float speedOfAnim = 1;
    public float num_of_moves = 20;
    public List<int> list_of_moves = new List<int>();

    //to Rotate MainCube
    private float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;
    public bool rotx = false, roty = false;

    // List of moves, 1 - UpLeft, 2 - BottomLeft, 3 - UpMid, 4 - BottomMid, 5 - UpRight, 6 - BottomRight
    // 7 - LeftUp, 8 - RightUp, 9 - LeftMid, 10 - RightMid, 11 - LeftDown, 12 - RightDown

    // Use this for initialization

    //Rozwazyc zrobienie zagadki
    void Start () {
        UpdatePositions();
        _sensitivity = 0.5f;
        _rotation = Vector3.zero;
    }

    void Update()
    {
        /*foreach(GameObject gb in buttons)
        {
            gb.GetComponent<Button>().enabled = first;
        }*/
        if (_isRotating && endsolve && first)
        {
            if(rotx && roty) {
                _mouseOffset = (Input.mousePosition - _mouseReference);
                _rotation.x = (_mouseOffset.x + _mouseOffset.y) * _sensitivity;
                _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
                wholeCube.transform.Rotate(_rotation);
                _mouseReference = Input.mousePosition;
            }
            else if (rotx)
            {
                _mouseOffset = (Input.mousePosition - _mouseReference);
                _rotation.x = (_mouseOffset.x + _mouseOffset.y) * _sensitivity;
                wholeCube.transform.Rotate(_rotation);
                _mouseReference = Input.mousePosition;
            }else if (roty)
            {
                _mouseOffset = (Input.mousePosition - _mouseReference);
                _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
                wholeCube.transform.Rotate(_rotation);
                _mouseReference = Input.mousePosition;
            }
        }
    }

    public void Shuffle(int a)
    {
        speedOfAnim = 0.2f;
        if (a == 1)
        {
            StartCoroutine(Shuff());
        }
        else
        {
            StartCoroutine(Solve());
        }
    }

    IEnumerator Solve()
    {
        endsolve = false;
        for (int i = list_of_moves.Count -1; i >= 0; i--)
        {
            switch (list_of_moves[i])
            {
                case 1:
                    BottomLeft();
                    break;
                case 2:
                    UpLeft();
                    break;
                case 3:
                    BottomMid();
                    break;
                case 4:
                    UpMid();
                    break;
                case 5:
                    BottomRight();
                    break;
                case 6:
                    UpRight();
                    break;
                case 7:
                    RightUp();
                    break;
                case 8:
                    LeftUp();
                    break;
                case 9:
                    RightMid();
                    break;
                case 10:
                    LeftMid();
                    break;
                case 11:
                    RightDown();
                    break;
                case 12:
                    LeftDown();
                    break;
            }
            yield return new WaitForSeconds(0.25f);
        }
        list_of_moves.Clear();
        endsolve = true;
    }

    IEnumerator Shuff()
    {
        endsolve = false;
        for (int i = 0; i < num_of_moves; i++)
        {
            switch (Random.Range(1, 7))
            {
                case 1:
                    UpLeft();
                    break;
                case 2:
                    UpMid();
                    break;
                case 3:
                    UpRight();
                    break;
                case 4:
                    LeftUp();
                    break;
                case 5:
                    LeftMid();
                    break;
                case 6:
                    LeftDown();
                    break;
            }
            yield return new WaitForSeconds(0.25f);
        }
        endsolve = true;
    }

    public void UpLeft()
    {
        if (first)
        {
            first = false;
            foreach (GameObject gb in leftUD)
            {
                gb.transform.parent = left.transform;
            }

            StartCoroutine(Rotate(left, Vector3.right, 90, speedOfAnim));

            GameObject k1 = allCubes[0], k2 = allCubes[3], k3 = allCubes[6], k4 = allCubes[9], k5 = allCubes[15],
                k6 = allCubes[18], k7 = allCubes[21], k8 = allCubes[24];

            allCubes[0] = k6;
            allCubes[3] = k4;
            allCubes[6] = k1;
            allCubes[9] = k7;
            allCubes[15] = k2;
            allCubes[18] = k8;
            allCubes[21] = k5;
            allCubes[24] = k3;

            list_of_moves.Add(1);

            UpdatePositions();
        }
    }

    public void UpMid()
    {
        if (first)
        {
            first = false;
            foreach (GameObject gb in centerUD)
            {
                gb.transform.parent = midUD.transform;
            }

            StartCoroutine(Rotate(midUD, Vector3.right, 90, speedOfAnim));

            GameObject k1 = allCubes[1], k2 = allCubes[4], k3 = allCubes[7], k4 = allCubes[10], k5 = allCubes[16],
                    k6 = allCubes[19], k7 = allCubes[22], k8 = allCubes[25];

            allCubes[1] = k6;
            allCubes[4] = k4;
            allCubes[7] = k1;
            allCubes[10] = k7;
            allCubes[16] = k2;
            allCubes[19] = k8;
            allCubes[22] = k5;
            allCubes[25] = k3;

            list_of_moves.Add(3);

            UpdatePositions();
        }
    }

    public void UpRight()
    {
        if (first)
        {
            first = false;
            foreach (GameObject gb in rightUD)
            {
                gb.transform.parent = right.transform;
            }

            StartCoroutine(Rotate(right, Vector3.right, 90, speedOfAnim));

            GameObject k1 = allCubes[2], k2 = allCubes[5], k3 = allCubes[8], k4 = allCubes[11], k5 = allCubes[17],
                        k6 = allCubes[20], k7 = allCubes[23], k8 = allCubes[26];

            allCubes[2] = k6;
            allCubes[5] = k4;
            allCubes[8] = k1;
            allCubes[11] = k7;
            allCubes[17] = k2;
            allCubes[20] = k8;
            allCubes[23] = k5;
            allCubes[26] = k3;

            list_of_moves.Add(5);

            UpdatePositions();
        }
    }

    public void LeftUp()
    {
        if (first)
        {
            first = false;
            foreach (GameObject gb in topLR)
            {
                gb.transform.parent = top.transform;
            }
            StartCoroutine(Rotate(top, Vector3.up, 90, speedOfAnim));

            GameObject k1 = allCubes[6], k2 = allCubes[7], k3 = allCubes[8], k4 = allCubes[15], k5 = allCubes[17],
                k6 = allCubes[24], k7 = allCubes[25], k8 = allCubes[26];

            allCubes[6] = k3;
            allCubes[7] = k5;
            allCubes[8] = k8;
            allCubes[15] = k2;
            allCubes[17] = k7;
            allCubes[24] = k1;
            allCubes[25] = k4;
            allCubes[26] = k6;

            list_of_moves.Add(7);

            UpdatePositions();
        }
    }

    public void LeftMid()
    {
        if (first)
        {
            first = false;
            foreach (GameObject gb in midLR)
            {
                gb.transform.parent = midlr.transform;
            }
            StartCoroutine(Rotate(midlr, Vector3.up, 90, speedOfAnim));

            GameObject k1 = allCubes[3], k2 = allCubes[4], k3 = allCubes[5], k4 = allCubes[12], k5 = allCubes[14],
                    k6 = allCubes[21], k7 = allCubes[22], k8 = allCubes[23];

            allCubes[3] = k3;
            allCubes[4] = k5;
            allCubes[5] = k8;
            allCubes[12] = k2;
            allCubes[14] = k7;
            allCubes[21] = k1;
            allCubes[22] = k4;
            allCubes[23] = k6;

            list_of_moves.Add(9);

            UpdatePositions();
        }
    }

    public void LeftDown()
    {
        if (first)
        {
            first = false;
            foreach (GameObject gb in bottomLR)
            {
                gb.transform.parent = bottom.transform;
            }
            StartCoroutine(Rotate(bottom, Vector3.up, 90, speedOfAnim));

            GameObject k1 = allCubes[0], k2 = allCubes[1], k3 = allCubes[2], k4 = allCubes[9], k5 = allCubes[11],
                        k6 = allCubes[18], k7 = allCubes[19], k8 = allCubes[20];

            allCubes[0] = k3;
            allCubes[1] = k5;
            allCubes[2] = k8;
            allCubes[9] = k2;
            allCubes[11] = k7;
            allCubes[18] = k1;
            allCubes[19] = k4;
            allCubes[20] = k6;

            list_of_moves.Add(11);

            UpdatePositions();
        }
    }

    public void BottomLeft()
    {
        if (first)
        {
            first = false;
            foreach (GameObject gb in leftUD)
            {
                gb.transform.parent = left.transform;
            }

            StartCoroutine(Rotate(left, Vector3.left, 90, speedOfAnim));

            GameObject k1 = allCubes[0], k2 = allCubes[3], k3 = allCubes[6], k4 = allCubes[9], k5 = allCubes[15],
                    k6 = allCubes[18], k7 = allCubes[21], k8 = allCubes[24];

            allCubes[0] = k3;
            allCubes[3] = k5;
            allCubes[6] = k8;
            allCubes[9] = k2;
            allCubes[15] = k7;
            allCubes[18] = k1;
            allCubes[21] = k4;
            allCubes[24] = k6;

            list_of_moves.Add(2);

            UpdatePositions();
        }
    }

    public void BottomMid()
    {
        if (first)
        {
            first = false;
            foreach (GameObject gb in centerUD)
            {
                gb.transform.parent = midUD.transform;
            }

            StartCoroutine(Rotate(midUD, Vector3.left, 90, speedOfAnim));

            GameObject k1 = allCubes[1], k2 = allCubes[4], k3 = allCubes[7], k4 = allCubes[10], k5 = allCubes[16],
                        k6 = allCubes[19], k7 = allCubes[22], k8 = allCubes[25];

            allCubes[1] = k3;
            allCubes[4] = k5;
            allCubes[7] = k8;
            allCubes[10] = k2;
            allCubes[16] = k7;
            allCubes[19] = k1;
            allCubes[22] = k4;
            allCubes[25] = k6;

            list_of_moves.Add(4);

            UpdatePositions();
        }
    }

    public void BottomRight()
    {
        if (first)
        {
            first = false;
            foreach (GameObject gb in rightUD)
            {
                gb.transform.parent = right.transform;
            }

            StartCoroutine(Rotate(right, Vector3.left, 90, speedOfAnim));

            GameObject k1 = allCubes[2], k2 = allCubes[5], k3 = allCubes[8], k4 = allCubes[11], k5 = allCubes[17],
                            k6 = allCubes[20], k7 = allCubes[23], k8 = allCubes[26];

            allCubes[2] = k3;
            allCubes[5] = k5;
            allCubes[8] = k8;
            allCubes[11] = k2;
            allCubes[17] = k7;
            allCubes[20] = k1;
            allCubes[23] = k4;
            allCubes[26] = k6;

            list_of_moves.Add(6);

            UpdatePositions();
        }
    }

    public void RightUp()
    {
        if (first)
        {
            first = false;
            foreach (GameObject gb in topLR)
            {
                gb.transform.parent = top.transform;
            }
            StartCoroutine(Rotate(top, Vector3.down, 90, speedOfAnim));

            GameObject k1 = allCubes[6], k2 = allCubes[7], k3 = allCubes[8], k4 = allCubes[15], k5 = allCubes[17],
                    k6 = allCubes[24], k7 = allCubes[25], k8 = allCubes[26];

            allCubes[6] = k6;
            allCubes[7] = k4;
            allCubes[8] = k1;
            allCubes[15] = k7;
            allCubes[17] = k2;
            allCubes[24] = k8;
            allCubes[25] = k5;
            allCubes[26] = k3;

            list_of_moves.Add(8);

            UpdatePositions();
        }
    }

    public void RightMid()
    {
        if (first)
        {
            first = false;
            foreach (GameObject gb in midLR)
            {
                gb.transform.parent = midlr.transform;
            }
            StartCoroutine(Rotate(midlr, Vector3.down, 90, speedOfAnim));

            GameObject k1 = allCubes[3], k2 = allCubes[4], k3 = allCubes[5], k4 = allCubes[12], k5 = allCubes[14],
                        k6 = allCubes[21], k7 = allCubes[22], k8 = allCubes[23];

            allCubes[3] = k6;
            allCubes[4] = k4;
            allCubes[5] = k1;
            allCubes[12] = k7;
            allCubes[14] = k2;
            allCubes[21] = k8;
            allCubes[22] = k5;
            allCubes[23] = k3;

            list_of_moves.Add(10);

            UpdatePositions();
        }
    }

    public void RightDown()
    {
        if (first)
        {
            first = false;
            foreach (GameObject gb in bottomLR)
            {
                gb.transform.parent = bottom.transform;
            }
            StartCoroutine(Rotate(bottom, Vector3.down, 90, speedOfAnim));

            GameObject k1 = allCubes[0], k2 = allCubes[1], k3 = allCubes[2], k4 = allCubes[9], k5 = allCubes[11],
                            k6 = allCubes[18], k7 = allCubes[19], k8 = allCubes[20];

            allCubes[0] = k6;
            allCubes[1] = k4;
            allCubes[2] = k1;
            allCubes[9] = k7;
            allCubes[11] = k2;
            allCubes[18] = k8;
            allCubes[19] = k5;
            allCubes[20] = k3;

            list_of_moves.Add(12);

            UpdatePositions();
        }
    }

    public void PointUp()
    {
        left.transform.localEulerAngles = new Vector3((((int)left.transform.localEulerAngles.x)/90 + 1)*90, 0, 0);
        Debug.Log(Input.mousePosition);
    }

    /*public void OnMouseDrag()
    {
        if (mouseStartY < Input.mousePosition.y-15)
        {
            left.transform.Rotate(Vector3.right * Time.deltaTime * numSpeed);
        }
        else if (mouseStartY > Input.mousePosition.y + 15)
        {
            left.transform.Rotate(Vector3.left * Time.deltaTime * numSpeed);
        }
    }*/

    public void OnMouseDown()
    {
        // rotating flag
        _isRotating = true;

        // store mouse
        _mouseReference = Input.mousePosition;
    }

    public void OnMouseUp()
    {
        // rotating flag
        _isRotating = false;
    }

    /*public void PointDown()
    {
        mouseStartY = Input.mousePosition.y;
        mouseStartX = Input.mousePosition.x;
        Debug.Log(Input.mousePosition);
    }*/

    IEnumerator Rotate(GameObject gb, Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = gb.transform.rotation;
        Quaternion to = gb.transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            gb.transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        gb.transform.rotation = to;
       // yield return new WaitForSeconds(0.3f);
        first = true;
    }

    void UpdatePositions()
    {
        topLR[0] = allCubes[6];
        topLR[1] = allCubes[7];
        topLR[2] = allCubes[8];
        topLR[3] = allCubes[15];
        topLR[4] = allCubes[16];
        topLR[5] = allCubes[17];
        topLR[6] = allCubes[24];
        topLR[7] = allCubes[25];
        topLR[8] = allCubes[26];

        midLR[0] = allCubes[3];
        midLR[1] = allCubes[4];
        midLR[2] = allCubes[5];
        midLR[3] = allCubes[12];
        midLR[4] = allCubes[13];
        midLR[5] = allCubes[14];
        midLR[6] = allCubes[21];
        midLR[7] = allCubes[22];
        midLR[8] = allCubes[23];

        bottomLR[0] = allCubes[0];
        bottomLR[1] = allCubes[1];
        bottomLR[2] = allCubes[2];
        bottomLR[3] = allCubes[9];
        bottomLR[4] = allCubes[10];
        bottomLR[5] = allCubes[11];
        bottomLR[6] = allCubes[18];
        bottomLR[7] = allCubes[19];
        bottomLR[8] = allCubes[20];

        leftUD[0] = allCubes[0];
        leftUD[1] = allCubes[3];
        leftUD[2] = allCubes[6];
        leftUD[3] = allCubes[9];
        leftUD[4] = allCubes[12];
        leftUD[5] = allCubes[15];
        leftUD[6] = allCubes[18];
        leftUD[7] = allCubes[21];
        leftUD[8] = allCubes[24];

        centerUD[0] = allCubes[1];
        centerUD[1] = allCubes[4];
        centerUD[2] = allCubes[7];
        centerUD[3] = allCubes[10];
        centerUD[4] = allCubes[13];
        centerUD[5] = allCubes[16];
        centerUD[6] = allCubes[19];
        centerUD[7] = allCubes[22];
        centerUD[8] = allCubes[25];

        rightUD[0] = allCubes[2];
        rightUD[1] = allCubes[5];
        rightUD[2] = allCubes[8];
        rightUD[3] = allCubes[11];
        rightUD[4] = allCubes[14];
        rightUD[5] = allCubes[17];
        rightUD[6] = allCubes[20];
        rightUD[7] = allCubes[23];
        rightUD[8] = allCubes[26];
    }

    public void ChangeRotx()
    {
        rotx = !rotx;
    }

    public void ChangeRotY()
    {
        roty = !roty;
    }

    public void CenterCube()
    {
        wholeCube.transform.localEulerAngles = Vector3.zero;
    }
}
