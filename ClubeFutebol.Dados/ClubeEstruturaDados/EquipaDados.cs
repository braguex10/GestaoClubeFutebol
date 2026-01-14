/*
*	<copyright file="EquipaDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System.Collections.Generic;
using ClubeFutebol.BOO.ClubeEstrutura;
using ClubeFutebol.BOO.Pessoas;
using ClubeFutebol.Dados.Interfaces;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClubeFutebol.Dados.ClubeEstrutura
{
    /// <summary>
    /// Camada de Dados responsável pela gestão de uma Equipa
    /// </summary>
    public class EquipaDados : InterfaceEquipaDados
    {
        #region Atributos

        private readonly Dictionary<Equipa, List<Jogador>> jogadoresPorEquipa;  //permite saber a que equipa pertecem os jogadores ( ligacao 1 para muitos)

        #endregion

        #region Construtor

        public EquipaDados()
        {
            jogadoresPorEquipa = new Dictionary<Equipa, List<Jogador>>();
        }

        #endregion

        #region Jogadores da Equipa
        /// <summary>
        /// Criação de uma equipa
        /// </summary>
        public bool CriarEquipa(Equipa equipa)
        {
            jogadoresPorEquipa[equipa] = new List<Jogador>();
            return true;
        }
        /// <summary>
        /// Remoção de uma equipa
        /// </summary>
        public bool RemoverEquipa(Equipa equipa)
        {
            return jogadoresPorEquipa.Remove(equipa);
        }
        /// <summary>
        /// Inserção de um jogador na equipa
        /// </summary>
        public bool AdicionarJogador(Equipa equipa, Jogador jogador)
        {
            jogadoresPorEquipa[equipa].Add(jogador);
            return true;
        }
        /// <summary>
        /// Remoção de um jogador da equipa
        /// </summary>
        public bool RemoverJogador(Equipa equipa, Jogador jogador)
        {
            return jogadoresPorEquipa[equipa].Remove(jogador);
        }
        /// <summary>
        /// Devolve o dicionario de jogadores por equipa
        /// </summary>
        public IReadOnlyList<Jogador> ObterJogadores(Equipa equipa)
        {
            return jogadoresPorEquipa[equipa].AsReadOnly();
        }
        /// <summary>
        /// Conta o número de jogadores de uma equipa
        /// </summary>
        public int ObterNumeroJogadores(Equipa equipa)
        {
            return jogadoresPorEquipa[equipa].Count;
        }

        #endregion

        #region Treinador
        /// <summary>
        /// Inserção de um treinador na equipa
        /// </summary>
        public bool AtribuirTreinador(Equipa equipa, Treinador treinador)
        {
            equipa.TreinadorPrincipal = treinador;
            return true;
        }
        /// <summary>
        /// Remoção de um treinador da equipa
        /// </summary>
        public bool RemoverTreinador(Equipa equipa)
        {
            equipa.TreinadorPrincipal = null;
            return true;
        }

        #endregion
        /// <summary>
        /// Devolve os jogadores de uma certa posição
        /// </summary>
        public IReadOnlyList<Jogador> ObterJogadoresPorPosicao(Equipa equipa, string posicao)
        {
            List<Jogador> resultado = new List<Jogador>();

            foreach (Jogador j in jogadoresPorEquipa[equipa])
            {
                if (j.Posicao == posicao)
                    resultado.Add(j);
            }

            return resultado.AsReadOnly();
        }
        /// <summary>
        /// Guarda em ficheiro as equipas
        /// </summary>
        public bool GuardarEquipas(string ficheiro)
        {
            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, jogadoresPorEquipa);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Abre para leitura as equipas
        /// </summary>
        public bool LerEquipas(string ficheiro)
        {
            if (!File.Exists(ficheiro))
                return false;

            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    jogadoresPorEquipa.Clear();

                    var dados = (Dictionary<Equipa, List<Jogador>>)bf.Deserialize(fs);
                    foreach (var d in dados)
                        jogadoresPorEquipa.Add(d.Key, d.Value);
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