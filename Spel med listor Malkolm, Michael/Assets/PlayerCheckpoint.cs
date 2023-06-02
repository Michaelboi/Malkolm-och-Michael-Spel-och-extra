using bil;
using System.IO;
using System;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    
    public GameObject mållinje;
    public GameObject[] Checkpoints = new GameObject[8];
    public GameObject Bilreset;
    public float avrundadtid;
    public int collectedpoints = 0;
    public float timer = 0f;

    public string filepath = "savetime.xlsx";


    public void SaveTime()
    {
        System.IO.File.WriteAllText(filepath, avrundadtid.ToString());



        /*using (var pack = new ExcelPackage())
        {
            var worksheet = pack.Workbook.Worksheets.Add("Sheet1");
            worksheet.Cells["A1"].Value = avrundadtid;

            pack.SaveAs(new FileInfo(filepath));
        }*/

    }
    // Om den når max antalet så aktiveras mållinje, den blir true.
    void Update()
    {
        timer += Time.deltaTime;
        if (collectedpoints == 8)
        {
            mållinje.SetActive(true);
        }
        Checkpoints_Spawn();


    }
    // Om man klickar på R så kan man respawna vid den senaste checkpointen man tog.
    // Vi har också fixat så att Om man inte har tagit checkpoints och den blir mindre än 0 så hamnar man fortfarande där man börja.
    public void Checkpoints_Spawn()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Bilreset.transform.position = Checkpoints[collectedpoints - 1].transform.position;
            Bilreset.transform.rotation = Checkpoints[collectedpoints - 1].transform.rotation;

        }
        if (collectedpoints < 0)
        {
            collectedpoints = 0;
        }
        
    }
    // Den här funktion gäller för alla som har Ontrigger knappen på.
    // När man kolliderar med mållinjen så sparas en tid, antalet checkpoints man har tagit resetas.
    // Alla checkpoints sätts true medans mållinje blir false.
    // När man kolliderar med checkpoints blir de false så ökas antalet collectedcheckpoints som har ett max antal.
    
    public void OnTriggerEnter(Collider Kollision)
    {
        if (Kollision.gameObject.CompareTag("mål"))
        {
            mållinje.SetActive(false);
            avrundadtid = (float)Math.Round(timer, 2);
            Debug.Log(avrundadtid + "sekunder");
            SaveTime();
            timer = 0f;
            collectedpoints = 0;
            for (int i = 0; i < Checkpoints.Length; i++)
            {
                Checkpoints[i].SetActive(true);
            }
        }

        if (Kollision.gameObject.CompareTag("Checkpoint"))
        {
            this.collectedpoints += 1;
            Debug.Log("Checkpoint! " + collectedpoints + "/8");
            Kollision.gameObject.SetActive(false);
            
            
        }
    }
}
