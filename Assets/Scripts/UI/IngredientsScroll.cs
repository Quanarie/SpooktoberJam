using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class IngredientsScroll : MonoBehaviour
{
    [SerializeField] Text frogText;
    private int frogCount = 0;
    private int frogMax;

    [SerializeField] Text skinlessText;
    private int skinlessCount = 0;
    private int skinlessMax;

    [SerializeField] Text zombieText;
    private int zombieCount = 0;
    private int zombieMax;

    [SerializeField] Text droopyText;
    private int droopyCount = 0;
    private int droopyMax;

    [SerializeField] Text vikingText;
    [SerializeField] Text flowerText;
    [SerializeField] Text spellText;


    // Start is called before the first frame update
    void Start()
    {
        UpdateIngredients();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIngredients();
    }

    public void UpdateIngredients()
    {
        frogText.text = "Eye of the cursed frog: " + GameManager.Instance.homeEnter.frogEyes + "/" + GameManager.Instance.homeEnter.maxFrogEyes;
        skinlessText.text = "Tongue of the skinless walker: " + GameManager.Instance.homeEnter.tongues + "/" + GameManager.Instance.homeEnter.maxTongues;
        zombieText.text = "Hair of the undead: " + GameManager.Instance.homeEnter.hair + "/" + GameManager.Instance.homeEnter.maxHair;
        droopyText.text = "Heart of the death hound: " + GameManager.Instance.homeEnter.hearts + "/" + GameManager.Instance.homeEnter.maxHearts;
        vikingText.text = "Soul of a possessed viking warrior: " + GameManager.Instance.homeEnter.souls + "/" + GameManager.Instance.homeEnter.maxSouls;
        flowerText.text = "The Eternal Flower. I think there's one somewhere in the village. The old man used to say it was \"a pink flower surrounded by other beautiful plants\". I wonder if it's still there...";
        spellText.text = "The Curse Reverse Spell. Legend says the original scholars wrote the instructions in their rune language, and that they would glow blue should the time come that others would need to use it again";
    }
}
