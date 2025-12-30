/*
*	<copyright file="InterfaceEquipaDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System.Collections.Generic;
using ClubeFutebol.BOO.ClubeEstrutura;
using ClubeFutebol.BOO.Pessoas;

namespace ClubeFutebol.Dados.Interfaces
{
    public interface InterfaceEquipaDados
    {
        // Ciclo de vida da Equipa (no contexto dos jogadores)
        bool CriarEquipa(Equipa equipa);
        bool RemoverEquipa(Equipa equipa);

        // Jogadores da Equipa
        bool AdicionarJogador(Equipa equipa, Jogador jogador);
        bool RemoverJogador(Equipa equipa, Jogador jogador);
        IReadOnlyList<Jogador> ObterJogadores(Equipa equipa);
        int ObterNumeroJogadores(Equipa equipa);
        IReadOnlyList<Jogador> ObterJogadoresPorPosicao(Equipa equipa, string posicao);

        // Treinador
        bool AtribuirTreinador(Equipa equipa, Treinador treinador);
        bool RemoverTreinador(Equipa equipa);

        bool GuardarEquipas(string ficheiro);
        bool LerEquipas(string ficheiro);
    }
}