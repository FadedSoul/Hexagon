using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SizeCounter : MonoBehaviour {

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Text textField;

    private string text;

    private int number;
	
	// Update is called once per frame
	void Update () {
        number = (int)slider.value;

        text = number.ToString();

        textField.text = text;
	}
}
