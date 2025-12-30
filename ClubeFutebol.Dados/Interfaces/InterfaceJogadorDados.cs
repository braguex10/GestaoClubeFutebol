/*
*	<copyright file="InterfaceJogadorDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using ClubeFutebol.BOO.Pessoas;
using System.Collections.Generic;

namespace ClubeFutebol.Dados.Interfaces
{
    public interface InterfaceJogadorDados
    {
        // Criação do Jogador
        Jogador CriarJogador(
            byte numero,
            string posicao,
            string nome,
            byte idade,
            string nacionalidade,
            string genero,
            int numeroSocio,
            int contacto
        );

        // Atualização de dados básicos do Jogador
        bool AtualizarJogador(Jogador jogador, byte numero, string posicao);
        Jogador ProcurarJogadorPorNumeroSocio(int numeroSocio);

        IReadOnlyList<Jogador> ListarJogadores();
        bool GuardarJogadores(string ficheiro);
        bool LerJogadores(string ficheiro);

    }
}