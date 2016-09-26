using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

    public GameObject hexPref;

    [SerializeField]
    private Slider sizeChanger;

    public GameObject cameraMain;

    private List<GameObject> hexPrefList;

    [SerializeField]
    private float x;
    [SerializeField]
    private float y;

    public int size;

    void Start() {
        hexPrefList = new List<GameObject> { };
    }

    public void StartGrid() {
        destroy();
        changeSize();
        makeGrid();
    }

    void makeGrid() {
        for (int i = 0; i < size * size; i++)
        {
            hexPrefList.Add(hexPref);
            hexPrefList[i] = Instantiate(hexPrefList[i], new Vector3((x + y % 2 / 2) * 1.81f, 0, y * 0.866f * 1.81f), Quaternion.identity) as GameObject;

            x++;

            if (x > size - 1)
            {
                x = 0;
                y++;
            }
        }
        print(size);
        cameraMain.gameObject.transform.position = new Vector3(hexPrefList[size / 2].transform.position.x, size * 2 , hexPrefList[size * size / 2].transform.position.z);
    }

    void changeSize() {
        size = (int)sizeChanger.value;
    }

    void destroy() {
        foreach (GameObject hexPref in hexPrefList)
        {
            hexPref.GetComponent<MeshSpawner>().destroyHex();
        }
        hexPrefList.Clear();
    }
}
