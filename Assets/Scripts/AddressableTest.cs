using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableTest : MonoBehaviour
{
    [SerializeField] 
    private AssetReferenceT<AudioClip> _bgm;

    [SerializeField]
    private GameObject BGMObj;


    private void Start()
    {
        StartCoroutine(InitAddressable());
    }

    IEnumerator InitAddressable()
    {
        var init = Addressables.InitializeAsync();
        yield return init;
    }

    public void OnButton()
    {
        _bgm.LoadAssetAsync().Completed += (Obj) =>
        {
            var bgmSound = BGMObj.GetComponent<AudioSource>();
            bgmSound.clip = Obj.Result;
            bgmSound.loop = true;
            bgmSound.Play();
        };
    }
}
