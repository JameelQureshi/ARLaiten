using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.UI;
public class TapToPlaceManager : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;
    public Slider speedSlider;
    public static float speed=1;
    public Text speedText;

    public Button AddButton;
    public ARSessionOrigin arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    public GameObject[] lanterns;
    public int totalLanterns = 0;
    public InputField inputField;
    public GameObject inputPanel;
    public string laternText;
    void Start()
    {
        lanterns = new GameObject[200];
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();


    }

    public void OnSpeedChanged()
    {
        speed = speedSlider.value;
        speedText.text = "Speed: " + speed;
    }

    public void AddText()
    {
        inputPanel.SetActive(false);
        if (inputField.text!="")
        {
            laternText = inputField.text;
        }
    }

    public void PlaceObject()
    {
        if (totalLanterns < 199)
        {

            GameObject lantern = Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
            lantern.transform.GetChild(2).gameObject.GetComponent<Text>().text=laternText;
            totalLanterns++;
            lanterns[totalLanterns] = lantern;
            AddButton.interactable = false;
        }

    }

    public void Release()
    {
        if (totalLanterns>0)
        {

            lanterns[totalLanterns].GetComponent<LanternManager>().Fly();
            totalLanterns--;

        }

    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arOrigin.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
