using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public string keyType;
    public Text KeyNameText;


    Canvas m_Canvas;

    void Start()
    {
        KeyNameText.text = keyType;

        m_Canvas = KeyNameText.GetComponentInParent<Canvas>();
        m_Canvas.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        m_Canvas.gameObject.SetActive(true);

        var keychain = other.GetComponent<Keychain>();

        if (keychain != null && keychain.HaveKey(keyType))
        {
            keychain.UseKey(keyType);
            Opened();
            //just destroy the script, if it's on the door we don't want to destroy the door.
            Destroy(this);
            Destroy(m_Canvas.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        m_Canvas.gameObject.SetActive(false);
    }

    public virtual void Opened()
    {
        Trigger();
    }
}
