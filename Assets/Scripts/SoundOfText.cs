using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class SoundOfText : MonoBehaviour
{
    private TextMeshProUGUI DialogueText;
    private bool IsDisplaying = false;


    private string[] DialogueArray;
    private string[] ArrayOfStringsForNPC;
    private AudioSource[] ArrayOfSounds;

    //sounds for Speaker
    public AudioSource Sound1;
    public AudioSource Sound2;
    public AudioSource Sound3;
    public AudioSource Sound4;
    public AudioSource Sound5;
    public AudioSource Sound6;
    public AudioSource Sound7;
    public AudioSource Sound8;
    public AudioSource Sound9;
    public AudioSource Sound10;
    public AudioSource Sound11;
    public AudioSource Sound12;

    public AudioSource SoundNPC;

    private void Start()
    {
        ArrayOfSounds = new AudioSource[] {
            Sound1,
            Sound2,
            Sound3,
            Sound4,
            Sound5,
            Sound6,
            Sound7,
            Sound8,
            Sound9,
            Sound10,
            Sound11,
            Sound12,
        };

        ArrayOfStringsForNPC = new string[] {
            "I have indulged in the pleasures of the flesh for far too long, yet the yearning for more never seems to abate, and my soul is consumed by the fire of desire.Lu",
            "The seductive allure of carnal desire has ensnared me, and I am but a slave to its whims, unable to resist its pull.Lu",
            "My thoughts are consumed with impure fantasies, and I cannot escape the grip of lust, for it holds me tightly in its embrace.Lu",
            "The insatiable hunger within me drives me to consume beyond my needs, and I am left with a sense of emptiness and despair.Gl",
            "My desire for more food and drink is never-ending, and I am unable to find satisfaction, even as my body screams out in agony.Gl",
            "I am trapped in a cycle of indulgence and regret, unable to resist the temptation of overindulging, and left with a sense of shame and disgust.Gl",
            "The thirst for wealth and power has corrupted me, and I am willing to sacrifice everything and everyone in pursuit of my insatiable desire.Gr",
            "My obsession with acquiring more has blinded me to the true value of life, and I am left with a hollow sense of accomplishment.Gr",
            "I am consumed by the desire for more, unable to find contentment in what I have, always seeking to accumulate more, even at the cost of my own soul.Gr",
            "My indolence has led me down a path of stagnation and apathy, and I am left with a sense of unfulfillment and regret.An",
            "I am weighed down by the burden of my own laziness, unable to muster the motivation to pursue my dreams and goals.An",
            "The inertia of my laziness is a prison from which I cannot escape, and I am left with a sense of hopelessness and despair.An",
            "I am consumed by jealousy and envy, unable to find joy in the successes of others, and left with a sense of bitterness and resentment.En",
            "The green-eyed monster within me rears its ugly head, driving me to covet that which I do not have, and leaving me with a sense of emptiness and longing.En",
            "My envy has twisted my perception of reality, causing me to see the world through a lens of bitterness and distrust, unable to find peace or contentment.En",
            "My ego has grown so large that it obscures all else, and I am blinded to the truth of my own shortcomings and weaknesses.Pr",
            "The hubris that consumes me is like a cancer, spreading throughout my being and corrupting all that is good within me.Pr",
            "My pride has become a prison, locking me away from the world and isolating me from those who could help me grow and learn.Pr",
        };

        DialogueText = GameObject.FindGameObjectWithTag("Text").GetComponent<TextMeshProUGUI>();

        DialogueArray = new string[2];
        DialogueArray[0] = GetRandomString();

        DialogueArray[1] = GetRandomSound();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && IsDisplaying == false)
        {
            IsDisplaying = true;
            StartCoroutine(DialogueDisplay(DialogueArray));
        }
    }

    private IEnumerator DialogueDisplay(string[] Dialogue)
    {
        for (int i = 0; i < 1; i++)
        {
            StringSplitter(Dialogue[i]);
            string[] Characters = new string[Dialogue[i].Length];

            yield return new WaitForSeconds((Characters.Length + 45) * 0.05f);
        }
    }

    private void StringSplitter(string Sentence)
    {
        DialogueText.text = "";
        string[] Characters = new string[Sentence.Length];

        for (int i = 0; i < Sentence.Length; i++)
        {
            Characters[i] = System.Convert.ToString(Sentence[i]);
        }
        StartCoroutine(StringDisplayDelay(Characters));
    }

    private IEnumerator StringDisplayDelay(string[] Characters)
    {
        for (int i = 0; i < Characters.Length - 2; i++)
        {
            DialogueText.text += Characters[i];
            if (Characters[Characters.Length - 2] + Characters[Characters.Length - 1] == "Lu")
            {
                SoundNPC.Play();
                
            }
            else 
            {
                SoundNPC.Play();
            }

            yield return new WaitForSecondsRealtime(0.05f);
        }

        IsDisplaying = false;
    }

    public string GetRandomString()
    {
        int index = Random.Range(0, ArrayOfStringsForNPC.Length);
        return ArrayOfStringsForNPC[index];
    }

    public string GetRandomSound()
    {
        int index = Random.Range(0, ArrayOfSounds.Length);
        SoundNPC = ArrayOfSounds[index];
        return "";
    }

}