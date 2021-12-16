using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace FinalQ4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SaveLoad Archive = SaveLoad.Instance;
            SaveLoad Archive2 = SaveLoad.Instance;
            if (Archive == Archive2)
            Archive.Player_name = "dschuh";
            Archive.Level = 4;
            Archive.HP = 99;
            Archive.Inventory = new string[] {
                "spear", "water bottle", "hammer", "sonic screwdriver", "cannonball",
                "wood", "scooby snack", "hydra", "poisonous potato", "dead bush", "repair powder"
            };
            Archive.LicenseKey = "DFGU99 - 1454";
            bool success = Archive.Save();
            if (success) Console.WriteLine("successfully saved");
            else Console.WriteLine("failed to save");
            Archive = Archive.Load();
            if (Archive == null) Console.WriteLine("failed to load");
            else Console.WriteLine("loaded sucessfully");
        }
    }
    public sealed class SaveLoad
    {
        private string player_name;
        private int level;
        private int hp;
        private string[] inventory;
        private string license_key;
        public string Player_name { get { return instance.player_name; } set { instance.player_name = value; } }
        public int Level { get { return instance.level; } set { instance.level = value; } }
        public int HP { get { return instance.hp; } set { instance.level = value; } }
        public string[] Inventory { get { return instance.inventory; } set { instance.inventory = value; } }
        public string LicenseKey { get { return instance.license_key; } set { instance.license_key = value; } }
        private static SaveLoad instance = null;
        private static readonly object padlock = new object();
        SaveLoad()
        {
            player_name = "";
            level = 0;
            hp = 0;
            inventory = new string[0];
            license_key = "";
        }
        public static SaveLoad Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) instance = new SaveLoad();
                    return instance;
                }
            }
            set
            {
                lock (padlock)
                {
                    instance = value;
                }
            }
        }
        public bool Save(string path = @"D:\SaveLoad\savefile.txt")
        {
            try
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamWriter sw = new StreamWriter(path))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    jsonSerializer.Serialize(writer, this);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public SaveLoad Load(string path = @"D:\SaveLoad\savefile.txt")
        {
            try
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamReader sr = new StreamReader(path))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    return jsonSerializer.Deserialize<SaveLoad>(reader);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
