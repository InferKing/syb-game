using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    }

}
