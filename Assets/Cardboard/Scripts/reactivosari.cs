﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class reactivosari : MonoBehaviour {

    private int estadio = variables.npa;
    private float inicio;
    private int preguntaactual = variables.npa;
    private string url = "https://logical-children.herokuapp.com/users/authentication.txt?";

    void Awake () {
       
        inicio= Time.time;
    }
	
	void Update () {
        
        if (estadio==2)
        {
            GameObject.Find("p").GetComponent<TextMesh>().text = variables.p2;
            GameObject.Find("r1").GetComponent<TextMesh>().text = variables.r12;
            GameObject.Find("r2").GetComponent<TextMesh>().text = variables.r22;
            GameObject.Find("r3").GetComponent<TextMesh>().text = variables.r32;
        }
        if (estadio == 3)
        {
            GameObject.Find("p").GetComponent<TextMesh>().text = variables.p3;
            GameObject.Find("r1").GetComponent<TextMesh>().text = variables.r13;
            GameObject.Find("r2").GetComponent<TextMesh>().text = variables.r23;
            GameObject.Find("r3").GetComponent<TextMesh>().text = variables.r33;
        }
        if (estadio == 1)
        {
            GameObject.Find("p").GetComponent<TextMesh>().text = variables.p1;
            GameObject.Find("r1").GetComponent<TextMesh>().text = variables.r11;
            GameObject.Find("r2").GetComponent<TextMesh>().text = variables.r21;
            GameObject.Find("r3").GetComponent<TextMesh>().text = variables.r31;
        }
        if (variables.modo == 1)
        {
            //GameObject.Find("letrero").GetComponent<TextMesh>().text = "timepo" + (Time.time - inicio);
            if ((Time.time-inicio) >= variables.timepo1)
            {
                GameObject.Find("p").GetComponent<TextMesh>().text = "";
                
                GameObject.Find("letrero").GetComponent<TextMesh>().text = "intentalo de nuevo\nla respuesta es:\n" + variables.respuesta;
                if ((Time.time - inicio) >= (variables.timepo1+1.5))
                {
                    url = "https://logical-children.herokuapp.com/students/history?";
                    variables.intentos_fallidos = variables.intentos_fallidos + 1;
                    url = url + "student_id=" + variables.id + "&nivel=" + (variables.modo - 1) + "&intentos_fallidos=" + variables.intentos_fallidos + "&modulo_evaluado=" + 0 + "&num_pregunta=" + preguntaactual + "0";
                    Debug.Log(url);
                    WWW www = new WWW(url);
                   StartCoroutine("GetdataEnumerator", www);
                    SceneManager.LoadScene("ari1");
                }
            }
        }
        if (variables.modo == 2)
        {
            //GameObject.Find("letrero").GetComponent<TextMesh>().text = "timepo" + (Time.time - inicio);
            if ((Time.time - inicio) >= variables.timepo2)
            {
                GameObject.Find("p").GetComponent<TextMesh>().text = "";
                
                GameObject.Find("letrero").GetComponent<TextMesh>().text = "intentalo de nuevo\nla respuesta es:\n" + variables.respuesta;
                if ((Time.time - inicio) >= (variables.timepo1 + 1.5))
                {
                    url = "https://logical-children.herokuapp.com/students/history?";
                    variables.intentos_fallidos = variables.intentos_fallidos + 1;
                    url = url + "student_id=" + variables.id + "&nivel=" + (variables.modo - 1) + "&intentos_fallidos=" + variables.intentos_fallidos + "&modulo_evaluado=" + 0 + "&num_pregunta=" + preguntaactual + "0";
                    Debug.Log(url);
                    WWW www = new WWW(url);
                    StartCoroutine("GetdataEnumerator", www);
                    SceneManager.LoadScene("ari1");
                }
            }
        }
        if (variables.modo == 3)
        {
            //GameObject.Find("letrero").GetComponent<TextMesh>().text = "timepo" + (Time.time - inicio);
            if ((Time.time - inicio) >= variables.timepo3)
            {
                GameObject.Find("p").GetComponent<TextMesh>().text = "";
                GameObject.Find("letrero").GetComponent<TextMesh>().text = "intentalo de nuevo\nla respuesta es:\n"+variables.respuesta;
                if ((Time.time - inicio) >= (variables.timepo1 + 1.5))
                {
                    url = "https://logical-children.herokuapp.com/students/history?";
                    variables.intentos_fallidos = variables.intentos_fallidos + 1;
                    url = url + "student_id=" + variables.id + "&nivel=" + (variables.modo - 1) + "&intentos_fallidos=" + variables.intentos_fallidos + "&modulo_evaluado=" + 0 + "&num_pregunta=" + preguntaactual + "0";
                    Debug.Log(url);
                    WWW www = new WWW(url);
                    StartCoroutine("GetdataEnumerator", www);
                    SceneManager.LoadScene("ari1");
                }
            }
        }

    }

    IEnumerator GetdataEnumerator(WWW www)
    {
        //Wait for request to complete

        yield return www;

        if (www.error == null)
        {

            string serviceData = www.text;

            if (serviceData == "OK")
            {
                Debug.Log("Datos ENVIADOS CON EXITO");
            }
            else
            {
                Debug.Log("Datos erroneos");
            }
        }
        else
        {
            Debug.Log(www.error);
        }
    }
}
