using UnityEngine;

public class Player : MonoBehaviour
{
    public TypePlayer.Type Type;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Type = TypePlayer.Type.Human;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
