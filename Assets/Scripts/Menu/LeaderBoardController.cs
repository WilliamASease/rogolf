﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LeaderBoardController : MonoBehaviour
{
    public const string PREFIX = ".\\Assets\\Data\\";
    public const string LEADERBOARD = "leaderboard.xml";
    
    public Text[] names = new Text[5];
    public Text[] dates = new Text[5];
    public Text[] strokes = new Text[5];
    public Text[] scores = new Text[5];
    
    // Start is called before the first frame update
    void Start()
    {
            DisplayAllRecords();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DisplayRecord(int pos, Record r)
    {
        names[pos].text = r.name;
        dates[pos].text = r.date;
        strokes[pos].text = r.stroke;
        scores[pos].text = r.score;
    }
    
    public void DisplayAllRecords()
    {
            List<Record> toDisplay = ReadXMLFromDisk();
            toDisplay = SortByScores(toDisplay);
            int i = 0;
            foreach (Record rec in toDisplay)
            {
                DisplayRecord(i, rec);
                i++;
            }
    }
    
    public void appendSubmission(string name, string date, string stroke, int theScore)
    {
        string score = "" + theScore;
        Record newRecord = new Record (name, date, stroke, score);
        List<Record> current = ReadXMLFromDisk();
        current.Add(newRecord);
        current = SortByScores(current);
        XmlWriter xmlWriter = XmlWriter.Create(PREFIX + LEADERBOARD);
        
        xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("records");
            foreach (Record r in current)
            {
                xmlWriter.WriteStartElement("record");
                
                    xmlWriter.WriteStartElement("name");
                    xmlWriter.WriteString(r.name);
                    xmlWriter.WriteEndElement();
                    
                    xmlWriter.WriteStartElement("date");
                    xmlWriter.WriteString(r.date);
                    xmlWriter.WriteEndElement();
                    
                    xmlWriter.WriteStartElement("stroke");
                    xmlWriter.WriteString(r.stroke);
                    xmlWriter.WriteEndElement();
                    
                    xmlWriter.WriteStartElement("score");
                    xmlWriter.WriteString(r.score);
                    xmlWriter.WriteEndElement();
                    
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
        xmlWriter.WriteEndDocument();
        xmlWriter.Close();
        DisplayAllRecords();
    }
    
    public List<Record> ReadXMLFromDisk()
    {
        try
        {
            XDocument xml = XDocument.Load(PREFIX + LEADERBOARD);
            return (from Record in xml.Root.Elements("record")
                        select new Record()
                        {
                            name = (string) Record.Element("name"),
                            date = (string) Record.Element("date"),
                            stroke = (string) Record.Element("stroke"),
                            score = (string) Record.Element("score"),
                        }).ToList();
        }
        catch
        {
            UnityEngine.Debug.Log("leaderboard parse error!");
            throw new Exception(string.Format("leaderboard parse error ({0})", LEADERBOARD));
        }

    }
    
    public List<Record> SortByScores(List<Record> toProcess)
    {
        List<Record> ret = new List<Record>(5); //Only get the 5 best scores.
        int localMax;
        Record tempRec;
        for (int i = 0; i < 5; i++)
        {
            tempRec = new Record();
            localMax = 0;
            foreach (Record rec in toProcess)
            {
                    int tScore = int.Parse(rec.score);
                    if (tScore > localMax)
                    {
                        tempRec = rec;
                        localMax = tScore;
                    }
            }
                ret.Add(tempRec);
                toProcess.Remove(tempRec);
        }
        return ret;
    }
}

public class Record
{
    public Record (string name, string date, string stroke, string score) {this.name = name; this.date = date; this.stroke = stroke; this.score = score;}
    public Record() {}
    public string name { get; set; }
    public string date { get; set; }
    public string stroke { get; set; }
    public string score { get; set; }
}
