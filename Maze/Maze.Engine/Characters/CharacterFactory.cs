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
            _character = new Character();

            switch (name)
            {
                case "carlita":
                    _character.Name = "Carlita";
                    _character.Face_AssetName = "Characters\\Carlita\\carlitaFace";
                    _character.Body_AssetName = "Characters\\Carlita\\carlitaSelect";
                    _character.CallName = null;
                    break;
                case "carlos":
                    _character.Name = "Carlos";
                    _character.Face_AssetName = "Characters\\Carlos\\carlosFace";
                    _character.Body_AssetName = "Characters\\Carlos\\carlosSelect";
                    _character.CallName = null;
                    break;
                case "chavakane":
                    _character.Name = "Chavakane";
                    _character.Face_AssetName = "Characters\\Chavakane\\chavaFace";
                    _character.Body_AssetName = "Characters\\Chavakane\\chavaSelect";
                    _character.CallName = null;
                    break;
                case "diaz":
                    _character.Name = "Diaz";
                    _character.Face_AssetName = "Characters\\Diaz\\diazFace";
                    _character.Body_AssetName = "Characters\\Diaz\\diazSelect";
                    _character.CallName = null;
                    break;
                case "erika":
                    _character.Name = "Erika";
                    _character.Face_AssetName = "Characters\\Erika\\erikaFace";
                    _character.Body_AssetName = "Characters\\Erika\\erikaSelect";
                    _character.CallName = null;
                    break;
                case "felipe":
                    _character.Name = "Felipe";
                    _character.Face_AssetName = "Characters\\Felipe\\felipeFace";
                    _character.Body_AssetName = "Characters\\Felipe\\felipeSelect";
                    _character.CallName = null;
                    break;
                case "ficachi":
                    _character.Name = "Ficachi";
                    _character.Face_AssetName = "Characters\\Ficachu\\ficachiFace";
                    _character.Body_AssetName = "Characters\\Ficachu\\ficachiSelect";
                    _character.CallName = null;
                    break;
                case "george":
                    _character.Name = "George";
                    _character.Face_AssetName = "Characters\\George\\georgeFace";
                    _character.Body_AssetName = "Characters\\George\\georgeSelect";
                    _character.CallName = null;
                    break;
                case "ivansini":
                    _character.Name = "Ivansini";
                    _character.Face_AssetName = "Characters\\Ivansini\\ivanFace";
                    _character.Body_AssetName = "Characters\\Ivansini\\ivanSelect";
                    _character.CallName = null;
                    break;
                case "jose":
                    _character.Name = "Jose";
                    _character.Face_AssetName = "Characters\\José\\joseFace";
                    _character.Body_AssetName = "Characters\\José\\joseSelect";
                    _character.CallName = null;
                    break;
                case "luz":
                    _character.Name = "Luz";
                    _character.Face_AssetName = "Characters\\Luz\\luzFace";
                    _character.Body_AssetName = "Characters\\Luz\\luzSelect";
                    _character.CallName = null;
                    break;
                case "manny":
                    _character.Name = "Manny";
                    _character.Face_AssetName = "Characters\\Manny\\mannyFace";
                    _character.Body_AssetName = "Characters\\Manny\\mannySelect";
                    _character.CallName = null;
                    break;
                case "martin":
                    _character.Name = "Martin";
                    _character.Face_AssetName = "Characters\\Martin\\martinFace";
                    _character.Body_AssetName = "Characters\\Martin\\martinSelect";
                    _character.CallName = null;
                    break;
                case "omar":
                    _character.Name = "Omar";
                    _character.Face_AssetName = "Characters\\Omar\\omarFace";
                    _character.Body_AssetName = "Characters\\Omar\\omarSelect2";
                    _character.CallName = null;
                    break;
                case "oscar":
                    _character.Name = "Oscar";
                    _character.Face_AssetName = "Characters\\Oscar\\oscarFace";
                    _character.Body_AssetName = "Characters\\Oscar\\oscarSelect";
                    _character.CallName = null;
                    break;
                case "sarita":
                    _character.Name = "Sarita";
                    _character.Face_AssetName = "Characters\\Sarita\\saritaFace";
                    _character.Body_AssetName = "Characters\\Sarita\\saritaSelect";
                    _character.CallName = null;
                    break;
                case "shelby":
                    _character.Name = "Shelby";
                    _character.Face_AssetName = "Characters\\Shelby\\shelbyFace";
                    _character.Body_AssetName = "Characters\\Shelby\\shelbySelect";
                    _character.CallName = null;
                    break;
                case "stephania":
                    _character.Name = "Stephania";
                    _character.Face_AssetName = "Characters\\Stephania\\stephaniaFace";
                    _character.Body_AssetName = "Characters\\Stephania\\stephaniaSelect";
                    _character.CallName = null;
                    break;
                case "turi":
                    _character.Name = "Turi";
                    _character.Face_AssetName = "Characters\\Turi\\turiFace";
                    _character.Body_AssetName = "Characters\\Turi\\turiSelect";
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
