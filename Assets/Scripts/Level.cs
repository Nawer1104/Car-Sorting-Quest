using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<Truck> trucks;

    private Car slectedCar_1;

    private Car slectedCar_2;

    public void SetSelectedCar(Car car)
    {
        if (slectedCar_1 == null)
        {
            slectedCar_1 = car;
            slectedCar_1.GetComponent<Animator>().SetTrigger("Selected");
        }
        else
        {
            if (slectedCar_1.GetId() == car.GetId())
            {
                slectedCar_1.GetComponent<Animator>().SetTrigger("UnSelect");
                slectedCar_1 = null;
            }
            else
            {
                slectedCar_2 = car;
                SwitchCar();
            }
        }
    }

    private void SwitchCar()
    {
        Enum type_temp;
        type_temp = slectedCar_1.type;
        slectedCar_1.type = slectedCar_2.type;
        slectedCar_2.type = type_temp;

        slectedCar_1.SetCarSprite(slectedCar_1.type);
        slectedCar_2.SetCarSprite(slectedCar_2.type);

        slectedCar_1.GetComponent<Animator>().SetTrigger("UnSelect");
        slectedCar_2.GetComponent<Animator>().SetTrigger("UnSelect");

        slectedCar_1 = null;
        slectedCar_2 = null;

        foreach(Truck truck in trucks)
        {
            truck.CheckCars();
        }
    } 

    public static List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}
