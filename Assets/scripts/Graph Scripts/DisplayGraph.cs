using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DisplayGraph : MonoBehaviour
{
    ToggleGroup toggleGroup;

    BarChart barChart;
    [SerializeField] GameObject chart;

    Toggle overall_toggle;
    Toggle directions_toggle;
    Toggle trafficSigns_toggle;
    Toggle pedestrians_toggle;
    Toggle trafficLight_toggle;
    Toggle speedLimit_toggle;
    Toggle collisions_toggle;
    Toggle lanes_toggle;

    int[] overall_values;
    int[] directions_values;
    int[] trafficSigns_values;
    int[] pedestrians_values;
    int[] trafficLight_values;
    int[] speedLimit_values;
    int[] collisions_values;
    int[] lanes_values;

    public Toggle currentSelection
    {
        get { return toggleGroup.ActiveToggles().FirstOrDefault(); }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject progressObject;
        ViewProgress viewProgress;
        progressObject = GameObject.Find("MyProgress");
        if(progressObject!= null)
        {
            viewProgress = progressObject.GetComponent<ViewProgress>();
            overall_values = viewProgress.getSumArr();
            directions_values = viewProgress.getDirectionsArr();
            trafficSigns_values = viewProgress.getTrafficSignsArr();
            pedestrians_values = viewProgress.getPedestriansArr();
            trafficLight_values = viewProgress.getTrafficLightArr();
            speedLimit_values = viewProgress.getSpeedLimitArr();
            collisions_values = viewProgress.getCollisionsArr();
            lanes_values = viewProgress.getLanesArr();
        }
            
        toggleGroup = GetComponent<ToggleGroup>();
        
        barChart = chart.GetComponent<BarChart>();

        overall_toggle = transform.Find("Overall Errors").GetComponent<Toggle>();
        //present the correct graph according to which category toggle is pressed
        overall_toggle.onValueChanged.AddListener(delegate {
            if (overall_toggle.isOn)
            {
                displayGraph(overall_values);
            }
        });
        directions_toggle = transform.Find("Directions").GetComponent<Toggle>();
        directions_toggle.onValueChanged.AddListener(delegate {
            if (directions_toggle.isOn)
            {
                displayGraph(directions_values);
            }
        });
        trafficSigns_toggle = transform.Find("Traffic Signs").GetComponent<Toggle>();
        trafficSigns_toggle.onValueChanged.AddListener(delegate {
            if (trafficSigns_toggle.isOn)
            {
                displayGraph(trafficSigns_values);
            }
        });
        pedestrians_toggle = transform.Find("Pedestrians").GetComponent<Toggle>();
        pedestrians_toggle.onValueChanged.AddListener(delegate {
            if (pedestrians_toggle.isOn)
            {
                displayGraph(pedestrians_values);
            }
        });
        trafficLight_toggle = transform.Find("Traffic Lights").GetComponent<Toggle>();
        trafficLight_toggle.onValueChanged.AddListener(delegate {
            if (trafficLight_toggle.isOn)
            {
                displayGraph(trafficLight_values);
            }
        });
        speedLimit_toggle = transform.Find("Speed Limit").GetComponent<Toggle>();
        speedLimit_toggle.onValueChanged.AddListener(delegate {
            if (speedLimit_toggle.isOn)
            {
                displayGraph(speedLimit_values);
            }
        });
        collisions_toggle = transform.Find("Collisions").GetComponent<Toggle>();
        collisions_toggle.onValueChanged.AddListener(delegate {
            if (collisions_toggle.isOn)
            {
                displayGraph(collisions_values);
            }
        });
        lanes_toggle = transform.Find("Lanes").GetComponent<Toggle>();
        lanes_toggle.onValueChanged.AddListener(delegate {
            if (lanes_toggle.isOn)
            {
                displayGraph(lanes_values);
            }
        });
        //by default when we enter the progress scene the overall errors graph is presented
        displayGraph(overall_values);
    }

    public void displayGraph(int[] inputValues)
    {
        if (inputValues.Length != 0)
        {
            barChart.Clear();
            barChart.DisplayGraph(inputValues);
        } else
        {
            barChart.DestroyMessage();
            barChart.DisplayMessage();
        }
        
    }
}