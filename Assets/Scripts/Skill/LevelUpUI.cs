using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    [Header("Option")]
    [SerializeField] private Option opOne;
    [SerializeField] private Option opTwo;
    [SerializeField] private Option opThr;
    [SerializeField] private Image bar;
    private bool isSelect;
    private Skill selectSkill;

    public void SetOptions(int one, int two, int thr)
    {
        isSelect = false;
        SetOption(ref opOne, one);
        SetOption(ref opTwo, two);
        SetOption(ref opThr, thr);

        gameObject.SetActive(true);
        StartCoroutine(Select());
    }

    public void SetOption(ref Option op, int i)
    {
        Skill skill = SkillFactory.GetSkill(i);
        LoadImage(op, skill.spriteAddress);
        op.text.text = skill.text;
        op.name.text = skill.name;
        op.skill = skill;
        op.button.onClick.AddListener(() => SelectSkill(skill));
    }

    private void LoadImage(Option op, string address)
    {
        Addressables.LoadAssetAsync<Sprite>(address).Completed +=
            (AsyncOperationHandle<Sprite> handle) =>
            {
                op.image.sprite = handle.Result;
                op.handle = handle;
            };
    }

    private void ReleaseImage()
    {
        Addressables.Release(opOne.handle);
        Addressables.Release(opTwo.handle);
        Addressables.Release(opThr.handle);
    }

    private void SelectSkill(Skill skill)
    {
        selectSkill = skill;
        isSelect = true;
    }

    private IEnumerator Select()
    {
        RectTransform rect = GetComponent<RectTransform>();

        float cool = 0;
        float maxCool = 0.15f;
        while (cool < maxCool)
        {
            rect.anchoredPosition = new Vector2(1500 - (1500 * cool / maxCool), 0);
            cool += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        cool = 0;
        while (!isSelect)
        {
            if (cool > 2f) SelectSkill(opOne.skill);
            bar.fillAmount = 1 - (cool / 2f);
            cool += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        cool = 0;
        while (cool < maxCool)
        {
            rect.anchoredPosition = new Vector2(1500 * cool / maxCool, 0);
            cool += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        ReleaseImage();
        gameObject.SetActive(false);
        PlayerSkillSystem.Instance.LevelUpEnd(selectSkill);
    }
}

[System.Serializable]
public class Option
{
    public Button button;
    public Image image;
    public Text name;
    public Text text;
    public Skill skill;

    public AsyncOperationHandle handle;
}