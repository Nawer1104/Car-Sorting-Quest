using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public List<Car> cars;

    public Enum type;

    public GameObject vfxFinish;

    public bool isFinished = false;

    public void CheckCars()
    {
        if (isFinished) return;

        foreach(Car car in cars)
        {
            if (car.type != type) return;
        }

        GameObject vfx = Instantiate(vfxFinish, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 1f);

        isFinished = true;
        GameManager.Instance.CheckLevelUp();
        foreach (Car car in cars)
        {
            car.canTouch = false;
            car.BlurAllCar();
        }

        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 0.5f;
        GetComponent<SpriteRenderer>().color = tmp;
    }
}
