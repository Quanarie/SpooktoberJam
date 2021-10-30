using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class IngredientsScroll : MonoBehaviour
{
    [SerializeField] Text frogText;
    [SerializeField] Text skinlessText;
    [SerializeField] Text zombieText;
    [SerializeField] Text droopyText;
    [SerializeField] Text vikingText;
    [SerializeField] Text flowerText;
    [SerializeField] Text spellText;

    [SerializeField] Image frogCrossedOut;
    [SerializeField] Image skinlessCrossedOut;
    [SerializeField] Image zombieCrossedOut;
    [SerializeField] Image droopyCrossedOut;
    [SerializeField] Image vikingCrossedOut;
    [SerializeField] Image flowerCrossedOut;
    [SerializeField] Image spellCrossedOut;

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
        int frogCount;
        if (GameManager.Instance.homeEnter.frogEyes >= GameManager.Instance.homeEnter.maxFrogEyes)
        {
            frogCount = GameManager.Instance.homeEnter.maxFrogEyes;
            frogCrossedOut.enabled = true;
        }
        else
        {
            frogCount = GameManager.Instance.homeEnter.frogEyes;
        }
        frogText.text = "Eye of the cursed frog: " + frogCount + "/" + GameManager.Instance.homeEnter.maxFrogEyes;

        int skinlessCount;
        if (GameManager.Instance.homeEnter.tongues >= GameManager.Instance.homeEnter.maxTongues)
        {
            skinlessCount = GameManager.Instance.homeEnter.maxTongues;
            skinlessCrossedOut.enabled = true;
        }
        else
        {
            skinlessCount = GameManager.Instance.homeEnter.tongues;
        }
        skinlessText.text = "Tongue of the skinless walker: " + skinlessCount + "/" + GameManager.Instance.homeEnter.maxHair;

        int hairCount;
        if (GameManager.Instance.homeEnter.hair >= GameManager.Instance.homeEnter.maxHair)
        {
            hairCount = GameManager.Instance.homeEnter.maxHair;
            zombieCrossedOut.enabled = true;
        }
        else
        {
            hairCount = GameManager.Instance.homeEnter.hair;
        }
        zombieText.text = "Hair of the undead: " + hairCount + "/" + GameManager.Instance.homeEnter.maxHair;

        int heartCount;
        if (GameManager.Instance.homeEnter.hearts >= GameManager.Instance.homeEnter.maxHearts)
        {
            heartCount = GameManager.Instance.homeEnter.maxHearts;
            zombieCrossedOut.enabled = true;
        }
        else
        {
            heartCount = GameManager.Instance.homeEnter.hearts;
        }
        droopyText.text = "Heart of the death hound: " + heartCount + "/" + GameManager.Instance.homeEnter.maxHearts;

        int soulCount;
        if (GameManager.Instance.homeEnter.souls >= GameManager.Instance.homeEnter.maxSouls)
        {
            soulCount = GameManager.Instance.homeEnter.maxSouls;
            zombieCrossedOut.enabled = true;
        }
        else
        {
            soulCount = GameManager.Instance.homeEnter.souls;
        }
        vikingText.text = "Soul of a possessed viking warrior: " + soulCount + "/" + GameManager.Instance.homeEnter.maxSouls;

        flowerText.text = "The Eternal Flower. I think there's one somewhere in the village. The old man used to say it was \"a pink flower surrounded by other beautiful plants\". I wonder if it's still there...";
        if (GameManager.Instance.homeEnter.isFlowerPicked)
            flowerCrossedOut.enabled = true;
        
        spellText.text = "The Curse Reverse Spell. Legend says the original scholars wrote the instructions in their rune language, and that they would glow blue should the time come that others would need to use it again";
        if (GameManager.Instance.homeEnter.isSpellPicked)
            spellCrossedOut.enabled = true;
    }
}
