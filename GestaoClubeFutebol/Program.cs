/*
*	<copyright file="Program.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System;
using ClubeFutebol.BOO.ClubeEstrutura;
using ClubeFutebol.Dados.ClubeEstrutura;
using ClubeFutebol.Regras;

namespace GestaoClubeFutebol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ======================
            // Inicialização
            // ======================
            var clubeDados = new ClubeDados();
            var financasDados = new FinancasDados();

            var regrasClube = new RegrasClube(clubeDados);
            var regrasFinancas = new RegrasFinancas(financasDados);

            // ======================
            // Criar clube
            // ======================
            Clube clube = new Clube(
                "Gil Vicente",
                2000,
                "gilvicente@ipca.pt",
                253123456,
                "Portugal"
            );

            regrasClube.CriarClube(clube);
            financasDados.InicializarClube(clube);

            // ======================
            // Atualizar finanças
            // ======================
            regrasFinancas.AtualizarSaldo(clube, 1_000_000f);
            regrasFinancas.AtualizarOrcamentoSalarios(clube, 400_000f);
            regrasFinancas.AtualizarOrcamentoTransferencias(clube, 300_000f);

            // ======================
            // Mostrar dados
            // ======================
            Console.WriteLine("CLUBE CRIADO:");
            Console.WriteLine(clube);
            Console.WriteLine();
            Console.WriteLine("FINANÇAS:");
            Console.WriteLine(clube.Financas);

            Console.ReadKey();
        }
    }
}
