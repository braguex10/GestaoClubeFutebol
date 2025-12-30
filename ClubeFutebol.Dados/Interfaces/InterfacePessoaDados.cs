/*
*	<copyright file="InterfacePessoaDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using ClubeFutebol.BOO.Pessoas;

namespace ClubeFutebol.Dados.Interfaces
{
    public interface InterfacePessoaDados
    {
        bool AtualizarDadosPessoa(
            Pessoa pessoa,
            string nome,
            byte idade,
            string nacionalidade,
            string genero,
            int numeroSocio,
            int contacto
        );
    }
}