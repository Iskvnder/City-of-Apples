using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData {
    public int currentLevel;
    public bool starterHit;

    public GameData(int currentLevel, bool starterHit) {
        this.currentLevel = currentLevel;
        this.starterHit = starterHit;
    }
}