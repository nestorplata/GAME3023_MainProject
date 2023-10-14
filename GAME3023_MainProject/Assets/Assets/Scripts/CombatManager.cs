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
    void Awake()
    {
        AListOfPokemons = new List<Pokemon>();
        EListOfPokemons = new List<Pokemon>();
        availableFiles = new List<string>();
        AListOfPokemons = SetPokemonList("Assets\\Save0\\player");
        EListOfPokemons = SetPokemonList("Assets\\Save0\\enemy");
    }

    static public List<Pokemon> SetPokemonList(string folder)
    {

        List <Pokemon> pokemonList = new List <Pokemon>();

        if (Directory.Exists(folder))
        {
            string[] SPCFolder = Directory.GetFiles(folder);


            foreach (string file in SPCFolder)
            {
                string[] name = file.Split('\\', '.');

                if (name.Length!=6)
                {
                    Debug.Log(file);
                    pokemonList.Add(LoadPokemons(file, name[3]));
                }
            }
        }

        return pokemonList;

    }


    // Update is called once per frame
    static public Pokemon LoadPokemons(string FilePath, string name)
    {
        Pokemon pokemon = new Pokemon();

        using (StreamReader spc = new StreamReader(FilePath))
        {
            List<string> StateList = new List<string>();

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

            pokemon = new Pokemon(name, abilities, Text, StateList, SValue);
            Debug.Log(name + " loaded");


        }
        return pokemon;


    }
    public Pokemon GetPokemon(bool type)
    {
        if(type)
        {
            return AListOfPokemons[0];
        }
        else
        {
            return EListOfPokemons[0];
        }
    }


    void Update()

    {

    }
}
