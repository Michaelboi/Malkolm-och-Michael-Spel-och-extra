using bil;
using System.IO;
using System;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    
    public GameObject m�llinje;
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
    // Om den n�r max antalet s� aktiveras m�llinje, den blir true.
    void Update()
    {
        timer += Time.deltaTime;
        if (collectedpoints == 8)
        {
            m�llinje.SetActive(true);
        }
        Checkpoints_Spawn();


    }
    // Om man klickar p� R s� kan man respawna vid den senaste checkpointen man tog.
    // Vi har ocks� fixat s� att Om man inte har tagit checkpoints och den blir mindre �n 0 s� hamnar man fortfarande d�r man b�rja.
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
    // Den h�r funktion g�ller f�r alla som har Ontrigger knappen p�.
    // N�r man kolliderar med m�llinjen s� sparas en tid, antalet checkpoints man har tagit resetas.
    // Alla checkpoints s�tts true medans m�llinje blir false.
    // N�r man kolliderar med checkpoints blir de false s� �kas antalet collectedcheckpoints som har ett max antal.
    
    public void OnTriggerEnter(Collider Kollision)
    {
        if (Kollision.gameObject.CompareTag("m�l"))
        {
            m�llinje.SetActive(false);
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
