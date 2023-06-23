using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SoundText : MonoBehaviour {


    public Text timerText;
    public Text foodText;
    public AudioClip[] musicTracks;
    public GameObject imageBG;

    public GameObject[] avatars;

    private AudioSource audioSource;

    [SerializeField]
    private TextMeshProUGUI dialogueText;

    public bool isDisplaying = false;
    private bool isTextDoneDisplaying = false;
    private bool timeIsOver = false;
    private float textSpeed = 0.05f;
    private int foodCounter = 0;

    private string dialog;
    /*
    Гордыня (превышение самооценки, высокомерие)
    Алчность (жадность, неудержимое стремление к богатству и материальным вещам)
    Похоть (неправильное использование или чрезмерное удовлетворение сексуальных желаний)
    Зависть (желание иметь то, что у других, ревность)
    Гнев (ярость, ненависть, деструктивная злоба)
    Праскрупулезность (лень, отсутствие рвения в духовных и моральных делах)
    Праздность (усталость, безделье, отсутствие стремления к делу и ответственности)
    */
    private string[] arrayOfStringsForNPC = {
             "I always know the best way to do it, I don't need to consult anyone. Pr",
             "My opinion is always right, I can't be wrong. Pr",
             "My success and accomplishments speak to my excellence in this field. Pr",
             "I always crave more - more accomplishments, more wealth, more power. My desires are never satisfied. Gr",
             "I never have enough of what I have. Always striving for more luxury, dissolution and excess. Gr",
             "I strive to possess all I can - material possessions, resources, and influence. My thirsty heart knows no limit. Gr",
             "My desires burst into flames, they are indomitable and dominate my mind. Lu",
             "Simple satisfaction is not enough for me--I seek seduction, sensual pleasures, and a constant search for new sexual adventures. Lu",
             "My body and depraved fantasies vote against my rational side, and I plunge into the unrestrained satisfaction of my passions. Lu",
             "I look at the successes of others with a burning desire to possess what they have and to reach their heights. En",
             "Seeing the prosperity and achievements of others, I feel jabs of envy that feed my desires and dissatisfaction with my position. En",
             "My heart is full of negative emotions when I compare myself to others and realize I have less than they do. En",
             "My emotions rage and overwhelm me when I experience injustice or abuse, and it's hard to hide it behind a mask of calm. Wr",
             "Often I find myself in a state of inner rage when situations don't go the way I expect, and this leads to conflict and negative reactions. Wr",
             "My anger transforms into a fire that burns inside me when I encounter obstacles or injustice, and it affects my relationships and decisions. Wr",
             "I like to enjoy serenity and idleness, letting time just pass me by. Sl",
             "I always have an excuse to put off tasks for later and enjoy idleness. Sl",
             "I prefer to avoid effort and not put in extra energy because I believe I can succeed without too much effort. Sl",
             "I find pleasure in idleness and serenity, abandoning effort and immersing myself in a world of doing nothing. Gl",
             "My days are often filled with frivolous entertainment and idleness as I shirk responsibility and prefer relaxation Gl",
             "I like to spend my time in idleness, putting things off and enjoying the carefree nature of every moment. Gl"
    };

    void Start() {
        //foodCounter = SaveData.currentApples;
        foodText.text = foodCounter + "";
        timerText.text = "";
        audioSource = GetComponent<AudioSource>();
        imageBG.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && isDisplaying) {
            textSpeed = 0.007f;
        }
        if (isDisplaying) {
            if (isTextDoneDisplaying) CheckAnswer();
        }

        
    }

    private IEnumerator StringDisplayDelay(string sentence) {
        dialogueText.text = "";

        for (int i = 0; i < sentence.Length - 2; i++) {
            dialogueText.text += sentence[i];
            audioSource.Play();

            yield return new WaitForSecondsRealtime(textSpeed);
        }
        isTextDoneDisplaying = true;
        StartCoroutine(Timerset());
    }

    private string GetRandomString() {
        int index = Random.Range(0, arrayOfStringsForNPC.Length);
        return arrayOfStringsForNPC[index];
    }

    private void GetRandomSound() {
        int index = Random.Range(0, musicTracks.Length);
        audioSource.clip = musicTracks[index];
    }

    public void GetRandomDialog() {

        int r = Random.Range(0, 6);

        for (int i = 0; i < 6; i++) {
            if (i == r) { 
                avatars[i].SetActive(true); 
                continue;
            }
            avatars[i].SetActive(false);
        }

        isTextDoneDisplaying = false;
        timeIsOver = false;
        isDisplaying = true;
        imageBG.SetActive(true);
        Time.timeScale = 0f;
        dialog = GetRandomString();
        GetRandomSound();

        StartCoroutine(StringDisplayDelay(dialog));
    }

    private void CheckAnswer() {
        if (timeIsOver) {
            foodCounter--;
            foodText.text = foodCounter + "";
            timerText.text = "";
            isDisplaying = false;
            imageBG.SetActive(false);
            Time.timeScale = 1f;
            textSpeed = 0.05f;
            timeIsOver = false;
            return;
        }
        int answer = -1;
        if (Input.GetKeyDown(KeyCode.Alpha1)) answer = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2)) answer = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3)) answer = 3;
        if (Input.GetKeyDown(KeyCode.Alpha4)) answer = 4;
        if (Input.GetKeyDown(KeyCode.Alpha5)) answer = 5;
        if (Input.GetKeyDown(KeyCode.Alpha6)) answer = 6;
        if (Input.GetKeyDown(KeyCode.Alpha7)) answer = 7;

        if (answer > 0) {
            if (GetCorrectAnswer() == answer) foodCounter++;
            else if (GetCorrectAnswer() != answer) foodCounter--;
            foodText.text = foodCounter + "";
            timerText.text = "";
            isDisplaying = false;
            imageBG.SetActive(false);
            Time.timeScale = 1f;
            textSpeed = 0.05f;
        }
    }

    private int GetCorrectAnswer() {
        string ans = dialog.Substring(dialog.Length - 2, 2);
        switch (ans) {
            case "Pr": return 1;
            case "Gr": return 2;
            case "Lu": return 3;
            case "En": return 4;
            case "Wr": return 5;
            case "Sl": return 6;
            case "Gl": return 7;
            default: return 0;
        }
    }

    private IEnumerator Timerset() {
        int time = 15;
        for (int i = time; i >= 0; i--) {
            if (!isDisplaying) break;
            if (i == 0) timeIsOver = true;
            timerText.text = i + "";
            yield return new WaitForSecondsRealtime(1f);
        }

    }
}
