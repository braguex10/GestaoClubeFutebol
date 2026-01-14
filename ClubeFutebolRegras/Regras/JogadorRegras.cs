/*
*	<copyright file="JogadorRegras.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using ClubeFutebol.BOO.Pessoas;
using ClubeFutebol.Dados.Interfaces;
using System.IO;


namespace ClubeFutebol.Regras
{
    /// <summary>
    /// Camada de Dados responsável pela verificação dos jogadores
    /// </summary>
    public class RegrasJogador
    {
        #region Atributos

        private readonly InterfaceJogadorDados jogadorDados;

        #endregion

        #region Construtor

        public RegrasJogador(InterfaceJogadorDados jogadorDados)
        {
            this.jogadorDados = jogadorDados;
        }

        #endregion

        #region Criar Jogador
        /// <summary>
        /// Valida a crição de um jogador
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
            if (numero <= 0)
                return null;

            if (numero < 1 || numero > 99)
                return null;


            if (string.IsNullOrWhiteSpace(posicao))
                return null;

            if (string.IsNullOrWhiteSpace(nome))
                return null;

            if (idade <= 5)
                return null;

            if (numeroSocio <= 0)
                return null;

            if (contacto <= 0)
                return null;


            return jogadorDados.CriarJogador(
                numero,
                posicao,
                nome,
                idade,
                nacionalidade,
                genero,
                numeroSocio,
                contacto
            );
        }

        #endregion

        #region Atualizar Jogador
        /// <summary>
        /// Valida a atualização de um jogador
        /// </summary>
        public bool AtualizarJogador(
            Jogador jogador,
            byte numero,
            string posicao)
        {
            if (jogador == null)
                return false;

            if (numero <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(posicao))
                return false;

            if (numero < 1 || numero > 99)
                return false;


            return jogadorDados.AtualizarJogador(jogador, numero, posicao);
        }

        #endregion
        /// <summary>
        /// Verifica os dados de jogador a serem guardados em ficheiro 
        /// </summary>
        public bool GuardarDados(string ficheiro)
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            return jogadorDados.GuardarJogadores(ficheiro);
        }
        /// <summary>
        /// Verifica a leitura do ficheiro acerca do jogador
        /// </summary>
        public bool LerDados(string ficheiro)
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            if (!File.Exists(ficheiro))
                return false;

            return jogadorDados.LerJogadores(ficheiro);
        }
    }
}