/*
*	<copyright file="EquipaRegras.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using ClubeFutebol.BOO.ClubeEstrutura;
using ClubeFutebol.BOO.Pessoas;
using ClubeFutebol.Dados.Interfaces;
using System.IO;

namespace ClubeFutebol.Regras
{
    public class RegrasEquipa
    {
        #region Atributos

        private readonly InterfaceEquipaDados equipaDados;

        #endregion

        #region Construtor

        public RegrasEquipa(InterfaceEquipaDados equipaDados)
        {
            this.equipaDados = equipaDados;
        }

        #endregion

        #region Criar / Remover Equipa

        public bool CriarEquipa(Equipa equipa)
        {
            if (equipa == null)
                return false;

            if (string.IsNullOrWhiteSpace(equipa.Escalao))
                return false;

            if (string.IsNullOrWhiteSpace(equipa.Liga))
                return false;

            if (string.IsNullOrWhiteSpace(equipa.NomeClube))
                return false;


            return equipaDados.CriarEquipa(equipa);
        }

        public bool RemoverEquipa(Equipa equipa)
        {
            if (equipaDados.ObterNumeroJogadores(equipa) > 0)
                return false;

            if (equipa == null)
                return false;

            return equipaDados.RemoverEquipa(equipa);
        }

        #endregion

        #region Jogadores

        public bool AdicionarJogador(Equipa equipa, Jogador jogador)
        {
            if (equipa == null || jogador == null)
                return false;

            // REGRA: idade compatível com o escalão
            int idadeMaxima = ObterIdadeMaximaEscalao(equipa.Escalao);
            if (jogador.Idade > idadeMaxima)
                return false;

            // REGRA: número do jogador não pode repetir na mesma equipa
            foreach (Jogador j in equipaDados.ObterJogadores(equipa))
            {
                if (j.Numero == jogador.Numero)
                    return false;
            }

            return equipaDados.AdicionarJogador(equipa, jogador);
        }

        public bool RemoverJogador(Equipa equipa, Jogador jogador)
        {
            if (equipa == null || jogador == null)
                return false;

            return equipaDados.RemoverJogador(equipa, jogador);
        }

        #endregion

        #region Treinador

        public bool AtribuirTreinador(Equipa equipa, Treinador treinador)
        {
            if (equipa == null || treinador == null)
                return false;

            if (equipa.TemTreinador)
                return false;

            return equipaDados.AtribuirTreinador(equipa, treinador);
        }

        public bool RemoverTreinador(Equipa equipa)
        {
            if (equipa == null)
                return false;

            if (!equipa.TemTreinador)
                return false;

            return equipaDados.RemoverTreinador(equipa);
        }

        #endregion

        #region Métodos Auxiliares (Regras)

        private int ObterIdadeMaximaEscalao(string escalao)
        {
            // Exemplo: "Sub-17" -> 17
            if (escalao.StartsWith("Sub-"))
            {
                string numero = escalao.Replace("Sub-", "");
                return int.Parse(numero);
            }

            // Ex: Sénior, Profissional, etc.
            return int.MaxValue;
        }

        #endregion

        public bool GuardarDados(string ficheiro)
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            return equipaDados.GuardarEquipas(ficheiro);
        }
        public bool LerDados(string ficheiro)
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            if (!File.Exists(ficheiro))
                return false;

            return equipaDados.LerEquipas(ficheiro);
        }

    }
}