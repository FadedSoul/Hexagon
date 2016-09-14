using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexGrid : MonoBehaviour {

    public GameObject hexPref;

    public Camera camera;

    private List<GameObject> hexPrefList;

    [SerializeField]
    private float x;
    [SerializeField]
    private float y;
    [SerializeField]
    private int size;

    void Start() {
        makeGrid();
    }

    void makeGrid() {
        hexPrefList = new List<GameObject> { };

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

        camera.transform.position = new Vector3(hexPrefList[size / 2].transform.position.x, camera.transform.position.y, hexPrefList[size * size / 2].transform.position.z);
    }

}
