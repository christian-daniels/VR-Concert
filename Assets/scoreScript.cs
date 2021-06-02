
using UnityEngine;
using UnityEngine.UI;
public class scoreScript : MonoBehaviour
{
    public GameManager gameManager;
    public Text scoreText;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(player.position.z);
        scoreText.text = gameManager.createText();
        
    }
}
