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
        public bool GuardarDados(string ficheiro)
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            return jogadorDados.GuardarJogadores(ficheiro);
        }
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