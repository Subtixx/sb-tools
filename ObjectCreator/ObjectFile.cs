using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObjectCreator
{
    public class Orientation
    {
        [JsonProperty("image", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string image { get; set; }

        [JsonProperty("spaceScan", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double spaceScan { get; set; }

        [JsonProperty("anchors", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> anchors { get; set; }

        [JsonProperty("direction", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string direction { get; set; }
    }

    public class StarboundObject
    {
        [JsonProperty("objectName")]
        public string objectName { get; set; }

        [JsonProperty("rarity", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string rarity { get; set; }

        [JsonProperty("colonyTags", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> colonyTags { get; set; }

        [JsonProperty("description", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }

        [JsonProperty("shortdescription", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string shortdescription { get; set; }

        [JsonProperty("race", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string race { get; set; }

        [JsonProperty("price", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int price { get; set; }

        [JsonProperty("printable", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool printable { get; set; }

        [JsonProperty("inventoryIcon", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string inventoryIcon { get; set; }

        [JsonProperty("orientations", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Orientation> orientations { get; set; }

        [JsonProperty("scripts", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> scripts { get; set; }

        [JsonProperty("scriptDelta", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int scriptDelta { get; set; }

        [JsonProperty("openSounds", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> openSounds { get; set; }

        [JsonProperty("closeSounds", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> closeSounds { get; set; }

        [JsonProperty("slotCount", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? slotCount { get; set; }

        [JsonProperty("uiConfig", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string uiConfig { get; set; }

        [JsonProperty("frameCooldown", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? frameCooldown { get; set; }

        [JsonProperty("autoCloseCooldown", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? autoCloseCooldown { get; set; }

        [JsonProperty("inputNodes", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<List<int>> inputNodes { get; set; }

        [JsonProperty("outputNodes", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<List<int>> outputNodes { get; set; }

        [JsonProperty("interactive", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool interactive { get; set; }
        
        public StarboundObject(string name)
        {
            objectName = name;
            rarity = "Common";
            colonyTags = new List<string>();
            description = name;
            shortdescription = name;
            race = "generic";
            price = 500;
            printable = false;
            inventoryIcon = name.ToLower() + "icon.png";

            orientations = new List<Orientation>();
            Orientation defaultOrientation = new Orientation
            {
                image = name.ToLower() + ".png",
                spaceScan = 0.1,
                anchors = new List<string> { "background" },
                direction = "right"
            };
            orientations.Add(defaultOrientation);
            scripts = new List<string> { name.ToLower() + ".lua" };
            scriptDelta = 10;
            
            slotCount = null;
            uiConfig = null;
            frameCooldown = null;
            autoCloseCooldown = null;

            inputNodes = new List<List<int>>();
            outputNodes = new List<List<int>>();
            interactive = false;
        }
    }
    /*
{
  "objectName" : "hopper",
  "rarity" : "Common",
  "colonyTags" : ["wire"],  
  "description" : "Hopper",
  "shortdescription" : "Hopper",
  "race" : "generic",
  "price" : 500,
  "printable" : false,

  "inventoryIcon" : "hoppericon.png",
  "orientations" : [
    {
      "image" : "hopper.png",

      "spaceScan" : 0.1,
      "anchors" : [ "background" ],
      "direction" : "right"
    }
  ],
  "scripts" : [ "hopper.lua" ],
  "scriptDelta" : 60, // 1 sec

  "openSounds" : [ "/sfx/objects/mannequin_open.ogg" ],
  "closeSounds" : [ "/sfx/objects/mannequin_close.ogg" ],
  "slotCount" : 1,
  "uiConfig" : "/interface/scripted/hopper/hoppergui.config",
  "frameCooldown" : 5,
  "autoCloseCooldown" : 3600,

  "inputNodes" : [ [0, 0] ],
  "interactive" : true
}
    */
}
