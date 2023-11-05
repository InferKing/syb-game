using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChoosingLevel : MonoBehaviour
{
    [SerializeField] private Button _lvl1, _lvl2, _lvl3;
    private int _curLvl = 1;
    public void SetScene(int position) { 
        _curLvl = position;
    }
    public void ToPlay() {
        SceneManager.LoadScene($"Level{_curLvl}");
    }
}
