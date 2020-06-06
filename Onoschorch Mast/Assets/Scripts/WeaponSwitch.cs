using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int CurrentWeapon = 0;

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {

        int previousCurrentWeapon = CurrentWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (CurrentWeapon >= transform.childCount - 1)
                CurrentWeapon = 0;
            else
                CurrentWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (CurrentWeapon <= 0)
                CurrentWeapon = transform.childCount - 1;
            else
                CurrentWeapon--;
        }

        if (previousCurrentWeapon != CurrentWeapon)
        {
            SelectWeapon();
        }

    }

    void SelectWeapon ()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == CurrentWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }
}
