/*
*	<copyright file="InterfaceTreinadorDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using ClubeFutebol.BOO.Pessoas;
using System.Collections.Generic;

namespace ClubeFutebol.Dados.Interfaces
{
    public interface InterfaceTreinadorDados
    {
        // Criação do Treinador
        Treinador CriarTreinador(
            short anosExperiencia,
            string tatica,
            string nome,
            byte idade,
            string nacionalidade,
            string genero,
            int numeroSocio,
            int contacto
        );

        // Atualização de dados básicos do Treinador
        bool AtualizarTreinador(
            Treinador treinador,
            short anosExperiencia,
            string tatica
        );
        Treinador ProcurarTreinadorPorNumeroSocio(int numeroSocio);
        IReadOnlyList<Treinador> ListarTreinadores();
        bool GuardarTreinadores(string ficheiro);
        bool LerTreinadores(string ficheiro);
    }
}