using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public void ChangeScene(string scene) {
        FindObjectOfType<MusicLoad>().PlayFX();
        SceneManager.LoadScene(scene);
    }

}
