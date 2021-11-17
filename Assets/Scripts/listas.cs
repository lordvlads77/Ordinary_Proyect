using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class listas : MonoBehaviour
{
    public AudioSource Num1;
    public AudioSource num2;
    public GameObject ball;
    public GameObject ball1;
    public List<int> RandomList = new List<int>(); // crear lista con numeros random
    public List<int> RandomListC = new List<int>(); // dependiendo de la eleccion del jugador
    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(Mov());
       /* Num1 = GetComponent<AudioSource>();
        num2 = GetComponent<AudioSource>();*/
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // crear un "rayo" dependiendo de la posicion del mouse
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                print(hit.transform.name);
                RandomListC.Add(int.Parse(hit.transform.name));
            }

            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //crea una variable booleana, compara posicion vs la posicion de la otra lis
            bool isEqual = Enumerable.SequenceEqual(RandomList.OrderBy(e => e), RandomListC.OrderBy(e => e));

            if (isEqual)
            {
                print("lista igual");
            }
            else
            {
                print("listam difer");
            }
            RandomList.Clear();
            RandomListC.Clear();
        }

        if (ball.CompareTag(tag.ToString()))
        {

        }
    }


    IEnumerator Mov()
    {
        // Llena la lista random
        for (int i = 0; i < 5; i++)
        {
            RandomList.Add(Random.Range(1, 5));
        }

        //listaRandom = {2 ,3 2, 4, 1}
        yield return null;
        foreach( int tag in RandomList) // por cada elemento llamado en la lista "listaRandom"
        {
            
            GameObject objectotag = GameObject.FindGameObjectWithTag(tag.ToString()); // busca el objeto con el tag de cada uno de los elementos de la lista
            objectotag.transform.position += new Vector3(0, 1, 0);
            yield return new WaitForSeconds(1);
            objectotag.transform.position -= new Vector3(0, 1, 0);
        }
    }

    public void rutine()
    {
        

    }
}
