using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using SimpleJSON;


public class ExampleJSON : MonoBehaviour {

    #region Variables
    //Variables UI para interaccion con el usuario
    public InputField m_name;
    public InputField m_pass;
    public Text m_message;
    #endregion

    //Estructura de datos 
    class Datos
    {
        public string m_name;
        public string m_pass;

        public Datos(string name, string pass)
        {
            m_name = name;
            m_pass = pass;
        }
    }

    //Funcion que hace la validacion
    public void Login()
    {
        //Variable que almacena los datos del txt (JSON)
        string json = Resources.Load<TextAsset>("users").ToString();
        //Variable que me permite verifiar si el usuario existe
        bool isUser = false;
        //Debug.Log(json);
        //Convertimos el texto del JSON en un nodo JSON porque asi estan nuestro datos
        //y los tomamos el objeto users y los pasamos como array
        JSONNode jsonData = JSON.Parse(json)["users"].AsArray;

        //Debug.Log(jsonData.Count);
        for(int i = 0; i < jsonData.Count; i++)
        {
            //Debug.Log(jsonData[i]);
            //Comparamos si el usuario existe recorriendo todos los usuarios
            if (jsonData[i]["name"] == m_name.text)
            {
                if (jsonData[i]["pass"] == m_pass.text)
                {
                    m_message.text = "Ingreso Exitoso";
                    Debug.Log("Ingreso Exitoso");                   
                }
                else
                {
                    m_message.text = "Password Incorrecto";
                    Debug.Log("Password Incorrecto");
                }
                isUser = true;
                break;
            }
        }

        if(!isUser)
        {
            m_message.text = "Usuario no existe";
            Debug.Log("Usuario no existe");
        }
        
       
    }
	
	
}
