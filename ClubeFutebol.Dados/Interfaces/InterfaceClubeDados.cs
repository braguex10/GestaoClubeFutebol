/*
*	<copyright file="InterfaceClubeDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System.Collections.Generic;
using ClubeFutebol.BOO.ClubeEstrutura;

namespace ClubeFutebol.Dados.Interfaces
{
    public interface InterfaceClubeDados
    {
        // Clubes
        bool CriarClube(Clube clube);
        bool RemoverClube(Clube clube);
        IReadOnlyList<Clube> ListarClubes();

        // Equipas do Clube
        bool AdicionarEquipa(Clube clube, Equipa equipa);
        bool RemoverEquipa(Clube clube, Equipa equipa);
        IReadOnlyList<Equipa> ObterEquipas(Clube clube);
        bool ExisteClube(Clube clube);
        int NumeroEquipas(Clube clube);
        Clube ObterClubePorNome(string nome);
        bool GuardarClubes(string ficheiro);
        bool LerClubes(string ficheiro);


    }
}