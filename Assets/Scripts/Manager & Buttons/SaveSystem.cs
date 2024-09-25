using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private string filePath;

    private void Start()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Debug.Log("JSON Leido: " + json);
            playerData data = JsonUtility.FromJson<playerData>(json);
        }
        // Definir la ruta donde se guardará el archivo.En la carpeta persistente tenemos permiso de escritura.
        filePath = Application.persistentDataPath + "/playerData.json";

        //GuardarDatos( new Vector3(0,0,0), new Vector3(0, 0, 0), false, 0) ;
        //CargarDatos();

    }

    // Función para guardar en formato JSON
    public void GuardarDatos(Vector3 playerPosition, bool extraLife, int nivel)
    {
        print("METODO EN SAVESYSTEM = PlayerPos: " + playerPosition + "Life: " + extraLife + "nivel: " + nivel);
        playerData data = new playerData(playerPosition, extraLife, nivel);

        // Convertimos los datos a formato JSON
        string json = JsonUtility.ToJson(data, true);

        // IMPORTANTE Escribimos el archivo en el sistema, utiliza el sistema.IO
        File.WriteAllText(filePath, json);
        Debug.Log("Datos guardados en " + filePath);
    }

    // Función para cargar los datos del jugador desde un archivo JSON
    public playerData CargarDatos()
    {
        if (File.Exists(filePath)) 
        {
            // IMPORTANTE Leemos el archivo
            string json = File.ReadAllText(filePath);

            // Convertimos el JSON a la clase playerData
            playerData data = JsonUtility.FromJson<playerData>(json);

            Debug.Log("Datos cargados correctamente: PosicionPlayer: " + data.playerPosition 
                + ", ExtraVida: " + data.extraLife + ", Nivel: " + data.nivel);
            return data;
        }
        else
        {
            Debug.LogWarning("No se encontró un archivo de guardado.");
            return null;
        }
    }

}
