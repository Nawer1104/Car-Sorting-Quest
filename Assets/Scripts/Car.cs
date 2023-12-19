using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Enum type;

    public GameObject car_blue;
    public GameObject car_grey;
    public GameObject car_yellow;

    private int id;

    public bool canTouch = true;

    private void Start()
    {
        car_blue.SetActive(false);
        car_grey.SetActive(false);
        car_yellow.SetActive(false);

        SetCarSprite(this.type);

        id = GetInstanceID();
    }

    public int GetId()
    {
        return id;
    }

    public void SetCarSprite(Enum type)
    {
        switch (type)
        {
            case Enum.Blue:
                car_blue.SetActive(true);
                car_grey.SetActive(false);
                car_yellow.SetActive(false);
                break;
            case Enum.Grey:
                car_grey.SetActive(true);
                car_blue.SetActive(false);
                car_yellow.SetActive(false);
                break;
            case Enum.Yellow:
                car_yellow.SetActive(true);
                car_blue.SetActive(false);
                car_grey.SetActive(false);
                break;
        }
    }

    public void BlurAllCar()
    {
        SetBlur(car_blue);
        SetBlur(car_yellow);
        SetBlur(car_grey);
    }

    private void SetBlur(GameObject obj)
    {
        Color tmp = obj.GetComponent<SpriteRenderer>().color;
        tmp.a = 0.5f;
        obj.GetComponent<SpriteRenderer>().color = tmp;
    }

    private void OnMouseDown()
    {
        if (!canTouch) return;
        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].SetSelectedCar(this);
    }
}
