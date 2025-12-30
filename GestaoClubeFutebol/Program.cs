/*
*	<copyright file="Program.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System;
using ClubeFutebol.BOO.ClubeEstrutura;
using ClubeFutebol.BOO.Pessoas;
using ClubeFutebol.Dados.ClubeEstrutura;
using ClubeFutebol.Dados.Pessoas;
using ClubeFutebol.Regras;
using ClubeFutebol.Exceptions;

namespace ClubeFutebol.App
{
    class Program
    {
        static int Main(string[] args)
        {
            // ===============================
            // DADOS
            // ===============================
            ClubeDados clubeDados = new ClubeDados();
            EquipaDados equipaDados = new EquipaDados();
            JogadorDados jogadorDados = new JogadorDados();
            TreinadorDados treinadorDados = new TreinadorDados();
            FinancasDados financasDados = new FinancasDados();

            // ===============================
            // REGRAS
            // ===============================
            RegrasClube regrasClube = new RegrasClube(clubeDados);
            RegrasEquipa regrasEquipa = new RegrasEquipa(equipaDados);
            RegrasJogador regrasJogador = new RegrasJogador(jogadorDados);
            RegrasTreinador regrasTreinador = new RegrasTreinador(treinadorDados);
            RegrasFinancas regrasFinancas = new RegrasFinancas(financasDados);

            // ===============================
            // LEITURA DE DADOS
            // ===============================
            regrasClube.LerDados("clubes.dat");
            regrasEquipa.LerDados("equipas.dat");
            regrasJogador.LerDados("jogadores.dat");
            regrasTreinador.LerDados("treinadores.dat");
            regrasFinancas.LerDados("financas.dat");

            // ===============================
            // CRIAÇÃO DE ENTIDADES
            // ===============================
            Clube clube = new Clube(
                "FC GOGO",
                1900,
                "info@fcgogo.pt",
                912345678,
                "Portugal");

            bool clubeCriado = regrasClube.CriarClube(clube);

            Equipa equipa = new Equipa(
                "Sénior",
                "Primeira Liga",
                clube.Nome);

            bool equipaCriada = regrasEquipa.CriarEquipa(equipa);

            Jogador jogador = regrasJogador.CriarJogador(
                10,
                "Avançado",
                "João Silva",
                22,
                "Portugal",
                "Masculino",
                1001,
                912111222);

            Treinador treinador = regrasTreinador.CriarTreinador(
                10,
                "4-3-3",
                "Carlos Sousa",
                45,
                "Portugal",
                "Masculino",
                2001,
                913333444);

            bool treinadorAtribuido = regrasEquipa.AtribuirTreinador(equipa, treinador);
            bool jogadorAdicionado = regrasEquipa.AdicionarJogador(equipa, jogador);

            // ===============================
            // FINANÇAS
            // ===============================
            Financas financas = new Financas(
                100000,
                30000,
                20000);

            bool financasInseridas = regrasFinancas.InserirFinancas(financas);

            try
            {
                bool salarioDefinido = regrasFinancas.DefinirSalario(
                    financas,
                    jogador,
                    1500);

                bool jogadorComprado = regrasFinancas.ComprarPessoa(
                    financas,
                    jogador,
                    10000);
            }
            catch (DominioException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // ===============================
            // GUARDAR DADOS
            // ===============================
            regrasClube.GuardarDados("clubes.dat");
            regrasEquipa.GuardarDados("equipas.dat");
            regrasJogador.GuardarDados("jogadores.dat");
            regrasTreinador.GuardarDados("treinadores.dat");
            regrasFinancas.GuardarDados("financas.dat");

            // ===============================
            // FIM DA EXECUÇÃO
            // ===============================
            return 0;
        }
    }
}