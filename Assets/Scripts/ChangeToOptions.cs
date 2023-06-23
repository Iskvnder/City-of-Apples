using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToOptions : MonoBehaviour
{
    // Start is called before the first frame update
    // /* public static bool OptionIsChanged = false;*/

    public GameObject hideOption;
    public GameObject showOption;

    // Update is called once per frame

    public void ChangeOption()
    {
        hideOption.SetActive(false);
        showOption.SetActive(true);
    }
    public void ChangeMenu()
    {
        hideOption.SetActive(true);
        showOption.SetActive(false);
    }
}
