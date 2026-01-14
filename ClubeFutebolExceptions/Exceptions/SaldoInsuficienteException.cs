/*
*	<copyright file="SaldoInsuficienteException.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

namespace ClubeFutebol.Exceptions
{
    /// <summary>
    /// Explicação de que há saldo insuficiente para a execução de um processo
    /// </summary>
    public class SaldoInsuficienteException : DominioException
    {
        public SaldoInsuficienteException()
            : base("Saldo insuficiente para realizar a operação.")
        {
        }
    }
}
