using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    GameManager gm;
    public Image cutSceneImage, dialogImage;
    public Sprite[] images;
    public Text dialog;
    public string[] dialogTexts;
    private void Start()
    {
        StartCoroutine(CutScene());
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    IEnumerator CutScene()
    {
        cutSceneImage.sprite = images[0];
        for (int i = 0; i < dialogTexts.Length; i++)
        {
            //cutSceneImage.sprite = images[i];
            StartCoroutine(Dialog(i));
            yield return new WaitForSeconds(dialogTexts[i].Length * 0.1f);
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Dialog End");
        StartCoroutine(FadeManager.FadeOut(dialogImage, 1));
        StartCoroutine(FadeManager.FadeOut(dialog, 1));
        StartCoroutine(FadeManager.FadeOut(cutSceneImage, 1));

        yield return new WaitForSeconds(1);
        StartCoroutine(FadeManager.FadeIn(cutSceneImage, 1));
        cutSceneImage.sprite = images[1];
    }

    IEnumerator Dialog(int num)
    {
        yield return null;
        dialog.text = "";
        for (int i = 0; i < dialogTexts[num].Length; i++)
        {
            dialog.text += dialogTexts[num][i];
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void GoToBattle()
    {
        gm.nextStep = true;
    }
}
