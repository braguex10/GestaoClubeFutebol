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
            if (clube == null)       // o clube tem de existir
                return false;

            if (string.IsNullOrWhiteSpace(clube.Nome))   // clube tem de ter nome
                return false;

            if (string.IsNullOrWhiteSpace(clube.Email))   // clube tem de ter email
                return false;

            if (clube.NumeroTelefonico <= 0)    // numero de telefone nao pode ser negativo
                return false;

            if (clube.NumeroTelefonico.ToString().Length < 9)     // numero de telefone nao pode ter comprimento inferior a 9 caracteres
                return false;

            if (clube.AnoFundacao < 1863)     // ano de fundacao tem de ser 1863 ou apos pois e o ano que foi fundado o futebol
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

        public bool AtualizarClube(Clube clube, string novoNome, short novoAnoFundacao, string novoEmail, int novoNumeroTelefonico, string novoPais)
        {
            if (clube == null)               // se o clube nao exsitir
                return false;

            if (string.IsNullOrWhiteSpace(novoNome))       // se o nome for nulo
                return false;

            if (string.IsNullOrWhiteSpace(novoEmail))       // se o email for nulo
                return false;

            if (novoNumeroTelefonico <= 0)                  // numero de telefone tem de ser maior que 0
                return false;

            if (novoNumeroTelefonico.ToString().Length < 9)     // o numero de telefone nao pode ter menos que 9 caracteres
                return false;

            if (novoAnoFundacao < 1863)               // ano fundacao nao pode ser inferior a 1863, data fundacao do futebol
                return false;

            if (!clubeDados.ExisteClube(clube))           // se o clube ja existir
                return false;

            if (string.IsNullOrWhiteSpace(novoPais))         // tem de ter novo pais
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