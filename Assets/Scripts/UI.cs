using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TMP_Text objectName, currentAge;
    public Slider age;
    public TMP_Dropdown dropdown;
    public Toggle m, f;
    public SpawnerLab spawner;
    public void Create()
    {
        string gender = "�������";
        if (m.isOn)
        {
            gender = "�������";
        }
        else if (f.isOn)
        {
            gender = "�������";
        }
        spawner.SpawnObject(dropdown.value, "� " + objectName.text + ", ��� " + age.value + ", " + gender);
    }

    public void CurrentAge()
    {
        currentAge.text = age.value.ToString();
    }
}
