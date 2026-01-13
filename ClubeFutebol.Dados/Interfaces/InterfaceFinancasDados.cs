/*
*	<copyright file="InterfaceFinancasDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using ClubeFutebol.BOO.ClubeEstrutura;
using ClubeFutebol.BOO.Pessoas;

namespace ClubeFutebol.Dados.Interfaces
{
    public interface InterfaceFinancasDados
    {
        #region Inicialização

        // Inicializa as estruturas financeiras de um clube
        void InicializarClube(Clube clube);

        #endregion

        #region Saldo e Orçamentos

        bool AtualizarSaldo(Clube clube, float valor);
        bool AtualizarOrcamentoSalarios(Clube clube, float valor);
        bool AtualizarOrcamentoTransferencias(Clube clube, float valor);

        #endregion

        #region Salários

        bool DefinirSalario(Clube clube, Pessoa pessoa, float valor);
        bool RemoverSalario(Clube clube, Pessoa pessoa);
        float ObterSalario(Clube clube, Pessoa pessoa);
        float TotalSalarios(Clube clube);

        #endregion

        #region Valores de Mercado

        bool DefinirValorMercado(Clube clube, Pessoa pessoa, float valor);
        bool RemoverValorMercado(Clube clube, Pessoa pessoa);
        float ObterValorMercado(Clube clube, Pessoa pessoa);

        #endregion

        #region Persistência

        bool GuardarFinancas(string ficheiro);
        bool LerFinancas(string ficheiro);

        #endregion
    }
}