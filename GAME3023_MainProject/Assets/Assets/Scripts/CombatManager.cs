using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using UnityEngine.WSA;
using Unity.IO.LowLevel.Unsafe;

public class CombatManager : MonoBehaviour
{
    public static string PlayerName;
    public static string EnemyName;

    static List<Pokemon> AListOfPokemons;
    static List<Pokemon> EListOfPokemons;

    static List<string> availableFiles;
    static string path = ".txt";
    
    // Start is called before the first frame update
    void Start()
    {
        AListOfPokemons = new List<Pokemon>();
        EListOfPokemons = new List<Pokemon>();
        availableFiles = new List<string>();
    }

    static public List<Pokemon> SetPokemonList(string folder)
    {

        List <Pokemon> pokemonList = new List <Pokemon>();

        if (Directory.Exists(folder))
        {
            string[] SPCFolder = Directory.GetFiles(folder);

            foreach (string file in SPCFolder)
            {
                availableFiles.Add(file);
                Debug.Log(file);

            }

            foreach (string FilePath in availableFiles)
            {
                pokemonList.Add(LoadPokemons(FilePath));
            }
        }

        return pokemonList;

    }


    // Update is called once per frame
    static public Pokemon LoadPokemons(string FilePath)
    {
        Pokemon pokemon = new Pokemon();

        using (StreamReader spc = new StreamReader(FilePath))
        {
            List<string> StateList = new List<string>();

            string[] name = FilePath.Split('\\', '.');
            string[] abilities = spc.ReadLine().Split(',');
            string[] Text = spc.ReadLine().Split(',');
            string[] States = spc.ReadLine().Split(',');
            string[] stats = spc.ReadLine().Split(',');
            int[] SValue = new int[stats.Length - 1];

            foreach (string information in States)
            {
                StateList.Add(information);
            }

            for (int i = 0; i < SValue.Length; i++)
            {
                int.TryParse(stats[i + 1], out SValue[i]);
            }

            pokemon = new Pokemon(name[1], abilities, Text, StateList, SValue);
            Debug.Log(name[1]);

        }
        return pokemon;


    }
    //static public List<string> GetListOfPartyNames(string CharacterName)
    //{

    //    string[] SPCFolder = Directory.GetFiles(folder);

    //    foreach (string FilesPath in SPCFolder)
    //    {
    //        string[] name = FilesPath.Split('\\', '.');

    //        if (!ListOfPokemons.Contains(name[1]))
    //        {
    //            ListOfPokemons.Add(name[1]);
    //        }
    //    }
    //    return ListOfPokemons;
    //}

    void Update()

    {

    }
}
