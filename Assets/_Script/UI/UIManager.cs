using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager instance{ get { return _instance; } }

    PlayerBehaviour Pb;
    
    [Header("CoolTime")]
    [SerializeField]
    private Image coolTimeImage;
    [SerializeField]
    private Text coolTimeText;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Pb = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();

        coolTimeImage.gameObject.SetActive(false);
    }


    #region  Skill
    /// <summary>
    /// NOTE : 스킬 쿨타임 Image 
    /// </summary>
    /// <param name="Time"></param>
    public void StartSkillCoolTime(float cooltime)
    {
        if (!Pb.isRunningCooltimeSkill)
            StartCoroutine(CooltimeImageProcess(cooltime));
    }

    /// <summary>
    /// NOTE : 남은 시간에 따른 TEXT변경 및 IMAGE Amount값 변경
    /// </summary>
    /// <param name="cooltime"></param>
    /// <returns></returns>
    IEnumerator CooltimeImageProcess(float cooltime)
    {
        Pb.isRunningCooltimeSkill = true;
        var count = cooltime;
        coolTimeImage.fillAmount = 1;
        coolTimeText.text = count.ToString();
        coolTimeImage.gameObject.SetActive(true);
        while (count > 0)
        {
            count -= Time.deltaTime;
            coolTimeText.text = ((int)count).ToString();
            coolTimeImage.fillAmount = count / cooltime;
            yield return new WaitForFixedUpdate();
        }
        coolTimeImage.gameObject.SetActive(false);
        Pb.isRunningCooltimeSkill = false;
    }
    #endregion

}
