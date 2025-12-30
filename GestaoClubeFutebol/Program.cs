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

namespace GestaoClubeDeFutebol
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ===============================
            // INICIALIZAÇÃO DE DADOS E REGRAS
            // ===============================
            ClubeDados clubeDados = new ClubeDados();
            EquipaDados equipaDados = new EquipaDados();
            JogadorDados jogadorDados = new JogadorDados();
            TreinadorDados treinadorDados = new TreinadorDados();
            FinancasDados financasDados = new FinancasDados();

            RegrasClube regrasClube = new RegrasClube(clubeDados);
            RegrasEquipa regrasEquipa = new RegrasEquipa(equipaDados);
            RegrasJogador regrasJogador = new RegrasJogador(jogadorDados);
            RegrasTreinador regrasTreinador = new RegrasTreinador(treinadorDados);
            RegrasFinancas regrasFinancas = new RegrasFinancas(financasDados);

            // ===============================
            // CRIAÇÃO DE CLUBE
            // ===============================
            Clube clube = new Clube("FC GOGO", 1900, "info@fcgogo.pt", 912345678, "Portugal");
            bool clubeCriado = regrasClube.CriarClube(clube);
            Console.WriteLine($"Clube criado: {(clubeCriado ? "OK" : "ERRO")}");

            // ===============================
            // CRIAÇÃO DE EQUIPA
            // ===============================
            Equipa equipa = new Equipa("Sénior", "Primeira Liga", clube.Nome);
            bool equipaCriada = regrasEquipa.CriarEquipa(equipa);
            Console.WriteLine($"Equipa criada: {(equipaCriada ? "OK" : "ERRO")}");

            // ===============================
            // CRIAÇÃO DE TREINADOR
            // ===============================
            Treinador treinador = regrasTreinador.CriarTreinador(
                10, "4-3-3",
                "João Silva", 45, "Portugal", "M", 1001, 910000000);

            bool treinadorAtribuido = regrasEquipa.AtribuirTreinador(equipa, treinador);
            Console.WriteLine($"Treinador atribuído: {(treinadorAtribuido ? "OK" : "ERRO")}");

            // ===============================
            // CRIAÇÃO DE JOGADOR
            // ===============================
            Jogador jogador = regrasJogador.CriarJogador(
                10, "Avançado",
                "Pedro Costa", 25, "Portugal", "M", 2001, 920000000);

            bool jogadorAdicionado = regrasEquipa.AdicionarJogador(equipa, jogador);
            Console.WriteLine($"Jogador adicionado à equipa: {(jogadorAdicionado ? "OK" : "ERRO")}");

            // ===============================
            // FINANÇAS + EXCEPTIONS
            // ===============================
            Financas financas = new Financas(100000f, 30000f, 20000f);
            financasDados.InserirFinancas(financas);

            try
            {
                bool compra = regrasFinancas.ComprarPessoa(financas, jogador, 15000f);
                Console.WriteLine($"Jogador comprado: {(compra ? "OK" : "ERRO")}");
            }
            catch (DominioException ex)
            {
                Console.WriteLine($"ERRO FINANCEIRO: {ex.Message}");
            }

            // ===============================
            // GUARDAR DADOS
            // ===============================
            regrasClube.GuardarDados("clubes.dat");
            regrasEquipa.GuardarDados("equipas.dat");
            regrasJogador.GuardarDados("jogadores.dat");
            regrasTreinador.GuardarDados("treinadores.dat");
            regrasFinancas.GuardarDados("financas.dat");

            Console.WriteLine("Dados guardados com sucesso.");

            // ===============================
            // LER DADOS
            // ===============================
            regrasClube.LerDados("clubes.dat");
            regrasEquipa.LerDados("equipas.dat");
            regrasJogador.LerDados("jogadores.dat");
            regrasTreinador.LerDados("treinadores.dat");
            regrasFinancas.LerDados("financas.dat");

            Console.WriteLine("Dados lidos com sucesso.");

            // ===============================
            // FIM
            // ===============================
            Console.WriteLine("\nFim da execução. Pressione qualquer tecla.");
            Console.ReadKey();

            return 0;
        }
    }
}
