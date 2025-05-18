using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;  // Para ejecutar procesos externos
using System;

public class ReferenceInfo : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] Banck_acount banck;
    private GuardarNombre nombre;
    [SerializeField] Player_lives lives;

    InfoPlayer player = new InfoPlayer();
    public static ReferenceInfo Instance;

    public void saveData()
    {
        // Recolectar datos
        nombre = GetComponent<GuardarNombre>();
        player.time = this.timer.time;
        player.score = this.banck.banck;
        player.lives = this.lives.banck;
        player.name = PlayerPrefs.GetString("nombre", "SinNombre");

        // Guardar datos (tu método existente)
        SaveGame.saveDataGame(player);

        // Ejecutar el .jar para actualizar la base de datos
        EjecutarJarJava();
    }

    private void EjecutarJarJava()
    {
        // Obtiene la ruta de la carpeta del build
        string buildFolder = Application.dataPath; // Esta apunta a la carpeta *_Data dentro del build
        string parentFolder = System.IO.Directory.GetParent(buildFolder).FullName; // Carpeta donde está el ejecutable (projecto)

        string jarRelativePath = @"cosas del mongo db\Castelvania_ant\dist\Castelvania_ant.jar";
        string jarFullPath = System.IO.Path.Combine(parentFolder, jarRelativePath);

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "java";
        startInfo.Arguments = $@"-jar ""{jarFullPath}""";
        startInfo.CreateNoWindow = true;
        startInfo.UseShellExecute = false;

        try
        {
            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();
            UnityEngine.Debug.Log("Ejecutando actualización Java...");
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError("Error ejecutando Java: " + e.Message);
        }
    }


    private void Update()
    {
        UnityEngine.Debug.Log(PlayerPrefs.GetString("nombre", "SinNombre"));
    }
}
