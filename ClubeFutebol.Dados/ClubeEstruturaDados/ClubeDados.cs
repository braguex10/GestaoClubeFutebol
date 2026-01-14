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
    /// <summary>
    /// Camada de Dados responsável pelo controlo e gestão de um clube
    /// </summary>
    public class ClubeDados : InterfaceClubeDados
    {
        #region Atributos

        private readonly List<Clube> clubes;                                     // lista que guarda todos os clubes, ordem importa
        private readonly Dictionary<Clube, List<Equipa>> equipasPorClube;        // guarda as equipas por clube

        #endregion

        #region Construtor

        public ClubeDados()                         // inicializa a estrutura de dados
        {
            clubes = new List<Clube>();
            equipasPorClube = new Dictionary<Clube, List<Equipa>>();
        }

        #endregion

        #region Clubes
        /// <summary>
        /// Criação de um clube
        /// </summary>
        public bool CriarClube(Clube clube)                         // criar um clube
        {
            clubes.Add(clube);                                      // cria clube
            equipasPorClube[clube] = new List<Equipa>();            // cria uma lista no dicionario para o clube criado
            return true;
        }
        /// <summary>
        /// Remoção de um clube
        /// </summary>
        public bool RemoverClube(Clube clube)                      // eliminar um clube
        {
            equipasPorClube.Remove(clube);                         // elimina as equipas associadas ao clube
            return clubes.Remove(clube);                           // elimina o clube
        }
        /// <summary>
        /// Devolve a lista de clubes
        /// </summary>
        public IReadOnlyList<Clube> ListarClubes()                // lista os clubes presentes na lista de clubes
        {
            return clubes.AsReadOnly();
        }

        #endregion

        #region Equipas do Clube
        /// <summary>
        /// Inserção de uma equipa no clube
        /// </summary>
        public bool AdicionarEquipa(Clube clube, Equipa equipa)             // adicionar equipas ao clube
        {
            equipasPorClube[clube].Add(equipa);                          // adiciona equipa no dicionario do clube, na lista
            return true;
        }
        /// <summary>
        /// Remoção de uma equipa pertencente a um clube
        /// </summary>
        public bool RemoverEquipa(Clube clube, Equipa equipa)           // remove equipa do clube
        {
            return equipasPorClube[clube].Remove(equipa);             // remove do dicionario do clube, da lista
        }
        /// <summary>
        /// Devolve as equipas presentes no dicionário do clube
        /// </summary>
        public IReadOnlyList<Equipa> ObterEquipas(Clube clube)              // listar as equipas presentes no dicionario do clube
        {
            return equipasPorClube[clube].AsReadOnly();
        }

        #endregion
        /// <summary>
        /// Procura a existência de um clube
        /// </summary>
        public bool ExisteClube(Clube clube)                            // verifica se existe o clube
        {
            return clubes.Contains(clube);
        }
        /// <summary>
        /// Conta o numero de equipas que um clube tem
        /// </summary>
        public int NumeroEquipas(Clube clube)               // quantas equipas tem o clube
        {
            return equipasPorClube[clube].Count;
        }
        /// <summary>
        /// Devolve um objeto de clube
        /// </summary>
        public Clube ObterClubePorNome(string nome)            // devolve o objeto do clube
        {
            foreach (Clube c in clubes)
            {
                if (c.Nome == nome)
                    return c;
            }
            return null;
        }
        /// <summary>
        /// guarda o clube e a sua relação com equipas em ficheiro
        /// </summary>
        public bool GuardarClubes(string ficheiro)              // guarda os clubes e a sua relacao com equipas
        {
            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Create))      // abre cria o ficheiro em que ira ser guardado
                {
                    BinaryFormatter bf = new BinaryFormatter();                         // em binario
                    bf.Serialize(fs, clubes);                                           // converte a lista de clubes em bytes
                    bf.Serialize(fs, equipasPorClube);                                  // converte o dicionario de clubes e as suas respetivas equipas em bytes
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Abre o ficheiro e lê os clubes e a sua relação a equipas
        /// </summary>
        public bool LerClubes(string ficheiro)                      // le os clubes e a sua relacao com equipas
        {
            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Open))         // abre o ficheiro existe 
                {
                    BinaryFormatter bf = new BinaryFormatter();                         // em formato binario

                    clubes.Clear();                                                     // limpa a memoria que tem do ficheiro neste momento para evitar mistura de dados
                    equipasPorClube.Clear();                                            // e necessario limpara para nao provocar duplicacoes e lixo

                    clubes.AddRange((List<Clube>)bf.Deserialize(fs));                  // lê a lista de clubes presente no ficheiro

                    var dados = (Dictionary<Clube, List<Equipa>>)bf.Deserialize(fs);   // como o dicionario é readonly é necessario passar primeiro o dicionario para a variavel dados(copia)
                    foreach (var d in dados)                                           // copia os dados e coloca-os no dicionario
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