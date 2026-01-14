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
    /// <summary>
    /// Camada de Dados responsável pela validação de treinador
    /// </summary>
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
        /// <summary>
        /// Valida a criação de treinador
        /// </summary>
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
        /// <summary>
        /// Valida a atualização de treinador
        /// </summary>
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
        /// <summary>
        /// Valida os dados de treinador a serem guardados
        /// </summary>
        public bool GuardarDados(string ficheiro)
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            return treinadorDados.GuardarTreinadores(ficheiro);
        }
        /// <summary>
        /// Valida a leitura dos dados de treinador
        /// </summary>
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
