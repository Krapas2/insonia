using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// boa sorte ao amigo que for refatorar isso :)
public class HomeTasks : MonoBehaviour
{

    [System.Serializable]
    public struct TaskObject
    {
        public GiveItem giveItem;
        public ReceiveItem receiveItem;
    }

    public GameObject bed;
    public GameObject wardrobe;
    public GameObject fridge;
    public GameObject microwave;
    public GameObject counter;
    public GameObject lasagna;

    public string bedTaskText;
    public string wardrobeTaskText;
    public string lasagnaTaskText;

    private TaskObject _bed;
    private Bed bedbed;
    private TaskObject _wardrobe;
    private TaskObject _fridge;
    private TaskObject _microwave;
    private TaskObject _counter;
    private Door door;

    private LayerManager lm;
    private HomeUIManager homeUIManager;

    void Start()
    {
        lm = FindObjectOfType<LayerManager>();
        homeUIManager = FindObjectOfType<HomeUIManager>();

        _bed.giveItem = bed.GetComponent<GiveItem>();
        _bed.receiveItem = bed.GetComponent<ReceiveItem>();
        bedbed = bed.GetComponent<Bed>();
        
        _wardrobe.giveItem = wardrobe.GetComponent<GiveItem>();
        _wardrobe.receiveItem = wardrobe.GetComponent<ReceiveItem>();
        
        _fridge.giveItem = fridge.GetComponent<GiveItem>();
        _fridge.receiveItem = fridge.GetComponent<ReceiveItem>();
        
        _microwave.giveItem = microwave.GetComponent<GiveItem>();
        _microwave.receiveItem = microwave.GetComponent<ReceiveItem>();
        
        _counter.giveItem = counter.GetComponent<GiveItem>();
        _counter.receiveItem = counter.GetComponent<ReceiveItem>();

        door = FindObjectOfType<Door>();

        lm.SetLayerRecursively(bed, gameObject.layer = LayerMask.NameToLayer("Scene"));
        _bed.giveItem.active = false;
        _bed.receiveItem.active = true;

        lm.SetLayerRecursively(wardrobe, gameObject.layer = LayerMask.NameToLayer("Default"));
        _wardrobe.giveItem.active = true;
        _wardrobe.receiveItem.active = false;
        
        lm.SetLayerRecursively(fridge, gameObject.layer = LayerMask.NameToLayer("Scene"));
        _fridge.giveItem.active = false;
        
        lm.SetLayerRecursively(microwave, gameObject.layer = LayerMask.NameToLayer("Scene"));
        _microwave.giveItem.active = false;
        _microwave.receiveItem.active = true;

        lm.SetLayerRecursively(counter, gameObject.layer = LayerMask.NameToLayer("Scene"));
        _counter.receiveItem.active = false;

        StartCoroutine("BedsheetToBed");
    }

    private IEnumerator BedsheetToBed(){

        while(_wardrobe.giveItem.active)
            yield return null;
        lm.SetLayerRecursively(bed, gameObject.layer = LayerMask.NameToLayer("Default"));
        lm.SetLayerRecursively(wardrobe, gameObject.layer = LayerMask.NameToLayer("Scene"));

        while(_bed.receiveItem.active)
            yield return null;
        lm.SetLayerRecursively(bed, gameObject.layer = LayerMask.NameToLayer("Scene"));

        StartCoroutine("BedsheetToBedTaskEnd");
    }

    private IEnumerator BedsheetToBedTaskEnd(){

        lm.SetLayerRecursively(bed, gameObject.layer = LayerMask.NameToLayer("Default"));
        bedbed.active = true;
        while(bedbed.active)
            yield return null;
        homeUIManager.text.text = bedTaskText;
        lm.SetLayerRecursively(bed, gameObject.layer = LayerMask.NameToLayer("Scene"));

        StartCoroutine("BedsheetToWardrobe");
    }
    
    private IEnumerator BedsheetToWardrobe(){

        lm.SetLayerRecursively(bed, gameObject.layer = LayerMask.NameToLayer("Default"));
        _bed.giveItem.active = true;
        lm.SetLayerRecursively(wardrobe, gameObject.layer = LayerMask.NameToLayer("Scene"));
        _wardrobe.receiveItem.active = true;

        while(_bed.giveItem.active)
            yield return null;
        lm.SetLayerRecursively(bed, gameObject.layer = LayerMask.NameToLayer("Scene"));
        lm.SetLayerRecursively(wardrobe, gameObject.layer = LayerMask.NameToLayer("Default"));

        while(_wardrobe.receiveItem.active)
            yield return null;
        lm.SetLayerRecursively(wardrobe, gameObject.layer = LayerMask.NameToLayer("Scene"));

        StartCoroutine("BedsheetToWardrobeTaskEnd");
    }

    private IEnumerator BedsheetToWardrobeTaskEnd(){

        lm.SetLayerRecursively(bed, gameObject.layer = LayerMask.NameToLayer("Default"));
        bedbed.active = true;
        while(bedbed.active)
            yield return null;
        homeUIManager.text.text = wardrobeTaskText;
        lm.SetLayerRecursively(bed, gameObject.layer = LayerMask.NameToLayer("Scene"));

        StartCoroutine("LasagnaToMicrowave");
    }

    private IEnumerator LasagnaToMicrowave(){
        lm.SetLayerRecursively(fridge, gameObject.layer = LayerMask.NameToLayer("Default"));
        _fridge.giveItem.active = true;
        _microwave.receiveItem.active = true;

        while(_fridge.giveItem.active)
            yield return null;
        lm.SetLayerRecursively(fridge, gameObject.layer = LayerMask.NameToLayer("Scene"));
        lm.SetLayerRecursively(microwave, gameObject.layer = LayerMask.NameToLayer("Default"));

        while(_microwave.receiveItem.active)
            yield return null;
        lm.SetLayerRecursively(microwave, gameObject.layer = LayerMask.NameToLayer("Scene"));
        
        StartCoroutine("LasagnaToCounter");
    }

    private IEnumerator LasagnaToCounter(){
        lm.SetLayerRecursively(microwave, gameObject.layer = LayerMask.NameToLayer("Default"));
        _microwave.giveItem.active = true;
        _counter.receiveItem.active = true;

        while(_microwave.giveItem.active)
            yield return null;
        lm.SetLayerRecursively(microwave, gameObject.layer = LayerMask.NameToLayer("Scene"));
        lm.SetLayerRecursively(counter, gameObject.layer = LayerMask.NameToLayer("Default"));

        while(_counter.receiveItem.active)
            yield return null;
        lm.SetLayerRecursively(counter, gameObject.layer = LayerMask.NameToLayer("Scene"));
        
        StartCoroutine("EatLasagna");
    }

    private IEnumerator EatLasagna(){
        lm.SetLayerRecursively(lasagna, gameObject.layer = LayerMask.NameToLayer("Default"));
        lasagna.GetComponent<Lasagna>().active = true;

        while(lasagna)
            yield return null;
        
        StartCoroutine("EatLasagnaTaskEnd");
    }

    private IEnumerator EatLasagnaTaskEnd(){

        lm.SetLayerRecursively(bed, gameObject.layer = LayerMask.NameToLayer("Default"));
        bedbed.active = true;
        while(bedbed.active)
            yield return null;
        homeUIManager.text.text = lasagnaTaskText;
        lm.SetLayerRecursively(bed, gameObject.layer = LayerMask.NameToLayer("Scene"));

        door.active = true;
        lm.SetLayerRecursively(door.gameObject, gameObject.layer = LayerMask.NameToLayer("Default"));
    }
}
