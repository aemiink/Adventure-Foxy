using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fox_Save : MonoBehaviour
{
    [SerializeField] TMP_Text saveWarning;

    void SavePosition(Vector3 playerPos)
    {
        // ->  Bu fonksiyon, PlayerPrefs'te belirli bir isim altında bir Ondalıklı sayıyı saklamak için kullanılır.
        PlayerPrefs.SetFloat("posX", playerPos.x);
        PlayerPrefs.SetFloat("posY", playerPos.y);
        PlayerPrefs.SetFloat("posZ", playerPos.z);
        // -> Tanımlanmış verileri kayıt etmek için kullanılır.
        PlayerPrefs.Save();
        // Canvas'ta kayıt edildiğini kullanıcya bildirme
        saveWarning.text = "Konumuzun Başarıyla Kayıt Edildi!";
        // 2 saniye gecikmeli olarak çağır
        Invoke("DeleteText", 2f);
    }

    public void DeleteText()
    {
        saveWarning.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 pos = other.transform.position;
            SavePosition(pos);
        }
    }

}
