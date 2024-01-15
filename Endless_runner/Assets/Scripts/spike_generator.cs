using UnityEngine;

public class spike_generator : MonoBehaviour
{
    public GameObject spike;
    public float MinSpeed;
    public float MaxSpeed;

    public float currentSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;
        generateSpike();
    }

    public void generateSpike()
    {
        GameObject Spikeins = Instantiate(spike, transform.position, transform.rotation);
        
        Spikeins.GetComponent<spike_script>().spikeGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
