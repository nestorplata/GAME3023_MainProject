using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class CombatManager : MonoBehaviour
{


    static List<Pokemon> AListOfPokemons;
    static List<Pokemon> EListOfPokemons;
    static string AnimationPath;


    // Start is called before the first frame update
    void Awake()
    {
        AListOfPokemons = new List<Pokemon>();
        EListOfPokemons = new List<Pokemon>();
        AnimationPath = "Assets\\Assets\\Characters\\Sprites\\Animations\\Pkmn\\";

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
            List<List<Sprite>> sprites = SetPNGLists(AnimationPath + name);
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

            pokemon = new Pokemon(name, abilities, Text, StateList, SValue, sprites);
            Debug.Log("Pokemon "+ name + " loaded");


        }
        return pokemon;


    }

    public static List<List<Sprite>> SetPNGLists(string folder)
    {
        List<List<Sprite>> Animations = new List<List<Sprite>>();
        List<Sprite> ASprites = new List<Sprite>();
        int Anum=0;

        if (Directory.Exists(folder))
        {
            string[] SPCFolder = Directory.GetFiles(folder);

            foreach (string file in SPCFolder)
            {
                string[] name = file.Split('\\',',', '.');

                if (name.Length<11)
                {
                    int TmpNum;
                    int.TryParse(name[name.Length - 3], out TmpNum);
                    if (Anum != TmpNum)
                    {
                        Animations.Add(ASprites);
                        ASprites = new List<Sprite>();
                        Anum = TmpNum;
                    }
                    Debug.Log(name[name.Length - 3]+','+ name[name.Length - 2]);
                    ASprites.Add(LoadNewSprite(file, name[name.Length - 2]));
                }
            }
            Animations.Add(ASprites);

        }
        return Animations;
    }





    public static Sprite LoadNewSprite(string FilePath, string Name, float PixelsPerUnit = 100.0f, SpriteMeshType spriteType = SpriteMeshType.Tight)
    {

        Texture2D SpriteTexture = LoadTexture(FilePath);
        Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit, 0, spriteType);
        NewSprite.name= Name;
        return NewSprite;
    }

    public static Texture2D LoadTexture(string FilePath)
    {

        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        return null;                     // Return null if load failed
    }

    public Pokemon GetPokemon(bool type, int number = 0)
    {
        if (type)
        {
            return AListOfPokemons[number];
        }
        else
        {
            return EListOfPokemons[number];
        }
    }

}




