/*
*	<copyright file="PessoaRegras.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using ClubeFutebol.BOO.Pessoas;
using ClubeFutebol.Dados.Interfaces;

namespace ClubeFutebol.Regras
{
    /// <summary>
    /// Camada de Dados responsável pela verificação de pessoa
    /// </summary>
    public class RegrasPessoa
    {
        #region Atributos

        private readonly InterfacePessoaDados pessoaDados;

        #endregion

        #region Construtor

        public RegrasPessoa(InterfacePessoaDados pessoaDados)
        {
            this.pessoaDados = pessoaDados;
        }

        #endregion

        #region Atualizar Pessoa
        /// <summary>
        /// Valida a atualização dos dados de pessoa
        /// </summary>
        public bool AtualizarDadosPessoa(
            Pessoa pessoa,
            string nome,
            byte idade,
            string nacionalidade,
            string genero,
            int numeroSocio,
            int contacto
        )
        {
            if (pessoa == null)
                return false;

            if (string.IsNullOrWhiteSpace(nome))
                return false;

            if (idade <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(nacionalidade))
                return false;

            if (string.IsNullOrWhiteSpace(genero))
                return false;

            if (numeroSocio <= 0)
                return false;

            if (contacto <= 0)
                return false;

            return pessoaDados.AtualizarDadosPessoa(
                pessoa,
                nome,
                idade,
                nacionalidade,
                genero,
                numeroSocio,
                contacto
            );
        }

        #endregion
    }
}
