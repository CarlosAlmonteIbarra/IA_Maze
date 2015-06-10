using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Engine.Characters
{
    public class CharacterFactory
    {
        private Character _character;

        public Character CreateCharacter(string name)
        {
            switch (name)
            {
                case "carlita":
                    _character.Name = "Carlita";
                    _character.Face_AssetName = "carlitaFace";
                    _character.Body_AssetName = "carlitaSelect";
                    _character.CallName = null;
                    break;
                case "carlos":
                    _character.Name = "Carlos";
                    _character.Face_AssetName = "carlosFace";
                    _character.Body_AssetName = "carlosSelect";
                    _character.CallName = null;
                    break;
                case "chavakane":
                    _character.Name = "Chavakane";
                    _character.Face_AssetName = "chavakaneFace";
                    _character.Body_AssetName = "chavakaneSelect";
                    _character.CallName = null;
                    break;
                case "diaz":
                    _character.Name = "Diaz";
                    _character.Face_AssetName = "diazFace";
                    _character.Body_AssetName = "diazSelect";
                    _character.CallName = null;
                    break;
                case "erika":
                    _character.Name = "Erika";
                    _character.Face_AssetName = "erikaFace";
                    _character.Body_AssetName = "erikaSelect";
                    _character.CallName = null;
                    break;
                case "felipe":
                    _character.Name = "Felipe";
                    _character.Face_AssetName = "felipeFace";
                    _character.Body_AssetName = "felipeSelect";
                    _character.CallName = null;
                    break;
                case "ficachi":
                    _character.Name = "Ficachi";
                    _character.Face_AssetName = "ficachiFace";
                    _character.Body_AssetName = "ficachiSelect";
                    _character.CallName = null;
                    break;
                case "george":
                    _character.Name = "George";
                    _character.Face_AssetName = "georgeFace";
                    _character.Body_AssetName = "georgeSelect";
                    _character.CallName = null;
                    break;
                case "ivansini":
                    _character.Name = "Ivansini";
                    _character.Face_AssetName = "ivansiniFace";
                    _character.Body_AssetName = "ivansiniSelect";
                    _character.CallName = null;
                    break;
                case "jose":
                    _character.Name = "Jose";
                    _character.Face_AssetName = "joseFace";
                    _character.Body_AssetName = "joseSelect";
                    _character.CallName = null;
                    break;
                case "luz":
                    _character.Name = "Luz";
                    _character.Face_AssetName = "luzFace";
                    _character.Body_AssetName = "luzSelect";
                    _character.CallName = null;
                    break;
                case "manny":
                    _character.Name = "Manny";
                    _character.Face_AssetName = "mannyFace";
                    _character.Body_AssetName = "mannySelect";
                    _character.CallName = null;
                    break;
                case "martin":
                    _character.Name = "Martin";
                    _character.Face_AssetName = "martinFace";
                    _character.Body_AssetName = "martinSelect";
                    _character.CallName = null;
                    break;
                case "omar":
                    _character.Name = "Carlita";
                    _character.Face_AssetName = "carlitaFace";
                    _character.Body_AssetName = "carlitaSelect";
                    _character.CallName = null;
                    break;
                case "oscar":
                    _character.Name = "Omar";
                    _character.Face_AssetName = "omarFace";
                    _character.Body_AssetName = "omarSelect";
                    _character.CallName = null;
                    break;
                case "sarita":
                    _character.Name = "Sarita";
                    _character.Face_AssetName = "saritaFace";
                    _character.Body_AssetName = "saritaSelect";
                    _character.CallName = null;
                    break;
                case "shelby":
                    _character.Name = "Shelby";
                    _character.Face_AssetName = "shelbyFace";
                    _character.Body_AssetName = "shelbySelect";
                    _character.CallName = null;
                    break;
                case "stephania":
                    _character.Name = "Stephania";
                    _character.Face_AssetName = "stephaniaFace";
                    _character.Body_AssetName = "stephaniaSelect";
                    _character.CallName = null;
                    break;
                case "turi":
                    _character.Name = "Turi";
                    _character.Face_AssetName = "turiFace";
                    _character.Body_AssetName = "turiSelect";
                    _character.CallName = null;
                    break;
                default:
                    _character.Name = null;
                    _character.Face_AssetName = null;
                    _character.Body_AssetName = null;
                    _character.CallName = null;
                    break;
            }
            return _character;
        }
    }
}
