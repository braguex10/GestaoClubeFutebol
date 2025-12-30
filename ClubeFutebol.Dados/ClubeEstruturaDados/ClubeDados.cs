/*
*	<copyright file="ClubeDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using ClubeFutebol.BOO.ClubeEstrutura;
using ClubeFutebol.Dados.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClubeFutebol.Dados.ClubeEstrutura
{
    public class ClubeDados : InterfaceClubeDados
    {
        #region Atributos

        private readonly List<Clube> clubes;
        private readonly Dictionary<Clube, List<Equipa>> equipasPorClube;

        #endregion

        #region Construtor

        public ClubeDados()
        {
            clubes = new List<Clube>();
            equipasPorClube = new Dictionary<Clube, List<Equipa>>();
        }

        #endregion

        #region Clubes

        public bool CriarClube(Clube clube)
        {
            clubes.Add(clube);
            equipasPorClube[clube] = new List<Equipa>();
            return true;
        }

        public bool RemoverClube(Clube clube)
        {
            equipasPorClube.Remove(clube);
            return clubes.Remove(clube);
        }

        public IReadOnlyList<Clube> ListarClubes()
        {
            return clubes.AsReadOnly();
        }

        #endregion

        #region Equipas do Clube

        public bool AdicionarEquipa(Clube clube, Equipa equipa)
        {
            equipasPorClube[clube].Add(equipa);
            return true;
        }

        public bool RemoverEquipa(Clube clube, Equipa equipa)
        {
            return equipasPorClube[clube].Remove(equipa);
        }

        public IReadOnlyList<Equipa> ObterEquipas(Clube clube)
        {
            return equipasPorClube[clube].AsReadOnly();
        }

        #endregion
        public bool ExisteClube(Clube clube)
        {
            return clubes.Contains(clube);
        }

        public int NumeroEquipas(Clube clube)
        {
            return equipasPorClube[clube].Count;
        }

        public Clube ObterClubePorNome(string nome)
        {
            foreach (Clube c in clubes)
            {
                if (c.Nome == nome)
                    return c;
            }
            return null;
        }

        public bool GuardarClubes(string ficheiro)
        {
            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, clubes);
                    bf.Serialize(fs, equipasPorClube);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool LerClubes(string ficheiro)
        {
            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    clubes.Clear();
                    equipasPorClube.Clear();

                    clubes.AddRange((List<Clube>)bf.Deserialize(fs));

                    var dados = (Dictionary<Clube, List<Equipa>>)bf.Deserialize(fs);
                    foreach (var d in dados)
                        equipasPorClube.Add(d.Key, d.Value);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}