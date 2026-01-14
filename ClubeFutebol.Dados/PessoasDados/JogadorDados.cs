/*
*	<copyright file="JogadorDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using ClubeFutebol.BOO.Pessoas;
using ClubeFutebol.Dados.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Camada de Dados responsável pela gestão de Jogadores
/// </summary>
namespace ClubeFutebol.Dados.Pessoas
{
    public class JogadorDados : InterfaceJogadorDados
    {
        #region Atributos

        private readonly List<Jogador> jogadores;   // Lista para armazenar os jogadores

        #endregion

        #region Construtor

        public JogadorDados()
        {
            jogadores = new List<Jogador>();   // Inicializa a lista de jogadores
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Criação de jogador e adiciona à lista de jogadores
        /// </summary>
        public Jogador CriarJogador(
            byte numero,
            string posicao,
            string nome,
            byte idade,
            string nacionalidade,
            string genero,
            int numeroSocio,
            int contacto)
        {
            // Criação do objeto jogador com os dados passados como parâmetros
            Jogador j = new Jogador(
                numero,
                posicao,
                nome,
                idade,
                nacionalidade,
                genero,
                numeroSocio,
                contacto
            );

            jogadores.Add(j);  // Adiciona o jogador à lista de jogadores
            return j;  // Retorna o jogador criado
        }
        /// <summary>
        /// Atualizar numero e posicao de um jogador
        /// </summary>
        public bool AtualizarJogador(Jogador jogador, byte numero, string posicao)
        {
            jogador.Numero = numero; 
            jogador.Posicao = posicao;  
            return true;  // Retorna true indicando que a atualização foi bem-sucedida
        }

        /// <summary>
        /// Devolve um jogador procurado pelo seu número de sócio
        /// </summary>
        public Jogador ProcurarJogadorPorNumeroSocio(int numeroSocio)
        {
            // Percorre a lista de jogadores para encontrar o jogador com o número de sócio correspondente
            foreach (Jogador j in jogadores)
            {
                if (j.NumeroSocio == numeroSocio)
                    return j;  
            }
            return null; 
        }

        /// <summary>
        /// Devolve a lista de jogadores
        /// </summary>
        public IReadOnlyList<Jogador> ListarJogadores()
        {
            return jogadores.AsReadOnly();  // Retorna uma versão somente leitura da lista de jogadores
        }

        /// <summary>
        /// Guarda em ficheiro a lista de todos os jogadores
        /// </summary>
        public bool GuardarJogadores(string ficheiro)
        {
            try
            {
                // Cria o fluxo de arquivo para salvar os dados
                using (FileStream fs = new FileStream(ficheiro, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();  // Utiliza o BinaryFormatter para serializar os dados
                    bf.Serialize(fs, jogadores);  // Serializa a lista de jogadores e grava no arquivo
                }
                return true;  
            }
            catch
            {
                return false;  
            }
        }

        /// <summary>
        /// Abre e lê os jogadores em ficheiro
        /// </summary>
        public bool LerJogadores(string ficheiro)
        {
            if (!File.Exists(ficheiro))  
                return false;  

            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Open))  // Abre o arquivo para leitura
                {
                    BinaryFormatter bf = new BinaryFormatter();  
                    jogadores.Clear();  // Limpa a lista de jogadores antes de carregar os novos dados
                    jogadores.AddRange((List<Jogador>)bf.Deserialize(fs));  // Desserializa os dados do arquivo e adiciona à lista
                }
                return true;  
            }
            catch
            {
                return false;  
            }
        }

        #endregion
    }
}
