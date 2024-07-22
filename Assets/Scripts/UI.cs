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
        string gender = "Мужчина";
        if (m.isOn)
        {
            gender = "Мужчина";
        }
        else if (f.isOn)
        {
            gender = "Женщина";
        }
        spawner.SpawnObject(dropdown.value, "Я " + objectName.text + ", мне " + age.value + ", " + gender);
    }

    public void CurrentAge()
    {
        currentAge.text = age.value.ToString();
    }
}
