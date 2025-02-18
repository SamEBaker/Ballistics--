using UnityEngine;

public class BoadTrigger : MonoBehaviour
{
    public string myScore;
    public GameManager gm;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "dart")
        {
            gm.UpdateScore(myScore);
        }

    }
}
