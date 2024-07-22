using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class USPU : MonoBehaviour
{
    public Text number1, number2, result, decimalText;
    public InputField field1, field2;
    public Dropdown operationType;
    public Toggle isDecimal;
    public Slider decimalSlider;
    public float decimalNumber;
    public float DecimalNumber
    {
        get { return decimalNumber; }
        set { 
            decimalNumber = value;
            decimalText.text = "����� ����� �������: " + value;
        }
    }

    // Start is called before the first frame update
    public void Summa()
    {
        try
        {
            if (!isDecimal.isOn)
            {
                switch (operationType.value)
                {
                    case 0:
                        result.text = "���������: " + (int.Parse(number1.text) + int.Parse(number2.text)).ToString();
                        break;
                    case 1:
                        result.text = "���������: " + (int.Parse(number1.text) - int.Parse(number2.text)).ToString();
                        break;
                    case 2:
                        result.text = "���������: " + (int.Parse(number1.text) * int.Parse(number2.text)).ToString();
                        break;
                    case 3:
                        result.text = "���������: " + (int.Parse(number1.text) / int.Parse(number2.text)).ToString();
                        break;
                    case 4:
                        result.text = "���������: " + (int.Parse(number1.text) % int.Parse(number2.text)).ToString();
                        break;
                }
            }
            else
            {
                string value1 = number1.text.Replace(".", ",");
                string value2 = number2.text.Replace(".", ",");
                switch (operationType.value)
                {
                    case 0:
                        result.text = "���������: " + (Math.Round(float.Parse(value1) + float.Parse(value2), (int) decimalNumber)).ToString();
                        break;
                    case 1:
                        result.text = "���������: " + (Math.Round(float.Parse(value1) - float.Parse(value2), (int) decimalNumber)).ToString();
                        break;
                    case 2:
                        result.text = "���������: " + (Math.Round(float.Parse(value1) * float.Parse(value2), (int) decimalNumber)).ToString();
                        break;
                    case 3:
                        result.text = "���������: " + (Math.Round(float.Parse(value1) / float.Parse(value2), (int) decimalNumber)).ToString();
                        break;
                    case 4:
                        result.text = "���������: " + (Math.Round(float.Parse(value1) % float.Parse(value2), (int) decimalNumber)).ToString();
                        break;
                }
            }
        }

        catch(Exception ex)
        {
            result.text = "�� ���������� ���� ��� ���������� ��������. ������� �����";
            print(ex);
        }

        
    }

    public void DecimalOperation(bool isDecimal)
    {
        if (isDecimal)
        {
            field1.contentType = InputField.ContentType.DecimalNumber;
            field2.contentType = InputField.ContentType.DecimalNumber;
            number1.text = null;
            number2.text = null;
            decimalSlider.gameObject.SetActive(true);
        }
        else
        {
            field1.contentType = InputField.ContentType.IntegerNumber;
            field2.contentType = InputField.ContentType.IntegerNumber;
            number1.text = null;
            number2.text = null;
            decimalSlider.gameObject.SetActive(false);
        }
    }
}
