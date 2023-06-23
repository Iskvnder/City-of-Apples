using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatablesGenerator : MonoBehaviour {

    
    public GameObject mainPlatform;
    public GameObject[] activeWindowPrefab;
    public GameObject player;

    public GameObject[] aimImages;

    public List<GameObject> aims;

    public int maxActiveWindows = 3;
    public int currentActiveWindows = 0;

    public bool[] activeWindows;

    private Transform[] rawWindows;
    private List<Transform> readyWindows;

    private int currentLevel;


    void Start() {

        currentLevel = SaveData.currentLevel;

        rawWindows = mainPlatform.GetComponentsInChildren<Transform>();
        readyWindows = new List<Transform>();

        SortPlatforms();

        activeWindows = new bool[readyWindows.Count];

        for (int i = 0; i < activeWindows.Length; i++) {
            activeWindows[i] = false;
        }
    }

    private void FixedUpdate() {
        int aimsCount = aims.Count;

        if (aimsCount == 3) {
            for (int i = 0; i < aimsCount; i++) {
                Ray ray = new Ray(player.transform.position, (aims[i].transform.position - player.transform.position).normalized * 3f);
                Vector3 point = ray.GetPoint(5);
                aimImages[i].transform.position = point;
            }
        } else
        if (aimsCount == 2) {
            for (int i = 0; i < aimsCount; i++) {
                Ray ray = new Ray(player.transform.position, (aims[i].transform.position - player.transform.position).normalized * 3f);
                Vector3 point = ray.GetPoint(5);
                aimImages[i].transform.position = point;
            }
            aimImages[2].transform.position = new Vector3(-65, 0, 0);
        } else
        if (aimsCount == 1) {
            Ray ray = new Ray(player.transform.position, (aims[0].transform.position - player.transform.position).normalized * 3f);
            Vector3 point = ray.GetPoint(5);
            aimImages[0].transform.position = point;
            aimImages[2].transform.position = new Vector3(-65, 0, 0);
            aimImages[1].transform.position = new Vector3(-65, 0, 0);
        } else 
        if (aimsCount == 0) {
            for (int i = 0; i < aimImages.Length; i++) {
                aimImages[i].transform.position = new Vector3(-65, 0, 0);
            }
        }
    }

    void SortPlatforms() {
        foreach (Transform window in rawWindows) {
            if (window.gameObject.tag == "FoodPlatform") {
                readyWindows.Add(window);
            }
        }
    }

    public void GenerateWindows() {
        int windowsCount = readyWindows.Count;
        int currentWindowsCount = currentLevel + 5;
 
        int r;
        if (currentWindowsCount > windowsCount) currentWindowsCount = windowsCount;

        do {
            r = Random.Range(0, currentWindowsCount);
        } while (activeWindows[r] != false);

        activeWindows[r] = true;
        currentActiveWindows++;

        int r2 = 0;
        r2 = Random.Range(0, 3);

        GameObject go = Instantiate(activeWindowPrefab[r2], readyWindows[r].position, readyWindows[r].rotation);
        
        go.name = r + "";
        go.transform.SetParent(transform);
        aims.Add(go);
    }
}
