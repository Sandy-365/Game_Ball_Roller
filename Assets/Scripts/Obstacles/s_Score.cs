using TMPro;
using UnityEngine;

public class s_Score : MonoBehaviour
{

    public TextMeshProUGUI text;
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        int value = (int)player.position.z + 39;
        // Debug.Log(value);
        text.SetText(value.ToString());
    }
}
