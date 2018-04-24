using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class DialogueLoader : MonoBehaviour
{
    public TextAsset[] xmlDocs;
    public static SortedDictionary<String, Graph> fullDialogue;

    private void Awake()
    {
        fullDialogue = new SortedDictionary<String, Graph>();

        foreach (TextAsset xmlFile in xmlDocs)
        {
            Graph _g = new Graph();
            _g = _g.Load(xmlFile);
            fullDialogue.Add(xmlFile.name, _g);
            Debug.Log(xmlFile.name);
        }
    }
}

[XmlRoot("Graph")]
public class Graph
{   
    public int score = 0;
    [XmlArray("NodeList")]
    [XmlArrayItem("Node")]
    public List<Node> nodeList = new List<Node>();

    public Graph Load(TextAsset xml)
    {
        var serializer = new XmlSerializer(typeof(Graph));
        StringReader _reader = new StringReader(xml.text);
        Graph _graph = serializer.Deserialize(_reader) as Graph;
        _reader.Close();
        return _graph;
    }
}

public class Node
{
    [XmlArray("dialogue")]
    [XmlArrayItem("line")]
    public List<string> dialogue = new List<string>();
        
    [XmlArray("optionList")]
    [XmlArrayItem("option")]
    public List<Option> optionList = new List<Option>();
}

public class Option
{
    [XmlElement("text")]
    public string text;

    [XmlElement("score")]
    public int score;

    [XmlElement("factionArmy")]
    public int factionArmy;

    [XmlElement("factionChurch")]
    public int factionChurch;

    [XmlElement("factionCult")]
    public int factionCult;

    [XmlElement("factionPolitics")]
    public int factionPolitics;

    [XmlElement("Node")]
    public Node target;
}
