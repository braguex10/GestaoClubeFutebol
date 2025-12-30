/*
*	<copyright file="TreinadorRegras.cs"
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
    public class RegrasTreinador
    {
        #region Atributos

        private readonly InterfaceTreinadorDados treinadorDados;

        #endregion

        #region Construtor

        public RegrasTreinador(InterfaceTreinadorDados treinadorDados)
        {
            this.treinadorDados = treinadorDados;
        }

        #endregion

        #region Criar Treinador

        public Treinador CriarTreinador(
            short anosExperiencia,
            string tatica,
            string nome,
            byte idade,
            string nacionalidade,
            string genero,
            int numeroSocio,
            int contacto)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return null;

            if (idade <= 18)
                return null;

            if (anosExperiencia < 0)
                return null;

            if (anosExperiencia > idade)
                return null;

            if (string.IsNullOrWhiteSpace(tatica))
                return null;

            if (numeroSocio <= 0 || contacto <= 0)
                return null;

            return treinadorDados.CriarTreinador(
                anosExperiencia,
                tatica,
                nome,
                idade,
                nacionalidade,
                genero,
                numeroSocio,
                contacto
            );
        }

        #endregion

        #region Atualizar Treinador

        public bool AtualizarTreinador(
            Treinador treinador,
            short anosExperiencia,
            string tatica)
        {
            if (treinador == null)
                return false;

            if (anosExperiencia < 18)
                return false;

            if (anosExperiencia > treinador.Idade)
                return false;

            if (string.IsNullOrWhiteSpace(tatica))
                return false;

            return treinadorDados.AtualizarTreinador(
                treinador,
                anosExperiencia,
                tatica
            );
        }

        #endregion
        #region Ficheiros

        public bool GuardarDados(string ficheiro)
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            return treinadorDados.GuardarTreinadores(ficheiro);
        }

        public bool LerDados(string ficheiro)
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            if (!File.Exists(ficheiro))
                return false;

            return treinadorDados.LerTreinadores(ficheiro);
        }

        #endregion
        
    }
}
