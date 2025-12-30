/*
*	<copyright file="ClubeRegras.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/


using ClubeFutebol.BOO.ClubeEstrutura;
using ClubeFutebol.Dados.Interfaces;
using System.IO;


namespace ClubeFutebol.Regras
{
    public class RegrasClube
    {
        #region Atributos

        private readonly InterfaceClubeDados clubeDados;

        #endregion

        #region Construtor

        public RegrasClube(InterfaceClubeDados clubeDados)
        {
            this.clubeDados = clubeDados;
        }

        #endregion

        #region Criar Clube

        public bool CriarClube(Clube clube)
        {
            if (clube == null)
                return false;

            if (string.IsNullOrWhiteSpace(clube.Nome))
                return false;

            if (string.IsNullOrWhiteSpace(clube.Email))
                return false;

            if (clube.NumeroTelefonico <= 0)
                return false;

            if (clube.NumeroTelefonico.ToString().Length < 9)
                return false;

            if (clube.AnoFundacao < 1863)
                return false;

            // nome do clube tem de ser único
            Clube existente = clubeDados.ObterClubePorNome(clube.Nome);
            if (existente != null)
                return false;

            if (string.IsNullOrWhiteSpace(clube.Pais))
                return false;

            if (clubeDados.ExisteClube(clube))
                return false;


            return clubeDados.CriarClube(clube);
        }

        #endregion

        #region Remover Clube

        public bool RemoverClube(Clube clube)
        {
            if (clube == null)
                return false;

            if (!clubeDados.ExisteClube(clube))
                return false;

            // não pode remover se tiver equipas
            if (clubeDados.NumeroEquipas(clube) > 0)
                return false;

            return clubeDados.RemoverClube(clube);
        }

        #endregion

        #region Atualizar Clube

        public bool AtualizarClube(
            Clube clube,
            string novoNome,
            short novoAnoFundacao,
            string novoEmail,
            int novoNumeroTelefonico,
            string novoPais)
        {
            if (clube == null)
                return false;

            if (string.IsNullOrWhiteSpace(novoNome))
                return false;

            if (string.IsNullOrWhiteSpace(novoEmail))
                return false;

            if (novoNumeroTelefonico <= 0)
                return false;

            if (novoNumeroTelefonico.ToString().Length < 9)
                return false;

            if (novoAnoFundacao < 1863)
                return false;

            if (!clubeDados.ExisteClube(clube))
                return false;

            if (string.IsNullOrWhiteSpace(novoPais))
                return false;

            // se mudar o nome, tem de continuar único
            Clube outro = clubeDados.ObterClubePorNome(novoNome);
            if (outro != null && !outro.Equals(clube))
                return false;

            // atualização direta no BO
            clube.Nome = novoNome;
            clube.AnoFundacao = novoAnoFundacao;
            clube.Email = novoEmail;
            clube.NumeroTelefonico = novoNumeroTelefonico;
            clube.Pais = novoPais;

            return true;
        }

        #endregion

        public bool GuardarDados(string ficheiro)
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            return clubeDados.GuardarClubes(ficheiro);
        }
        public bool LerDados(string ficheiro)
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            if (!File.Exists(ficheiro))
                return false;

            return clubeDados.LerClubes(ficheiro);
        }

    }
}