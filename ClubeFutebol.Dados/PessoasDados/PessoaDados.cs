/*
*	<copyright file="PessoaDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using ClubeFutebol.BOO.Pessoas;
using ClubeFutebol.Dados.Interfaces;

namespace ClubeFutebol.Dados.Pessoas
{
    public class PessoaDados : InterfacePessoaDados
    {
        #region Construtor

        public PessoaDados()
        {
        }

        #endregion

        // Atualização de dados básicos da Pessoa
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
            pessoa.Nome = nome;
            pessoa.Idade = idade;
            pessoa.Nacionalidade = nacionalidade;
            pessoa.Genero = genero;
            pessoa.NumeroSocio = numeroSocio;
            pessoa.Contacto = contacto;

            return true;
        }
    }
}